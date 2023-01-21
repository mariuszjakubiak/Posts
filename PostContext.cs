using Microsoft.EntityFrameworkCore;
using Posts.Models;

namespace Posts
{
    public class PostContext : DbContext
    {
        public DbSet<PostModel> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptions)
        {
            var cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PostsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            dbContextOptions.UseSqlServer(cs);
        }
    }
}
