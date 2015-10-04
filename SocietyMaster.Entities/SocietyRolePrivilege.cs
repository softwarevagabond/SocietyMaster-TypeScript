using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Entities
{
    public partial class SocietyRolePrivilege : EntityBase, IIdentifiableEntity, IObjectWithState
    {
        public System.Guid Id { get; set; }
        public System.Guid SocietyId { get; set; }
        public System.Guid RoleId { get; set; }
        public string Privileges { get; set; }
        public virtual Role Role { get; set; }
        public virtual Society Society { get; set; }

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

        public ObjectState ObjectState
        {
            get;
            set;
        }
    }
}
