using AutoMapper;
using JornadaAPI.Data.DTOs;
using JornadaAPI.Models;

namespace JornadaAPI.Profiles;

public class DepoimentosProfile : Profile
{
    public DepoimentosProfile()
    {
        CreateMap<CreateDepoimentoDto, Depoimentos>();
        CreateMap<UpdateDepoimentoDto, Depoimentos>(); 
        CreateMap<Depoimentos, UpdateDepoimentoDto>();
        CreateMap<Depoimentos, ReadDestinoDto>();
    }
}
