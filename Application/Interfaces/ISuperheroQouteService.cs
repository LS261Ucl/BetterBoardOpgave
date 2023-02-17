using BetterboardOpgave.Application.Dtos;
using BetterboardOpgave.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BetterboardOpgave.Application.Interfaces
{
    public interface ISuperheroQouteService
    {
        Task<SuperheroQoute> CreateSuperheroQouteAsync([FromBody] CreateSuperheroQouteDto requestDto);
        Task<List<ReadSuperheroQouteDto>> GetAllSuperheroQouteAsync();
        Task<ReadSuperheroQouteDto> GetRandomQoute();
    }
}
