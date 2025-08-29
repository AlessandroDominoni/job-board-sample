using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

public class ApplicationController : ControllerBase
{
    private readonly MyDbContext _context;

    public ApplicationController(MyDbContext context)
    {
        _context = context;
    }

    [HttpPost("api/applications")]
    public async Task<ActionResult<ApplicationViewModel>> PostApplication([FromBody] ApplicationDTO dto)
    {
        var applicationViewModel = new ApplicationViewModel
        {
            PositionId = dto.PositionId,
            CandidateName = dto.CandidateName,
            Email = dto.Email,
            CvUrl = dto.CvUrl,
            Notes = dto.Notes
        };

        _context.Applications.Add(applicationViewModel);
        await _context.SaveChangesAsync();
        return Created("", applicationViewModel);
    }

    [HttpGet("api/applications/by-position/{positionId}")]
    public async Task<ActionResult<List<ApplicationViewModel>>> GetApplications(int positionId)
    {
        var applications = await _context.Applications.Where(application => application.PositionId == positionId).ToListAsync();

        if (applications == null)
        {
            return NotFound();
        }

        return applications;
    }
}