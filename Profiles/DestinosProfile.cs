using AutoMapper;
using JornadaAPI.Data.DTOs;
using JornadaAPI.Models;


namespace JornadaAPI.Profiles;

public class DestinosProfile : Profile
{
    public DestinosProfile()
    {
        CreateMap<CreateDestinoDto, Destinos>();
        CreateMap<UpdateDestinoDto, Destinos>();
        CreateMap<Destinos, UpdateDestinoDto>();
        CreateMap<Destinos, ReadDestinoDto>();
    }
}
