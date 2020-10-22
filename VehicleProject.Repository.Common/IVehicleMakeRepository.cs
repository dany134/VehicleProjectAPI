using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleProject.Models;
using VehicleProject.Common;
using VehicleProject.Common.Extensions;

namespace VehicleProject.Repository.Common
{
    public interface IVehicleMakeRepository : IGenericRepository<VehicleMake>
    {
        Task<IEnumerable<VehicleMake>> GetAllMakes(Filtering filter, Paging page);
        Task<VehicleMake> GetMakeById(int id);
        Task<bool> AddMake(VehicleMake make);
        Task<bool> UpdateMake(VehicleMake make);
        Task<bool> DeleteMake(int Id);
    }
}
