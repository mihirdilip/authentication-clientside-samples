using RestApi.Client;
using RestApi.Client.Authentication;
using System;
using System.Threading.Tasks;

namespace Authentication.ClientSide.Basic
{
	class Program
	{
		private const string BaseUrl = "https://localhost:44354";

		static async Task Main(string[] args)
		{
			var client = new RestClientBuilder()
				.SetBaseAddress(new Uri(BaseUrl))
				.AddBasicAuthentication<BasicAuthenticationProvider>()
				.Build();

			await client.ExecuteConsoleTestRequestAsync().ConfigureAwait(false);

			Console.ReadKey();
		}
	}
}
