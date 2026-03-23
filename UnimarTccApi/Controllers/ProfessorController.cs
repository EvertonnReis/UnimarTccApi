using Microsoft.AspNetCore.Mvc;
using UnimarTcc.Application.Services;
using UnimarTcc.Domain.Entities;

namespace UnimarTcc.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly ProfessorService _service;

        public ProfessorController(ProfessorService service)
        {
            _service = service;
        }

        [HttpGet("buscar-todos-professores")]
        public async Task<IActionResult> GetAll()
        {
            var professores = await _service.GetAllAsync();
            return Ok(professores);
        }

        [HttpGet("buscar-por-id")]
        public async Task<IActionResult> GetById(string id) 
        {
            var professor = await _service.GetByIdAsync(id);
            return Ok(professor);
        }

        [HttpPut("editar-professor")]
        public async Task<IActionResult> Update(string id, Professor professor)
        {
            var professorObj = new Professor
            {
                Nome = professor.Nome,
                Disciplina = professor.Disciplina,
                Email = professor.Email,
                Ativo = professor.Ativo
            };

            await _service.UpdateAsync(id, professorObj);

            return Ok(professorObj);
        }

        [HttpDelete("deletar-professor")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProfessorCreateDto dto)
        {
            var professor = new Professor
            {
                Nome = dto.Nome,
                Disciplina = dto.Disciplina,
                Email = dto.Email,
                Ativo = dto.Ativo
            };

            await _service.CreateAsync(professor);

            return Ok(professor);
        }

        [HttpGet("ativos")]
        public async Task<IActionResult> GetAtivos()
        {
            var result = await _service.GetAtivosAsync();
            return Ok(result);
        }

        [HttpGet("disciplina")]
        public async Task<IActionResult> GetByDisciplina([FromQuery] string disciplina)
        {
            var result = await _service.GetByDisciplinaAsync(disciplina);
            return Ok(result);
        }

        [HttpGet("recentes")]
        public async Task<IActionResult> GetRecentes([FromQuery] int limit)
        {
            var result = await _service.GetRecentesAsync(limit);
            return Ok(result);
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> GetBuscar(
        [FromQuery] string? nome,
        [FromQuery] bool? ativo,
        [FromQuery] string? disciplina,
        [FromQuery] int? limit)
        {
            var result = await _service.GetBuscarAsync(nome, ativo, disciplina, limit);
            return Ok(result);
        }

    }
}