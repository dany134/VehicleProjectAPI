﻿using System;
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
using VehicleProject.Models.Common;
using AutoMapper;

namespace VehicleProject.Repository
{
    public class VehicleModelRepository : GenericRepository<VehicleModel>, IVehicleModelRepository
    {
        
        private IGenericRepository<VehicleModel> _genericRepository;
        private IMapper _mapper;
        public VehicleModelRepository(VehicleContext context, IGenericRepository<VehicleModel> genericRepository, IMapper mapper) : base(context)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
         

        }
        public async Task<IEnumerable<IVehicleModel>> GetAllModels(Filtering filter, Paging page, Sorting sorting)
        {
            IQueryable<VehicleModel> models = _genericRepository.GetAll();
            models = models.Include(m => m.VehicleMake);
            if (filter.Filter())
            {
                models = models.Where(m => m.Name.Contains(filter.FilterBy) || m.Abrv.Contains(filter.FilterBy) || m.VehicleMake.Name.Contains(filter.FilterBy));
            }
            page.TotalItems = models.Count();
            switch (sorting.SortBy)
            {
                case "name_desc":
                    models = models.OrderByDescending(v => v.Name);
                    break;

                case "Abrv":
                    models = models.OrderBy(v => v.Abrv);
                    break;

                case "abrv_desc":
                    models = models.OrderByDescending(v => v.Abrv);
                    break;

                default:
                    models = models.OrderBy(v => v.Name);
                    break;
            }

            return await models.Skip(page.ItemsToSkip).Take(page.PageSize).ToListAsync();
        }
        public async Task<IVehicleModel> GetModelById(int makeId)
        {
            VehicleModel make = await _genericRepository.Get(makeId);
            return make;
        }
        public async Task<bool> AddModel(IVehicleModel model)
        {
            try
            {
                VehicleModel eModel = _mapper.Map<VehicleModel>(model);
                await _genericRepository.Add(eModel);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public async Task<bool> UpdateModel(IVehicleModel model)
        {
            try
            {
                VehicleModel eModel = _mapper.Map<VehicleModel>(model);
                await _genericRepository.Edit(eModel);
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
