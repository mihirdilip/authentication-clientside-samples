using RestApi.Client.Authentication;
using System.Threading.Tasks;

namespace Authentication.ClientSide
{
	internal class ApiKeyAuthenticationProvider : IApiKeyAuthenticationProvider
	{
		public Task<ApiKeyAuthentication> ProvideAsync()
		{
			return Task.FromResult(new ApiKeyAuthentication("X-API-Key", "Key1"));
		}
	}
}