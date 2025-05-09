using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SIGOBackend.Domain.Entities
{
    public class ConfiguracionSistema
    {
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        public Logos Logos { get; set; }
        public Tema Tema { get; set; }
    }

    public class Logos
    {
        public string LogoPrincipal { get; set; }
        public string LogoSecundario { get; set; }
    }

    public class Tema
    {
        public Colores Colores { get; set; }
        public Tipografia Tipografia { get; set; }
    }

    public class Colores
    {
        public string Primario { get; set; }
        public string Secundario { get; set; }
        public string Fondo { get; set; }
        public string Texto { get; set; }
    }

    public class Tipografia
    {
        public string Fuente { get; set; }
        public string TamañoBase { get; set; }
    }
}