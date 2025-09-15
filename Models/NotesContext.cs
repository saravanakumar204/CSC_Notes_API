using CSC_NotesService.CustomModels;
using Microsoft.EntityFrameworkCore;

namespace CSC_NotesService.Models
{

    public class NotesContext : DbContext
    {
        public NotesContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Notes> Notes { get; set; }
        
    }
}
