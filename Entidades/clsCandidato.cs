namespace Entidades
{
    public class clsCandidato
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        //Se usará para determinar si es apto para una mision o no junto con su fecha de nacimiento
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNac { get; set; }
        public decimal PrecioMedio { get; set; }

        public clsCandidato(int id, string nombre, string apellidos, string direccion, string pais, string telefono, DateTime fechaNac, decimal precioMedio)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Direccion = direccion;
            Pais = pais;
            Telefono = telefono;
            FechaNac = fechaNac;
            PrecioMedio = precioMedio;
        }
    }
}
