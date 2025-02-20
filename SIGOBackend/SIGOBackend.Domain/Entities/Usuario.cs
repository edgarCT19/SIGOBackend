using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

public class Usuario
{
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    [BsonRepresentation(BsonType.String)]
    public Guid UnidadResponsableId { get; set; } // Agrega esto

    public string NombreDeUsuario { get; set; }
    public string Password { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Correo { get; set; }
    public string Telefono { get; set; }
    public string Rol { get; set; } // "admin" o "encargado"
    public string Estado { get; set; } // "activo" o "inactivo"
    public DateTime FechaAlta { get; set; }
    public DateTime? FechaBaja { get; set; }
}
