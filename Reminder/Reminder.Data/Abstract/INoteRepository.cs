using System.Collections.Generic;
using System.Threading.Tasks;
using Reminder.Data.Entities;

namespace Reminder.Data.Abstract
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetAll(string userId);
        Task<Note> Get(string userId, int noteId);
        Task<Note> Create(string userId, Note note);
        Task<Note> Update(string userId, int noteId, Note note);
        Task<Note> Delete(string userId, int noteId);
    }
}