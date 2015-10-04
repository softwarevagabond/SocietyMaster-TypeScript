﻿using Core.Common.Contracts;
using Core.Common.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Data
{
    public abstract class DataRepositoryBase<T,U> : IDataRepository<T>
        where T : class,IIdentifiableEntity, new()
        where U : DbContext, new()

    {
        protected abstract T AddEntity(U entityContext, T entity);
        protected abstract T GetEntity(U entityContext, Guid id);
        protected abstract T UpdateEntity(U entityContext, T entity);
        protected abstract IEnumerable<T> GetEntities(U entityContext);

        public T Add(T entity)
        {
             using (U entityContext = new U())
             {
                 T addedEntity = AddEntity(entityContext, entity);
                 entityContext.SaveChanges();
                 return addedEntity;
             }
        }

        public void Remove(T entity)
        {
            using (U entityContext = new U())
            {
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public void Remove(Guid id)
        {
            using (U entityContext = new U())
            {
                T entity = GetEntity(entityContext, id);
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public T Update(T entity)
        {
            //using (U entityContext = new U())
            //{
            //    T existingEntity = UpdateEntity(entityContext, entity);
            //    SimpleMapper.PropertyMap(entity, existingEntity);
            //    entityContext.SaveChanges();
            //    return existingEntity;
            //}

            using (U entityContext = new U())
            {
                T existingEntity = UpdateEntity(entityContext, entity);
                entityContext.ApplyStateChanges();
                entityContext.SaveChanges();
                return existingEntity;
            }


            //using (U entityContext = new U())
            //{
               
            //    T existingEntity = UpdateEntity(entityContext, entity);
            //  //  SimpleMapper.PropertyMap(entity, existingEntity);
            //  //  entityContext.ApplyStateChanges();
            //    entityContext.SaveChanges();
            // //   return existingEntity;
            //    return entity;
            //}
        }

        public IEnumerable<T> Get()
        {
            using (U entityContext = new U())
            {
                return (GetEntities(entityContext)).ToArray().ToList();
            }
        }

        public T Get(Guid id)
        {
            using (U entityContext = new U())
            {
                return GetEntity(entityContext, id);
            }
        }
    }
}
