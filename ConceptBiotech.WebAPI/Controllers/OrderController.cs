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
    [RoutePrefix("v1/order")]
    public class OrderController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        public OrderController()
        {
        }

        /// <summary>
        /// Get All Flat Type
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPost()]
        [Route("Getall")]
        public HttpResponseMessage GetAll([FromBody] UserUI user)
        {
            var tokens = Common.getBasetokenData();
            //filter.UsersId = tokens.gblUserId;
            using (IOrderService _OrderService = new OrderService())
            {
                var bankdata = _OrderService.GetAll(user.UIDN);
                return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, bankdata);
            }
        }

        /// <summary>
        /// Get Flat Type By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [Route("GetbyId/{id}")]
        public HttpResponseMessage GetOrderById(long id)
        {
            if (id > 0)
            {
                using (IOrderService _OrderService = new OrderService())
                {
                    var buildig = _OrderService.GetById(id);

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
        /// Add New Order
        /// </summary>
        /// <param name="Order"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPost()]
        [Route("Add")]
        public HttpResponseMessage AddOrder([FromBody]OrderUI Order)
        {
            if (Order != null)
            {
                var token = Common.getBasetokenData();
                using (IOrderService _OrderService = new OrderService())
                {
                    //if (Common.getBasetokenData().glbShopId != Order.SI)
                    //{
                    //    return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
                    //}
                    Order = Common.GetDefaultValues(Order);
                    var Orders = _OrderService.Add(Order, Convert.ToInt64(token.glbShopId));
                    return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, Orders);

                }
            }
            else
            {
                return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
            }
        }


        ///// <summary>
        ///// Update Orders
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="Order"></param>
        ///// <returns></returns>
        ///// <response code="200">Success</response>
        ///// <response code="404">Not found</response>
        ///// <response code="500">Internal server error</response>
        //[HttpPut()]
        //[Route("Update/{id}")]
        //public HttpResponseMessage UpdateOrder(long id, [FromBody]OrderUI Order)
        //{
        //    if (id > 0)
        //    {
        //        var token = Common.getBasetokenData();
        //        using (IOrderService _OrderService = new OrderService())
        //        {
        //            if (_OrderService.IsDuplicateOrders(Order) == false)
        //            {
        //                if (Common.getBasetokenData().glbSignup != Order.SI)
        //                {
        //                    return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
        //                }
        //                string basePath = System.Web.HttpContext.Current.Server.MapPath("~");
        //                var Orders = _OrderService.Update(id, Order, Convert.ToInt64(token.glbCompany));
        //                return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, Orders);
        //            }
        //            else
        //            {
        //                return Response.CreateResponse(ResultCodes.AlreadyExist, HttpStatusCode.BadRequest, "Buildig with the same name already exists.");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
        //    }
        //}

        /// <summary>
        /// Delete Orders
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //  [HttpDelete]
        [Route("isduplicatepromotioncode/{promotioncode}")]
        public HttpResponseMessage IsDuplicatePromotionCode(string PromotionCode)
        {
            if (PromotionCode != string.Empty)
            {
                var Order = Common.GetDefaultValues(new OrderUI());
                using (IOrderService _OrderService = new OrderService())
                {
                    var isdelete = _OrderService.IsDuplicatePromotionCode(PromotionCode);
                    return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, isdelete);
                }
            }
            else
            {
                return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
            }
        }


        /// <summary>
        /// Get All Flat Type
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPost()]
        [Route("GetUserCommission/{UserID}/{UserPromotionId}")]
        public HttpResponseMessage GetUserCommission(long UserID, long UserPromotionId)
        {
            var tokens = Common.getBasetokenData();
            //filter.UsersId = tokens.gblUserId;
            using (IOrderService _OrderService = new OrderService())
            {
                var bankdata = _OrderService.GetAllUserCommission(UserID,UserPromotionId);
                return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, bankdata);
            }
        }


        /// <summary>
        /// Get All Flat Type
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPost()]
        [Route("GetUserTotalTCommission/{UserID}")]
        public HttpResponseMessage GetUserTotalCommission(long UserID)
        {
            var tokens = Common.getBasetokenData();
            //filter.UsersId = tokens.gblUserId;
            using (IOrderService _OrderService = new OrderService())
            {
                var bankdata = _OrderService.GetAllUserTotalCommission(UserID);
                return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, bankdata);
            }
        }
    }
}
