using BuyMe.Application.Common.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Infrastructure.Authorization
{
    public class JwtFactoryService : IJwtFactoryService
    {
        private readonly JwtIssuerOptions _jwtOptions;
        public JwtFactoryService(IOptions<JwtIssuerOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }
        public async Task<string> GenerateEncodedToken(string identifierId,string name, int userId,int companyId)
        {
            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.Sub, identifierId),
                 new Claim("name",identifierId),
                 new Claim("fullName",name),
                 new Claim("id",userId.ToString()),
                 new Claim("CompanyId",companyId.ToString()),
                 new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
            };
            var jwt = new JwtSecurityToken(
               issuer: _jwtOptions.Issuer,
               audience: _jwtOptions.Audience,
               claims: claims,
               notBefore: _jwtOptions.NotBefore,
               expires: _jwtOptions.Expiration,
               signingCredentials: _jwtOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }
}
