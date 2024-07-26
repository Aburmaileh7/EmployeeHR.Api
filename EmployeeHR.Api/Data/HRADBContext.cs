using EmployeeHR.Api.Models;
using Microsoft.EntityFrameworkCore;


namespace EmployeeHR.Api.Data
{
    public class HRADBContext : DbContext
    {
        public HRADBContext(DbContextOptions<HRADBContext>options):base(options) { }

        public DbSet<Department> Departments { get; set; }

    }
}
