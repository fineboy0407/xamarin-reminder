using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Extensions;

namespace ReminderXamarin.Models
{
    public class BirthdaysRepository
    {
        private readonly SQLiteConnection _db;

        public BirthdaysRepository(string dbPath)
        {
            _db = new SQLiteConnection(dbPath);
            _db.CreateTable<BirthdayModel>();
        }

        /// <summary>
        /// Get all birthdays from database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BirthdayModel> GetAll()
        {
            return _db.GetAllWithChildren<BirthdayModel>();
        }

        /// <summary>
        /// Get birthday from database by id.
        /// </summary>
        /// <param name="id">Id of the birthday</param>
        /// <returns></returns>
        public BirthdayModel GetBirthdayAsync(int id)
        {
            return _db.GetWithChildren<BirthdayModel>(id);
        }

        /// <summary>
        /// Create (if id = 0) or update BirthdayModel in database.
        /// </summary>
        /// <param name="model">BirthdayModel to be saved</param>
        /// <returns></returns>
        public void Save(BirthdayModel model)
        {
            if (model.Id != 0)
            {
                _db.InsertOrReplaceWithChildren(model);
            }
            else
            {
                _db.InsertWithChildren(model);
            }
        }

        /// <summary>
        /// Delete Birthday model from database.
        /// </summary>
        /// <param name="model">BirthdayModel to be deleted</param>
        /// <returns></returns>
        public int DeleteBirthday(BirthdayModel model)
        {
            return _db.Delete(model);
        }
    }
}