using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleProject.Common.Extensions;
using VehicleProject.Models;

namespace VehicleProject.Service.Common
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<VehicleModel>> GetModelsList(Filtering filter, Paging page);
        Task<VehicleModel> GetModelById(int Id);
        Task<bool> DeleteModel(int Id);
        Task<bool> InsertModel(VehicleModel model);
        Task<bool> UpdateModel(VehicleModel model);
    }
}
