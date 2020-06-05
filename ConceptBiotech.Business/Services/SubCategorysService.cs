using AutoMapper;
using ConceptBiotech.Data;
using ConceptBiotech.UIEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.Business
{
    public class SubCategorysService : ISubCategorysService, IDisposable
    {
        private readonly UnitOfWorkSql _unitOfWork;

        public SubCategorysService()
        {
            _unitOfWork = new UnitOfWorkSql();
        }

        public Tuple<List<SubCategorysMasterUI>, long> GetAll(ListFilter filter)
        {
            //FilterDefinitionBuilder<SubCategorysMaster> builder = Builders<SubCategorysMaster>.Filter;

            //var signupbuilder = builder.Eq("SignupId", filter.SignupId);
            //FilterDefinition<SubCategorysMaster> filterdata = signupbuilder & (builder.Ne("Status", (int)RecordStatus.Deleted));
            // && a.CompanyId == filter.CompanyId
            var cond = PredicateBuilder.Create<SubCategorysMaster>(a => a.Status != RecordStatus.Deleted);// && a.ShopId == filter.ShopId);

            //if (filter.FilterData != null && false == string.IsNullOrWhiteSpace(filter.FilterData.Wngs))
            //{
            //    filter.FilterData.Wngs = filter.FilterData.Wngs.ToLower();
            //    cond = cond.And(a => a.CategoryName.ToLower().Contains(filter.FilterData.Wngs));
            //}

            //if (filter.FilterData != null && filter.FilterData.SiteId > 0)
            //{

            //    cond = cond.And(a => a.SiteId == filter.FilterData.SiteId);
            //}

            //if (true == string.IsNullOrWhiteSpace(filter.sort))
            //{
            //    filter.sort = "Categoryss";
            //    //filter.sortorder = false;
            //}

            Tuple<List<SubCategorysMaster>, long> Categoryslist = null;

            //if (filter.ExportType == ExportType.None)
            //{
            //    Categoryslist = _unitOfWork.SubCategorysMasterRepository.GetFilteredList(cond, filter.sort, filter.sortorder, filter.startindex, filter.endindex, true);
            //}
            //else
            {
                Categoryslist = _unitOfWork.SubCategorysMasterRepository.GetFilteredList(cond);
            }

            var Categoryss = Mapper.Map<List<SubCategorysMaster>, List<SubCategorysMasterUI>>(Categoryslist.Item1);
            return new Tuple<List<SubCategorysMasterUI>, long>(Categoryss, Categoryslist.Item2);
        }


        public SubCategorysMasterUI GetById(long Id)
        {
            var task = _unitOfWork.SubCategorysMasterRepository.GetByID(Id);
            if (task != null)
            {
                var taskModel = Mapper.Map<SubCategorysMaster, SubCategorysMasterUI>(task);
                return taskModel;
            }
            else
            {
                return null;
            }
        }

        public bool IsDuplicateBuilding(SubCategorysMasterUI building)
        {
            //FilterDefinitionBuilder<SubCategorysMaster> builder = Builders<SubCategorysMaster>.Filter;
            var filter = PredicateBuilder.Create<SubCategorysMaster>(s =>
                                                                     s.Status == RecordStatus.Active  && s.CategoryId == building.CID &&
                                                                     s.Name.ToLower() == building.Name.ToLower());
            //&& s.ShopId == building.SI
            if (building.UIDN > 0)
            {
                filter = filter.And(a => a.PK_Id != building.UIDN);
            }

            var existsunit = _unitOfWork.SubCategorysMasterRepository.Getnotrack(filter);
            if (existsunit != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public SubCategorysMasterUI Add(SubCategorysMasterUI Entity)
        {
            var building = Mapper.Map<SubCategorysMasterUI, SubCategorysMaster>(Entity);
            //building.SiteMaster = _unitOfWork.SiteMastersRepository.GetByID(Entity.SiteId);
            _unitOfWork.SubCategorysMasterRepository.Insert(building);
            _unitOfWork.Save();
            if (building != null)
            {
                var taskModel = Mapper.Map<SubCategorysMaster, SubCategorysMasterUI>(building);
                return taskModel;
            }
            else
            {
                return null;
            }
        }

        public SubCategorysMasterUI Update(long id, SubCategorysMasterUI Entity)
        {
            //var bank = _unitOfWork.SubCategorysMasterRepository.GetByID(id);
            //if (bank != null)
            {
                var requestModel = Mapper.Map<SubCategorysMasterUI, SubCategorysMaster>(Entity);
                requestModel.PK_Id = id;
                //  requestModel.SiteMaster = _unitOfWork.SiteMastersRepository.GetByID(Entity.SiteId);
                _unitOfWork.SubCategorysMasterRepository.Update(requestModel);
                _unitOfWork.Save();
                if (requestModel != null)
                {
                    var taskModel = Mapper.Map<SubCategorysMaster, SubCategorysMasterUI>(requestModel);
                    return taskModel;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool Delete(long Id, string basePath, SubCategorysMasterUI Entity)
        {
            if (Id > 0)
            {
                //_unitOfWork.bank.Delete(Id);
                var building = _unitOfWork.SubCategorysMasterRepository.GetByID(Id);
                building.ModifiedBy = Entity.MBy;
                building.ModifiedDate = Entity.MDt;
                building.Status = RecordStatus.Deleted;
                _unitOfWork.SubCategorysMasterRepository.Update(building);
                _unitOfWork.Save();

                return true;
            }
            else
            {
                return false;
            }
        }

        public void Dispose()
        {
            _unitOfWork.closeConnection();
        }
    }
}
