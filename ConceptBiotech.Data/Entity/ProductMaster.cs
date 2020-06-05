using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.Data
{
    [Collection(Name = "productmaster")]
    public class ProductMaster : Entity<string>
    {
        /// <summary>
        /// UserName
        /// </summary>
        //  [Required]
        //[StringLength(50)]
        public long? ShopId { get; set; }

        [NotMapped]
        public long UserId { get; set; }

        //public string Name { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
      //  [Required]
        [StringLength(200)]
        public string ProductName { get; set; }

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
        //[StringLength(50)]
        public decimal SellingRate { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        //[Required]
        //[StringLength(50)]
        public decimal PurchaseRate { get; set; }

        /// <summary>
        /// CategoryId
        /// </summary>
        //[NotMapped]
        [StringLength(50)]
        public string UnitName { get; set; }

        /// <summary>
        /// CategoryId
        /// </summary>
        //[NotMapped]
        //[StringLength(50)]
        public string ImagePath { get; set; }

        /// <summary>
        /// CategoryId
        /// </summary>
        //[NotMapped]
        //[StringLength(50)]
        public string Description { get; set; }
    }
}
