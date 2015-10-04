using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Core
{
   public abstract class EntityBase
    {
       public static CompositionContainer Container { get; set; }
    }
}
