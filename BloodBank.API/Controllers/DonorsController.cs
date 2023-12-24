using Microsoft.AspNetCore.Mvc;

using MediatR;

using BloodBank.Application.Donors.Models;
using BloodBank.Application.Donors.Queries;
using BloodBank.Application.Donors.Commands;

namespace BloodBank.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DonorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DonorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<GetDonorViewModel>>> GetAll(int skip = 0, int take  = 50)
    {
        var donors = await _mediator.Send(new GetDonorsQuery(skip, take));

        return Ok(donors);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetDonorViewModel>> GetById(int id)
    {
        var donor = await _mediator.Send(new GetDonorQuery(id));

        if (donor is null)
            return NotFound();

        return Ok(donor);
    }

    [HttpGet("{id}/donations")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetDonorWithDonationsViewModel>> GetWithDonationsById(int id, int take = 50)
    {
        var donor = await _mediator.Send(new GetDonorWithDonationsQuery(id, take));

        if (donor is null)
            return NotFound();

        return Ok(donor);
    }

    [HttpGet("{id}/last-donation")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetDonorWithDonationsViewModel>> GetWithLastDonationById(int id)
    {
        var donor = await _mediator.Send(new GetDonorWithDonationsQuery(id, 1));

        if (donor is null)
            return NotFound();

        return Ok(donor);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateDonorCommand command)
    {
        var donorId = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = donorId }, command);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDonorInputModel inputModel)
    {
        var updated = await _mediator.Send(new UpdateDonorCommand(id, inputModel));

        if (updated)
            return NoContent();

        return NotFound();
    }
}