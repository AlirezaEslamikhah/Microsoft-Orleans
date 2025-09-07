using Microsoft.AspNetCore.Mvc;
using orleans.client.Dtos;
using orleans.grains.Abstractions;

namespace orleans.client.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HumanController :ControllerBase
    {
        private readonly IClusterClient _client;

        public HumanController(IClusterClient clusterClient)
        {
            _client = clusterClient;
        }


        [HttpGet("checkcrime")]
        public async Task<IActionResult> CheckCrime(NationalCodeInputDto dto)
        { 
            var humanGrain = _client.GetGrain<IHumanGrain>(dto.NationalCode);
            if (dto.Age < 18 )
            {
                return Ok("OK");
            }
            else
            {
                var result = await humanGrain.CheckCrime(dto.NationalCode, dto.Age);
                return Ok(result);
            }
            
        }
    }
}
