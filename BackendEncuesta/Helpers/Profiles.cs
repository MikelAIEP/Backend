using AutoMapper;
using BackendEncuesta.DTO;
using BackendEncuesta.DTO.AccountDTO;

namespace BackendEncuesta.Helpers
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<UserRegister, UserCredentials>();
            
        }
    }
}
