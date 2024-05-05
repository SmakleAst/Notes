using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Notes.Persistance.EntityTypeConfigurations;

namespace Notes.Persistance
{
    public class NotesDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
