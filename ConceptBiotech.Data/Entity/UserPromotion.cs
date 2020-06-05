using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.Data
{
    [Collection(Name = "UserPromotion")]
    public class UserPromo : Entity<string>
    {
        public long UserId { get; set; }

        public string Code { get; set; }

        public bool IsAvailable { get; set; }

        //[StringLength(50)]
    }
}
