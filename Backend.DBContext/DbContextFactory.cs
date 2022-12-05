using Backend.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext
{
    public class DbContextFactory : IDbContextFactory
    {
        public DbContextFactory()
        {
        }

        public BackendSystemContext CreateDbContext()
        {
            return CreateDbContext(null);
        }

        public BackendSystemContext CreateDbContext(string[] args)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

            var optionsBuilder = new DbContextOptionsBuilder<BackendSystemContext>();

            optionsBuilder.UseMySql(DataConstants.IdentitySettings.DefaultConnection, serverVersion);

            var builder = new BackendSystemContext(optionsBuilder.Options);

            return builder;
        }
    }
}
