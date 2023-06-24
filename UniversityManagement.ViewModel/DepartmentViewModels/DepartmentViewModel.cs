using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagement.Entities.Models;

namespace UniversityManagement.ViewModel.DepartmentViewModels
{
    public class DepartmentViewModel
    {
        public int DeparmentId { get; set; }
        public string? DeparmentName { get; set; }
        public string? Description { get; set; }
    }
}
