namespace SIGOBackend.Infrastructure.Configuration
{
    public class JwtSettings
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty; // QUIEN EMITE EL TOCKEN COMO https://mi-servidor.com
        public string Audience { get; set; } = string.Empty; // QUIEN RECIBE EL TOCKEN COMO https://mi-cliente.com
        public int ExpirationInMinutes { get; set; } = 60; // TIEMPO DE EXPIRACION DEL TOCKEN EN MINUTOS
    }
}