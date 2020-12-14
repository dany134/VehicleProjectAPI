using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleProject.Models;
using VehicleProject.Common.Extensions;
using VehicleProject.Models.Common;

namespace VehicleProject.Repository.Common
{
    public interface IVehicleModelRepository : IGenericRepository<VehicleModel>
    {
        Task<IEnumerable<IVehicleModel>> GetAllModels(Filtering filter, Paging page, Sorting sorting);
        Task<IVehicleModel> GetModelById(int id);
        Task<bool> AddModel(VehicleModel model);
        Task<bool> UpdateModel(VehicleModel model);
        Task<bool> DeleteModel(int Id);

    }
}
