using AutoMapper;
using ConceptBiotech.Data;
using ConceptBiotech.UIEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.Business
{
    public class ShopMasterService : IShopMasterService, IDisposable
    {
        private readonly UnitOfWorkSql _unitOfWork;

        public ShopMasterService(UnitOfWorkSql unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ShopMasterService()
        {
            _unitOfWork = new UnitOfWorkSql();
        }

        public Tuple<List<ShopMasterUI>, long> GetAll(ListFilter filter, long userId)
        {

            // int exporttype = Convert.ToInt16(filter.ExportType);

            var strquery = "exec uspGetAllShops @UserId";
            var parameters = new[]
            {
                new SqlParameter("UserId", userId)
            };
            var multiResultSet = new MultiResultSetReader(_unitOfWork.getContext(), strquery, parameters);
            List<ShopMasterUI> ShopList = new List<ShopMasterUI>();
            // ShopList = multiResultSet.ResultSetFor<ShopMasterUI>().ToList();

            //List<Data.files> rFiles = new List<Data.files>();
            //rFiles = multiResultSet.ResultSetFor<Data.files>().ToList();

            //List<UIEntity.files> files = Mapper.Map<List<Data.files>, List<UIEntity.files>>(rFiles);

            foreach (var Shop in ShopList)
            {
                // Shop.CL = files.Where(s => s.ShopMaster_PK_Id == Shop.UIDN).ToList();
            }

            ShopMasterUI Shopui = ShopList.FirstOrDefault();
            if (Shopui != null)
            {
                return new Tuple<List<ShopMasterUI>, long>(ShopList, ShopList.Count());
            }
            else
            {
                return new Tuple<List<ShopMasterUI>, long>(ShopList, 0);
            }


            /*


            var condition = PredicateBuilder.Create<ShopMaster>(t => t.SignupId == filter.SignupId && t.Status != RecordStatus.Deleted);

            if (false == string.IsNullOrWhiteSpace(filter.FilterData))
            {
                filter.FilterData = filter.FilterData.ToLower();
                condition = condition.And(a => a.ShopName.ToLower().Contains(filter.FilterData)
                                                        || a.Website.ToLower().Contains(filter.FilterData)
                                                        || a.EmailID.ToLower().Contains(filter.FilterData));
            }
            if (userId > 0)
            {
                UserRoleService userRoleService = new UserRoleService();
                ListFilter<string> fil = new ListFilter<string>();
                fil.FilterData = userId.ToString();
                List<UserRoleUI> userRoles = userRoleService.GetAll(fil).Item1;
                var CompIds = userRoles.Select(s => s.CI).Distinct();

                condition = condition.And(x => CompIds.Any(c => c == x.PK_Id));
            }

            if (true == string.IsNullOrWhiteSpace(filter.sort))
            {
                filter.sort = "ShopName";
            }

            Tuple<List<ShopMaster>, long> complist = null;


            if (filter.ExportType == ExportType.None)
            {
                complist = _unitOfWork.ShopMastersRepository.GetFilteredList(condition, filter.sort, filter.sortorder, filter.startindex, filter.endindex, true, "ShopLogo");
            }
            else
            {
                complist = _unitOfWork.ShopMastersRepository.GetFilteredList(condition, filter.sort, filter.sortorder, filter.startindex, filter.endindex, true, "ShopLogo");
            }
            var companies = Mapper.Map<List<ShopMaster>, List<ShopMasterUI>>(complist.Item1);
            return new Tuple<List<ShopMasterUI>, long>(companies, complist.Item2);
            */
        }

        public ShopMasterUI GetById(long Id)
        {
            var Shop = _unitOfWork.ShopMastersRepository.GetWithInclude(a => a.PK_Id == Id, "ShopLogo").FirstOrDefault();
            if (Shop != null)
            {
                var compModel = Mapper.Map<ShopMaster, ShopMasterUI>(Shop);
                return compModel;
            }
            else
            {
                return null;
            }

        }

        public ShopMasterUI Add(ShopMasterUI Entity, string basePath)
        {
            var Shop = Mapper.Map<ShopMasterUI, ShopMaster>(Entity);
            _unitOfWork.ShopMastersRepository.Insert(Shop);
            _unitOfWork.Save();
            if (Shop != null)
            {

                var Shopui = Mapper.Map<ShopMaster, ShopMasterUI>(Shop);

                return Shopui;
            }
            else
            {
                return null;
            }
        }

        public ShopMasterUI Update(long id, string basePath, ShopMasterUI Entity)
        {
            var requestModel = Mapper.Map<ShopMasterUI, ShopMaster>(Entity);
            requestModel.PK_Id = id;
            _unitOfWork.ShopMastersRepository.Update(requestModel);
            if (requestModel.ShopLogo != null)
            {

            }
            _unitOfWork.Save();
            if (requestModel != null)
            {
                var Shopui = Mapper.Map<ShopMaster, ShopMasterUI>(requestModel);
                return Shopui;
            }
            else
            {
                return null;
            }
        }

        public bool Delete(long Id, string basePath, ShopMasterUI Entity)
        {
            if (Id > 0)
            {
                var compobj = _unitOfWork.ShopMastersRepository.GetByID(Id);
                compobj.ModifiedBy = Entity.MBy;
                compobj.ModifiedDate = Entity.MDt;
                compobj.Status = RecordStatus.Deleted;
                _unitOfWork.ShopMastersRepository.Update(compobj);
                _unitOfWork.Save();
                if (compobj != null)
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool IsDuplicateShop(ShopMasterUI Entity)
        {

            var condition = PredicateBuilder.Create<ShopMaster>(s => s.Status == RecordStatus.Active &&
                                                                   s.ShopName.ToLower() == Entity.SN.ToLower());

            if (Entity.UIDN > 0)
            {
                condition = condition.And(a => a.PK_Id != Entity.UIDN);
            }

            var existsShop = _unitOfWork.ShopMastersRepository.GetFilteredList(condition, null).Item1;
            if (existsShop != null && existsShop.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public TokenUI SelectShopById(long tokenId, long ShopId)
        //{
        //    TokenService tokenService = new TokenService();
        //    return tokenService.UpdateTokenShop(tokenId, ShopId);
        //}
        public void Dispose()
        {
            _unitOfWork.closeConnection();
        }
    }
}