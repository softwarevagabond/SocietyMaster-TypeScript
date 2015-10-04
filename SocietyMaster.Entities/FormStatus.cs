using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Entities
{
    public class FormStatus : EntityBase
    {
        public FormStatus()
        {
            this.FormInstances = new List<FormInstance>();
        }

        public int Id { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public virtual ICollection<FormInstance> FormInstances { get; set; }
    }
}
