using Google.Cloud.Firestore;

namespace UnimarTcc.Domain.Entities
{
    [FirestoreData]
    public class Professor
    {
        [FirestoreProperty]
        public string Id { get; set; }
        [FirestoreProperty]
        public string Nome { get; set; }
        [FirestoreProperty]
        public string Disciplina { get; set; }
        [FirestoreProperty]
        public string Email { get; set; }
        [FirestoreProperty]
        public bool Ativo { get; set; }
        [FirestoreProperty]
        public DateTime DataCadastro { get; set; }
    }
}