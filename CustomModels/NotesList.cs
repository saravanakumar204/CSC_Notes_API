namespace CSC_NotesService.CustomModels
{
    public class NotesList
    {
        public int NotesId { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public DateTime? Created { get; set; }
        public int enteredBy { get; set; }
        public bool? isActive { get; set; }
    }
}
