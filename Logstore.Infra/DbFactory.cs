using Logstore.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logstore.Infra
{
    public class DbFactory : IDesignTimeDbContextFactory<LogstoreDbContext>
    {
        public LogstoreDbContext CreateDbContext(string[] args)
        {
            var construtor = new DbContextOptionsBuilder<LogstoreDbContext>();
            construtor.UseSqlite("Data Source=LogstoreAPI.db");
            return new LogstoreDbContext(construtor.Options);
        }
    }
}
