using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.UIEntity
{
    public class ShopMasterUI : BaseEntity
    {
        public long SI { get; set; }

        [Required]
        [StringLength(100)]
        public string SN { get; set; }

        [StringLength(500)]
        public string Des { get; set; }

        [Required]
        [StringLength(500)]
        public string Addr { get; set; }

        [Required]
        [StringLength(50)]
        public string Ct { get; set; }

        [Required]
        [StringLength(50)]
        public string Ste { get; set; }

        [Required]
        [StringLength(50)]
        public string Ctr { get; set; }

        public DateTime StDt { get; set; }

        public string SL { get; set; }

        [StringLength(200)]
        public string EI { get; set; }

        [StringLength(50)]
        public string CON { get; set; }

        [StringLength(200)]
        public string COP { get; set; }

        [StringLength(200)]
        public string Ws { get; set; }

        [StringLength(200)]
        public string GSTN { get; set; }

        [StringLength(200)]
        public string VN { get; set; }

        public bool IsPA { get; set; }
        
    }
}