using HackathonBackEnd.Data.Models;
using HackathonBackEnd.Models;

namespace HackathonBackEnd.Data.Repositories
{
    public class TesteRepository : StorageBase<TesteDocument>
    {
        public TesteRepository(Colecoes colecao) : base(colecao)
        {
        }

        public override void Insere(TesteDocument entidade)
        {
            var collection = _mongoDatabase.GetCollection<TesteDocument>(Colecao);
            collection.InsertOne(entidade);
        }
    }
}