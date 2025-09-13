using CSC_NotesService.Interface;
using CSC_NotesService.Models;
using Microsoft.EntityFrameworkCore;
namespace CSC_NotesService.Services
{
    public class NotesService : INotesService
    {
        private readonly NotesContext _context;

        public NotesService( NotesContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Notes>> getNotesList()
        {
            var response = await _context.Notes.Select(a => new Notes
            {
                NotesId = a.NotesId,
                Type = a.Type,
                Description = a.Description,
                Created = a.Created,
                enteredBy = a.enteredBy,
                isActive = a.isActive
            }).ToListAsync();
            return response;
        }

        /// <summary>
        /// get notes details by note id
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public Notes GetNoteDetailsById(int noteId)
        {
            Notes note;
            try
            {
                note = _context.Find<Notes>(noteId);
            }
            catch (Exception)
            {
                throw;
            }
            return note;
        }
        public async Task<int> SaveNote(Notes noteModel)
        {
            Notes _temp = GetNoteDetailsById(noteModel.NotesId);
            if (_temp != null)
            {
                _temp.Type = noteModel.Type;
                _temp.Description = noteModel.Description;
                _temp.Created = noteModel.Created;
                _temp.enteredBy = Convert.ToInt32("1");
                _temp.isActive = true;
            }
            else
            {
                //_context.Add<Notes>(noteModel);
                _context.Notes.Add(noteModel);
            }
            _context.SaveChanges();
            return 1;
        }


        public async Task<int> DeleteNote(int NotesId)
        {
            Notes _temp = GetNoteDetailsById(NotesId);
            if (_temp != null)
            {
                _context.Remove<Notes>(_temp);
                _context.SaveChanges();
            }
            return 1;
        }

    }
}
