using SocietyMaster.Data.Contracts;
using SocietyMaster.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Data.DataRepositories
{
    [Export(typeof(IHouseRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]

   public class HouseRepository:DataRepositoryBase<House>,IHouseRepository
    {
        protected override House AddEntity(SocietyMasterContext entityContext, House entity)
        {
           return entityContext.HouseSet.Add(entity);
        }

        protected override House GetEntity(SocietyMasterContext entityContext, Guid id)
        {
            return entityContext.HouseSet.Where(h => h.Id == id).FirstOrDefault();
        }

        protected override House UpdateEntity(SocietyMasterContext entityContext, House entity)
        {
            return entityContext.HouseSet.Where(h => h.Id == entity.Id).FirstOrDefault();
        }

        protected override IEnumerable<House> GetEntities(SocietyMasterContext entityContext)
        {
            return entityContext.HouseSet;
        }

        public House GetHouseByNumber(string number)
        {
            using(SocietyMasterContext context = new SocietyMasterContext())
            {
                return context.HouseSet.Where(h => h.HouseNumber == number).FirstOrDefault();
            }
        }
    }
}
