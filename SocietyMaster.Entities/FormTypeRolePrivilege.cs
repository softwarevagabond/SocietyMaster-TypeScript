using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Entities
{
    public partial class FormTypeRolePrivilege : EntityBase, IIdentifiableEntity
    {
        public System.Guid Id { get; set; }
        public int FormTypeId { get; set; }
        public System.Guid RoleId { get; set; }
        public string Privileges { get; set; }
        public string RoleMailBox { get; set; }
        public virtual FormType FormType { get; set; }
        public virtual Role Role { get; set; }

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
