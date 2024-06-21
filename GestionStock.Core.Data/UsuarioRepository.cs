using GestionStock.Core.Entities;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace GestionStock.Core.Data
{
    public class UsuarioRepository
    {
        private readonly string CONNECTIONSTRING = "Persist Security Info=True;Initial Catalog=Prog3RecurGoya;Data Source=LAPTOPLOCAL1234\\SQLEXPRESS; Application Name=DemoApp;Integrated Security=True;TrustServerCertificate=True;";

        private readonly string QUERY_DEMO = "SELECT [UsuarioId]\r\n      ,[Nombre]\r\n      ,[Hash]\r\n      ,[Salt]\r\n  FROM [Prog3RecurGoya].[dbo].[Usuario]";
        public UsuarioRepository()
        {

        }
        public UsuarioResult GetAll()
        {
            //obtener datos desde la BD
            var result = new UsuarioResult();
            result.Usuarios = new List<Usuario>();

            //Obtener los datos de DB

            var cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = QUERY_DEMO;


            try
            {
                //action
                using (var conn = new Microsoft.Data.SqlClient.SqlConnection(CONNECTIONSTRING))
                {
                    cmd.Connection = conn;

                    conn.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        //var usuarioId = (int)reader.GetValue(0);
                        var usuarioId = reader.GetInt32(0);
                        var usuarioNombre = reader.GetString(1);

                        result.Usuarios.Add(new Usuario
                        {
                            usuarioId = usuarioId,
                            nombre = usuarioNombre
                        });
                    }

                    //conn.Close();
                }
            }
            catch (SqlException ex)
            {
                //log
                //Mensajes
                var mensaje = ex.Message;
                result.HasError = true;
                result.Message = ex.Message;
            }
            catch (Exception ex)
            {
                //log
                //Mensajes
                var mensaje = ex.Message;
                result.HasError = true;
                result.Message = ex.Message;
            }
            
            return result;
        }

    }
}
