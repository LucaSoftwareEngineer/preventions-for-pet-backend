using dto;
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

        [HttpGet("{idPet:int}")]
        public async Task<IActionResult> FindById([FromRoute] int idPet)
        {
            try
            {
                var pet = await _petService.FindById(idPet);
                return Ok(pet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] PetAddRequest request) {
            try
            {
                var pet = await _petService.Add(request);
                return Ok(pet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] PetUpdateRequest request)
        {
            try
            {
                var pet = await _petService.Update(request);
                return Ok(pet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                var msg = await _petService.Delete(id);
                return Ok(msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
