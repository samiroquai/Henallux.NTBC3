using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace LabAccConc{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<Customer> Customers { get; set; }
    }
}