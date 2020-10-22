using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleProject.Repository.Common
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> Get(int Id);
        Task<bool> Add(TEntity entity);
        Task<bool> Edit(TEntity entity);
        Task<bool> Delete(int id);
    }
}
