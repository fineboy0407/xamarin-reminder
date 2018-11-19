using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Reminder.Data.Abstract;
using Reminder.Data.Entities;

namespace Reminder.Data.Concrete
{
    public class NoteRepository : INoteRepository, IDisposable
    {
        private readonly DbContext _dbContext;
        private bool _disposed;

        public NoteRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected IDbSet<Note> DbSet => _dbContext.Set<Note>();

        public async Task<IEnumerable<Note>> GetAllNotes(string userId)
        {
            return await DbSet.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Note> GetNote(string userId, int noteId)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == noteId);
        }

        public async Task<Note> CreateNote(string userId, Note note)
        {
            note.UserId = userId;
            var createdNote = DbSet.Add(note);
            await _dbContext.SaveChangesAsync();
            return createdNote;
        }

        public async Task<Note> UpdateNote(string userId, int noteId, Note note)
        {
            _dbContext.Entry(note).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return note;
        }

        public async Task<Note> DeleteNote(string userId, int noteId)
        {
            var noteToDelete = await DbSet.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == noteId);
            var deletedNote =  DbSet.Remove(noteToDelete);
            await _dbContext.SaveChangesAsync();
            return deletedNote;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
