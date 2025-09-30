namespace VeterinariaAPI.Models
{
    public class Mascota
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Raza { get; set; } = string.Empty;
        public string Localidad { get; set; } = string.Empty;
        public string Calle { get; set; } = string.Empty;
        public int Altura { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string TipoMascota { get; set; } = string.Empty; // Perro, Gato, Otro
    }
}

