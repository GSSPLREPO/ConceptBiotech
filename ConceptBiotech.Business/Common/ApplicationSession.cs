using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;

namespace ConceptBiotech.Business
{
    public class ApplicationSession
    {
        private static HttpSessionState mvarSession;

        public static void Init(HttpSessionState Session)
        {
            mvarSession = Session;
        }

        #region Constant declaration of the session variable

        public const string USERNAME = "UserName";
        public const string EMPLOYEENAME = "EmployeeName";
        public const string USERID = "UserID";
        public const string ORGANISATIONID = "OrganisationID";
        public const string ORGANISATIONNAME = "Name";
        public const string ORGANISATIONADDRESS = "OrganisationAddress";
        public const string ORGANISATIONGROUPID = "OrganisationGroupID";
        public const string ORGANISATIONGROUPNAME = "OrganisationGroupName";
        public const string ROLEID = "RoleID";
       

        public static void ClearAllSessions()
        {
            mvarSession.Remove(USERNAME);
        }
        #endregion
    }
}
