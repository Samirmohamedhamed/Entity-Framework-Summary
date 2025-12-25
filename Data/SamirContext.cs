
using EntityFrameWorkCodeFirst.Configurations;
using EntityFrameWorkCodeFirst.Models;//to use the Department class
using Microsoft.EntityFrameworkCore;//to use the DbContext and DbSet classes

namespace EntityFrameWorkCodeFirst.Data
{
    internal class SamirContext: DbContext//to represent the session with the database and can be used to query and save instances of your entities
    {
        public DbSet<Department> Departments { get; set; }//to represent the Departments table in the database
        public DbSet<Student> Students { get; set; }//to represent the Students table in the database
        public DbSet<Course> Courses { get; set; }//to represent the Courses table in the database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//to configure the database to be used

        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=SamirDBCodeFirst;Integrated Security=True;Encrypt=False");//connection string
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          // modelBuilder.ApplyConfiguration(new Configurations.DepartmentConfiguration());//to apply the configuration for the Department entity from the DepartmentConfiguration class. one  by one
          // modelBuilder.ApplyConfiguration(new Configurations.StudentConfiguration());//to apply the configuration for the Student entity from the StudentConfiguration class. one  by one
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfiguration).Assembly);//to apply all the configurations from the assembly where the StudentConfiguration class is located. all at once
            //fluent API way to configure the Student entity
            //modelBuilder.Entity<Student>(std =>
            //{
            //    std.HasKey(s => s.StudId);//to make the primary key defult is identity
            //    std.Property(s => s.StudId).ValueGeneratedNever();//to make the primary key not identity
            //   // std.Property(s => s.StudName).HasColumnName("StudentNameInDB");//to change the column name in the database
            //    std.Property(s => s.StudName).HasMaxLength(100).IsRequired(); //to set the maximum length of the string and make it not null
            //    std.Property(s => s.Age).IsRequired(false);//to make the column nullable[Optional]
            //});

            //fluent API way to configure the Course entity
            modelBuilder.Entity<Course>(crs =>
            {
                crs.HasKey(c => c.CrsId);//to make the primary key
                crs.Property(c => c.CrsId).ValueGeneratedNever();//to make the primary key not identity
                crs.Property(c => c.CrsName).HasMaxLength(20).IsRequired();//to set the maximum length of the string and make it not null
            });
            modelBuilder.Entity<StudentCourse>()
            .HasKey(sc => new { sc.StudentId, sc.CourseId });//to make the composite primary key
           // modelBuilder.Entity<Department>().HasMany(e => e.Courses).WithMany(e => e.Departments);// relation many to many 
            //modelBuilder.Entity<Student>(st =>
            //{
            //    st.HasOne(st => st.Department).WithMany(d => d.Students).HasForeignKey(st => st.DepartmentId);//to configure the one to many relationship between Student and Department
            //});
            base.OnModelCreating(modelBuilder);
        }
    }
}
