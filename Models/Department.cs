
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameWorkCodeFirst.Models
{
    //[Table("Departments")]//to change the table name in the database
    public class Department
    {
        //Convintional way to write primary key
        public int DepartmentId { get; set; }//if i  put  the name Id or ClassNameId it will be consider as primary key and Identity by default
                                             // public int Id { get; set; }//if i  put  the name Id or ClassNameId it will be consider as primary key and Identity by default

        //#region Data Annotations Way
        ////data annotations way to write primary key
        //[Key]//to make the primary key
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]//to make the primary key as identity
        //public int depaid { get; set; }//if i  put other name it will not be consider as primary key by default i have to use data annotations or fluent api to make it primary key
        //#endregion
        [Required]//to make the column not null
        [StringLength(50)]//to set the maximum length of the string
        public string? DepartmentName { get; set; }
        public int? Capacity { get; set; }


        //Relationship :  one Department has many Students
        public virtual List<Student>? Students { get; set; } = new List<Student>();//navigation property to represent the relationship between Department and Student
       public virtual List<Course> Courses { get; set; } = new List<Course>();//navigation property to represent the relationship between Department and Course

    }
}

