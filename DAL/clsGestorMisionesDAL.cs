using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class clsGestorMisionesDAL
    {
        private readonly clsMyConnection _myConnection = new clsMyConnection();

        /// <summary>
        /// Obtiene todas las misiones desde la base de datos.
        /// </summary>
        public List<clsMision> ObtenerMisiones()
        {
            List<clsMision> misiones = new List<clsMision>();
            SqlConnection connection = null;

            try
            {
                connection = _myConnection.getConnection();
                string query = "SELECT Id, Nombre, Dificultad FROM Misiones";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clsMision mision = new clsMision
                            (
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetInt32(2)
                            );
                            misiones.Add(mision);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener las misiones.", ex);
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    _myConnection.closeConnection(ref connection);
                }
            }

            return misiones;
        }
    }
}
