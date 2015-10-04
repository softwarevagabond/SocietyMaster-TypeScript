using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Entities
{
    public partial class FormType : EntityBase
    {
        public FormType()
        {
            this.FormInstances = new List<FormInstance>();
            this.FormTypeRolePrivileges = new List<FormTypeRolePrivilege>();
            this.SocietyForms = new List<SocietyForm>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<FormInstance> FormInstances { get; set; }
        public virtual ICollection<FormTypeRolePrivilege> FormTypeRolePrivileges { get; set; }
        public virtual ICollection<SocietyForm> SocietyForms { get; set; }
    }
}
