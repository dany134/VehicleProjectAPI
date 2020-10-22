using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleProject.DAL;
using VehicleProject.Models;
using VehicleProject.Repository.Common;
using VehicleProject.Models.Common;
using VehicleProject.Common;
using VehicleProject.Common.Extensions;

namespace VehicleProject.Repository
{
    public class VehicleMakeRepository : GenericRepository<VehicleMake>, IVehicleMakeRepository
    {
       
        private IGenericRepository<VehicleMake> _genericRepository;


        public VehicleMakeRepository(VehicleContext context, IGenericRepository<VehicleMake> genericRepository) : base(context)
        {
           
            _genericRepository = genericRepository;

        }




        public async Task<IEnumerable<VehicleMake>> GetAllMakes(Filtering filters, Paging paging)
        {
            IQueryable<VehicleMake> makes =  _genericRepository.GetAll();
            if (filters.Filter())
            {
                makes = makes.Where(m => m.Name.Contains(filters.FilterBy) || m.Abrv.Contains(filters.FilterBy));
            }
            paging.TotalItems = makes.Count();
            
            return await makes.OrderBy(m => m.Name).Skip(paging.ItemsToSkip).Take(paging.PageSize).ToListAsync();
        }

        public async Task<VehicleMake> GetMakeById(int makeId)
        {
            VehicleMake make = await _genericRepository.Get(makeId);
            return make;
        }
        public async Task<bool> AddMake(VehicleMake make)
        {
            try
            {
                await _genericRepository.Add(make);
                return true;
            }catch
            {
                return false;
            }






        }
        public async Task<bool> UpdateMake(VehicleMake make)
        {
            try
            {
                await _genericRepository.Edit(make);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> DeleteMake(int Id)
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
    

