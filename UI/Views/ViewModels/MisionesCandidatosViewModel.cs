using Entidades;

public class MisionesCandidatosViewModel
{ 
    //Este ViewModel sirve para unir la mision con su lista de candidatos
    public List<clsMision> Misiones { get; set; }
    public int MisionSeleccionadaId { get; set; }
    public List<clsCandidato> Candidatos { get; set; }
}
