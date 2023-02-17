using AutoMapper;
using BetterboardOpgave.Application.Dtos;
using BetterboardOpgave.Application.Interfaces;
using BetterboardOpgave.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BetterboardOpgave.Application.Services
{
    public class SuperheroQouteService : ISuperheroQouteService
    {
        private readonly IGenericRepository<SuperheroQoute> _genericRepository;
        private readonly IMapper _mapper;

        public SuperheroQouteService(IGenericRepository<SuperheroQoute> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<SuperheroQoute> CreateSuperheroQouteAsync([FromBody] CreateSuperheroQouteDto requestDto)
        {
            try
            {
                var dbRequest = _mapper.Map<SuperheroQoute>(requestDto);

                var dbResult = await _genericRepository.CreateAsync(dbRequest);

                return dbResult;
            }
            catch(Exception ex)
            {
                throw new Exception("Error on Service", ex.InnerException);
            }
        }

        public async Task<List<ReadSuperheroQouteDto>> GetAllSuperheroQouteAsync()
        {
            try
            {
                var dbRequest = await _genericRepository.GetAllAsync();

                return _mapper.Map<List<ReadSuperheroQouteDto>>(dbRequest);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Service", ex.InnerException);
            }
           
        }

        public async Task<ReadSuperheroQouteDto> GetRandomQoute()
        {
            try
            {
                var rnd = new Random();
                var dbRequest = await _genericRepository.GetAllAsync();
                var numberOfQoutes = dbRequest.Count();
                var randomIndex = rnd.Next(numberOfQoutes);
                return _mapper.Map<ReadSuperheroQouteDto>(dbRequest[randomIndex]);
            }

            catch(Exception ex)
            {
                throw new Exception("Error in Service", ex.InnerException);
            }
        }
    }
}
