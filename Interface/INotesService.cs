using CSC_NotesService.CustomModels;
using CSC_NotesService.Models;

namespace CSC_NotesService.Interface
{
    public interface INotesService
    {
        public Task<IEnumerable<Notes>> getNotesList();
        public Task<int> SaveNote(Notes NoteModel);
        public Task<int> DeleteNote(int NotesId);
    }
}
