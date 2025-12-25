using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkCodeFirst.Models
{
    public class Course   
    {
        public int CrsId { get; set; }
        public string CrsName { get; set; }
        public int Duration { get;set; }
        public virtual List<Department> Departments { get; set; } = new List<Department>();//navigation property to represent the relationship between Course and Department
        public virtual List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();//navigation property to represent the relationship between Course and Student
    }
}
