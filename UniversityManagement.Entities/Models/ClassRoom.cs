﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagement.Entities.Models
{
    public class ClassRoom
    {
        [Key]
        public int IdClassRoom { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Subject_Classroom>? Subject_Classrooms { get; set; }
    }
}