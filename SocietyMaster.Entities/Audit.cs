using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Entities
{
    public partial class Audit : EntityBase, IIdentifiableEntity
    {
        public System.Guid Id { get; set; }
       //ToDo: Add SocietyId - Update Table Later
        public string UserId { get; set; }
        public Nullable<int> AuditEventType { get; set; }
        public string AuditDetails { get; set; }

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
