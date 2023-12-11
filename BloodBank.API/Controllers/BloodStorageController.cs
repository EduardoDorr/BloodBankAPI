using Microsoft.AspNetCore.Mvc;

using BloodBank.Domain.Entities;
using BloodBank.Application.BloodStorage.Services;

namespace BloodBank.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BloodStorageController : ControllerBase
    {
        private readonly IBloodStorageService _bloodStorageService;

        public BloodStorageController(IBloodStorageService bloodStorageService)
        {
            _bloodStorageService = bloodStorageService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BloodStorage>>> GetAll(int skip = 0, int take = 50)
        {
            var stockOfBloods = await _bloodStorageService.GetAllAsync(skip, take);

            return Ok(stockOfBloods);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BloodStorage>> GetById(int id)
        {
            var stockOfBlood = await _bloodStorageService.GetByIdAsync(id);

            if (stockOfBlood is null)
                return NotFound();

            return Ok(stockOfBlood);
        }

        [HttpGet("bloodData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BloodStorage>> GetByBloodType(string bloodType, string rhFactor)
        {
            var stockOfBlood = await _bloodStorageService.GetByBloodTypeAsync(bloodType, rhFactor);

            if (stockOfBlood is null)
                return NotFound();

            return Ok(stockOfBlood);
        }
    }
}