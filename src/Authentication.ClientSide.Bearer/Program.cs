using Microsoft.Extensions.DependencyInjection;
using RestApi.Client;
using RestApi.Client.Authentication;
using System;
using System.Threading.Tasks;

namespace Authentication.ClientSide
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var services = new ServiceCollection();
			services.AddRestClient(builder =>
			{
				builder.SetBaseAddress(new Uri(Constants.BaseUrl));
				builder.AddBearerAuthentication<BearerAuthenticationProvider>();
				builder.AddTokenProvider(new PasswordCredentialsTokenProviderConfig
				{
					TokenRequestEndpointAddress = Constants.BaseUrl + "/id/connect/token",
					TokenRevocationEndpointAddress = Constants.BaseUrl + "/id/connect/revocation",
					ClientId = "console-client",
					ClientSecret = "console-client-secret",
					Scope = "api"
				});
				builder.AddTokenProvider("testing", new PasswordCredentialsTokenProviderConfig
				{
					TokenRequestEndpointAddress = Constants.BaseUrl + "/id/connect/token",
					TokenRevocationEndpointAddress = Constants.BaseUrl + "/id/connect/revocation",
					ClientId = "console-client",
					ClientSecret = "console-client-secret",
					Scope = "api"
				});
			});

			var client = services.BuildServiceProvider().GetService<IRestClient>();
			await client.ExecuteConsoleTestRequestAsync().ConfigureAwait(false);
			await client.ExecuteConsoleTestRequestAsync().ConfigureAwait(false);

			Console.ReadKey();
		}
	}
}
