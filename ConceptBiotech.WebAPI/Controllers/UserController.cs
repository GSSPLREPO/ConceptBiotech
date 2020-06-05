using AutoMapper;
using ConceptBiotech.Business;
using ConceptBiotech.Data;
using ConceptBiotech.UIEntity;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;

namespace ConceptBiotech.WebAPI.Controllers
{
    // [ApiAuthenticationFilter]
    [RoutePrefix("v1/user")]
    public class UserController : ApiController
    {
        public UserController()
        {

        }


        /// <summary>
        /// Get All Users
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>user
        /// <response code="500">Internal server error</response>
        [HttpPost()]
        [Route("Getall", Order = 0)]
        public HttpResponseMessage GetAllUser([FromBody] ListFilter filter)
        {
            var tokens = Common.getBasetokenData();
            //  filter.ShopId = tokens.glbShopId;
            using (IUserService _userService = new UserService())
            {
                var UserData = _userService.GetAll();

                return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, UserData);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="SignupId"></param>
        /// <param name="SC"></param>
        /// <param name="CS"></param>
        /// <returns></returns>
        private HttpResponseMessage GetAuthToken(long userId)
        {
            var _tokenServices = new TokenService();
            var token = _tokenServices.GenerateToken(userId);
            var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
            response.Headers.Add("Token", token.UIDN.ToString());
            //"SignupCode","Encryption Strnig"
            response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
            return response;
        }


        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        // GET: api/SignUp/5
        [Route("GetbyId/{id}")]
        public HttpResponseMessage GetUserById(long id)
        {
            if (id > 0)
            {
                using (IUserService _userService = new UserService())
                {
                    var User = _userService.GetById(id);

                    if (User != null)
                    {
                        return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, User);
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
        /// Get User By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        // GET: api/SignUp/5
        [Route("GetProfile/{id}")]
        public HttpResponseMessage GetProfile(long id)
        {
            return GetUserById(id);
        }



        /// <summary>
        /// Add New User
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPost()]
        [Route("Add")]
        public HttpResponseMessage AddUser([FromBody]UserUI User)
        {

            if (User != null)
            {
                var token = Common.getBasetokenData();
                using (IUserService _userService = new UserService())
                {
                    if (_userService.IsDuplicateUser(User) == false)
                    {

                        string basePath = System.Web.HttpContext.Current.Server.MapPath("~");
                        User = Common.GetDefaultValues(User);
                        // User.Pwd = Encrypt(User.Pwd, true);
                        var userdata = _userService.Add(User);
                        return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, userdata);
                    }
                    else
                    {
                        return Response.CreateResponse(ResultCodes.AlreadyExist, HttpStatusCode.BadRequest, "User with the same name or username or email or mobile already exists.");
                    }
                }
            }
            else
            {
                return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="User"></param>
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
        public HttpResponseMessage UpdateUser(long id, [FromBody]UserUI User)
        {
            if (id > 0)
            {
                var token = Common.getBasetokenData();
                using (IUserService _userService = new UserService())
                {
                    if (_userService.IsDuplicateUser(User) == false)
                    {
                        string basePath = System.Web.HttpContext.Current.Server.MapPath("~");
                        var userdata = _userService.Update(id, User);
                        return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, userdata);
                    }
                    else
                    {
                        return Response.CreateResponse(ResultCodes.AlreadyExist, HttpStatusCode.BadRequest, "User with the same name or username or email or mobile already exists.");
                    }
                }
            }
            else
            {
                return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage DeleteUser(long id)
        {
            if (id > 0)
            {
                var token = Common.getBasetokenData();
                string basePath = System.Web.HttpContext.Current.Server.MapPath("~");
                var user = Common.GetDefaultValues(new UserUI());
                using (IUserService _userService = new UserService())
                {
                    var isdelete = _userService.Delete(id, user, basePath, Convert.ToInt64(token.gblUserId));
                    return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, isdelete);
                }
            }
            else
            {
                return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Delete Orders
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //  [HttpDelete]
        [Route("IsDuplicateUserPromotion/{promotioncode}")]
        public HttpResponseMessage IsDuplicateUserPromotion(string PromotionCode)
        {
            if (PromotionCode != string.Empty)
            {
                var Order = Common.GetDefaultValues(new OrderUI());
                using (IUserService _UserService = new UserService())
                {
                    var isdelete = _UserService.IsDuplicatePromotionCode(PromotionCode);
                    return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, isdelete);
                }
            }
            else
            {
                return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Delete Orders
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //  [HttpDelete]
        [Route("checkAvast/{FilePath}")]
        public HttpResponseMessage IsCheckFile(string FilePath)
        {
            if (FilePath != string.Empty)
            {
                var Order = Common.GetDefaultValues(new OrderUI());
                using (IUserService _UserService = new UserService())
                {
                    int timeout = 200000;
                    string commnd = @"ashcmd.exe / t = a / s / p / d / _ " + FilePath;
                    var pp = new ProcessStartInfo("cmd.exe", "/C" + commnd)
                    {
                        //CreateNoWindow = true,
                        UseShellExecute = false,
                        WorkingDirectory = @"C:\Program Files\AVAST Software\Avast",
                    };
                    var process = Process.Start(pp);
                    process.WaitForExit(timeout);
                    return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
                    //return true;
                }
            }
            else
            {
                return Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
            }
        }
    }
}
