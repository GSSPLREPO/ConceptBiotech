using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ConceptBiotech.WebAPI
{
    public class AuthorizationRequiredAttribute : ActionFilterAttribute
    {
        private const string Token = "Token";

        ///// <summary>
        ///// Authenticates user and returns token with expiry.
        ///// </summary>
        ///// <returns></returns>
        //public static string DescryptAesManaged(string raw)
        //{
        //    string decrypted = null;
        //    try
        //    {
        //        using (AesManaged aes = new AesManaged())
        //        {
        //            // Encrypt string    
        //            decrypted =Common.Decrypt(System.Text.Encoding.UTF8.GetBytes(raw), aes.Key, aes.IV);
        //            decrypted = Common.Decrypt(Encoding.Default.GetBytes(raw), aes.Key, aes.IV);
        //        }
        //        return decrypted;
        //    }
        //    catch
        //    {
        //        return decrypted;
        //    }
        //}

        /// <summary>
        /// Validate Token on each Action Execution
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            //  Get API key provider

            //bool isValidRequst = true;
            //check for model is valid or not
            if (filterContext.ModelState.IsValid == false)
            {
                filterContext.Response = Response.CreateResponse(ResultCodes.DataValidationError, HttpStatusCode.BadRequest);
                return;
            }

            var actionDescriptor = filterContext.ActionDescriptor;

            var isAnonymousAllowed = actionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Any() ||
                actionDescriptor.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Any();

            if (isAnonymousAllowed == false)
            {
                int Order = 0;
                var currentRoute = filterContext.Request.GetRouteData().Route.DataTokens.Where(a => a.Key == "order");
                if (currentRoute.Count() > 0)
                {
                    Order = Convert.ToInt32(currentRoute.First().Value);
                }

                if (filterContext.Request.Headers.Contains(Token))
                {
                    var tokenValue = filterContext.Request.Headers.GetValues(Token).First();
                    //var identity1 = new BasicAuthenticationIdentity(string.Empty, string.Empty, filterContext.Request.Headers.GetValues("SC").First(), filterContext.Request.Headers.GetValues("CS").First());
                    //var genericPrincipal1 = new GenericPrincipal(identity1, null);
                    //Thread.CurrentPrincipal = genericPrincipal1;
                   // var provider = new TokenService(); //filterContext.ControllerContext.Configuration.DependencyResolver.GetService(typeof(ITokenService)) as ITokenService;
                    //var tokenValue = filterContext.Request.Headers.GetValues(Token).First();

                    // Validate Token
                    //if (provider != null)
                    {
                        //    var tokenui = provider.ValidateToken(Convert.ToInt64(tokenValue));
                        //    if (tokenui == null)
                        //    {
                        //        //var responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Invalid Request" };
                        //        //filterContext.Response = responseMessage;
                        //        var responseMess = Response.CreateResponse(ResultCodes.UnAuthorize, HttpStatusCode.Unauthorized);
                        //        responseMess.ReasonPhrase = "Invalid Request";
                        //        filterContext.Response = responseMess;
                        //    }
                        //    else
                        //    {
                        //        //Get Role Attribute Given to Method
                        //        var RoleAttributes = actionDescriptor.GetCustomAttributes<RoleManagerAttribute>().ToList();
                        //        RoleManagerAttribute RoleAttributeDetails = null;
                        //        if (RoleAttributes != null && RoleAttributes.Count() >= Order && RoleAttributes.Count() > 0)
                        //        {
                        //            RoleAttributeDetails = RoleAttributes[Order];
                        //        }
                        //        else
                        //        {
                        //            RoleAttributeDetails = RoleAttributes.FirstOrDefault();
                        //        }


                        //        if (tokenui.UT == UIEntity.UserTypeUI.User)
                        //        {
                        //            if (RoleAttributeDetails != null && RoleAttributeDetails.AccessLevel != AccessLevel.Anonymous && tokenui.RDet != null)
                        //            {
                        //                //Get Access Level From Attribute
                        //                AccessLevel methodAccessLevel = RoleAttributeDetails.AccessLevel;
                        //                //Get Module Name From Attribute
                        //                string Module = RoleAttributeDetails.ModuleName.ToString();
                        //                //Get Role Rights From Token Passed
                        //                var ModelRights = Extended.GetPropValue(tokenui.RDet, Module) as List<string>;
                        //                if (ModelRights != null)
                        //                {
                        //                    //Rights For Specific Page

                        //                    if (
                        //                          ((methodAccessLevel == AccessLevel.View && Convert.ToBoolean(ModelRights[0]) == true)
                        //                        || (methodAccessLevel == AccessLevel.Add && Convert.ToBoolean(ModelRights[1]) == true)
                        //                        || (methodAccessLevel == AccessLevel.Edit && Convert.ToBoolean(ModelRights[2]) == true)
                        //                        || (methodAccessLevel == AccessLevel.Delete && Convert.ToBoolean(ModelRights[3]) == true))
                        //                         == false)
                        //                    {
                        //                        filterContext.Response = Response.CreateResponse(ResultCodes.UnAuthorize, HttpStatusCode.MethodNotAllowed);
                        //                        return;
                        //                    }
                        //                }
                        //                else
                        //                {
                        //                    filterContext.Response = Response.CreateResponse(ResultCodes.UnAuthorize, HttpStatusCode.MethodNotAllowed);
                        //                    return;
                        //                }
                        //            }
                        //            else if (RoleAttributeDetails != null && RoleAttributeDetails.AccessLevel != AccessLevel.Anonymous)
                        //            {
                        //                filterContext.Response = Response.CreateResponse(ResultCodes.UnAuthorize, HttpStatusCode.MethodNotAllowed);
                        //                return;
                        //            }
                        //        }
                        //        string CS = string.Empty;
                        //        string SC = string.Empty;
                        //        if (filterContext.Request.Headers.GetValues("CS") != null && filterContext.Request.Headers.GetValues("SC") != null)
                        //        {
                        //            CS = filterContext.Request.Headers.GetValues("CS").First();
                        //            SC = filterContext.Request.Headers.GetValues("SC").First();
                        //        }
                        //        //var identity = System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                        //        var identity = new BasicAuthenticationIdentity(string.Empty, string.Empty, SC, CS);
                        //        identity.CompanyId = tokenui.CI;
                        //        identity.UserId = tokenui.UI;
                        //        identity.UserName = tokenui.UN;
                        //        identity.SignupId = tokenui.SI;
                        //        identity.RoleData = tokenui.RDet;
                        //        identity.userType = tokenui.UT;
                        //        var genericPrincipal = new GenericPrincipal(identity, null);
                        //        Thread.CurrentPrincipal = genericPrincipal;
                        //        //identity.RoleData = tokenui.RDet;
                        //    }
                    }
                }
                else
                {
                    filterContext.Response = Response.CreateResponse(ResultCodes.UnAuthorize, HttpStatusCode.Unauthorized);
                    return;
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}