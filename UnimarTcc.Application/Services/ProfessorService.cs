using UnimarTcc.Domain.Entities;
using UnimarTcc.Domain.Interfaces;

namespace UnimarTcc.Application.Services
{
    public class ProfessorService
    {
        private readonly IProfessorRepository _repository;

        public ProfessorService(IProfessorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Professor>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Professor> GetByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Professor professor)
        {
            professor.Id = Guid.NewGuid().ToString();
            professor.DataCadastro = DateTime.UtcNow;

            await _repository.CreateAsync(professor);
        }

        public async Task UpdateAsync(string id, Professor professor)
        {
            await _repository.UpdateAsync(id, professor);
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<Professor>> GetAtivosAsync()
        {
            return await _repository.GetAtivosAsync();
        }

        public async Task<List<Professor>> GetByDisciplinaAsync(string disciplina)
        {
            return await _repository.GetByDisciplinaAsync(disciplina);
        }

        public async Task<List<Professor>> GetRecentesAsync(int limit)
        {
            return await _repository.GetRecentesAsync(limit);
        }
        public async Task<List<Professor>> GetBuscarAsync(string? nome, bool? ativo, string? disciplina, int? limit)
        {
            return await _repository.GetBuscarAsync(nome, ativo, disciplina, limit);
        }

    }
}