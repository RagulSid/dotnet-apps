using Microsoft.EntityFrameworkCore;

namespace EmployeeDetail.Models
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options): base(options)
        {}

        public DbSet<Employee> Employees { get; set;}

    }
}


//dB context is kind of string that connecting your db with the created entity 
//it has their own constructor property, we have to use them in required area
//db context says what we need in actual db after migration
//db set used to connecting Employee Model to db context
//dbcontext has Dependecy injection specified in program.cs


//DI?
//how that is a DI, we are creating a instance of EmployeeDbContext in program.cs
//we have the EmployeeDbContext class above which expects parameter of type dB contextOptions
//                  - which contains db connection string along with we are telling which type of database we are using in this application
//options -> parameter
//