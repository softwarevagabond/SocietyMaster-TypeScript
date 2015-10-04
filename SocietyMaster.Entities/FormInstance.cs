using Core.Common.Contracts;
using Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Entities
{
    public partial class FormInstance : EntityBase, IIdentifiableEntity, IObjectWithState
    {
        public FormInstance()
        {
            this.FormInstanceApprovers = new List<FormInstanceApprover>();
            this.FormInstanceContents = new List<FormInstanceContent>();
        }

        public System.Guid Id { get; set; }
        public System.Guid FormId { get; set; }
        public System.Guid SocietyId { get; set; }
        public int FormTypeId { get; set; }
        public string Reference { get; set; }
        public System.Guid InputterId { get; set; }
        public int FormStatusId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime SubmittedDate { get; set; }
        public string Column0 { get; set; }
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }
        public string Column4 { get; set; }
        public string Column5 { get; set; }
        public Nullable<int> NextApproverOrder { get; set; }
        public virtual Form Form { get; set; }
        public virtual FormType FormType { get; set; }
        public virtual FormStatus FormStatus { get; set; }
        public virtual Society Society { get; set; }
        public virtual ICollection<FormInstanceApprover> FormInstanceApprovers { get; set; }
        public virtual ICollection<FormInstanceContent> FormInstanceContents { get; set; }

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
