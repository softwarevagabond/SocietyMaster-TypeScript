using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Entities
{
    public partial class Building : EntityBase, IIdentifiableEntity, IObjectWithState
    {
        public Building()
        {
            this.ResidentSocietyMappings = new List<ResidentSocietyMapping>();
            this.Houses = new List<House>();
        }

        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.Guid SocietyId { get; set; }
        public virtual ICollection<ResidentSocietyMapping> ResidentSocietyMappings { get; set; }
        public virtual Society Society { get; set; }
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
