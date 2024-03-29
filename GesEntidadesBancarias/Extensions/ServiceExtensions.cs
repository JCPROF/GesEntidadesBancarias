﻿using Contracts;
using Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Serilog;
using System;
using System.Text;

namespace GesEntidadesBancarias.Extensions
{
	public static class ServiceExtensions
	{
		public static void ConfigureCors(this IServiceCollection services)
		{
			services.AddCors(options =>
			{
			options.AddPolicy("CorsPolicy",
				buider => buider.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader()
				.AllowCredentials()
					);
			}
			);
		}

		public static void ConfigureIISIntegration(this IServiceCollection services)
		{
			services.Configure<IISOptions>(options =>{
			});
		}

		public static void ConfigureSqlServerContext(this IServiceCollection services, IConfiguration config)
		{
			var connectionString = config["ConnectionStrings:EntidadesBancariasDB"];
			services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(connectionString));
		}

		public static void ConfigureRepositoryWrapper(this IServiceCollection services)
		{
			services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
		}

		public static void ConfigureAuthenticationJwt(this IServiceCollection services, IConfiguration config)
		{
			var key = config["keyValid:issuerSigningKey"];
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,

						ValidIssuer = "http://localhost:5000",
						ValidAudience = "http://localhost:5000",
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
					};
				});
		}

		public static IServiceCollection AddSerilogServices(
			this IServiceCollection services)
		{
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Verbose()
				.WriteTo.Console()
				.CreateLogger();
			AppDomain.CurrentDomain.ProcessExit += (s, e) => Log.CloseAndFlush();
			return services.AddSingleton(Log.Logger);
		}


	}
}
