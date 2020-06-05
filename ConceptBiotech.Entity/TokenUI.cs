

namespace ConceptBiotech.UIEntity
{
    public class TokenUI : BaseEntity
    {
        public long UI { get; set; }
        public long CI { get; set; }
        public long SI { get; set; }
        //public RoleMasterUI RDet { get; set; }
        public UserTypeUI UT { get; set; }
        public string AT { get; set; }
        public string RI { get; set; }
        public System.DateTime IsOn { get; set; }
        public System.DateTime ExOn { get; set; }
        public string UN { get; set; }
        public string Photo { get; set; }

    }

    public enum UserTypeUI
    {
        User = 0,
        Admin = 1,
        SuperAdmin = 2,
        Agent = 3
    }
}
