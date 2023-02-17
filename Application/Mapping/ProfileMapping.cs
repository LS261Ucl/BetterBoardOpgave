using AutoMapper;
using BetterboardOpgave.Application.Dtos;
using BetterboardOpgave.Entities;

namespace BetterboardOpgave.Application.Mapping
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            //Target -- Source

            CreateMap<SuperheroQoute, ReadSuperheroQouteDto>();
            CreateMap<ReadSuperheroQouteDto, SuperheroQoute>();
            CreateMap<CreateSuperheroQouteDto, SuperheroQoute>();
           
        }
    }
}
