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
using AutoMapper;

namespace VehicleProject.Repository
{
    public class VehicleMakeRepository : GenericRepository<VehicleMake>, IVehicleMakeRepository
    {
       
        private IGenericRepository<VehicleMake> _genericRepository;
        private readonly IMapper _mapper;

        public VehicleMakeRepository(VehicleContext context, IGenericRepository<VehicleMake> genericRepository, IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;

        }


        public async Task<IEnumerable<IVehicleMake>> GetMakesList()
        {
            IQueryable<VehicleMake> makes = _genericRepository.GetAll();
            return await makes.ToListAsync();
        }

        public async Task<IEnumerable<IVehicleMake>> GetAllMakes(Filtering filters, Paging paging, Sorting sorting)
        {
            IQueryable<IVehicleMake> makes =  _genericRepository.GetAll();
            
            if (filters.Filter())
            {
                makes = makes.Where(m => m.Name.Contains(filters.FilterBy) || m.Abrv.Contains(filters.FilterBy));
            }
            paging.TotalItems = makes.Count();
            switch (sorting.SortBy)
            {
                case "name_desc":
                    makes = makes.OrderByDescending(v => v.Name);
                    break;

                case "Abrv":
                    makes = makes.OrderBy(v => v.Abrv);
                    break;

                case "abrv_desc":
                    makes = makes.OrderByDescending(v => v.Abrv);
                    break;

                default:
                    makes = makes.OrderBy(v => v.Name);
                    break;
            }

            return await makes.Skip(paging.ItemsToSkip).Take(paging.PageSize).ToListAsync();
        }

        public async Task<IVehicleMake> GetMakeById(int makeId)
        {
            IVehicleMake make = await _genericRepository.Get(makeId);
            return make;
        }
        public async Task<bool> AddMake(IVehicleMake make)
        {
            try
            {
                VehicleMake eModel = _mapper.Map<VehicleMake>(make);
                await _genericRepository.Add(eModel);
                return true;
            }catch
            {
                return false;
            }


        }
        public async Task<bool> UpdateMake(IVehicleMake make)
        {
            try
            {
                VehicleMake eModel = _mapper.Map<VehicleMake>(make);
                await _genericRepository.Edit(eModel);
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
    

