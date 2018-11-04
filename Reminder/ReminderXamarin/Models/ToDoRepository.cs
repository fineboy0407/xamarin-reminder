using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Extensions;

namespace ReminderXamarin.Models
{
    public class ToDoRepository
    {
        private readonly SQLiteConnection _db;

        public ToDoRepository(string dbPath)
        {
            _db = new SQLiteConnection(dbPath);
            _db.CreateTable<ToDoModel>();
        }

        /// <summary>
        /// Get all models from database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ToDoModel> GetAll()
        {
            return _db.GetAllWithChildren<ToDoModel>();
        }

        /// <summary>
        /// Get ToDoModel from database by id.
        /// </summary>
        /// <param name="id">Id of the model</param>
        /// <returns></returns>
        public ToDoModel GetToDoAsync(int id)
        {
            return _db.GetWithChildren<ToDoModel>(id);
        }

        /// <summary>
        /// Create (if id = 0) or update model in database.
        /// </summary>
        /// <param name="model">Model to be saved</param>
        /// <returns></returns>
        public void Save(ToDoModel model)
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
        /// Delete model from database.
        /// </summary>
        /// <param name="model">Model to be deleted</param>
        /// <returns></returns>
        public int DeleteModel(ToDoModel model)
        {
            return _db.Delete(model);
        }
    }
}