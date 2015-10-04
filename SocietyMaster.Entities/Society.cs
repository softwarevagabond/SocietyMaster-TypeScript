using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Entities
{
    public partial class Society : EntityBase, IIdentifiableEntity, IObjectWithState
    {
        public Society()
        {
           
            this.ResidentSocietyMappings = new List<ResidentSocietyMapping>();
            this.ResidentSocietyRoleMappings = new List<ResidentSocietyRoleMapping>();
            this.SocietyRolePrivileges = new List<SocietyRolePrivilege>();
            this.Buildings = new List<Building>();
            this.Houses = new List<House>();
        }

        public System.Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Locality { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public bool Disabled { get; set; }
       
        public virtual ICollection<ResidentSocietyMapping> ResidentSocietyMappings { get; set; }
        public virtual ICollection<ResidentSocietyRoleMapping> ResidentSocietyRoleMappings { get; set; }
        public virtual ICollection<SocietyRolePrivilege> SocietyRolePrivileges { get; set; }
        public virtual List<Building> Buildings { get; set; }
        public virtual ICollection<House> Houses { get; set; }

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
