using Microsoft.AspNetCore.Mvc;
using PolicyNotes.Api.DTOs;
using PolicyNotes.Api.Models;
using PolicyNotes.Api.Services;

namespace PolicyNotes.Api.Controllers
{
    [ApiController]
    [Route("notes")]
    public class NotesController : ControllerBase
    {
        private readonly IPolicyNoteService _service;

        public NotesController(IPolicyNoteService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(NoteCreateDto dto)
        {
            var created = await _service.AddNoteAsync(dto.PolicyNumber, dto.Note);
            return Created($"/notes/{created.Id}", created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var note = await _service.GetByIdAsync(id);
            return note is null ? NotFound() : Ok(note);
        }
    }
}
