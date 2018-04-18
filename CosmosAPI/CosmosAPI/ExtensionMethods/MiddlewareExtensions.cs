using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.TokenAuthGettingStarted.CustomTokenProvider;
using CosmosAPI.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace CosmosAPI.ExtensionMethods
{
	public static class MiddlewareExtensions
	{
		public static IApplicationBuilder UseTokenProvider(
			this IApplicationBuilder builder, TokenProviderOptions parameters)
		{
			return builder.UseMiddleware<TokenProviderMiddleware>(Options.Create(parameters));
		}
	}
}
