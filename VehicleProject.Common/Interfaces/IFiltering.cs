using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleProject.Common.Interfaces
{
    public interface IFiltering
    {
        string SearchString { get; set; }
        string FilterBy { get; set; }
        bool Filter();
    }
}
