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
    [RoutePrefix("v1/shopmaster")]
    public class ShopMasterController : ApiController
    {
        //private readonly IShopMasterService _ShopMasterService;

        /// <summary>
        /// Constructor to call Interface
        /// </summary>
        public ShopMasterController()
        {
            //if (System.Web.HttpContext.Current.Request.RequestType != "OPTIONS")
            //{
            //    _ShopMasterService = new ShopMasterService();
            //}
        }

        /// <summary>
        /// Get All Companies
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPost()]
        [Route("Getall")]
        public HttpResponseMessage GetAllShopMaster([FromBody] ListFilter filter)
        {
            var tokens = Common.getBasetokenData();
         //   filter.ShopId = tokens.gblUserId;
            using (IShopMasterService _ShopMasterService = new ShopMasterService())
            {
                if (tokens.userType == UserTypeUI.User)
                {
                    var ShopMasterfilterdata = _ShopMasterService.GetAll(filter, tokens.gblUserId);
                    return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, ShopMasterfilterdata);
                }
                else
                {
                    var ShopMasterdata = _ShopMasterService.GetAll(filter, 0);
                    return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, ShopMasterdata);
                }
            }
        }

        /// <summary>
        /// Get ShopMaster By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [Route("GetbyId/{id}")]
        public HttpResponseMessage GetShopMasterById(long id)
        {
            if (id > 0)
            {
                using (IShopMasterService _ShopMasterService = new ShopMasterService())
                {
                    var ShopMaster = _ShopMasterService.GetById(id);

                    if (ShopMaster != null)
                    {
                        return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, ShopMaster);
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

        ///// <summary>
        ///// Get ShopMaster By Id
        ///// </summary>
        ///// <param name="tokenId"></param>
        ///// <param name="ShopMasterId"></param>
        ///// <returns></returns>
        ///// <response code="200">Success</response>
        ///// <response code="404">Not found</response>
        ///// <response code="500">Internal server error</response>
        //[Route("SelectShopMasterById/{ShopMasterId}/{tokenId}")]
        //public HttpResponseMessage SelectShopMasterById(long tokenId, long ShopMasterId)
        //{
        //    if (ShopMasterId > 0)
        //    {
        //        using (IShopMasterService _ShopMasterService = new ShopMasterService())
        //        {
        //            var ShopMaster = _ShopMasterService.GetById(ShopMasterId);

        //            if (ShopMaster != null)
        //            {
        //                var token = _ShopMasterService.SelectShopMasterById(tokenId, ShopMasterId);
        //                selectShopMasterResult cResult = new selectShopMasterResult();
        //                cResult.Token = token;
        //                cResult.ShopMaster = ShopMaster;
        //                return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, cResult);
        //            }
        //            else
        //            {
        //                return Response.CreateResponse(ResultCodes.RecordsNotFound, HttpStatusCode.NotFound);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
        //    }
        //}

        /// <summary>
        /// Add New ShopMaster
        /// </summary>
        /// <param name="ShopMaster"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPost()]
        [Route("Add")]
        public HttpResponseMessage AddShopMaster([FromBody]ShopMasterUI ShopMaster)
        {
            if (ShopMaster != null)
            {
                using (IShopMasterService _ShopMasterService = new ShopMasterService())
                {
                    if (_ShopMasterService.IsDuplicateShop(ShopMaster) == false)
                    {
                        string basePath = System.Web.HttpContext.Current.Server.MapPath("~");
                        ShopMaster = Common.GetDefaultValues(ShopMaster);
                        var ShopMasters = _ShopMasterService.Add(ShopMaster, basePath);

                        return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, ShopMasters);
                    }
                    else
                    {
                        return Response.CreateResponse(ResultCodes.AlreadyExist, HttpStatusCode.BadRequest, "ShopMaster with the same name already exists.");
                    }
                }
            }
            else
            {
                return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Update ShopMaster
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ShopMaster"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPut()]
        [Route("Update/{id}")]
        public HttpResponseMessage UpdateShopMaster(long id, [FromBody]ShopMasterUI ShopMaster)
        {
            if (id > 0)
            {
                using (IShopMasterService _ShopMasterService = new ShopMasterService())
                {
                    if (_ShopMasterService.IsDuplicateShop(ShopMaster) == false)
                    {
                        //if (Common.getBasetokenData().glbSignup != ShopMaster.SI)
                        //{
                        //    return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
                        //}
                        string basePath = System.Web.HttpContext.Current.Server.MapPath("~");
                        var ShopMasters = _ShopMasterService.Update(id, basePath, ShopMaster);
                        return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, ShopMasters);
                    }
                    else
                    {
                        return Response.CreateResponse(ResultCodes.AlreadyExist, HttpStatusCode.BadRequest, "ShopMaster with the same name already exists.");
                    }
                }
            }
            else
            {
                return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Delete ShopMaster
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage DeleteShopMaster(long id)
        {
            if (id > 0)
            {
                string basePath = System.Web.HttpContext.Current.Server.MapPath("~");
                using (IShopMasterService _ShopMasterService = new ShopMasterService())
                {
                    var ShopMaster = Common.GetDefaultValues(new ShopMasterUI());
                    var isdelete = _ShopMasterService.Delete(id, basePath, ShopMaster);
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
