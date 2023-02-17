using BetterboardOpgave.Application.Dtos;
using BetterboardOpgave.Application.Interfaces;
using BetterboardOpgave.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetterboardOpgave.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroQouteController : ControllerBase
    {
        private readonly ISuperheroQouteService _qouteService;
        private readonly ILogger<SuperheroQouteController> _logger;

        public SuperheroQouteController(ISuperheroQouteService qouteService, ILogger<SuperheroQouteController> logger)
        {
            _qouteService = qouteService;
            _logger = logger;
        }

        [HttpGet]
        [Route("qoutes")]
        public async Task<ActionResult<List<ReadSuperheroQouteDto>>> GetAllQoutesAsync()
        {
            try
            {
                var qoutes = await _qouteService.GetAllSuperheroQouteAsync();

                if (qoutes == null)
                {
                    _logger.LogInformation("Unable to find any Qoutes");
                    return NotFound();
                }

                return Ok(qoutes);
            }
            catch (Exception ex)
            {
                throw new Exception("Error on QoutesController", ex.InnerException);
            }

        }

        [HttpPost]
        public async Task<ActionResult<SuperheroQoute>> CreateQoutesAsync([FromBody] CreateSuperheroQouteDto requestDto)
        {
            try
            {
                var result = await _qouteService.CreateSuperheroQouteAsync(requestDto);

                if(result == null)
                {
                    _logger.LogError("Error in Controller");
                    return BadRequest();
                }

                return Ok(result);
            }
            catch(Exception ex)
            {
                throw new Exception("Error on QoutesController", ex.InnerException);
            }
        }

        [HttpGet]
        [Route("singleqoute")]
        public async Task<ActionResult<ReadSuperheroQouteDto>> GetRandomQouteAsync()
        {
           try
            {
                var result = await _qouteService.GetRandomQoute();

                return Ok(result);
            }
            catch(Exception ex)
            {
                throw new Exception("Error on QoutesController", ex.InnerException);
            }
        }
    }
}
