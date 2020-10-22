using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using VehicleProject.DAL;
using VehicleProject.Models;
using VehicleProject.Repository.Common;
using VehicleProject.Common.Extensions;
namespace VehicleProject.Repository
{
    public class VehicleModelRepository : GenericRepository<VehicleModel>, IVehicleModelRepository
    {
        
        private IGenericRepository<VehicleModel> _genericRepository;
        public VehicleModelRepository(VehicleContext context, IGenericRepository<VehicleModel> genericRepository) : base(context)
        {
            _genericRepository = genericRepository;
         

        }
        public async Task<IEnumerable<VehicleModel>> GetAllModels(Filtering filter, Paging page)
        {
            IQueryable<VehicleModel> models = _genericRepository.GetAll();
            if (filter.Filter())
            {
                models = models.Where(m => m.Name.Contains(filter.FilterBy) || m.Abrv.Contains(filter.FilterBy));
            }
            page.TotalItems = models.Count();


            return await models.OrderBy(m => m.Name).Skip(page.ItemsToSkip).Take(page.PageSize).ToListAsync();
        }
        public async Task<VehicleModel> GetModelById(int makeId)
        {
            VehicleModel make = await _genericRepository.Get(makeId);
            return make;
        }
        public async Task<bool> AddModel(VehicleModel model)
        {
            try
            {
                await _genericRepository.Add(model);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public async Task<bool> UpdateModel(VehicleModel model)
        {
            try
            {
                await _genericRepository.Edit(model);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> DeleteModel(int Id)
        {
            try
            {
                await _genericRepository.Delete(Id);
                return true;
            }

            catch
            {
                return false;
            }

        }
    }
}
