using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace ConceptBiotech.Data
{
    [Collection(Name = "user")]
    public class User : Entity<string>
    {
        //public long ShopId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        //[StringLength(50)]
        //public string Designation { get; set; }

        //public DateTime? EmployeeSince { get; set; }

        [StringLength(200)]
        public string Password { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(500)]
        public string Address1 { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string PromotionCode { get; set; }

        public UserType UserType { get; set; }

        public int? UserPromotionId { get; set; }

        //public List<files> UserImages { get; set; }
    }


}
