using System;

namespace BackendEncuesta.DTO.AccountDTO
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
