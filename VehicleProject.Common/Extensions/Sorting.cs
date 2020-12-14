using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleProject.Common.Interfaces;

namespace VehicleProject.Common.Extensions
{
    public class Sorting : ISorting
    {
        public string SortBy { get; set; }
        public string SortByName { get; set; }
        public string SortByAbrv { get; set; }
        public string SortById { get; set; }

        public Sorting(string sortBy)
        {
            SortBy = sortBy;
            SortByName = String.IsNullOrEmpty(sortBy) ? "name_desc" : "";
            SortByAbrv = sortBy == "abrv" ? "abrv_desc" : "abrv";
            SortById = sortBy == "makeId" ? "makeId_desc" : "makeId";
        }
    }
}
