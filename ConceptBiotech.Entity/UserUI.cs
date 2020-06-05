using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConceptBiotech.UIEntity
{
    public class UserUI : BaseEntity
    {
        /// <summary>
        /// UserName
        /// </summary>
        //  [Required]
        //[StringLength(50)]
        //  public long SI { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        //  [Required]
        //[StringLength(50)]
        public string UN { get; set; }

        /// <summary>
        /// FirstName
        /// </summary>
       // [Required]
        //[StringLength(50)]
        public string FN { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        //[Required]
        //[StringLength(50)]
        public string MN { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
      //  [Required]
        //[StringLength(50)]
        public string LN { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        //   [Required]
        //[StringLength(200)]
        public string Pwd { get; set; }

        /// <summary>
        /// Email
        /// </summary>
     //   [Required]
        //[StringLength(250)]
        public string Eml { get; set; }

        /// <summary>
        /// Mobile
        /// </summary>
        //    [Required]
        // [StringLength(50)]
        public string Mo { get; set; }

        /// <summary>
        /// Address
        /// </summary>
    //    [Required]
        //[StringLength(500)]
        public string Addr1 { get; set; }

        /// <summary>
        /// City
        /// </summary>
      //  [Required]
        //[StringLength(50)]
        public string Ct { get; set; }

        /// <summary>
        /// State
        /// </summary>
        //    [Required]
        // [StringLength(50)]
        public string Ste { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        //  [Required]
        // [StringLength(50)]
        public string Ctr { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        //  [Required]
        // [StringLength(50)]
        public string PC { get; set; }



        /// <summary>
        /// Country
        /// </summary>
        //  [Required]
        public int? UserPromotionId { get; set; }


        /// <summary>
        /// UserType
        /// </summary>
        public UserTypeUI UT { get; set; }
    }

    public class RootObject
    {
        public int custom_code { get; set; }
        public string message { get; set; }
        public UserUI data { get; set; }
    }

    public class ListFilter
    {
        //public long ShopId { get; set; }

        public long UserId { get; set; }
        //public int endindex { get; set; }
        //private string _sort;
        //public string sort
        //{
        //    get
        //    {
        //        if (string.IsNullOrWhiteSpace(_sort))
        //            return null;
        //        return _sort;
        //    }
        //    set { _sort = value; }
        //}
        //public bool sortorder { get; set; }
    }

    public class ListFilter<T>
    {
        //public int startindex { get; set; }
        //public int endindex { get; set; }
        //private string _sort;
        //public T FilterData;
        //public long ShopId { get; set; }

        public long UsersId { get; set; }

        //public string sort
        //{
        //    get
        //    {
        //        if (string.IsNullOrWhiteSpace(_sort))
        //            return null;
        //        return _sort;
        //    }
        //    set { _sort = value; }
        //}

        //public bool sortorder { get; set; }
    }

    public class ReportFilter
    {
        public long LedgerId { get; set; }
        public long Ledger2Id { get; set; }
        public bool ReportType { get; set; }
        public bool Isgroup { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public decimal LastOpbalance { get; set; }
        public long VoucherMasterId { get; set; }
        public decimal? amountvall { get; set; }
        public string amounttype { get; set; }
        public string instrumentno { get; set; }
        public DateTime? instrumentdate { get; set; }
        public List<long> UserId { get; set; }
        public string nurration { get; set; }
        public string voucherno { get; set; }
        public int? IsCreditDebit { get; set; }
        public long? CompanyId { get; set; }
        public long? Company2Id { get; set; }
        public long? InvId { get; set; }
        public long? TskId { get; set; }
        public long? SbTskId { get; set; }
        public bool IsFinalize { get; set; }
        public bool IsVoucherrestore { get; set; }
        public long InvLedgerId { get; set; }
    }
}
