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
    [RoutePrefix("v1/subSubCategorys")]
    public class SubSubCategoryController : ApiController
    {

        // private readonly ISubCategorysService _SubCategorysService;
        /// <summary>
        /// 
        /// </summary>
        public SubSubCategoryController()
        {
            //if (System.Web.HttpContext.Current.Request.RequestType != "OPTIONS")
            //{
            //    _SubCategorysService = new SubCategorysService();
            //}
        }
        /// <summary>
        /// Get All SubCategorys
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPost()]
        [Route("Getall", Order = 0)]
        [Route("GetallForSubCategory", Order = 1)]
        public HttpResponseMessage GetAll([FromBody] ListFilter filter)
        {
            var tokens = Common.getBasetokenData();
            //filter.ShopId = tokens.gblUserId;
            using (ISubCategorysService _SubCategorysService = new SubCategorysService())
            {
                var SubCategorydata = _SubCategorysService.GetAll(filter);
                return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, SubCategorydata);
            }
        }

        /// <summary>
        /// Get SubCategory By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [Route("GetbyId/{id}")]
        public HttpResponseMessage GetSubCategoryById(long id)
        {
            if (id > 0)
            {
                using (ISubCategorysService _SubCategorysService = new SubCategorysService())
                {
                    var buildig = _SubCategorysService.GetById(id);

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
        /// Add New SubCategory
        /// </summary>
        /// <param name="SubCategory"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPost()]
        [Route("Add")]
        public HttpResponseMessage AddSubCategory([FromBody]SubCategorysMasterUI SubCategory)
        {
            if (SubCategory != null)
            {
                using (ISubCategorysService _SubCategorysService = new SubCategorysService())
                {
                    if (_SubCategorysService.IsDuplicateBuilding(SubCategory) == false)
                    {
                        if (Common.getBasetokenData().glbShopId != SubCategory.SI)
                        {
                            return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
                        }


                        SubCategory = Common.GetDefaultValues(SubCategory);
                        var building = _SubCategorysService.Add(SubCategory);

                        return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, building);
                    }
                    else
                    {
                        return Response.CreateResponse(ResultCodes.AlreadyExist, HttpStatusCode.BadRequest, "SubCategory with the same name already exists.");
                    }
                }
            }
            else
            {
                return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
            }
        }


        /// <summary>
        /// Update SubCategory
        /// </summary>
        /// <param name="id"></param>
        /// <param name="SubCategory"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut()]
        [Route("Update/{id}")]
        public HttpResponseMessage UpdateSubCategory(long id, [FromBody]SubCategorysMasterUI SubCategory)
        {
            if (id > 0)
            {
                using (ISubCategorysService _SubCategorysService = new SubCategorysService())
                {
                    if (_SubCategorysService.IsDuplicateBuilding(SubCategory) == false)
                    {
                        if (Common.getBasetokenData().glbShopId != SubCategory.SI)
                        {
                            return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
                        }
                        string basePath = System.Web.HttpContext.Current.Server.MapPath("~");
                        var building = _SubCategorysService.Update(id, SubCategory);
                        return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, building);
                    }
                    else
                    {
                        return Response.CreateResponse(ResultCodes.AlreadyExist, HttpStatusCode.BadRequest, "SubCategory with the same name already exists.");
                    }
                }
            }
            else
            {
                return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Delete SubCategory
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage DeleteSubCategory(long id)
        {
            if (id > 0)
            {
                string basePath = System.Web.HttpContext.Current.Server.MapPath("~");
                var buildingMaster = Common.GetDefaultValues(new SubCategorysMasterUI());
                using (ISubCategorysService _SubCategorysService = new SubCategorysService())
                {
                    var isdelete = _SubCategorysService.Delete(id, basePath, buildingMaster);
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
