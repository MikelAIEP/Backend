using Microsoft.AspNetCore.Identity;

namespace BackendEncuesta.Entities
{
    public class Usuario   : IdentityUser
    {
        public int usuarioId { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }

        public string rut { get; set; }

        public string  email { get; set; }

        public string contrasena { get; set; }

        public string trabaja { get; set;}
        public string recuperar { get; set; }

        public int ModalidadTrabajoId { get; set; }

        public ModalidadTrabajo ModalidadTrabajo { get; set; }

        public int ComunaResidenciaId { get; set; }

        public ComunaResidencia ComunaResidencia { get; set; }

        public int EstadoId { get; set; }
        
        public Estado Estado { get; set; }

        public int ComunaTrabajoId { get; set; }

        public ComunaTrabajo ComunaTrabajo { get; set; }





    }
}