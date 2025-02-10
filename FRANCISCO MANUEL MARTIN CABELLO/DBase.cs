using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;

namespace FRANCISCO_MANUEL_MARTIN_CABELLO
{
    public static class DBase
    {
        private static readonly string connectionString = "server=localhost;port=3306;user id=root;password=root;database=northwind";
        private static MySqlConnection conexion;

        //Iniciamos la conexión una unica vez
        public static void IniciarConexion()
        {
            try
            {
                if (conexion == null)
                {
                    conexion = new MySqlConnection(connectionString);
                }
                if (conexion.State != System.Data.ConnectionState.Open)
                {
                    conexion.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar la conexión: " + ex.Message);
            }
        }

        public static void FinalizarConexion()
        {
            try
            {
                if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar la conexión: " + ex.Message);
            }
        }

        public static bool Login(string usuario, string contrasena)
        {
            try
            {
                if (conexion == null || conexion.State != System.Data.ConnectionState.Open)
                {
                    IniciarConexion();
                }
                string consulta = "SELECT COUNT(*) FROM usuarios WHERE nombre = @usuario AND contraseña = @contrasena";
                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message);
                return false;
            }
        }

        public static List<Producto> ObtenerProductos()
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                string consulta = @"SELECT p.ProductName AS Nombre, c.CategoryName AS Categoria 
                                     FROM products p 
                                     INNER JOIN categories c ON p.CategoryID = c.CategoryID";
                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                using (MySqlDataReader lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        productos.Add(new Producto
                        {
                            Nombre = lector["Nombre"].ToString(),
                            Categoria = lector["Categoria"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener productos: " + ex.Message);
            }
            return productos;
        }

        public static bool InsertarProducto(string nombre, int categoriaId)
        {
            try
            {
                string consulta = "INSERT INTO products (ProductName, CategoryID) VALUES (@nombre, @categoriaId)";
                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@categoriaId", categoriaId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar producto: " + ex.Message);
                return false;
            }
        }

        public static bool EliminarProducto(string productName)
        {
            try
            {

                // Obtener el ID del producto basado en el nombre
                string queryId = "SELECT ProductID FROM products WHERE ProductName = @productName";
                int productId;
                using (MySqlCommand cmd = new MySqlCommand(queryId, conexion))
                {
                    cmd.Parameters.AddWithValue("@productName", productName);
                    object result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("El producto no existe.");
                        return false;
                    }
                    productId = Convert.ToInt32(result);
                }

                // Eliminar el producto usando su ID
                string deleteQuery = "DELETE FROM products WHERE ProductID = @productId";
                using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conexion))
                {
                    cmd.Parameters.AddWithValue("@productId", productId);
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el producto: " + ex.Message);
                return false;
            }
        }

        public static bool ActualizarProducto(int productoId, string nuevoNombre)
        {
            try
            {
                string consulta = "UPDATE products SET ProductName = @nuevoNombre WHERE ProductID = @productoId";
                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@nuevoNombre", nuevoNombre);
                    cmd.Parameters.AddWithValue("@productoId", productoId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar producto: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Obtiene la lista de categorías.
        /// </summary>
        public static List<string> ObtenerCategorias()
        {
            List<string> categorias = new List<string>();

            try
            {
                string consulta = "SELECT CategoryName FROM categories";
                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                using (MySqlDataReader lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        categorias.Add(lector["CategoryName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener categorías: " + ex.Message);
            }

            return categorias;
        }

        /// <summary>
        /// Agrega un producto nuevo a la base de datos.
        /// </summary>
        public static bool AgregarProducto(string productName, string category)
        {
            try
            {

                string consulta = @"
                    INSERT INTO products (ProductName, CategoryID)
                    SELECT @productName, c.CategoryID
                    FROM categories c
                    WHERE c.CategoryName = @category";
                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@productName", productName);
                    cmd.Parameters.AddWithValue("@category", category);
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el producto: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Modifica los datos de un producto existente.
        /// </summary>
        public static bool ModificarProducto(string oldProductName, string newProductName, string newCategory)
        {
            try
            {

                // Obtener CategoryID de la nueva categoría
                string queryCategoria = "SELECT CategoryID FROM categories WHERE CategoryName = @newCategory";
                int newCategoryId;
                using (MySqlCommand cmdCategoria = new MySqlCommand(queryCategoria, conexion))
                {
                    cmdCategoria.Parameters.AddWithValue("@newCategory", newCategory);
                    object result = cmdCategoria.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("La categoría especificada no existe.");
                        return false;
                    }
                    newCategoryId = Convert.ToInt32(result);
                }

                // Actualizar el producto
                string updateQuery = "UPDATE products SET ProductName = @newProductName, CategoryID = @newCategoryId WHERE ProductName = @oldProductName";
                using (MySqlCommand cmdUpdate = new MySqlCommand(updateQuery, conexion))
                {
                    cmdUpdate.Parameters.AddWithValue("@newProductName", newProductName);
                    cmdUpdate.Parameters.AddWithValue("@newCategoryId", newCategoryId);
                    cmdUpdate.Parameters.AddWithValue("@oldProductName", oldProductName);
                    int filasAfectadas = cmdUpdate.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el producto: " + ex.Message);
                return false;
            }
        }

        public class Producto
        {
            public string Nombre { get; set; }
            public string Categoria { get; set; }
        }
    }
}
