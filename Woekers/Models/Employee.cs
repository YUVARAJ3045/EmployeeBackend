using System.ComponentModel.DataAnnotations.Schema;
using Woekers.Models;

namespace Woekers.Models
{
    public class Employee
    {
        
        public int Id { get; set; }
        public int IdNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public int BasicSalary { get; set; }
        public string? Type { get; set; }
    }
}
C: \Users\YUVARAJ\source\repos\Woekers\Woekers\Models\Employee.cs