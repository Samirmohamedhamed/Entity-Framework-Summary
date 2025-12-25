using EntityFrameWorkCodeFirst.Data;
using EntityFrameWorkCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //*************************************************************/
            //
            //    I Hope This Help You
            //    I Hope You Get Benefit From It
            //    it's My Pleasure to Help You
            //
            //ادعي لي بالخير وبالتوفيق  وبصلاح الحال 
            // سمير محمد_حاسبات ومعلومات_جامعة الزقازيق 
            //My Linkendin Profile: https://www.linkedin.com/in/samir-mohamed-074896383
            //
            //*************************************************************/




            //***********************Entity Framework***********************
            // Entity Framework (EF) is an open-source object-relational mapper (ORM) framework for .NET applications developed by Microsoft.
            // It allows developers to work with databases using .NET objects, eliminating the need for most of the data-access code that developers usually need to write.
            // EF supports two main approaches for database development: Code First and Database First.
            //تقدر تعمل ماب للعلاقات الموجودة ف الكود الي جداول موجوده ف الداتا بيز والعكس صحيح
            // - map database => object in code
            //use linq to entities to query and manipulate data
            //Trace changes made to objects and persist those changes to the database
            //***************************************************************
            //***********************DBContext Class***********************\
            // The DbContext class is the primary class that is responsible for interacting with the database in Entity Framework.
            // It acts as a bridge between the domain or entity classes and the database.
            // It is responsible for managing the database connections, tracking changes made to the entities, and persisting those changes to the database.
            //من خلاله بقدر افتح شسيشن مع الداتا بيز وانني ادير عمليات ال CRUD
            //or each entity in the model, the DbContext class contains a DbSet<T> property that represents a collection of entities of that type.
            // has two function:
            //OnConfiguring: to configure the database connection and other options
            //OnModelCreating: to configure the model and relationships between entities
            //***************************************************************
            //***************To Configuration We Can USe Two Ways:****************
            //1- Data Annotations : by using attributes in the model classes
            //2- Fluent API : by using the ModelBuilder class in the OnModelCreating method of the DbContext class Or by using IEntityTypeConfiguration<T> interface in separate configuration classes
            //*****************************************************************
            //first i write the Department class in the Models folder   
            //then i write the SamirContext class in the Data folder
            //then i open the Package Manager Console and run the following commands:
            //1- Add-Migration InitialCreate
            //2- Update-Database
            //this will create the database and the Departments table in the database
            //now i can use the SamirContext class to perform CRUD operations on the Departments table
            //i add a column Capacity to the Department class
            //i make the DepartmentName column not null and set its maximum length to 50
            //then i run the following commands in the Package Manager Console:
            //1- Add-Migration AddCapacityAndModifyDepartmentName
            //2- Update-Database
            //this will update the Departments table in the database
            //now i will add the Student class in the Models folder
            //then i will add the DbSet<Student> property to the SamirContext class
            //then i will configure the Student entity using data annotations
            //then i will run the following commands in the Package Manager Console:
            //1- Add-Migration AddStudentEntity
            //2- Update-Database
            //this will create the Students table in the database
            //now i can use the SamirContext class to perform CRUD operations on the Students table
            //now i will add the Course class in the Models folder
            //then i will configure the Course entity using fluent API in the OnModelCreating method of the SamirContext class
            //then i will run the following commands in the Package Manager Console:
            //1- Add-Migration AddCourseEntity
            //2- Update-Database
            //this will create the Courses table in the database
            //now i can use the SamirContext class to perform CRUD operations on the Courses table
            //now i wrtie the relationship between Student and Department one department has many students and many students belong to one department
            //then i will run the following commands in the Package Manager Console:
            //1- Add-Migration AddStudentDepartmentRelationship
            //2- Update-Database
            //this will update the Students table in the database to add the foreign key column DepartmentId
            //now i write the many to many relationship between Department and Course
            //then i will run the following commands in the Package Manager Console:
            //1- Add-Migration AddDepartmentCourseRelationship
            //2- Update-Database
            //this will create the junction table DepartmentCourse in the database
            //now i can use the SamirContext class to perform CRUD operations on the Departments, Students, and Courses tables
            //now i write the many to many relationship between Student and Course using the StudentCourse junction class
            //then i will run the following commands in the Package Manager Console:
            //1- Add-Migration AddStudentCourseRelationship
            //2- Update-Database
            //this will create the StudentCourses table in the database
            using (SamirContext context = new SamirContext())//to create an instance of the SamirContext class
            {

                var res1 = context.Departments.ToList();//to get all the departments from the Departments table
                foreach (var dept in res1)
                {
                    Console.WriteLine($"DepartmentId: {dept.DepartmentId}, DepartmentName: {dept.DepartmentName}, Capacity: {dept.Capacity}");
                }


            }
            //why i use the using statement?
            //the using statement is used to ensure that the Dispose method is called on the SamirContext object when it is no longer needed. it like a try-finally block
            SamirContext samirContext = new SamirContext();
            var res = samirContext.Students.ToList();
            //foreach (var student in res)
            //{
            //    Console.WriteLine($"StudId: {student.StudId}, StudName: {student.StudName}, Age: {student.Age}");
            //}
            samirContext.Dispose();//to release the resources used by the SamirContext object

           


            //Add Student in Department
            var std1 = new Student()
            {
                StudId = 2,
                StudName = "Samir2",
                Age = 25,
                DepartmentId = 2 //Assuming department with ID 1 exists


            };
            SamirContext samirContext1 = new SamirContext();
            var dept1 = samirContext1.Departments.FirstOrDefault(e => e.DepartmentId == 2);
          //  dept1.Students.Add(std1);// to add the student to the department's student list
            samirContext1.SaveChanges();
            var rees = samirContext1.Students.ToList();
            //foreach (var stu in rees)
            //{
            //    Console.WriteLine($"{stu.StudName}");
            //}
            samirContext1.Dispose();
            //****************Tracking*************************
            SamirContext samirContext2 = new SamirContext();
          var std5 =  samirContext2.Students.FirstOrDefault(s => s.StudId == 1);//EF Trace the std in database
            Console.WriteLine(samirContext2.Entry(std5).State);//Unchanged
            var std6 = samirContext2.Students.AsNoTracking().FirstOrDefault(e => e.StudId == 2);//EF didnt Trace
            Console.WriteLine(samirContext2.Entry(std6).State);//Detached

            //if i want ef didnt track all object USe UseQueryTrackingBrhavior in DbContext
            //*************************************************
            //*************************When i write query where evaluation happend? inServer OR Client*********************
            var res5 = samirContext2.Students.Select(e => new { Name = e.StudName + ": " + e.Age });//evalution happen in Server
            foreach (var item in res5)
            {
                Console.WriteLine(item);
            }
            //Function
            var res6 = samirContext2.Students.Select(e => new {Name = MyFun(e.StudName,"anyThing")});//evalution happen in Client
           // var res7 = samirContext2.Students.Where(a => MyFun(a.StudName, a.StudName).Contains("a"));//Error Will Happen becouse MyFun InClient
            var res8 = samirContext2.Students.ToList().Where(a => MyFun(a.StudName, a.StudName).Contains("a"));//return data first and write where
            //The best  make evalution happen in Server

            ///****************RelatedData(Navigation Property)****************
            //when i return student data and student have a prop Departmen is deparment data also return with it?
            var res11 = samirContext2 .Students.FirstOrDefault(e => e.StudId == 1);
            Console.WriteLine(res11.StudName);
           // Console.WriteLine(res11.Department.DepartmentName);//Null Reference Exception Will Happen becouse EF didnt load department data
            var res12 = samirContext2.Students.Select(a => new { StudId = a.StudId,Name =a.StudName,deptName=a.Department.DepartmentName}).FirstOrDefault(e => e.StudId == 1);
            Console.WriteLine(res12.Name);
            Console.WriteLine(res12.deptName);
            var res15 = samirContext2.Students.Include(e => e.Department).FirstOrDefault(e => e.StudId == 1);//Eager Loading : will return student data and department data also. Join Happen in query
            Console.WriteLine(res15.StudName);
            Console.WriteLine(res15.Department.DepartmentName);
            var res16 = samirContext2.Students
                .Include(e => e.Department)
                .ThenInclude(e=>e.Courses)//Eager Loading : will return student data and department data and Courses data. Join Happen in query
                .FirstOrDefault(e => e.StudId == 1);

            //*************************************************************************
            //What is the difference between Eager Loading and Lazy Loading and Explicit Loading?
            //******First Eager Loading: load related data as part of the initial query using Include and ThenInclude methods.بروح الداتا بيز مرة واحدة و بجيب كل الداتا اللي انا محتاجها

            SamirContext EgarContext = new SamirContext();//
            var egarRes = EgarContext.Students
                .Include(e => e.Department)
                .ThenInclude(e => e.Courses)
                .FirstOrDefault(e => e.StudId == 1);
            //***sexond Explicit Loading: load related data on demand using the Load method.بجيب الداتا الاساسية الاول و بعدين لما احتاج الداتا التانية بروح للداتا بيز تاني
            SamirContext ExplicitContext = new SamirContext();
            var explicitRes = ExplicitContext.Students.FirstOrDefault(e => e.StudId == 1);
            Console.WriteLine(explicitRes.StudName);
            ExplicitContext.Entry(explicitRes).Reference(e => e.Department).Load();//to load the related department data
            Console.WriteLine(explicitRes.Department.DepartmentName);
            //***Third Lazy Loading: load related data automatically when the navigation property is accessed.بجيب الداتا الاساسية الاول و لما ابص على الداتا التانية بروح للداتا بيز تاني و بجيبها
            SamirContext LazyContext = new SamirContext();
            var lazyRes = LazyContext.Students.FirstOrDefault(e => e.StudId == 1);
            Console.WriteLine(lazyRes.StudName);
            Console.WriteLine(lazyRes.Department.DepartmentName);//when i access the Department property, EF will automatically load the related department data
            //In Lazy Loading , the navigation properties must be virtual so that EF can create a proxy class that overrides the navigation properties and implements the lazy loading behavior.
            //Install-Package Microsoft.EntityFrameworkCore.Proxies
            //Go To DBContext and use UseLazyLoadingProxies method
            //***********************************************************************
            //In Explicit Loading if i want to load a collection navigation property use Collection method
            //Collection data like list of students in department
            SamirContext ExplicitContext2 = new SamirContext();
            var explicitRes2 = ExplicitContext2.Departments.FirstOrDefault(e => e.DepartmentId == 1);
            Console.WriteLine(explicitRes2.DepartmentName);
            ExplicitContext2.Entry(explicitRes2).Collection(e => e.Students).Load();//to load the related students data
            foreach (var stu in explicitRes2.Students)
            {
                Console.WriteLine(stu.StudName);
            }
            //In Explict Loading if i want to return Object or Navigation Property use Reference Method
            SamirContext ExplicitContext3 = new SamirContext();
            var explicitRes3 = ExplicitContext3.Students.FirstOrDefault(e => e.StudId == 1);
            Console.WriteLine(explicitRes3.StudName);
            ExplicitContext3.Entry(explicitRes3).Reference(e => e.Department).Load();//to load the related department
                                                                                     //
            Console.WriteLine(explicitRes3.Department.DepartmentName);
            //***********************************************************************
            //If I Write A lot OF Class And I want to configure them all without writing code for each one
            //I can use ModelBuilder.ApplyConfigurationsFromAssembly method in OnModelCreating method in DbContext 
            //this method will scan the assembly for all classes that implement IEntityTypeConfiguration<T> interface and apply the configurations automatically
            //First I Create A Folder Named Configurations
            //Then I Create A Class Named StudentConfiguration in the Configurations Folder and DepartmentConfiguration for Department Class
            //then I Implement IEntityTypeConfiguration<Student> interface in the StudentConfiguration class
            //then I Override the Configure method to configure the Student entity
            //then I use ModelBuilder.ApplyConfigurationsFromAssembly method in OnModelCreating method in SamirContext class
            //Now EF will apply the configurations for the Student entity from the StudentConfiguration class automatically
            //***********************************************************************
            //if i want to return all data about student 
            SamirContext samirContext3 = new SamirContext();
            var res55 = samirContext3.Students.FromSqlRaw($"SELECT * FROM Students").ToList();//to execute a raw SQL query and return all students data
            //if i want to return specific data about student
            //first i create a class to hold the specific data Like StudentView
            var res56 = samirContext3.Database.SqlQuery<StudentView>($"SELECT StudId, StudName FROM Students").ToList();//to execute a raw SQL query and return specific students data
            //If I want to execute stored procedure
            var res57 = samirContext3.Students.FromSqlRaw($"EXEC GetAllStudents").ToList();//to execute a stored procedure and return all students data


            //*************************************************************
            //***************PMC Comands:****************
            //Add-Migration :  To Add a new migration
            //Update-Database : To apply the pending migrations to the database
            //Remove-Migration : To remove the last migration
            //Get-Migrations : To get the list of all migrations
            //*************************************************************



    



        }
        static string MyFun(string s1,string s2)
        {
            return s1 + ":"+ s2;
        }
    }
}
