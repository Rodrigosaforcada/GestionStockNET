using GestionStock.Core.Data;
using GestionStock.Core.DataEF;
using GestionStock.Core.Entities;
using System.Security.Cryptography;
using System.Text;

namespace GestionStock.Core.Business
{
    public class UsuarioBusiness
    {
       

        private Core.DataEF.UsuarioRepository _usuarioRepositoryEF;
        public UsuarioBusiness()
        {
            _usuarioRepositoryEF = new GestionStock.Core.DataEF.UsuarioRepository();
        }
        public UsuarioResult GetAll()
        {
            return GetAllv2();
        }

        //ADO.NET
        public UsuarioResult GetAllv1()
        {
            return _usuarioRepositoryEF.GetAll();
        }
        //Entity Framework
        public UsuarioResult GetAllv2()
        {
            return _usuarioRepositoryEF.GetAll();
        }
        public GenericResult DeleteAsync(int usuarioId)
        {
            return _usuarioRepositoryEF.DeleteAsync(usuarioId);
        }
        public Usuario GetAsync(int usuarioId)
        {
            return _usuarioRepositoryEF.GetAsync(usuarioId);
        }
        public GenericResult UpdateAsync(Usuario usuario)
        {
            return _usuarioRepositoryEF.UpdateAsync(usuario);
        }
        public GenericResult CreateUsuario(string nombreNuevoUsuario, string contrasenaNuevoUsuario)
        {
            Usuario nuevoUsuario = new Usuario();
            int cantidadUsuarios = GetAll().Usuarios.Count();
            List<Usuario> usuarios = GetAll().Usuarios;
            int ultimoId = 0;
            foreach (Usuario usu in usuarios)
            {
                if(usu.usuarioId > ultimoId)
                {
                    ultimoId = usu.usuarioId;
                }
            }
            nuevoUsuario.usuarioId = ultimoId + 1;
            nuevoUsuario.nombre = nombreNuevoUsuario;


            string[] saltYHash = GenerarSaltYHash(contrasenaNuevoUsuario);
            nuevoUsuario.salt = saltYHash[0];
            nuevoUsuario.hash = saltYHash[1];

            return _usuarioRepositoryEF.CreateUsuario(nuevoUsuario);
        }
        public bool ControlContrasena(int usuarioId, string password)
        {
            Usuario usuarioAVerificar = _usuarioRepositoryEF.GetAsync(usuarioId);

            byte[] bytesDelSaltBaseDatos = Convert.FromBase64String(usuarioAVerificar.salt);

            string hashResult = Convert.ToBase64String(HashPassword(password, bytesDelSaltBaseDatos));

            if(hashResult == usuarioAVerificar.hash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string[] GenerarSaltYHash(string password) 
        {
            byte[] bytesSalt = new byte[32];
            bytesSalt = UsuarioBusiness.GenerateSalt();
            string salt = Convert.ToBase64String(bytesSalt);
            byte[] bytesHash = new byte[32];
            bytesHash = UsuarioBusiness.HashPassword(password, bytesSalt);
            string hash = Convert.ToBase64String(bytesHash);
            string[] saltYHash = [salt, hash];
            return saltYHash;
        }

        // Generar un salt aleatorio
        static byte[] GenerateSalt()
        {
            byte[] salt = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        // Aplicar hash a la contraseña con el salt
        static byte[] HashPassword(string password, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];
                Array.Copy(passwordBytes, saltedPassword, passwordBytes.Length);
                Array.Copy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

                return sha256.ComputeHash(saltedPassword);
            }
        }

    }
}
