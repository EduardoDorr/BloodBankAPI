using Microsoft.AspNetCore.Mvc;

using MediatR;

using BloodBank.Application.Donations.Models;
using BloodBank.Application.Donations.Queries;
using BloodBank.Application.Donations.Commands;

namespace BloodBank.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class DonationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DonationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<GetDonationViewModel>>> GetAll(int skip = 0, int take = 50)
    {
        var donors = await _mediator.Send(new GetDonationsQuery(skip, take));

        return Ok(donors);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetDonationViewModel?>> GetById(int id)
    {
        var donor = await _mediator.Send(new GetDonationQuery(id));

        if (donor is null)
            return NotFound();

        return Ok(donor);
    }

    [HttpGet("report")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetDonationWithDonorViewModel?>> GetReportWithDonors(int numberOfDays = 30)
    {
        var donor = await _mediator.Send(new GetReportOfDonationQuery(numberOfDays));

        return Ok(donor);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateDonationCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.Success)
            return BadRequest(result.Errors);

        return CreatedAtAction(nameof(GetById), new { id = result.Value }, command);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDonationInputModel donationInputModel)
    {
        var updated = await _mediator.Send(new UpdateDonationCommand(id, donationInputModel));

        if (updated)
            return NoContent();

        return NotFound();
    }
}
