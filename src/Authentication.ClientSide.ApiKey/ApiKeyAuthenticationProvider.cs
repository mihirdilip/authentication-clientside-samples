using RestApi.Client.Authentication;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.ClientSide
{
	internal class ApiKeyAuthenticationProvider : IApiKeyAuthenticationProvider
	{
		public Task<ApiKeyAuthentication> ProvideAsync(CancellationToken cancellationToken)
		{
			return Task.FromResult(new ApiKeyAuthentication("X-API-Key", "Key1"));
		}
	}
}