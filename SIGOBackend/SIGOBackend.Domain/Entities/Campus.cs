using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SIGOBackend.Domain.Entities
{
    // CATALOGO INICIAL REQUERIDO
    public class Campus
    {
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}