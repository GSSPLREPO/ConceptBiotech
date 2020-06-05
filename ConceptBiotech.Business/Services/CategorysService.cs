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
    public class CategorysService : ICategoryService, IDisposable
    {
        private readonly UnitOfWorkSql _unitOfWork;

        public CategorysService()
        {
            _unitOfWork = new UnitOfWorkSql();
        }

        public Tuple<List<CategorysMasterUI>, long> GetAll(ListFilter filter)
        {
            //FilterDefinitionBuilder<CategorysMaster> builder = Builders<CategorysMaster>.Filter;

            //var signupbuilder = builder.Eq("SignupId", filter.SignupId);
            //FilterDefinition<CategorysMaster> filterdata = signupbuilder & (builder.Ne("Status", (int)RecordStatus.Deleted));
            // && a.CompanyId == filter.CompanyId
            var cond = PredicateBuilder.Create<CategorysMaster>(a => a.Status != RecordStatus.Deleted);
             //&& a.ShopId == filter.ShopId
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

            Tuple<List<CategorysMaster>, long> Categoryslist = null;

            //if (filter.ExportType == ExportType.None)
            //{
            //    Categoryslist = _unitOfWork.CategorysMasterRepository.GetFilteredList(cond, filter.sort, filter.sortorder, filter.startindex, filter.endindex, true);
            //}
            //else
            {
                Categoryslist = _unitOfWork.CategorysMasterRepository.GetFilteredList(cond);
            }

            var Categoryss = Mapper.Map<List<CategorysMaster>, List<CategorysMasterUI>>(Categoryslist.Item1);
            return new Tuple<List<CategorysMasterUI>, long>(Categoryss, Categoryslist.Item2);
        }


        public CategorysMasterUI GetById(long Id)
        {
            var task = _unitOfWork.CategorysMasterRepository.GetByID(Id);
            if (task != null)
            {
                var taskModel = Mapper.Map<CategorysMaster, CategorysMasterUI>(task);
                return taskModel;
            }
            else
            {
                return null;
            }
        }

        public bool IsDuplicateBuilding(CategorysMasterUI building)
        {
            //FilterDefinitionBuilder<CategorysMaster> builder = Builders<CategorysMaster>.Filter;
            var filter = PredicateBuilder.Create<CategorysMaster>(s =>
                                                                     s.Status == RecordStatus.Active  &&
                                                                     s.CategoryName.ToLower() == building.CN.ToLower());
            //&& s.ShopId == building.SI
            if (building.UIDN > 0)
            {
                filter = filter.And(a => a.PK_Id != building.UIDN);
            }

            var existsunit = _unitOfWork.CategorysMasterRepository.Getnotrack(filter);
            if (existsunit != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CategorysMasterUI Add(CategorysMasterUI Entity)
        {
            var building = Mapper.Map<CategorysMasterUI, CategorysMaster>(Entity);
            //building.SiteMaster = _unitOfWork.SiteMastersRepository.GetByID(Entity.SiteId);
            _unitOfWork.CategorysMasterRepository.Insert(building);
            _unitOfWork.Save();
            if (building != null)
            {
                var taskModel = Mapper.Map<CategorysMaster, CategorysMasterUI>(building);
                return taskModel;
            }
            else
            {
                return null;
            }
        }

        public CategorysMasterUI Update(long id, CategorysMasterUI Entity)
        {
            //var bank = _unitOfWork.CategorysMasterRepository.GetByID(id);
            //if (bank != null)
            {
                var requestModel = Mapper.Map<CategorysMasterUI, CategorysMaster>(Entity);
                requestModel.PK_Id = id;
                //  requestModel.SiteMaster = _unitOfWork.SiteMastersRepository.GetByID(Entity.SiteId);
                _unitOfWork.CategorysMasterRepository.Update(requestModel);
                _unitOfWork.Save();
                if (requestModel != null)
                {
                    var taskModel = Mapper.Map<CategorysMaster, CategorysMasterUI>(requestModel);
                    return taskModel;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool Delete(long Id, string basePath, CategorysMasterUI Entity)
        {
            if (Id > 0)
            {
                //_unitOfWork.bank.Delete(Id);
                var building = _unitOfWork.CategorysMasterRepository.GetByID(Id);
                building.ModifiedBy = Entity.MBy;
                building.ModifiedDate = Entity.MDt;
                building.Status = RecordStatus.Deleted;
                _unitOfWork.CategorysMasterRepository.Update(building);
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
