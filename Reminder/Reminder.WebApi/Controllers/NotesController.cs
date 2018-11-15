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
        private readonly string _userId;

        public NotesController(INoteRepository noteRepository)
        {
            _userId = RequestContext.Principal.Identity.GetUserId();
            _noteRepository = noteRepository;
        }

        public async Task<IEnumerable<Note>> Get()
        {
            return await _noteRepository.GetAll(_userId);
        }

        public async Task<Note> GetNote(int id)
        {
            return await _noteRepository.Get(_userId, id);
        }

        public async Task Post([FromBody] Note note)
        {
            note.UserId = _userId;
            await _noteRepository.Create(_userId, note);
        }

        public async Task Put(int id, [FromBody] Note note)
        {
            note.UserId = _userId;
            await _noteRepository.Update(_userId, id, note);    
        }

        public async Task Delete(int noteId)
        {
            await _noteRepository.Delete(_userId, noteId);
        }
    }
}
