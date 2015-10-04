using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Entities
{
    public partial class Form : EntityBase, IIdentifiableEntity
    {
        public Form()
        {
            this.FormInstances = new List<FormInstance>();
        }

        public System.Guid Id { get; set; }
        public int FormType { get; set; }
        public Nullable<int> ApprovalLevel { get; set; }
        public Nullable<int> NumberOfApprovalLevels { get; set; }
        public string Heading { get; set; }
        public virtual ICollection<FormInstance> FormInstances { get; set; }

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
