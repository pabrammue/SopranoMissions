using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Simula la obtención de candidatos desde una base de datos.
    /// </summary>
    public class clsGestorCandidatosDAL
    {
        private readonly clsMyConnection _myConnection = new clsMyConnection();

        /// <summary>
        /// Obtiene todos los candidatos deade la base de datos
        /// </summary>
        public List<clsCandidato> ObtenerCandidatos()
        {
            var candidatos = new List<clsCandidato>();
            SqlConnection connection = null;

            try
            {
                // Obtenemos la conexión con la base de datos.
                connection = _myConnection.getConnection();
                string query = "SELECT Id, Nombre, Apellidos, Direccion, Pais, Telefono, FechaNac, PrecioMedio FROM Candidatos";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var candidato = new clsCandidato
                            (
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5),
                                reader.GetDateTime(6),
                                reader.GetInt32(7)
                            );
                            candidatos.Add(candidato);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Manejo de errores en caso de una excepción de SQL.
                throw new Exception("Error al obtener los candidatos.", ex);
            }
            finally
            {
                // Cerramos la conexión si está abierta.
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    _myConnection.closeConnection(ref connection);
                }
            }

            return candidatos;
        }
    }
}
