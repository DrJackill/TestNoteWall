using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace TestNoteWall.Data
{
    public class NoteContext : DbContext, INoteContext
    {       
        public NoteContext(DbContextOptions<NoteContext> options) : base(options)
        {
        }

        public DbSet<Note> Note { get; set; }

        public IEnumerable<Note> GetNoteAsNoTracking()
        {
            return Note.AsNoTracking().ToList();
        }

    }
}
