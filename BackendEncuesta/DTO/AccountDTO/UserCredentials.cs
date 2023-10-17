using System.ComponentModel.DataAnnotations;

namespace BackendEncuesta.DTO.AccountDTO
{
    public class UserCredentials
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        //Todo: Agregar campos nuevos para llenar tabla user

    }
}
