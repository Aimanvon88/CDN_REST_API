using Microsoft.EntityFrameworkCore;

namespace WEBAPI.Entities
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=myuser;password=mypass;database=mysql_api_test");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user_table");

                entity.Property(e => e.id).HasColumnType("int(11)");

                entity.Property(e => e.username)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.mail)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.phone)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.skill)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.hobby)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
