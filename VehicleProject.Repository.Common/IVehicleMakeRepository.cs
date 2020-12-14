using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleProject.Models;
using VehicleProject.Common;
using VehicleProject.Common.Extensions;
using VehicleProject.Models.Common;

namespace VehicleProject.Repository.Common
{
    public interface IVehicleMakeRepository : IGenericRepository<VehicleMake>
    {
        Task<IEnumerable<IVehicleMake>> GetMakesList();
        Task<IEnumerable<IVehicleMake>> GetAllMakes(Filtering filter, Paging page, Sorting sorting);
        Task<IVehicleMake> GetMakeById(int id);
        Task<bool> AddMake(IVehicleMake make);
        Task<bool> UpdateMake(IVehicleMake make);
        Task<bool> DeleteMake(int Id);
    }
}
