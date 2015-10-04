using Core.Common.Data;
using SocietyMaster.Data.Contracts;
using SocietyMaster.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyMaster.Data
{
    [Export(typeof(ISocietyRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]

    public class SocietyRepository : DataRepositoryBase<Society>, ISocietyRepository
    {
        protected override Society AddEntity(SocietyMasterContext entityContext, Society entity)
        {
            return entityContext.SocietySet.Add(entity);
        }

        protected override Society GetEntity(SocietyMasterContext entityContext, Guid id)
        {

            return entityContext.SocietySet.Where(s => s.Id == id).FirstOrDefault();
        }

        //protected override Society UpdateEntity(SocietyMasterContext entityContext, Society entity)
        //{
        //    //ToDO: Just Testing
        //    entityContext.SocietySet.Add(entity);
        //    entityContext.Entry(entity).State = EntityState.Modified;
        //    //entityContext.Entry(entity.SocietyForms).State = EntityState.Unchanged;
               //    //entityContext.Entry(entity.ResidentSocietyMappings).State = EntityState.Unchanged;
        //    //entityContext.Entry(entity.ResidentSocietyRoleMappings).State = EntityState.Unchanged;
        //    //entityContext.Entry(entity.SocietyRolePrivileges).State = EntityState.Unchanged;
        //    //foreach (var building in entity.Buildings)
        //    //{
        //    //   // entityContext.Entry(building).State = EntityState.Unchanged;
        //    //    entityContext.Entry(building).State = Helpers.ConvertState(building.ObjectState);
        //    //}

        //    entity.Buildings.ToList().ForEach(b =>
        //    {
        //        entityContext.Entry(b).State = Helpers.ConvertState(b.ObjectState);
        //    });
        //    //ToDo:Similarly as above apply the same to all collections..Change below
        //    foreach(var house in entity.Houses)
        //    {
        //        entityContext.Entry(house).State = EntityState.Unchanged;
        //    }

        //    return entityContext.SocietySet.Where(s => s.Id == entity.Id).FirstOrDefault();
        //}

        protected override Society UpdateEntity(SocietyMasterContext entityContext, Society entity)
        {
            entityContext.SocietySet.Add(entity);
                // in case you want to modify any other properties of entity then do it here.
            return entity;
        }

        protected override IEnumerable<Society> GetEntities(SocietyMasterContext entityContext)
        {
            return entityContext.SocietySet;
        }

        public Society GetSocietyByCode(int societyCode)
        {
            using(SocietyMasterContext context = new SocietyMasterContext())
            {
                 // context.Database.Log = Logger;
                // To log the Sql query generated to the debug window
                context.Database.Log = (s => Debug.WriteLine(s));
                
                Society society= context.SocietySet.Where(s => s.Code == societyCode).FirstOrDefault();
                return society;
            }
        }

        private void Logger(string logString)
        {
            Debug.WriteLine(logString);
        }


        public Society GetCompleteSocietyDetails(int societyCode)
        {
            using (SocietyMasterContext context = new SocietyMasterContext())
            {
               context.Database.Log = (s => Debug.WriteLine(s));
               Society society = context.SocietySet
                                 .Include("Buildings").Include("Houses").Include("SocietyForms")
                                 .Include("ResidentSocietyMappings").Include("ResidentSocietyRoleMappings").Include("SocietyRolePrivileges")
                                 .Where(s => s.Code == societyCode).FirstOrDefault();
               return society;
            }
        }
    }

}
