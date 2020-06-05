using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.UIEntity
{
    public class CategorysMasterUI : BaseEntity
    {
        [StringLength(50)]
        public string CN { get; set; }

        public long SI { get; set; }
    }
}
