using CSC_NotesService.Interface;
using CSC_NotesService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSC_NotesService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _notesService;
        public NotesController(INotesService service)
        {
            _notesService = service;
        }

        /// <summary>
        /// get all notes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {
            try
            {
                var notes = await _notesService.getNotesList();
                if (notes == null) 
                    return NotFound("Not Found");
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// save notes
        /// </summary>
        /// <returns></returns>
        [HttpPost]
            public async Task<IActionResult> SaveNote([FromBody] Notes noteData)
        {
            try
            {
                var add = await _notesService.SaveNote(noteData);
                return Ok(add);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// save notes
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteNote(int noteId)
        {
            try
            {
                var delete = await _notesService.DeleteNote(noteId);
                return Ok(delete);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
