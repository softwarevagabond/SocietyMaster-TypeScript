using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Entities
{
    public partial class House : EntityBase, IIdentifiableEntity, IObjectWithState
    {
        public House()
        {
            this.ResidentSocietyMappings = new List<ResidentSocietyMapping>();
        }

        public System.Guid Id { get; set; }
        public string HouseNumber { get; set; }
        public System.Guid SocietyId { get; set; }
        public System.Guid BuildingId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ResidentSocietyMapping> ResidentSocietyMappings { get; set; }
        public virtual Building Building { get; set; }
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
