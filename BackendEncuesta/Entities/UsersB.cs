using Microsoft.AspNetCore.Identity;

namespace BackendEncuesta.Entities
{
    public class UsersB : IdentityUser
    {
        public string nombres { get; set; }
        public string apellidos { get; set; }

        public string rut { get; set; }

        public DateTime fechaNacimiento { get; set; }

        public string trabaja { get; set; }

       
        public int ModalidadTrabajoId { get; set; }

        public int ComunaResidenciaId { get; set; }

        public int EstadoId { get; set; }

        
        public int ComunaTrabajoId { get; set; }

       
    }
}
