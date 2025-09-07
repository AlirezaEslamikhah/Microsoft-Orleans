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

        [HttpPost("init")]
        public async Task <IActionResult> Initialise([FromBody] NationalCodeInputDto dto)
        {
            var humanGrain = _client.GetGrain<IHumanGrain>(dto.NationalCode);
            await humanGrain.Initialise(dto.FirstName , dto.LastName , dto.NationalCode);
            return Ok($"Human {dto.FirstName} {dto.LastName} initialised with code {dto.NationalCode}");
        }

        [HttpGet("checkcrime")]
        public async Task<IActionResult> CheckCrime(string nationalCode)
        {
            var humanGrain = _client.GetGrain<IHumanGrain>(nationalCode);
            var result = await humanGrain.CheckCrime();
            return Ok(result);
        }
    }
}
