using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Extensions;

namespace ReminderXamarin.Models
{
    public class NoteRepository
    {
        private readonly SQLiteConnection _db;

        public NoteRepository(string dbPath)
        {
            _db = new SQLiteConnection(dbPath);
            _db.CreateTable<Note>();
            _db.CreateTable<PhotoModel>();
            _db.CreateTable<VideoModel>();
        }

        /// <summary>
        /// Get all notes from database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Note> GetAll()
        {
            return _db.GetAllWithChildren<Note>();
        }

        /// <summary>
        /// Get note from database by id.
        /// </summary>
        /// <param name="id">Id of the note</param>
        /// <returns></returns>
        public Note GetNoteAsync(int id)
        {
            return _db.GetWithChildren<Note>(id);
        }

        /// <summary>
        /// Create (if id = 0) or update note in database.
        /// </summary>
        /// <param name="note">Note to be saved</param>
        /// <returns></returns>
        public void Save(Note note)
        {
            if (note.Id != 0)
            {
                _db.InsertOrReplaceWithChildren(note);
            }
            else
            {
                _db.InsertWithChildren(note);
            }
        }

        /// <summary>
        /// Delete note from database.
        /// </summary>
        /// <param name="note">Note to be deleted</param>
        /// <returns></returns>
        public int DeleteNote(Note note)
        {
            return _db.Delete(note);
        }
    }
}