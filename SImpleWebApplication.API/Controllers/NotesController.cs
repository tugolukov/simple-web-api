using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SImpleWebApplication.API.Models;

namespace SImpleWebApplication.API.Controllers
{
    // CRUD
    // Create
    // Read
    // Update
    // Delete
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private List<Note> _notes;
        
        public NotesController(List<Note> notes)
        {
            _notes = notes;
        }

        [HttpGet]
        public List<Note> Get()
        {
            return _notes;
        }

        [HttpGet("{guid}")]
        public Note GetById([FromRoute] Guid guid)
        {
            return _notes.SingleOrDefault(a => a.Guid == guid);
        }
        
        [HttpGet("count")]
        public int GetCount()
        {
            return _notes.Count;
        }

        [HttpDelete("{guid}")]
        public int Delete([FromRoute] Guid guid)
        {
            var note = _notes.SingleOrDefault(a => a.Guid == guid);
            if (note != null)
            {
                _notes.Remove(note);
            }

            return _notes.Count;
        }

        [HttpPost]
        public int Create([FromBody] Note note)
        {
            _notes.Add(note);

            return _notes.Count;
        }

        [HttpPut]
        public int Update([FromBody] Note note)
        {
            var noteForUpdate = _notes.SingleOrDefault(a => a.Guid == note.Guid);
            if (noteForUpdate != null)
            {
                _notes.Remove(noteForUpdate);
                _notes.Add(note);
            }

            return _notes.Count;
        }
    }
}