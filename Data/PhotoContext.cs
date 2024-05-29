using net_il_mio_fotoalbum.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace net_il_mio_fotoalbum.Data
{
    public class PhotoContext : IdentityDbContext<IdentityUser>
    {


       
        public DbSet<PhotoModel> Photos { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<MessageModel> Messages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Initial Catalog=photoAlbum_db;");
        }


    }

}
