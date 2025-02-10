using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRANCISCO_MANUEL_MARTIN_CABELLO
{
    public class DataBase
    {
        // Definimos la conexión
        private static readonly MySqlConnection conexion =
            new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=root;database=northwind");

        // Método para Login con parámetros
        public static bool Login(string usuario, string contrasena)
        {
            bool existe = false;
            try
            {
                conexion.Open();
                string consultaUser = "SELECT * FROM users WHERE nombre = @usuario AND  = @contrasena";

                MySqlCommand cmd = new MySqlCommand(consultaUser, conexion);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);

                MySqlDataReader lector = cmd.ExecuteReader();

                if (lector.HasRows)  // Verificamos si existe al menos una fila
                {
                    existe = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar iniciar sesión: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            return existe;
        }

        // Método para mostrar productos (opcional)
        public static MySqlDataAdapter MostrarProductos()
        {
            string consulta = "SELECT * FROM products";
            return new MySqlDataAdapter(consulta, conexion);
        }

        // Método para cerrar la conexión
        public static void CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }
}
