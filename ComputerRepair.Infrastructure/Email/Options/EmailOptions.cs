namespace ComputerRepair.Infrastructure.Email.Options;

public class EmailOptions
{
    public const string SectionName = "EmailOptions";
    public string SmtpServer { get; set; } = null!;
    public int SmtpPort { get; set; }
    public string SmtpUsername { get; set; } = null!;
    public string SmtpPassword { get; set; } = null!;
    public string FromAddress { get; set; } = null!;
}
