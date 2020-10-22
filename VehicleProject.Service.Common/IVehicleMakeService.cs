using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleProject.Common.Extensions;
using VehicleProject.Models;

namespace VehicleProject.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<VehicleMake>> GetMakesList(Filtering filter, Paging page);
        Task<VehicleMake> GetMakeById(int Id);
        Task<bool> DeleteMake(int Id);
        Task<bool> InsertMake(VehicleMake make);
        Task<bool> UpdateMake(VehicleMake make);
    }
}
