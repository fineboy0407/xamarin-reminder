using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reminder.Data.Core;
using Reminder.Data.Entities;

namespace Reminder.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/notes")]
    public class NoteController : Controller
    {
        private readonly IRepository<Note> _noteRepository;

        public NoteController(IRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        [HttpGet]
        public IEnumerable<Note> Get()
        {
            var allNotes = _noteRepository.GetAll().OrderByDescending(x => x.Id).ToList();
            return allNotes;
        }
    }
}