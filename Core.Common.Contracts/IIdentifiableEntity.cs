using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Contracts
{
    public interface IIdentifiableEntity
    {
        Guid EntityId { get; set; } //Determines which is the primary key in the entity 
    }
}
