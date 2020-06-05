using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.Data
{
    [Collection(Name = "Order")]
    public class Order : Entity<string>
    {
        //public long SignupId { get; set; }

        public long UserId { get; set; }

        [StringLength(50)]
        public string OrderNo { get; set; }

        public DateTime OrderDate { get; set; }

        //[StringLength(50)]
        public decimal TotalAmount { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }

    public class OrderDetail
    {
        [Key]
        public long PK_Id { get; set; }

        [ForeignKey("Order")]
        public long OrderId { get; set; }

        [Required]
        public long ProductId { get; set; }

        public Order Order { get; set; }

        public decimal Rate { get; set; }

        public decimal Quantity { get; set; }

    }


    public class OrderUserData
    {
       
        public string Name { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        public DateTime? OrderDate { get; set; }

        //[StringLength(50)]
        public decimal Amount { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }
        
    }
}
