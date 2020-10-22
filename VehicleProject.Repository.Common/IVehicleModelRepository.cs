using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleProject.Models;
using VehicleProject.Common.Extensions;

namespace VehicleProject.Repository.Common
{
    public interface IVehicleModelRepository : IGenericRepository<VehicleModel>
    {
        Task<IEnumerable<VehicleModel>> GetAllModels(Filtering filter, Paging page);
        Task<VehicleModel> GetModelById(int id);
        Task<bool> AddModel(VehicleModel model);
        Task<bool> UpdateModel(VehicleModel model);
        Task<bool> DeleteModel(int Id);

    }
}
