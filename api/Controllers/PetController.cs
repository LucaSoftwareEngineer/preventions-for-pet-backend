using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service.interfaces;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var pets = await _petService.FindAll();
                return Ok(pets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("list/{idProprietario:int}")]
        public async Task<IActionResult> FindAllByProprietario([FromRoute] int idProprietario)
        {
            try
            {
                var pets = await _petService.FindAllByProprietario(idProprietario);
                return Ok(pets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
