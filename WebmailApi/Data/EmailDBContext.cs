using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Webmail.Core.Entities;

namespace WebmailApi.Data
{
    public class EmailDBContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionstring =
                "Data Source=PCH510M\\SRV_SQL;Initial Catalog=EmailDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            optionsBuilder.UseSqlServer(connectionstring);

        }
    }
}
