using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Entities
{
    public partial class FormInstanceContent : EntityBase, IIdentifiableEntity
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> FormInstanceId { get; set; }
        public string FormContent { get; set; }
        public string SubmittedBy { get; set; }
        public Nullable<System.DateTime> SubmittedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
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
