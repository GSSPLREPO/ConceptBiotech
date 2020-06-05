using AutoMapper;
using ConceptBiotech.Business;
using ConceptBiotech.Data;
using ConceptBiotech.UIEntity;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;

namespace ConceptBiotech.WebAPI.Controllers
{
    [RoutePrefix("v1/authenicate")]
    public class AuthenicateController : ApiController
    {

        /// <summary>
        /// 
        /// </summary>
        public AuthenicateController()
        {

        }

        /// <summary>
        /// Generate New Payment Request
        /// </summary>
        /// <param name="Login"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPost()]
        [Route("SignUp")]
        public HttpResponseMessage SignUp([FromBody] UserUI Userui)
        {
            using (IUserService _IuserService = new UserService())
            {
                                              //.DependencyResolver.GetService(typeof(IUserService)) as IUserService;
                var user = _IuserService.Add(Userui);
                if (user != null)
                {
                    return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, user);
                }
                else
                {
                    return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.BadRequest);
                }
            }
        }

        /// <summary>
        /// Generate New Payment Request
        /// </summary>
        /// <param name="Login"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal server error</response>
        [HttpPost()]
        [Route("Login")]
        public HttpResponseMessage Login([FromBody] UserUI Userui)
        {
            using (IUserService _IuserService = new UserService())
            {
                var User = Mapper.Map<UserUI, User>(Userui);
                var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;

                var provider = new UserService();// actionContext.ControllerContext.Configuration
                                                 //.DependencyResolver.GetService(typeof(IUserService)) as IUserService;
                var user = provider.Authenticate(User);
                if (user != null)
                {
                    if (basicAuthenticationIdentity == null)
                    {
                        basicAuthenticationIdentity = new BasicAuthenticationIdentity(User.UserName, User.Password);
                        //basicAuthenticationIdentity.CS = signUp.CS;
                        //basicAuthenticationIdentity.SC = signUp.SUC;
                        basicAuthenticationIdentity.UserId = user.UIDN;
                        //basicAuthenticationIdentity.CompanyId = user.co;
                        //basicAuthenticationIdentity.ShopId = user.SI;
                        //basicAuthenticationIdentity.UserId = user.Id;
                        basicAuthenticationIdentity.UserName = user.UN;
                        //basicAuthenticationIdentity.userType = user.UT;
                        //   return GetAuthToken(user.UIDN);

                        var _tokenServices = new TokenService();
                        var token = _tokenServices.GenerateToken(user.UIDN);
                        var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
                        response.Headers.Add("Token", token.UIDN.ToString());
                        //"SignupCode","Encryption Strnig"
                        response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
                        response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
                    }

                    return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.OK, user);
                }
                else
                {
                    return Response.CreateResponse(ResultCodes.Success, HttpStatusCode.BadRequest);
                }
            }
        }
        
    }
}
