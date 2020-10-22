using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleProject.Common.Interfaces;

namespace VehicleProject.Common.Extensions
{
    public class Paging : IPaging
    {
        public int PageSize { get; set; }
        public int? Page { get; set; }
        public int ItemsToSkip { get; set; }
        public int TotalItems { get; set; }

        public Paging(int? page)
        {
            PageSize = 5;
            Page = page;
            ItemsToSkip = PageSize * ((Page ?? 1) - 1);
        }
    }
}
