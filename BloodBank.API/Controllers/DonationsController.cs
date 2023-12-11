using Microsoft.AspNetCore.Mvc;

using BloodBank.Application.Donations.Read;
using BloodBank.Application.Donations.Update;
using BloodBank.Application.Donations.Create;
using BloodBank.Application.Donations.Services;

namespace BloodBank.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class DonationsController : ControllerBase
{
    private readonly IDonationService _donationService;

    public DonationsController(IDonationService donationService)
    {
        _donationService = donationService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ReadDonationModel>>> GetAll(int skip = 0, int take = 50)
    {
        var donors = await _donationService.GetAllAsync(skip, take);

        return Ok(donors);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReadDonationModel?>> GetById(int id)
    {
        var donor = await _donationService.GetByIdAsync(id);

        if (donor is null)
            return NotFound();

        return Ok(donor);
    }

    [HttpGet("report")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ReadDonationWithDonorModel?>> GetReportWithDonors(int numberOfDays)
    {
        var donor = await _donationService.GetReportWithDonorsAsync(numberOfDays);

        return Ok(donor);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateDonationInputModel donationInputModel)
    {
        var donationId = await _donationService.CreateAsync(donationInputModel);

        return CreatedAtAction(nameof(GetById), new { id = donationId }, donationInputModel);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDonationInputModel donationInputModel)
    {
        var updated = await _donationService.UpdateAsync(id, donationInputModel);

        if (updated)
            return NoContent();

        return NotFound();
    }
}
