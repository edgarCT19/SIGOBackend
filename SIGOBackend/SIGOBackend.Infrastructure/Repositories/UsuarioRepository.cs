using MongoDB.Driver;
using SIGOBackend.Domain.Entities;
using SIGOBackend.Application.Interfaces;
using SIGOBackend.Infrastructure.Data;

namespace SIGOBackend.Application.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMongoCollection<Usuario> _usuarios;

        public UsuarioRepository(MongoDbContext context)
        {
            _usuarios = context.Usuarios;
        }
        

        public async Task<Usuario> GetByIdAsync(Guid id)
        {
            return await _usuarios.Find(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Usuario> GetByCorreoAsync(string Correo)
        {
            return await _usuarios.Find(u => u.Correo == Correo).FirstOrDefaultAsync();
        }

        public async Task<Usuario> GetByUsuarioAsync(string usuario)
        {
            return await _usuarios.Find(u => u.NombreDeUsuario == usuario).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _usuarios.Find(_ => true).ToListAsync();
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _usuarios.InsertOneAsync(usuario);
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            await _usuarios.ReplaceOneAsync(u => u.Id == usuario.Id, usuario);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _usuarios.DeleteOneAsync(u => u.Id == id);
        }
    }
}