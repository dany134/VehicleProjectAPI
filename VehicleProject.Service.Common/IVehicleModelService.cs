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
    public interface IVehicleModelService
    {
        Task<IEnumerable<IVehicleModel>> GetModelsList(Filtering filter, Paging page, Sorting sorting);
        Task<IVehicleModel> GetModelById(int Id);
        Task<bool> DeleteModel(int Id);
        Task<bool> InsertModel(IVehicleModel model);
        Task<bool> UpdateModel(IVehicleModel model);
    }
}
