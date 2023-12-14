using Microsoft.EntityFrameworkCore;
using VassaSpraket_TW.Data.Models;

namespace VassaSpraket_TW.Data
{

    public class VassaSpraket_TWDbContext : DbContext
    {
        public VassaSpraket_TWDbContext(DbContextOptions<VassaSpraket_TWDbContext> options)
            : base(options)
        {
           
        }

        public DbSet<Chapters>Chapter { get; set; }
        public DbSet<PageTemplate> PageTemplates { get; set; }
        public DbSet<LabelCanvasPos> LabelCanvas_Pos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Chapters>(x =>
            {
                x.HasKey(x => x.Id);
                x.ToTable("Chapters");
            });

            modelBuilder.Entity<PageTemplate>(x =>
            {
                x.HasKey(x => x.Id);
                x.ToTable("PageTemplate");

            });

            modelBuilder.Entity<LabelCanvasPos>(x =>
            {
                x.HasKey(x => x.Id);
                x.ToTable("LabelCanvasPos");
            });


        }
    }

}
