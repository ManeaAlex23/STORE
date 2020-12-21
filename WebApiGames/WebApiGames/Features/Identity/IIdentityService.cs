


namespace WebApiGames.Features.Identity

{
    public interface IIdentityService
    {
        string GenerateJwtToken(string UserId, string UserName, string secret);
    }
}
