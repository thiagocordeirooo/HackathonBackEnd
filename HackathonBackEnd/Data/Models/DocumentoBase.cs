using MongoDB.Bson;
using System;

namespace HackathonBackEnd.Data.Models
{
    public class DocumentoBase
    {
        public ObjectId Id { get; set; }
        public DateTime Criacao { get; set; }

        public DocumentoBase()
        {
            Id = new ObjectId();
            Criacao = DateTime.UtcNow;
        }
    }
}