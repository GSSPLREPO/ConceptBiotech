using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.Data
{
    [Serializable]
    public abstract class Entity<T> : IEntity<T>
    {
        /// <summary>
        /// Gets or sets the id for this object (the primary record for an entity).
        /// </summary>
        /// <value>The id for this object (the primary record for an entity).</value>
        /// 


        //public long PK_Id { get; set; }
        //[BsonId]
        //[NotMapped]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public virtual T Id { get; set; }

        [Key]
        public long PK_Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        //public string IpAddress { get; set; }

        public long? CreatedBy { get; set; }

        public long? ModifiedBy { get; set; }

        //public string Device { get; set; }

        //public string UserAgent { get; set; }

        public RecordStatus Status { get; set; }
    }
    [Serializable]
    public abstract class EntityWithoutObjectID<T> : IEntity<T>
    {
        /// <summary>
        /// Gets or sets the id for this object (the primary record for an entity).
        /// </summary>
        /// <value>The id for this object (the primary record for an entity).</value>
        public virtual T Id { get; set; }

    }
    public enum RecordStatus
    {
        InActive = 0,
        Active = 1,
        Deleted = 2,
        Draft = 3,
        InProgress = 4,
        Sent = 5
    }

    //public enum CampaignType
    //{
    //    Normal = 0,
    //    Recurring = 1,

    //}

    //public enum RecurringType
    //{
    //    BirthDay = 1,
    //    NewInquiry = 2,
    //    statusChange = 3,
    //    other = 4,
    //    OnInquiry = 5
    //}
    //public enum RecurringFrequency
    //{
    //    Daily = 1,
    //    Weekly = 2,
    //    Monthly = 3,
    //    Quarterly = 4,
    //    Yearly = 5
    //}
    //public enum CampaignStatus
    //{
    //    NotSent = 1,
    //    Sent = 2,
    //    Inbox = 3,
    //    Spam = 4,
    //    Read = 5,
    //    Link = 6,
    //    Error = 7,
    //    ErrorSender = 8
    //}

    //public enum ModuleAction
    //{
    //    Add,
    //    Edit,
    //    Delete,
    //    Email,
    //    SMS
    //}
    //public enum ModuleName
    //{
    //    Bank, Inquiry, Booking, Voucher,
    //    Challan, Company, Customer,
    //    Role, User, Building,
    //    Wing, RoomType, Inventory, Task, SubTask,
    //    FlatType, SiteStructure, Source,
    //    DocumentType, EmailTemplate,
    //    Unit, Godown, Site, InventoryUsage, Document,
    //    IncomingCallService, SMSsetting,
    //    SystemSMS, SMStemplate, SystemEmail,
    //    TaxGroup, Ledger


    //}
}
