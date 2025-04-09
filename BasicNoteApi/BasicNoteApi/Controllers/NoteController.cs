using Microsoft.AspNetCore.Mvc;
using BasicNoteApi.Data;
using BasicNoteApi.Models;

namespace BasicNoteApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NoteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public IActionResult GetNotes(int userId)
        {
            var notes = _context.Notes.Where(n => n.UserId == userId).ToList();
            return Ok(notes);
        }

        [HttpPost]
        public IActionResult AddNote(Note note)
        {
            note.CreatedAt = DateTime.Now;
            _context.Notes.Add(note);
            _context.SaveChanges();
            return Ok(note);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            var note = _context.Notes.Find(id);
            if (note == null) return NotFound();

            _context.Notes.Remove(note);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateNote(int id, Note updatedNote)
        {
            var note = _context.Notes.Find(id);
            if (note == null) return NotFound();

            note.Content = updatedNote.Content;
            note.CreatedAt = DateTime.Now;
            _context.SaveChanges();

            return Ok(note);
        }
    }
}
