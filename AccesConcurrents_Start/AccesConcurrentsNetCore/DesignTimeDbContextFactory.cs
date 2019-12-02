using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesConcurrentsNetCore
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CompanyContext>
    {
        public CompanyContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<CompanyContext> builder = new DbContextOptionsBuilder<CompanyContext>();
            builder.UseSqlServer("Server=localhost\\SQLEXPRESS;Initial Catalog=FakeDB;Integrated Security=true;");
            return new CompanyContext(builder.Options);
        }
    }
}
