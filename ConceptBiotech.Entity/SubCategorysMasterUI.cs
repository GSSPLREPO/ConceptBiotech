using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.UIEntity
{
    public class SubCategorysMasterUI : BaseEntity
    { 
        //public long SignupId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public long CID { get; set; }

        public long SI { get; set; }
    }
}
