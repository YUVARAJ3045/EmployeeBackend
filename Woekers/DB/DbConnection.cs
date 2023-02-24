using Microsoft.EntityFrameworkCore;
using Woekers.Models;

namespace Woekers.DB
{
    public class DbConnection:DbContext
    {
        public DbConnection(DbContextOptions<DbConnection> options) : base(options) { }
        public DbSet<Employee> EmployeesLD { get; set; }
    }
}
