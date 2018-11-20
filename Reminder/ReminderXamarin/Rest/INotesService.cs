using System.Collections.Generic;
using System.Threading.Tasks;
using ReminderXamarin.Rest.Models;

namespace ReminderXamarin.Rest
{
    /// <summary>
    /// Provide access to Notes CRUD API.
    /// </summary>
    public interface INotesService
    {
        /// <summary>
        /// Get all notes from Note API.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<NoteModel>> GetAllNotes();
    }
}