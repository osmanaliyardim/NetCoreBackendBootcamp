﻿using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; set; }
        private TokenOptions _tokenOptions;
        private DateTime _accesTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            //appsettings.json'daki options bilgilerini alıp bind ediyoruz

            _accesTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);

            var signingCredentials = SigningCredentialsHelper.CreateSigingCredentials(securityKey);


        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                    issuer: tokenOptions.Issuer,
                    audience: tokenOptions.Audience,
                    expires: _accesTokenExpiration,
                    notBefore: DateTime.Now,
                    claims: SetClaims(user,operationClaims),
                    signingCredentials: signingCredentials
                );

            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();

            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddEmail(user.Email);
            claims.AddRoles(operationClaims.Select(x=>x.Name).ToArray());

            return claims;
        }
    }
}
