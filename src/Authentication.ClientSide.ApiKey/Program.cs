using RestApi.Client;
using RestApi.Client.Authentication;
using System;
using System.Threading.Tasks;

namespace Authentication.ClientSide
{
	enum ApiKeyIn
	{
		Header,
		QueryParams
	}

	class Program
	{
		private const string BaseUrl = "https://localhost:44354";
		private const ApiKeyIn ApiKeyIn = ClientSide.ApiKeyIn.Header;

		static async Task Main(string[] args)
		{
			var clientBuilder = new RestClientBuilder()
				.SetBaseAddress(new Uri(BaseUrl));

			switch (ApiKeyIn)
			{
				case ApiKeyIn.Header:
					clientBuilder.AddApiKeyInHeaderAuthentication<ApiKeyAuthenticationProvider>();
					break;

				case ApiKeyIn.QueryParams:
					clientBuilder.AddApiKeyInQueryParamsAuthentication<ApiKeyAuthenticationProvider>();
					break;
			}

			var client = clientBuilder.Build();

			await client.ExecuteConsoleTestRequestAsync().ConfigureAwait(false);

			Console.ReadKey();
		}
	}
}
