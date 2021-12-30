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
        }
    }
}
