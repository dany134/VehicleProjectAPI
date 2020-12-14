using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleProject.Repository.Common;
using VehicleProject.Repository;
using VehicleProject.DAL;
using VehicleProject.Models;
using VehicleProject.Service.Common;
using VehicleProject.Common;
using VehicleProject.Common.Extensions;
using VehicleProject.Models.Common;
namespace VehicleProject.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private IVehicleMakeRepository _vehicleRepository;
        private IUnitOfWork uow;
        

        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository, IUnitOfWork unitOfWork)
        {
            _vehicleRepository = vehicleMakeRepository;
            uow = unitOfWork;
        }

        public async Task<IEnumerable<IVehicleMake>> GetMakesForDropDown()
        {
            return await _vehicleRepository.GetMakesList();
        }
        public async Task<IEnumerable<IVehicleMake>> GetMakesList(Filtering filter, Paging page, Sorting sorting)
        {
            return await _vehicleRepository.GetAllMakes(filter, page, sorting);
        }
        public async Task<IVehicleMake> GetMakeById(int makeId)
        {
            IVehicleMake make = await _vehicleRepository.GetMakeById(makeId);
            return make;
        }
        public async Task<bool> InsertMake(VehicleMake make)
        {
            try
            {    
                await _vehicleRepository.AddMake(make);
                await uow.Save();
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
                
                await _vehicleRepository.DeleteMake(Id);
                await uow.Save();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public async Task<bool> UpdateMake(VehicleMake make)
        {
            try
            {
               await _vehicleRepository.UpdateMake(make);
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
