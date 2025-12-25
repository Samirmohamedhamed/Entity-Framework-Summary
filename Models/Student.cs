using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkCodeFirst.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//to make the primary key not identity
        public int StudId { get; set; }
        [Column("StudentNameInDB")]//to change the column name in the database
        [StringLength(100)]
        public string? StudName { get; set; }
        public int? Age { get;set; }

        //Relationship: many Students belong to one Department
        [ForeignKey("Department")]//to specify the foreign key
        public int DepartmentId { get; set; }//foreign key
        public virtual Department? Department { get; set; }//navigation property to represent the relationship between Student and Department
        public virtual List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();//navigation property to represent the relationship between Student and Course

    }
}
