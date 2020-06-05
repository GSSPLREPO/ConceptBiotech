using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace ConceptBiotech.WebAPI
{
    public class BasicAuthenticationIdentity : GenericIdentity
    {
        /// <summary>
        /// Get/Set for password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Get/Set for UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Get/Set for UserId
        /// </summary>
        public long UserId { get; set; }

        ///// <summary>
        /////  Get/Set for CompanyId
        ///// </summary>
        //public long CompanyId { get; set; }

        ///// <summary>
        /////  Get/Set for SignupId
        ///// </summary>
        //public long ShopId { get; set; }

        /// <summary>
        ///  Get/Set for SignupId
        /// </summary>
        //public UserTypeUI userType { get; set; }

        /// <summary>
        ///Role of User
        /// </summary>
        //public RoleMasterUI RoleData { get; set; }

        /// <summary>
		///SC
		/// </summary>
		public string SC { get; set; }

        /// <summary>
        ///  Get/Set for Con str
        /// </summary>
        public string CS { get; set; }

        /// <summary>
        /// Basic Authentication Identity Constructor
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        //public BasicAuthenticationIdentity(string userName, string password,string signupcode,string constr)
        public BasicAuthenticationIdentity(string userName, string password)
        : base(userName, "Basic")
        {
            Password = password;
            UserName = userName;
        }
    }
}