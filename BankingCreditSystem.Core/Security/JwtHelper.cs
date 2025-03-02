using BankingCreditSystem.Core.Security.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BankingCreditSystem.Core.Security;

public class JwtHelper : ITokenHelper
{
    private readonly TokenOptions _tokenOptions;
    private readonly IConfiguration _configuration;

    public JwtHelper(IConfiguration configuration)
    {
        _configuration = configuration;
        _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
    }

    public async Task<AccessToken> CreateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        var jwt = CreateJwtSecurityToken(user, signingCredentials);
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var token = jwtSecurityTokenHandler.WriteToken(jwt);

        return new AccessToken
        {
            Token = token,
            Expiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration)
        };
    }

    public string GetUserIdFromToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
        return securityToken?.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
    }

    private JwtSecurityToken CreateJwtSecurityToken(User user, SigningCredentials signingCredentials)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Role, user.Role)
        };

        return new JwtSecurityToken(
            issuer: _tokenOptions.Issuer,
            audience: _tokenOptions.Audience,
            expires: DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration),
            notBefore: DateTime.Now,
            claims: claims,
            signingCredentials: signingCredentials
        );
    }
} 