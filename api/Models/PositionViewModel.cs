namespace api.Models;

public class PositionViewModel
{
    public int Id { get; set; }
    public required String Title { get; set; }
    public required String Department { get; set; }
    public required String Location { get; set; }
    public String? Description { get; set; }
    public int? SalaryRangeMin { get; set; }
    public int? SalaryRangeMax { get; set; }
    public String? PublishedAtUtc { get; set; }
}