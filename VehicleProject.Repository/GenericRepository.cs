using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleProject.DAL;
using System.Data.Entity;
using VehicleProject.Repository.Common;
using System.Data.Entity.Infrastructure;

namespace VehicleProject.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly VehicleContext dbContext;
        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(VehicleContext context)
        {
            dbContext = context;
            this.dbSet = dbContext.Set<TEntity>();
        }

        public  IQueryable<TEntity> GetAll()
        {
            return dbSet;

        }

        public  async Task<TEntity> Get(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public  async Task<bool> Add(TEntity entity)
        {
            try
            {
               dbSet.Add(entity);

                return true;
            }
            catch
            {
                return false;
            }

        }

        public  async Task<bool> Edit(TEntity entity)
        {
            try
            {
                DbEntityEntry dbEntityEntry = dbContext.Entry(entity);
                if (dbEntityEntry.State == System.Data.Entity.EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbEntityEntry.State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch
            {
                return false;

            }


        }
        public  async Task<bool> Delete(int id)
        {
            try
            {
            TEntity entityToDelete = await dbSet.FindAsync(id);
            dbSet.Remove(entityToDelete);

                return true;
            }catch
            {
                return false;
            }


        }
    }
} 
