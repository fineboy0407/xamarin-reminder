using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Reminder.Data.Abstract;
using Reminder.Data.Entities;

namespace Reminder.WebApi.Controllers
{
    [Authorize]
    public class NotesController : ApiController
    {
        private readonly INoteRepository _noteRepository;

        public NotesController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<IEnumerable<Note>> Get()
        {
            var userId = User.Identity.GetUserId();
            var allNotes = await _noteRepository.GetAllNotes(userId);

            foreach (var note in allNotes)
            {
                Parallel.ForEach(note.Photos, x => x.Note = null);
                Parallel.ForEach(note.Videos, x => x.Note = null);
            }

            return allNotes;
        }

        public async Task<Note> GetNote(int id)
        {
            var userId = User.Identity.GetUserId();
            var note = await _noteRepository.GetNote(userId, id);

            Parallel.ForEach(note.Photos, x => x.Note = null);
            Parallel.ForEach(note.Videos, x => x.Note = null);

            return note;
        }

        public async Task Post([FromBody] Note note)
        {
            var userId = User.Identity.GetUserId();
            note.UserId = userId;
            await _noteRepository.CreateNote(userId, note);
        }

        public async Task Put(int id, [FromBody] Note note)
        {
            var userId = User.Identity.GetUserId();
            note.UserId = userId;
            await _noteRepository.UpdateNote(userId, id, note);    
        }

        public async Task Delete(int noteId)
        {
            var userId = User.Identity.GetUserId();
            await _noteRepository.DeleteNote(userId, noteId);
        }
    }
}
