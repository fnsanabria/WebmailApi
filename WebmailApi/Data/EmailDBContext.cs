using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Webmail.Core.Entities;

namespace WebmailApi.Data
{
    public class EmailDBContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Email> Emails { get; set; }



        //convencion para que los datos datetime sean todos de tipo date
        //protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        //{
        //    configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        //}




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionstring =
                "Data Source=.\\SRV_SQL;Initial Catalog=EmailDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            optionsBuilder.UseSqlServer(connectionstring);

        }
    }
}
