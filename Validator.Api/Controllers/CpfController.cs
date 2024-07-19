using Microsoft.AspNetCore.Mvc;
using Validator.Application.Services.Interfaces;

namespace Validator.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CpfController : ControllerBase
    {
        private readonly ICpfService _cpfService;

        public CpfController(ICpfService cpfService)
        {
            _cpfService = cpfService;
        }

        [HttpGet("Validate/{cpf}")]
        public IActionResult Validate(string cpf)
        {
            if (!_cpfService.ValidateCpf(cpf))
                return BadRequest();
            return Ok();
        }

        [HttpGet("Generate")]
        public IActionResult Generate()
        {
            var cpfRandom = _cpfService.GenerateRandomCpf();
            return Ok(new { cpf = cpfRandom });
        }
    }
}
