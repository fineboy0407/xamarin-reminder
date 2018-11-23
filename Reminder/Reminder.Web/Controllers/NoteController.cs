using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reminder.Data.Core;
using Reminder.Data.Entities;

namespace Reminder.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/notes")]
    public class NoteController : Controller
    {
        private readonly IRepository<Note> _repository;

        public NoteController(IRepository<Note> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Note> Get()
        {
            var allNotes = _repository.GetAll().OrderByDescending(x => x.Id).ToList();
            Parallel.ForEach(allNotes, note =>
            {
                Parallel.ForEach(note.Photos, x => x.Note = null);
                Parallel.ForEach(note.Videos, x => x.Note = null);
            });
            return allNotes;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var note = await _repository.GetByIdAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            Parallel.ForEach(note.Photos, photo => { photo.Note = null; });
            return Ok(note);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Note note)
        {
            if (ModelState.IsValid)
            {
                Parallel.ForEach(note.Photos, photo => { photo.Note = note; });

                var userId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
                note.UserId = userId;
                _repository.Create(note);
                await _repository.SaveAsync();

                Parallel.ForEach(note.Photos, photo => { photo.Note = null; });
                return Ok(note);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Note note)
        {
            if (note == null)
            {
                return BadRequest();
            }
            _repository.Update(note);
            await _repository.SaveAsync();
            return Ok(note);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            await _repository.SaveAsync();

            Parallel.ForEach(result.Photos, x => x.Note = null);
            Parallel.ForEach(result.Videos, x => x.Note = null);
            return Ok(result);
        }
    }
}