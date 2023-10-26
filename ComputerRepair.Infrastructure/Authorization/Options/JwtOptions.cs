namespace ComputerRepair.Infrastructure.Authorization.Options;

public sealed class JwtOptions
{
    public const string SectionName = "JwtOptions";
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public string SecretKey { get; set; } = null!;
    public int LifeTime { get; set; }
}
