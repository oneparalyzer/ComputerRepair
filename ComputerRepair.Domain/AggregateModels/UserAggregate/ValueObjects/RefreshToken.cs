using ComputerRepair.Domain.SeedWorks;
using System.Security.Cryptography;

namespace ComputerRepair.Domain.AggregateModels.UserAggregate.ValueObjects;

public sealed class RefreshToken : ValueObject
{
    private const int tokenLifeTimeHours = 3;

    private RefreshToken(string value, DateTime endLifeTime)
    {
        Value = value;
        EndLifeTime = endLifeTime;
    }

    public string Value { get; }
    public DateTime EndLifeTime { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return EndLifeTime;
    }

    public static RefreshToken Create()
    {
        byte[] refreshTokenBytes = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(refreshTokenBytes);
        }
        string refreshToken = BitConverter.ToString(refreshTokenBytes).Replace("-", "").ToLower();
        
        return new RefreshToken(
            refreshToken, 
            DateTime.Now.AddHours(tokenLifeTimeHours));
    }
}
