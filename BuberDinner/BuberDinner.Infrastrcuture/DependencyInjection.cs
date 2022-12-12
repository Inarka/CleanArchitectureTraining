using BuberDinner.Application.Common.Authentication.Interfaces;
using BuberDinner.Application.Common.Services;
using BuberDinner.Infrastrcuture.Authentication;
using BuberDinner.Infrastrcuture.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastrcuture
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
		{
			services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
			services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
			services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
			return services;
		}
	}
}
