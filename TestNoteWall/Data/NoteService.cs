using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TestNoteWall.Data
{
    public class NoteService
    {
        #region Property
        private readonly INoteContext _noteContext;
        #endregion

        #region Constructor
        public NoteService(INoteContext noteContext)
        {
            _noteContext = noteContext;
        }
        #endregion

        #region Add Note
        public IEnumerable<Note> AddNote(Note note)
        {
            _noteContext.Add(note);
            _noteContext.SaveChanges();
            return _noteContext.GetNoteAsNoTracking();
        }
        #endregion

        #region Get Notes
        public IEnumerable<Note> GetNotes()
        {
            return _noteContext.GetNoteAsNoTracking();
        }
        #endregion

        #region Update Note
        public IEnumerable<Note> UpdateNote(Note note)
        {
            _noteContext.Update(note);
            _noteContext.SaveChanges();
            return _noteContext.GetNoteAsNoTracking();
        }
        #endregion

        #region Delete Note
        public IEnumerable<Note> DeleteNote(Note note)
        {
            _noteContext.Remove(note);
            _noteContext.SaveChanges();
            return _noteContext.GetNoteAsNoTracking();
        }
        #endregion

        #region
        public IEnumerable<Note> SearchNote(string searchingParameter)
        {
           return _noteContext.Note.Where(a => a.NoteTitle.ToLower().Contains(searchingParameter.ToLower()) || a.NoteBody.ToLower().Contains(searchingParameter.ToLower()));
        }
        #endregion
    }
}
