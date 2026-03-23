using UnimarTcc.Domain.Entities;

namespace UnimarTcc.Domain.Interfaces
{
    public interface IProfessorRepository
    {
        Task<List<Professor>> GetAllAsync();

        Task<Professor> GetByIdAsync(string id);

        Task CreateAsync(Professor professor);

        Task UpdateAsync(string id, Professor professor);
        Task DeleteAsync(string id);
        Task<List<Professor>> GetAtivosAsync();
        Task<List<Professor>> GetByDisciplinaAsync(string disciplina);
        Task<List<Professor>> GetRecentesAsync(int limit);
        Task<List<Professor>> GetBuscarAsync(string? nome, bool? ativo, string? disciplina, int? limit);
    }
}