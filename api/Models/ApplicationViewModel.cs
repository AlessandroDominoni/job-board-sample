using System.ComponentModel.DataAnnotations;

namespace api.Models;

public class ApplicationViewModel
{
    public int Id { get; set; }
    public required int PositionId { get; set; }
    public required String CandidateName { get; set; }
    public required String Email { get; set; }
    public String? CvUrl { get; set; }
    public String? Notes { get; set; }
}

public class ApplicationDTO
{
    public required int PositionId { get; set; }
    public required String CandidateName { get; set; }
    public required String Email { get; set; }
    public String? CvUrl { get; set; }
    public String? Notes { get; set; }
}