using System.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Admix.NetCore.Models;
using MySqlConnector;

namespace Admix.NetCore.Configuration
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        private string _connectionString { get; set; }
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
        }

        
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        
        public IDbConnection GetConnection()
        {
            return new MySqlConnection(GetConnectionString());
        }

        public void SetConnectionString(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public string GetConnectionString()
        {
            return this._connectionString;
        }
        
    }
}