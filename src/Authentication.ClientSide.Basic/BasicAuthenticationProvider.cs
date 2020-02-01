using RestApi.Client.Authentication;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.ClientSide
{
	internal class BasicAuthenticationProvider : IBasicAuthenticationProvider
	{
		public Task<BasicAuthentication> ProvideAsync(CancellationToken cancellationToken)
		{
			return Task.FromResult(new BasicAuthentication("Admin", "Admin"));
		}
	}
}