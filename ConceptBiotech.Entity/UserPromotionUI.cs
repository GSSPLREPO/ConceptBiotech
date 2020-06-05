using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.UIEntity
{
    public class UserPromotionUI : BaseEntity
    {
        public long UserId { get; set; }

        public string Code { get; set; }

        public bool IsAvailable { get; set; }
    }
}
