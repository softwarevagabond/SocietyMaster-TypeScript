using Core.Common.Contracts;
using SocietyMaster.Business.Contracts;
using SocietyMaster.Data.Contracts;
using SocietyMaster.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Business
{
    [Export(typeof(ISocietyEngine))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SocietyEngine:ISocietyEngine
    {
        [ImportingConstructor]
        public SocietyEngine(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        IDataRepositoryFactory _DataRepositoryFactory;
        public Society GetSocietyByCode(int societyCode)
        {
            //Check granular security whether should be able to perform action.
           ISocietyRepository societyRepository= _DataRepositoryFactory.GetDataRepository<ISocietyRepository>();
           return societyRepository.GetSocietyByCode(societyCode);
        }

        //ToDo: Similarly Add other methods.
    }
}
