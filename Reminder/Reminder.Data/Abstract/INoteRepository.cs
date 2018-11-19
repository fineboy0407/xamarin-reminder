using System.Collections.Generic;
using System.Threading.Tasks;
using Reminder.Data.Entities;

namespace Reminder.Data.Abstract
{
    public interface INoteRepository
    {
        /// <summary>
        /// Get all notes by user id.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <returns></returns>
        Task<IEnumerable<Note>> GetAllNotes(string userId);

        /// <summary>
        /// Get single note which belong to user.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <param name="noteId">Note Id.</param>
        /// <returns></returns>
        Task<Note> GetNote(string userId, int noteId);

        /// <summary>
        /// Create note for user.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <param name="note">Note to be created.</param>
        /// <returns></returns>
        Task<Note> CreateNote(string userId, Note note);

        /// <summary>
        /// Update user's note by its id.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <param name="noteId">Note Id.</param>
        /// <param name="note">Note to be saved insted of old.</param>
        /// <returns></returns>
        Task<Note> UpdateNote(string userId, int noteId, Note note);

        /// <summary>
        /// Delete user's note by id.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <param name="noteId">Note Id.</param>
        /// <returns></returns>
        Task<Note> DeleteNote(string userId, int noteId);
    }
}