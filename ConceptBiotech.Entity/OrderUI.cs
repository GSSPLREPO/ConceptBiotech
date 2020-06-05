using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.UIEntity
{
    public class OrderUI : BaseEntity
    {
        //public long SignupId { get; set; }

        public long UserId { get; set; }

        [StringLength(50)]
        public string ONo { get; set; }

        public DateTime ODt { get; set; }

        //[StringLength(50)]
        public decimal TAmt { get; set; }

        [StringLength(2000)]
        public string Desc { get; set; }

        public List<OrderDetailUI> ODet { get; set; }
    }

    public class OrderDetailUI
    {
        //public long PK_Id { get; set; }

        public long OId { get; set; }

        [Required]
        public long PId { get; set; }

        public decimal Rt { get; set; }

        public decimal Qty { get; set; }

        public string ProductName { get; set; }
    }
}
