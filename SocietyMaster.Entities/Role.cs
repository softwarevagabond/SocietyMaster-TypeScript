using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Entities
{
    public partial class Role : EntityBase, IIdentifiableEntity
    {
        public Role()
        {
           
            this.ResidentSocietyRoleMappings = new List<ResidentSocietyRoleMapping>();
            this.SocietyRolePrivileges = new List<SocietyRolePrivilege>();
        }

        public System.Guid Id { get; set; }
        public string RoleName { get; set; }
      
        public virtual ICollection<ResidentSocietyRoleMapping> ResidentSocietyRoleMappings { get; set; }
        public virtual ICollection<SocietyRolePrivilege> SocietyRolePrivileges { get; set; }

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
