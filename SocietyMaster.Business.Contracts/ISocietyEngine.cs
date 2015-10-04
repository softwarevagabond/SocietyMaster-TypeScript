using Core.Common.Contracts;
using SocietyMaster.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Business.Contracts
{
    public interface ISocietyEngine:IBusinessEngine
    {
        Society GetSocietyByCode(int societyCode);
    }
}
