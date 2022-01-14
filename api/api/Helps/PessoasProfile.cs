using api.DTO;
using api.Models;
using api.Models.Tipos;
using AutoMapper;

namespace api.Helps
{
    public class PessoasProfile : Profile
    {
        public PessoasProfile()
        {
            CreateMap<Pessoa, PessoasDTO>();

            CreateMap<Pessoa, UpdatePessoasDTO>()
            .ForAllMembers(x => x.Condition((source, destination, srcmember) => srcmember != null));
        }
    }
}
