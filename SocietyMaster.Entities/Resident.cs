using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Entities
{
    public partial class Resident : EntityBase, IIdentifiableEntity
    {
        public Resident()
        {
            this.ResidentSocietyMappings = new List<ResidentSocietyMapping>();
            this.ResidentSocietyRoleMappings = new List<ResidentSocietyRoleMapping>();
        }

        public System.Guid Id { get; set; }
        public int UserId { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserType { get; set; }
        public string ContactNumber { get; set; }
        public string AdditionalContactNumber { get; set; }
        public bool Disabled { get; set; }
        public Nullable<bool> IsSuperUser { get; set; }
        public byte[] Signature { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public virtual ICollection<ResidentSocietyMapping> ResidentSocietyMappings { get; set; }
        public virtual ICollection<ResidentSocietyRoleMapping> ResidentSocietyRoleMappings { get; set; }

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
