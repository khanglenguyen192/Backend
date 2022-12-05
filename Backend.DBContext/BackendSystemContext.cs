using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext
{
    public class BackendSystemContext : DbContext
    {
        public BackendSystemContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<User> User { get; set; }
    }
}
