using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.Data
{
    [Collection(Name = "token")]
    public class Token : Entity<string>
    {
        public long UserId { get; set; }

        //public long CompanyId { get; set; }

        //public long SignupId { get; set; }

        //public long? RoleData_PK_Id { get; set; }

       // public RoleMaster RoleMaster { get; set; }

        public UserType UserType { get; set; }

        public string UserName { get; set; }

        //public long RoleId { get; set; }

        //public string Photo { get; set; }

        public string AuthToken { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
    public enum UserType
    {
        User = 1,
        Admin = 2,
        SuperAdmin = 3,
        Agent = 4
    }
}
