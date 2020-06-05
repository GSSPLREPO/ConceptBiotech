using ConceptBiotech.Business;
using ConceptBiotech.UIEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConceptBiotech.WebAPI
{
    //[AuthorizationRequired]
    [RoutePrefix("v1/productmaster")]
    public class ProductMasterController : ApiController
    {
        public ProductMasterController()
        {

        }

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>Product
        /// <response code="500">Internal server error</response>
        [HttpPost()]
        [Route("Getall", Order = 0)]
        public HttpResponseMessage GetAllProduct([FromBody] ListFilter filter)
        {
            var tokens = Common.getBasetokenData();
            // filter.ShopId = tokens.glbShopId;
            using (IProductMasterService _ProductMasterService = new ProductMasterService())
            {
                var ProductData = _ProductMasterService.GetAll();

                return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, ProductData);
            }
        }



        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        // GET: api/SignUp/5
        [Route("GetbyId/{id}")]
        public HttpResponseMessage GetProductById(long id)
        {
            if (id > 0)
            {
                using (IProductMasterService _ProductMasterService = new ProductMasterService())
                {
                    var Product = _ProductMasterService.GetById(id);

                    if (Product != null)
                    {
                        return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, Product);
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
        /// Add New Product
        /// </summary>
        /// <param name="Product"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPost()]
        [Route("Add")]
        public HttpResponseMessage AddProduct([FromBody]ProductMasterUI Product)
        {

            if (Product != null)
            {
                var token = Common.getBasetokenData();
                using (IProductMasterService _ProductMasterService = new ProductMasterService())
                {
                    if (_ProductMasterService.IsDuplicateProductMaster(Product) == false)
                    {

                        string basePath = System.Web.HttpContext.Current.Server.MapPath("~");
                        Product = Common.GetDefaultValues(Product);
                        // Product.Pwd = Encrypt(Product.Pwd, true);
                        var Productdata = _ProductMasterService.Add(Product, basePath, Convert.ToInt64(token.gblUserId));
                        return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, Productdata);
                    }
                    else
                    {
                        return Response.CreateResponse(ResultCodes.AlreadyExist, HttpStatusCode.BadRequest, "Product with the same name or Productname or email or mobile already exists.");
                    }
                }
            }
            else
            {
                return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Product"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        //[Route("Add111", Order = 0)]
        //[Route("Add1111", Order = 1)]
        //[Route("Update/{id}", Order = 2)]
        //[RoleManager(AccessLevel.Edit, ModuleName.InquiryM)]
        //[RoleManager(AccessLevel.Edit, ModuleName.InquiryM)]
        //[RoleManager(AccessLevel.Edit, ModuleName.Usr)]
        [HttpPut()]
        [Route("Update/{id}", Order = 0)]
        [Route("Updateprofile/{id}", Order = 1)]
        public HttpResponseMessage UpdateProduct(long id, [FromBody]ProductMasterUI Product)
        {
            if (id > 0)
            {
                var token = Common.getBasetokenData();
                using (IProductMasterService _ProductMasterService = new ProductMasterService())
                {
                    if (_ProductMasterService.IsDuplicateProductMaster(Product) == false)
                    {
                        string basePath = System.Web.HttpContext.Current.Server.MapPath("~");
                        var Productdata = _ProductMasterService.Update(id, Product, basePath, Convert.ToInt64(token.gblUserId));
                        return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, Productdata);
                    }
                    else
                    {
                        return Response.CreateResponse(ResultCodes.AlreadyExist, HttpStatusCode.BadRequest, "Product with the same name or Productname or email or mobile already exists.");
                    }
                }
            }
            else
            {
                return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage DeleteProduct(long id)
        {
            if (id > 0)
            {
                var token = Common.getBasetokenData();
                string basePath = System.Web.HttpContext.Current.Server.MapPath("~");
                var Product = Common.GetDefaultValues(new ProductMasterUI());
                using (IProductMasterService _ProductMasterService = new ProductMasterService())
                {
                    var isdelete = _ProductMasterService.Delete(id, Product, basePath, Convert.ToInt64(token.gblUserId));
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
