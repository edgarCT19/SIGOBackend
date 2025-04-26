using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

public class Usuario
{
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    [BsonRepresentation(BsonType.String)]
    public Guid UnidadResponsableId { get; set; } // Si el usuario es administrador, este campo es nulo

    public string NombreDeUsuario { get; set; }
    public string Password { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Correo { get; set; }
    public string Telefono { get; set; }
    // GENERAL CATALOGO O SIMPOLEMENTE USAR EL FORMATO 1 - NOMBRE DE ROL
    public string Rol { get; set; } // admin/encargado/administrador ADMIN, LECTOR, CAPTURISTA Y ENCARGADO DE LA UNIDAD RESPONSABLE 
    public string Estado { get; set; } // "activo" o "inactivo"
    public DateTime FechaAlta { get; set; }
    public DateTime? FechaBaja { get; set; }
}
