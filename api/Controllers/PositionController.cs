using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace api.Controllers;

public class PositionController : ControllerBase
{
    private readonly MyDbContext _context;

    public PositionController(MyDbContext context)
    {
        _context = context;
    }

    [HttpGet("/api/positions")]
    public async Task<ActionResult<IEnumerable<PositionViewModel>>> GetPositions(String search = "", String department = "", String location = "", int page = 1, int pageSize = 10)
    {
        var query = _context.Positions.AsQueryable();

        if (!search.IsNullOrEmpty())
        {
            query = query.Where(position => position.Title.Contains(search) || position.Description.Contains(search));
        }
        if (!department.IsNullOrEmpty())
        {
            query = query.Where(position => position.Department.Contains(department));
        }
        if (!location.IsNullOrEmpty())
        {
            query = query.Where(position => position.Location.Contains(location));
        }

        var positions = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

        return positions;
    }

    [HttpGet("api/positions/{id}")]
    public async Task<ActionResult<PositionViewModel>> GetPosition(int id)
    {
        var position = await _context.Positions.FindAsync(id);

        if (position == null)
        {
            return NotFound();
        }

        return position;
    }
}
