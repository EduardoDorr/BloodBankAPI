using Microsoft.AspNetCore.Mvc;

using MediatR;

using BloodBank.Domain.Entities;
using BloodBank.Application.BloodStorages.Queries;
using BloodBank.Application.BloodStorages.Services;

namespace BloodBank.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BloodStoragesController : ControllerBase
    {
        private readonly IBloodStorageService _bloodStorageService;
        private readonly IMediator _mediator;

        public BloodStoragesController(IBloodStorageService bloodStorageService, IMediator mediator)
        {
            _bloodStorageService = bloodStorageService;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BloodStorage>>> GetAll(int skip = 0, int take = 50)
        {
            var stockOfBloods = await _mediator.Send(new GetBloodStoragesQuery(skip, take));

            return Ok(stockOfBloods);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BloodStorage>> GetById(int id)
        {
            var stockOfBlood = await _mediator.Send(new GetBloodStorageQuery(id));

            if (stockOfBlood is null)
                return NotFound();

            return Ok(stockOfBlood);
        }

        [HttpGet("bloodData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BloodStorage>> GetByBloodType(string bloodType, string rhFactor)
        {
            var stockOfBlood = await _mediator.Send(new GetBloodTypeStorageQuery(bloodType, rhFactor));

            if (stockOfBlood is null)
                return NotFound();

            return Ok(stockOfBlood);
        }
    }
}