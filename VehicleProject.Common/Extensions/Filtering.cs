using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleProject.Common.Interfaces;

namespace VehicleProject.Common.Extensions
{
    public class Filtering : IFiltering
    {
        public string SearchString { get; set; }
        public string FilterBy { get; set; }
        public Filtering(string searchString)
        {
            SearchString = searchString;
        }

        public bool Filter()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                FilterBy = SearchString;
                return true;
            }
            return false;
        }
    }
}
