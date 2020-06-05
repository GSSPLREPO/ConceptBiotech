using ConceptBiotech.Business;
using ConceptBiotech.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;

namespace ConceptBiotech.WebAPI
{
    public class ApiAuthenticationFilter : GenericAuthenticationFilter
    {
        /// <summary>
        /// Default Authentication Constructor
        /// </summary>
        public ApiAuthenticationFilter()
        {
        }

        /// <summary>
        /// AuthenticationFilter constructor with isActive parameter4
        /// </summary>
        /// <param name="isActive"></param>
        public ApiAuthenticationFilter(bool isActive)
            : base(isActive)
        {
        }
        /// <summary>
        /// Protected overriden method for authorizing user
        /// </summary>
        /// <param name="SignupCode"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        //protected override bool OnAuthorizeUser(string username, string password,string Signupode, HttpActionContext actionContext)
        protected override bool OnAuthorizeUser(User userdata, HttpActionContext actionContext)
        {
            var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
            
            var provider = new UserService();// actionContext.ControllerContext.Configuration
                                             //.DependencyResolver.GetService(typeof(IUserService)) as IUserService;
            var user = provider.Authenticate(userdata);
            if (user != null)
            {
                if (basicAuthenticationIdentity != null)
                {
                    //basicAuthenticationIdentity.CS = signUp.CS;
                    //basicAuthenticationIdentity.SC = signUp.SUC;
                    basicAuthenticationIdentity.UserId = user.UIDN;
                    //basicAuthenticationIdentity.CompanyId = user.co;
                    //basicAuthenticationIdentity.SignupId = user.SI;
                    //basicAuthenticationIdentity.UserId = user.Id;
                    basicAuthenticationIdentity.UserName = user.UN;
                    //basicAuthenticationIdentity.userType = user.UT;
                }
                return true;
            }
            return false;
        }
    }

}