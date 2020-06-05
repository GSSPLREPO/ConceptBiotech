using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.UIEntity
{
    public class ProductMasterUI : BaseEntity
    {
        /// <summary>
        /// UserName
        /// </summary>
        //  [Required]
        //[StringLength(50)]
       // public long? SI { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
      //  [Required]
        [StringLength(50)]
        public string PN { get; set; }

        /// <summary>
        /// FirstName
        /// </summary>
       // [Required]
        [StringLength(50)]
        public string Code { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        //[Required]
       // [StringLength(50)]
        public decimal? SR { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        //[Required]
       // [StringLength(50)]
        public decimal? PR { get; set; }

        // /// <summary>
        /// CategoryId
        /// </summary>
        //[NotMapped]
        [StringLength(50)]
        public string UN { get; set; }

        /// <summary>
        /// CategoryId
        /// </summary>
        //[NotMapped]
        //[StringLength(50)]
        public string Image { get; set; }

        /// <summary>
        /// Desc      
        /// 
        /// /// </summary>
        public string Desc { get; set; }
    }

    public class RootObjectProduct
    {
        public int custom_code { get; set; }
        public string message { get; set; }
        public ProductMasterUI data { get; set; }
    }
}
