using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Reminder.Data.Abstract;
using Reminder.Data.Entities;

namespace Reminder.WebApi.Controllers
{
    public class NotesController : ApiController
    {
        private readonly IRepository<Note> _noteRepository;

        public NotesController(IRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public IEnumerable<Note> Get()
        {
            return _noteRepository.GetAll().ToList();
        }

        public async Task<Note> GetNote(int id)
        {
            return await _noteRepository.GetByIdAsync(id);
        }

        public async Task Post([FromBody] Note note)
        {
            await _noteRepository.CreateAsync(note);
        }

        public async Task Put(int id, [FromBody] Note note)
        {
            await _noteRepository.UpdateAsync(note);
        }

        public async Task Delete(int id)
        {
            await _noteRepository.DeleteAsync(id);
        }
    }
}
