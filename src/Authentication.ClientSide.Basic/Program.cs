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
			var client = new RestClientBuilder()
				.SetBaseAddress(new Uri(Constants.BaseUrl))
				.AddBasicAuthentication<BasicAuthenticationProvider>()
				.Build();

			await client.ExecuteConsoleTestRequestAsync().ConfigureAwait(false);

			Console.ReadKey();
		}
	}
}
