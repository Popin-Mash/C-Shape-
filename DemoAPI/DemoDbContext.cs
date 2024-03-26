using DemoAPI.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI
{
    public class DemoDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder opt)
        {
            opt.UseOracle("User Id=sale_user; Password=mypassword; Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1522))(CONNECT_DATA=(SERVER=dedicated)(SID=xe)))");
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; } 
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeEduction> EmployeeEductions { get; set; }
        public DbSet<EmployeeExperience> EmployeeExperiences { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
