using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SIGOBackend.Domain.Entities
{
    // Unidad Responsable
    // CATALOGO INICIAL REQUERIDO
    public class Edificio
    {
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        // NO ES NECESARIO
        public DateTime FechaRegistro { get; set; }

        // NO ES NECESARIO
        [BsonRepresentation(BsonType.String)]
        public Guid ResponsableAlta { get; set; }
    }
}