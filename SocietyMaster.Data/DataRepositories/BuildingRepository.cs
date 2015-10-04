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
    [Export(typeof(IBuildingRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]

   public class BuildingRepository: DataRepositoryBase<Building>,IBuildingRepository
    {
        protected override Building AddEntity(SocietyMasterContext entityContext, Building entity)
        {
           return entityContext.BuildingSet.Add(entity);
        }

        protected override Building GetEntity(SocietyMasterContext entityContext, Guid id)
        {
            return entityContext.BuildingSet.Where(b => b.Id == id).FirstOrDefault();
        }

        protected override Building UpdateEntity(SocietyMasterContext entityContext, Building entity)
        {
            return entityContext.BuildingSet.Where(b => b.Id == entity.Id).FirstOrDefault();
        }

        protected override IEnumerable<Building> GetEntities(SocietyMasterContext entityContext)
        {
            return entityContext.BuildingSet;
        }

        public Building GetBuildingByName(string name)
        {
            using(SocietyMasterContext context = new SocietyMasterContext())
            {
                return context.BuildingSet.Where(b => b.Name == name).FirstOrDefault();
            }
        }
    }
}
