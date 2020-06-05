using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.Data
{
    [Collection(Name = "shopmaster")]
    public class ShopMaster : Entity<string>
    {
        [Required]
        [StringLength(100)]
        public string ShopName { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        public DateTime StartDate { get; set; }

        public string ShopLogo { get; set; }

        [StringLength(200)]
        public string EmailID { get; set; }

        [StringLength(50)]
        public string ContactNumber { get; set; }

        [StringLength(200)]
        public string ContactPerson { get; set; }

        [StringLength(200)]
        public string Website { get; set; }

        [StringLength(200)]
        public string GSTNumber { get; set; }

        [StringLength(200)]
        public string VatNumber { get; set; }

        public bool IsPaymentActive { get; set; }

        public bool IsResgistredDomain { get; set; }

        public string ResgistredDomainName { get; set; }
    
    }
}
