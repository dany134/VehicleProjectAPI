using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleProject.Common.Extensions;
using VehicleProject.Models;
using VehicleProject.Models.Common;

namespace VehicleProject.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<IVehicleMake>> GetMakesForDropDown();
        Task<IEnumerable<IVehicleMake>> GetMakesList(Filtering filter, Paging page, Sorting sorting);
        Task<IVehicleMake> GetMakeById(int Id);
        Task<bool> DeleteMake(int Id);
        Task<bool> InsertMake(VehicleMake make);
        Task<bool> UpdateMake(VehicleMake make);
    }
}
