using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Entities
{
    public partial class FormInstanceApprover : EntityBase, IIdentifiableEntity
    {
        public System.Guid Id { get; set; }
        public System.Guid FormInstanceId { get; set; }
        public string Role { get; set; }
        public int Order { get; set; }
        public int ApproverType { get; set; }
        public Nullable<System.Guid> SelectedUserId { get; set; }
        public System.DateTime AddedDateTime { get; set; }
        public Nullable<System.Guid> AddedBy { get; set; }
        public System.DateTime ActionDateTime { get; set; }
        public Nullable<System.Guid> ApprovedByUserId { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public string Reason { get; set; }
        public string Comments { get; set; }
        public Nullable<int> RejectionReason { get; set; }
        public bool ApprovalRequired { get; set; }
        public Nullable<int> ReminderCount { get; set; }
        public Nullable<System.DateTime> LastReminderDate { get; set; }
        public Nullable<bool> CanBeSelected { get; set; }
        public virtual FormInstance FormInstance { get; set; }

        public Guid EntityId
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        }
    }
}
