using Microsoft.AspNetCore.Mvc;

using BloodBank.Application.Donors.Read;
using BloodBank.Application.Donors.Update;
using BloodBank.Application.Donors.Create;
using BloodBank.Application.Donors.Services;

namespace BloodBank.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class DonorsController : ControllerBase
{
    private readonly IDonorService _donorService;

    public DonorsController(IDonorService donorService)
    {
        _donorService = donorService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ReadDonorModel>>> GetAll(int skip = 0, int take  = 50)
    {
        var donors = await _donorService.GetAllAsync(skip, take);

        return Ok(donors);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReadDonorModel>> GetById(int id)
    {
        var donor = await _donorService.GetByIdAsync(id);

        if (donor is null)
            return NotFound();

        return Ok(donor);
    }

    [HttpGet("donations/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReadDonorWithDonationsModel>> GetWithDonationsById(int id, int take = 50)
    {
        var donor = await _donorService.GetWithDonationsByIdAsync(id, take);

        if (donor is null)
            return NotFound();

        return Ok(donor);
    }

    [HttpGet("last-donation/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReadDonorWithDonationsModel>> GetWithLastDonationById(int id)
    {
        var donor = await _donorService.GetWithLastDonationByIdAsync(id);

        if (donor is null)
            return NotFound();

        return Ok(donor);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateDonorModel donorInputModel)
    {
        var donorId = await _donorService.CreateAsync(donorInputModel);

        return CreatedAtAction(nameof(GetById), new { id = donorId }, donorInputModel);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDonorModel donorInputModel)
    {
        var updated = await _donorService.UpdateAsync(id, donorInputModel);

        if (updated)
            return NoContent();

        return NotFound();
    }
}