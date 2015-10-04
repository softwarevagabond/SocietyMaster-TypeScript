using Core.Common.Contracts;
using SocietyMaster.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Data.Contracts
{
    public interface ISocietyRepository:IDataRepository<Society>
    {
        Society GetSocietyByCode(int societyCode);
        Society GetCompleteSocietyDetails(int societyCode);

    }
}
