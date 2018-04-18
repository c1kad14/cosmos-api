using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Blog.TokenAuthGettingStarted.CustomTokenProvider;
using CosmosAPI.Auth;
using CosmosAPI.ExtensionMethods;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CosmosAPI
{
	public class Startup
	{
		private readonly SymmetricSecurityKey _signingKey;

		private readonly TokenValidationParameters _tokenValidationParameters;

		private readonly TokenProviderOptions _tokenProviderOptions;

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;

			_signingKey =
				new SymmetricSecurityKey(
					Encoding.ASCII.GetBytes(Configuration.GetSection("TokenAuthentication:SecretKey").Value));

			_tokenValidationParameters = new TokenValidationParameters
			{
				// The signing key must match!
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = _signingKey,
				// Validate the JWT Issuer (iss) claim
				ValidateIssuer = true,
				ValidIssuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
				// Validate the JWT Audience (aud) claim
				ValidateAudience = true,
				ValidAudience = Configuration.GetSection("TokenAuthentication:Audience").Value,
				// Validate the token expiry
				ValidateLifetime = true,
				// If you want to allow a certain amount of clock drift, set that here:
				ClockSkew = TimeSpan.Zero
			};


			_tokenProviderOptions = new TokenProviderOptions
			{
				Path = Configuration.GetSection("TokenAuthentication:TokenPath").Value,
				Audience = Configuration.GetSection("TokenAuthentication:Audience").Value,
				Issuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
				SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256),
				IdentityResolver = GetIdentity
			};
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			ConfigureAuth(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseTokenProvider(_tokenProviderOptions);
			app.UseAuthentication();
			app.UseMvc();
		}

		private void ConfigureAuth(IServiceCollection services)
		{
			services.AddAuthentication(options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(options => { options.TokenValidationParameters = _tokenValidationParameters; })
				.AddCookie(options =>
				{
					options.Cookie.Name = Configuration.GetSection("TokenAuthentication:CookieName").Value;
					options.TicketDataFormat = new CustomJwtDataFormat(
						SecurityAlgorithms.HmacSha256,
						_tokenValidationParameters);
				});
		}

		private Task<ClaimsIdentity> GetIdentity(string username, string password)
		{
			// Don't do this :D
			if (username == "sds" && password == "window")
			{
				return Task.FromResult(new ClaimsIdentity(new GenericIdentity(username, "Token"), new Claim[] { }));
			}

			// Credentials are invalid, or account doesn't exist
			return Task.FromResult<ClaimsIdentity>(null);
		}
	}

}
