using AutoMapper;
using ConceptBiotech.Data;
using ConceptBiotech.UIEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Services;

namespace ConceptBiotech.Business
{
    public class ProductMasterService : IProductMasterService, IDisposable
    {
        private readonly UnitOfWorkSql _unitOfWork;

        public ProductMasterService()
        {
            _unitOfWork = new UnitOfWorkSql();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Tuple<List<ProductMasterUI>, long> GetAll()
        {
            var condition = PredicateBuilder.Create<ProductMaster>(a => a.Status != RecordStatus.Deleted);

            Tuple<List<ProductMaster>, long> ProductMasterlist = null;
            ProductMasterlist = _unitOfWork.ProductMastersRepository.GetFilteredList(condition);


            var ProductMasters = Mapper.Map<List<ProductMaster>, List<ProductMasterUI>>(ProductMasterlist.Item1);
            return new Tuple<List<ProductMasterUI>, long>(ProductMasters, ProductMasterlist.Item2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ProductMasterUI GetById(long Id)
        {
            var ProductMaster = _unitOfWork.ProductMastersRepository.GetWithInclude(a => a.PK_Id == Id).FirstOrDefault();
            if (ProductMaster != null)
            {
                var ProductMasterModel = Mapper.Map<ProductMaster, ProductMasterUI>(ProductMaster);
                return ProductMasterModel;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="basePath"></param>
        /// <param name="companyid"></param>
        /// <returns></returns>
        public ProductMasterUI Add(ProductMasterUI Entity, string basePath, long companyid)
        {
            var condition = PredicateBuilder.Create<ProductMaster>(s => s.ProductName == Entity.PN && s.Status == RecordStatus.Active);
            var existsProductMaster = _unitOfWork.ProductMastersRepository.GetFilteredList(condition).Item1;
            if (existsProductMaster != null && existsProductMaster.Any())
            {
                return Entity;
            }

            if (Entity.Image != null)
            {
                //string imgPath = "~/CompanyLogo/" + Entity.PN + ".jpg";

                //  string folderPath = HostingEnvironment.MapPath("~/CompanyLogo/");
                string folderPath = System.Web.HttpContext.Current.Server.MapPath("~/CompanyLogo");
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(folderPath);
                }
                string FilePathOther = folderPath + "\\" + Entity.PN + ".PNG";
                //HelperMethods.Base64ToImage(Entity.Image).Save(FilePathOther);

                byte[] imageBytes = Convert.FromBase64String(Entity.Image);

                File.WriteAllBytes(FilePathOther, imageBytes);

                Entity.Image = string.Format("{0}{1}{2}", ConfigurationManager.AppSettings["basePath"], ConfigurationManager.AppSettings["CompanyLogoPath"], Entity.PN + ".PNG");

            }
            var ProductMaster = Mapper.Map<ProductMasterUI, ProductMaster>(Entity);
            _unitOfWork.ProductMastersRepository.Insert(ProductMaster);
            _unitOfWork.Save();

            if (ProductMaster != null)
            {
                var ProductMasterModel = Mapper.Map<ProductMaster, ProductMasterUI>(ProductMaster);

                return ProductMasterModel;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Entity"></param>
        /// <param name="basePath"></param>
        /// <param name="companyid"></param>
        /// <returns></returns>
        public ProductMasterUI Update(long id, ProductMasterUI Entity, string basePath, long companyid)
        {
            if (Entity.Image != null)
            {
                string folderPath = HostingEnvironment.MapPath("~/CompanyLogo/");
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(folderPath);
                }
                string FilePathOther = folderPath + Entity.PN + ".jpg";
                HelperMethods.Base64ToImage(Entity.Image).Save(FilePathOther);

                Entity.Image = FilePathOther;
                //   Entity.Image = HelperMethods.saveImageOnfile(Entity.Image.ToString(), basePath, ConfigurationManager.AppSettings["CompanyLogoPath"]).FirstOrDefault();
                //   Entity.Image = HelperMethods.saveImageOnfile(Entity.Image,basePath, ConfigurationManager.AppSettings["CompanyLogoPath"]) ;
            }
            var requestModel = Mapper.Map<ProductMasterUI, ProductMaster>(Entity);
            requestModel.PK_Id = id;
            _unitOfWork.ProductMastersRepository.Update(requestModel);

            _unitOfWork.Save();
            var ProductMasterModel = Mapper.Map<ProductMaster, ProductMasterUI>(requestModel);
            return ProductMasterModel;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public bool IsDuplicateProductMaster(ProductMasterUI Entity)
        {
            var condition = PredicateBuilder.Create<ProductMaster>(s => s.Status == RecordStatus.Active &&
                                                               (s.ProductName == Entity.PN));
            if (Entity.UIDN > 0)
            {
                condition = condition.And(a => a.PK_Id != Entity.UIDN);
            }

            var existProductMaster = _unitOfWork.ProductMastersRepository.Get(condition);
            if (existProductMaster != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Entity"></param>
        /// <param name="basePath"></param>
        /// <param name="companyid"></param>
        /// <returns></returns>
        public bool Delete(long Id, ProductMasterUI Entity, string basePath, long companyid)
        {
            if (Id > 0)
            {
                //_unitOfWork.ProductMaster.Delete(Id);

                var ProductMaster = _unitOfWork.ProductMastersRepository.GetByID(Id);
                ProductMaster.ModifiedBy = Entity.MBy;
                ProductMaster.ModifiedDate = Entity.MDt;
                ProductMaster.Status = RecordStatus.Deleted;

                _unitOfWork.ProductMastersRepository.Update(ProductMaster);
                _unitOfWork.Save();

                if (ProductMaster != null)
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

        public void Dispose()
        {
            _unitOfWork.closeConnection();
        }
    }
}
