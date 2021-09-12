using System.ComponentModel.DataAnnotations;


namespace TestNoteWall.Data
{
    public class Note
    {
        public Note() { }
        public Note(string NoteTitle, string NoteBody)
        {            
            this.NoteTitle = NoteTitle;
            this.NoteBody = NoteBody;
        }
        [Key]
        public int id { get; set; }

        [Required]            
        public string NoteTitle { get; set; }

        [Required]        
        public string NoteBody { get; set; }
    }
}
