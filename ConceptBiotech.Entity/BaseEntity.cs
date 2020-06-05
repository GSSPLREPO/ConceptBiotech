using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.UIEntity
{
    public class BaseEntity
    {/// <summary>
     /// UniqueIdNumber(ID)
     /// </summary>
        public long UIDN { get; set; }

        /// <summary>
        /// CreatedDate
        /// </summary>
        public DateTime? CDt { get; set; }

        /// <summary>
        /// ModifiedDate
        /// </summary>
        public DateTime? MDt { get; set; }
        
        /// <summary>
        /// CreatedBy
        /// </summary>
        public long CBy { get; set; }
        
        /// <summary>
        /// ModifiedBy
        /// </summary>
        public long MBy { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public UIRecordStatus St { get; set; }
    }

    /// <summary>
    /// RecordStatus Enums
    /// </summary>
    public enum UIRecordStatus
    {
        InActive = 0,
        Active = 1,
        Deleted = 2,
        Draft = 3,
        InProgress = 4,
        Sent = 5
    }
}
