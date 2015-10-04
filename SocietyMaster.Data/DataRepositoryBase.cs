using Core.Common.Contracts;
using Core.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Data
{
    public abstract class DataRepositoryBase<T> : DataRepositoryBase<T, SocietyMasterContext>
      where T : class,IIdentifiableEntity, new()
    {
    }
}
