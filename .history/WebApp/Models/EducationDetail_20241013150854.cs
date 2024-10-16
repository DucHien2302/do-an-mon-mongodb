namespace WebApp.Models;
public class EducationDetail
{
    public string CertificateDegreeName { get; set; }
    public string InstituteUniversityName { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public decimal Percentage { get; set; }
    public decimal Cgpa { get; set; }
}