namespace Entidades
{ 
    public class clsMision
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        //Dificultad de la mision, la usaremos para designar los candidatos adecuados
        public int Dificultad { get; set; }

        public clsMision(int id, string nombre, int dificultad)
        {
            Id = id;
            Nombre = nombre;
            Dificultad = dificultad;
        }
    }
}
