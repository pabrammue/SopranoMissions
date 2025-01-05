using DAL;
using Entidades;

namespace BL
{
    public static class clsGestorMisionesBL
    {
        /// <summary>
        /// Recibe la lista de misiones de la DAL y la devuelve
        /// </summary>
        /// <returns></returns>
        public static List<clsMision> ObtenerMisiones()
        {
            clsGestorMisionesDAL gestorMision = new clsGestorMisionesDAL();
            return gestorMision.ObtenerMisiones();
        }

        /// <summary>
        /// Recibe la lista de misiones de la DAL y devuelve la mision con el Id proporcionado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static clsMision ObtenerMisionPorId(int id)
        {
            clsGestorMisionesDAL gestorMision = new clsGestorMisionesDAL();
            return gestorMision.ObtenerMisiones().FirstOrDefault(m => m.Id == id);
        }
    }
}
