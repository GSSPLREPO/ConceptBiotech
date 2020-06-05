using ConceptBiotech.Business;
using ConceptBiotech.UIEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConceptBiotech.WebAPI.Controllers
{
    [RoutePrefix("v1/categorys")]
    public class CategoryController : ApiController
    {

        // private readonly ICategorysService _CategorysService;
        /// <summary>
        /// 
        /// </summary>
        public CategoryController()
        {
            //if (System.Web.HttpContext.Current.Request.RequestType != "OPTIONS")
            //{
            //    _CategorysService = new CategorysService();
            //}
        }
        /// <summary>
        /// Get All Categorys
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPost()]
        [Route("Getall", Order = 0)]
        [Route("GetallForCategory", Order = 1)]
        public HttpResponseMessage GetAll([FromBody] ListFilter filter)
        {
            var tokens = Common.getBasetokenData();
            //filter.ShopId = tokens.glbShopId;
            using (ICategoryService _CategorysService = new CategorysService())
            {
                var Categorydata = _CategorysService.GetAll(filter);
                return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, Categorydata);
            }
        }

        /// <summary>
        /// Get Category By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [Route("GetbyId/{id}")]
        public HttpResponseMessage GetCategoryById(long id)
        {
            if (id > 0)
            {
                using (ICategoryService _CategorysService = new CategorysService())
                {
                    var buildig = _CategorysService.GetById(id);

                    if (buildig != null)
                    {
                        return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, buildig);
                    }
                    else
                    {
                        return Response.CreateResponse(ResultCodes.RecordsNotFound, HttpStatusCode.NotFound);
                    }
                }
            }
            else
            {
                return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Add New Category
        /// </summary>
        /// <param name="Category"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPost()]
        [Route("Add")]
        public HttpResponseMessage AddCategory([FromBody]CategorysMasterUI Category)
        {
            if (Category != null)
            {
                using (ICategoryService _CategorysService = new CategorysService())
                {
                    if (_CategorysService.IsDuplicateBuilding(Category) == false)
                    {
                        if (Common.getBasetokenData().glbShopId != Category.SI)
                        {
                            return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
                        }


                        Category = Common.GetDefaultValues(Category);
                        var building = _CategorysService.Add(Category);

                        return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, building);
                    }
                    else
                    {
                        return Response.CreateResponse(ResultCodes.AlreadyExist, HttpStatusCode.BadRequest, "Category with the same name already exists.");
                    }
                }
            }
            else
            {
                return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
            }
        }


        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Category"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut()]
        [Route("Update/{id}")]
        public HttpResponseMessage UpdateCategory(long id, [FromBody]CategorysMasterUI Category)
        {
            if (id > 0)
            {
                using (ICategoryService _CategorysService = new CategorysService())
                {
                    if (_CategorysService.IsDuplicateBuilding(Category) == false)
                    {
                        if (Common.getBasetokenData().glbShopId != Category.SI)
                        {
                            return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
                        }
                        string basePath = System.Web.HttpContext.Current.Server.MapPath("~");
                        var building = _CategorysService.Update(id, Category);
                        return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, building);
                    }
                    else
                    {
                        return Response.CreateResponse(ResultCodes.AlreadyExist, HttpStatusCode.BadRequest, "Category with the same name already exists.");
                    }
                }
            }
            else
            {
                return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage DeleteCategory(long id)
        {
            if (id > 0)
            {
                string basePath = System.Web.HttpContext.Current.Server.MapPath("~");
                var buildingMaster = Common.GetDefaultValues(new CategorysMasterUI());
                using (ICategoryService _CategorysService = new CategorysService())
                {
                    var isdelete = _CategorysService.Delete(id, basePath, buildingMaster);
                    return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, isdelete);
                }
            }
            else
            {
                return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
            }
        }

    }
}
