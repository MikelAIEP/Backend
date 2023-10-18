namespace BackendEncuesta.DTO
{
    public class EncuestaCreateDTO
    {
        public DateTime fecharealizacion { get; set; }

        public string Pregunta1 { get; set; }

        public string Pregunta2 { get; set; }

        public string Pregunta3 { get; set; }

        public string Pregunta4 { get; set; }

        public string Pregunta5 { get; set; }

        public string Pregunta6 { get; set; }

        public int TipoTransporteId { get; set; }

        public int UsuarioId { get; set; }
    }
}
