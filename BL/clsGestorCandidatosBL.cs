using DAL;
using Entidades;

namespace BL
{
    /// <summary>
    /// Contiene las reglas de negocio relacionadas con los candidatos.
    /// </summary>
    public static class clsGestorCandidatosBL
    {
        /// <summary>
        /// Obtiene los candidatos válidos para una misión específica según las reglas de negocio.
        /// </summary>
        /// <param name="idMision">Id de la misión</param>
        /// <returns>Lista de candidatos válidos</returns>
        public static List<clsCandidato> ObtenerCandidatosPorMision(int idMision)
        {
            clsGestorCandidatosDAL gestorCandidatos = new clsGestorCandidatosDAL();
            return gestorCandidatos.ObtenerCandidatos()
                .Where(c => ValidarCandidatoPorMision(c, idMision))
                .ToList();
        }

        /// <summary>
        /// Valida si un candidato cumple las reglas de negocio para una misión específica.
        /// </summary>
        /// <param name="candidato">Candidato a validar</param>
        /// <param name="idMision">Id de la misión</param>
        /// <returns>True si es válido, false en caso contrario</returns>
        private static bool ValidarCandidatoPorMision(clsCandidato candidato, int idMision)
        {
            clsGestorMisionesDAL gestorMisiones = new clsGestorMisionesDAL();
            clsMision mision = gestorMisiones.ObtenerMisiones().FirstOrDefault(m => m.Id == idMision);

            if (mision == null) return false;

            switch (mision.Dificultad)
            {
                case 1:
                case 2:
                    return candidato.Pais == "USA";
                case 3:
                    return candidato.Pais == "USA" && CalcularEdad(candidato.FechaNac) > 40;
                case 4:
                    return candidato.Pais == "Italia" && CalcularEdad(candidato.FechaNac) < 45;
                case 5:
                    return candidato.Pais == "Italia" && CalcularEdad(candidato.FechaNac) >= 45 && CalcularEdad(candidato.FechaNac) < 55;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Calcula la edad de una persona en función de su fecha de nacimiento.
        /// </summary>
        /// <param name="fechaNacimiento">Fecha de nacimiento</param>
        /// <returns>Edad</returns>
        private static int CalcularEdad(DateTime fechaNacimiento)
        {
            int edad = DateTime.Now.Year - fechaNacimiento.Year;
            if (DateTime.Now.DayOfYear < fechaNacimiento.DayOfYear) edad--;
            return edad;
        }

        /// <summary>
        /// Obtiene los detalles de un candidato específico.
        /// </summary>
        /// <param name="id">Id del candidato</param>
        /// <returns>Detalles del candidato</returns>
        public static clsCandidato ObtenerCandidatoPorId(int id)
        {
            clsGestorCandidatosDAL gestorCandidatos = new clsGestorCandidatosDAL();
            return gestorCandidatos.ObtenerCandidatos().FirstOrDefault(c => c.Id == id);
        }
    }
}
