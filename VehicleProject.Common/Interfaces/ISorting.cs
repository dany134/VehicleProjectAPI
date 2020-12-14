using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleProject.Common.Interfaces
{
    public interface ISorting
    {
        string SortBy { get; set; }
        string SortByName { get; set; }
        string SortByAbrv { get; set; }
        string SortById { get; set; }
    }
}
