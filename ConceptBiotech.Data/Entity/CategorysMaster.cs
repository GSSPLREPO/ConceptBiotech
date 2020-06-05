using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.Data
{
    public class CategorysMaster : Entity<string>
    {
        //public long SignupId { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }
        
       // public long ShopId { get; set; }
    }
}
