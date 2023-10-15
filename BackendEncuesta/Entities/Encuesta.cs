namespace BackendEncuesta.Entities
{
    public class Encuesta
    {
        public int EncuestaId { get; set; }
        public DateTime fecharealizacion { get; set; }

        public string Pregunta1 { get; set; }

        public string Pregunta2 { get; set; }

        public string Pregunta3 { get; set; }

        public string Pregunta4 { get; set; }

        public string Pregunta5 { get; set; }

        public string Pregunta6 { get; set; }

        public int TipoTransporteId { get; set; }
        public TipoTransporte TipoTransporte { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }




    }
}
