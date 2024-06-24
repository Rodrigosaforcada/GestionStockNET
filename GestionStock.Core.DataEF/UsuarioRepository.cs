using GestionStock.Core.Configuration;
using GestionStock.Core.Entities;

namespace GestionStock.Core.DataEF
{
    public class UsuarioRepository
    {
        private readonly Config _config;
        public UsuarioRepository(Config config)
        {
            _config = config;
        }

        public UsuarioResult GetAll()
        {
            var result = new UsuarioResult();

            using(var db = new GestionStockContext(_config))
            {
                result.Usuarios = db.Usuarios.ToList();
            }

            return result;
        }
        public GenericResult DeleteAsync(int usuarioId)
        {
            var result = new GenericResult();

            using (var db = new GestionStockContext(_config))
            {
                var usuario = from us in db.Usuarios
                              where us.usuarioId == usuarioId
                              select us;

                var entntyEntry = db.Usuarios.Remove(usuario.FirstOrDefault());

                db.SaveChanges();
            }

            result.IsSuccessful = true;

            return result;
        }
        public Usuario GetAsync(int usuarioId)
        {
            using (var db = new GestionStockContext(_config))
            {
                var usuario = from us in db.Usuarios
                              where us.usuarioId == usuarioId
                              select us;

                return usuario.FirstOrDefault();
            }
        }
        public GenericResult UpdateAsync(Usuario usuario)
        {
            using (var db = new GestionStockContext(_config))
            {
                db.Attach(usuario);
                db.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                db.SaveChanges();
            }
            var result = new GenericResult();
            result.IsSuccessful = true;
            return result;
        }
        public GenericResult CreateUsuario(Usuario usuario)
        {
            using (var db = new GestionStockContext(_config))
            {
                db.Add(usuario);
                db.SaveChanges();
            }
            var result = new GenericResult();
            result.IsSuccessful = true;
            return result;
        }
    }
}
