using BuberDinner.Application.Common.Authentication.Interfaces;
using BuberDinner.Application.Common.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BuberDinner.Infrastrcuture.Authentication
{
	public class JwtTokenGenerator : IJwtTokenGenerator
	{
		private readonly IDateTimeProvider _dateTimeProvider;
		private readonly JwtSettings _jwtSettings;

		public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings)
		{
			_jwtSettings = jwtSettings.Value;
			_dateTimeProvider = dateTimeProvider;
		}

		public string GenerateToken(Guid userId, string firstName, string lastName)
		{
			var signingCredentials = new SigningCredentials(
				new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
				SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
				new Claim(JwtRegisteredClaimNames.GivenName, firstName),
				new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};

			var securityToken = new JwtSecurityToken(
				issuer: _jwtSettings.Issuer,
				audience: _jwtSettings.Audience,
				expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
				signingCredentials: signingCredentials,
				claims: claims);

			return new JwtSecurityTokenHandler().WriteToken(securityToken);
		}
	}
}
