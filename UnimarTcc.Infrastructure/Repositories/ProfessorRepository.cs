using Google.Cloud.Firestore;
using UnimarTcc.Domain.Entities;
using UnimarTcc.Domain.Interfaces;
using UnimarTcc.Infrastructure.Firebase;

namespace UnimarTcc.Infrastructure.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly FirestoreDb _db;
        private readonly CollectionReference _collection;

        public ProfessorRepository(FirebaseContext context)
        {
            _db = context.Db;
            _collection = _db.Collection("professores");
        }

        public async Task CreateAsync(Professor professor)
        {
            professor.DataCadastro = DateTime.UtcNow;

            await _collection.Document(professor.Id).SetAsync(professor);
        }

        public async Task<List<Professor>> GetAllAsync()
        {
            var snapshot = await _collection.GetSnapshotAsync();

            return snapshot.Documents
                .Select(doc => doc.ConvertTo<Professor>())
                .ToList();
        }

        public async Task<Professor> GetByIdAsync(string id)
        {
            var doc = await _collection.Document(id).GetSnapshotAsync();

            if (!doc.Exists) return null;

            return doc.ConvertTo<Professor>();
        }

        public async Task UpdateAsync(string id, Professor professor)
        {
            var docRef = _collection.Document(id);

            var updateData = new
            {
                professor.Nome,
                professor.Disciplina,
                professor.Email,
                professor.Ativo
            };

            await docRef.SetAsync(updateData, SetOptions.MergeAll);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.Document(id).DeleteAsync();
        }
        public async Task<List<Professor>> GetAtivosAsync()
        {
            var query = _collection.WhereEqualTo("Ativo", true);
            var snapshot = await query.GetSnapshotAsync();

            return snapshot.Documents
                .Select(doc => doc.ConvertTo<Professor>())
                .ToList();
        }
        public async Task<List<Professor>> GetByDisciplinaAsync(string disciplina)
        {
            var query = _collection.WhereEqualTo("Disciplina", disciplina);
            var snapshot = await query.GetSnapshotAsync();

            return snapshot.Documents
                .Select(doc => doc.ConvertTo<Professor>())
                .ToList();
        }

        public async Task<List<Professor>> GetRecentesAsync(int limit)
        {
            var query = _collection
                .OrderByDescending("DataCadastro")
                .Limit(limit);

            var snapshot = await query.GetSnapshotAsync();

            return snapshot.Documents.Select(doc => doc.ConvertTo<Professor>()).ToList();
        }

        public async Task<List<Professor>> GetBuscarAsync(string? nome, bool? ativo, string? disciplina, int? limit)
        {
            Query query = _collection;

            if (!string.IsNullOrEmpty(nome))
                query = query.WhereEqualTo("Nome", nome);

            if (ativo.HasValue)
                query = query.WhereEqualTo("Ativo", ativo.Value);

            if (!string.IsNullOrEmpty(disciplina))
                query = query.WhereEqualTo("Disciplina", disciplina);

            if (limit.HasValue && limit > 0)
                query = query.Limit(limit.Value);

            var snapshot = await query.GetSnapshotAsync();

            return snapshot.Documents
                .Select(doc => doc.ConvertTo<Professor>())
                .ToList();
        }
    }
}