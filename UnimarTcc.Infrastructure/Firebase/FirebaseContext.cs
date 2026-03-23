using Google.Cloud.Firestore;
using UnimarTcc.Domain.Entities;

namespace UnimarTcc.Infrastructure.Firebase
{
    public class FirebaseContext
    {
        public FirestoreDb Db { get; }

        public FirebaseContext()
        {
            Db = FirestoreDb.Create("tccunimar-12f29");
        }

    }
}