using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleProject.Common.Interfaces
{
    public interface IPaging
    {
        int? Page { get; set; }
        int ItemsToSkip { get; set; }
        int TotalItems { get; set; }
        int PageSize { get; set; }
    }
}
