using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Entities
{
    public partial class ResidentFormTypeMapping : EntityBase, IIdentifiableEntity
    {
        public System.Guid Id { get; set; }
        public System.Guid ResidentId { get; set; }
        public System.Guid SocietyId { get; set; }
        public int FormTypeId { get; set; }
        public System.Guid RoleId { get; set; }
        public Nullable<bool> IsFormAdmin { get; set; }

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
