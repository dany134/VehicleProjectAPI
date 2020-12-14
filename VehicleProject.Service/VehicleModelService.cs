using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleProject.Repository.Common;
using VehicleProject.Models;
using VehicleProject.Repository;
using VehicleProject.DAL;
using System.Runtime.InteropServices;
using VehicleProject.Service.Common;
using VehicleProject.Common.Extensions;
using VehicleProject.Models.Common;

namespace VehicleProject.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        private IVehicleModelRepository _modelRepository;
        private IUnitOfWork uow;
      
        public VehicleModelService(IVehicleModelRepository modelRepository, IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
            _modelRepository = modelRepository;
        }
        public async Task<IEnumerable<IVehicleModel>> GetModelsList(Filtering filter, Paging page, Sorting sorting)
        {
            return await _modelRepository.GetAllModels(filter, page, sorting);

        }
        public async Task<IVehicleModel> GetModelById(int Id)
        {
            return await _modelRepository.GetModelById(Id);
        }
        public async Task<bool> InsertModel(VehicleModel model)
        {
            try
            {
                //_modelRepository.AddModel(model);
                //await uow.Save();
                await _modelRepository.AddModel(model);
                await uow.Save();
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
                await _modelRepository.UpdateModel(model);
                await uow.Save();
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

                await _modelRepository.DeleteModel(Id);
                await uow.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
