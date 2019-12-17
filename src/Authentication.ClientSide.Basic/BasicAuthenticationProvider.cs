using RestApi.Client.Authentication;
using System.Threading.Tasks;

namespace Authentication.ClientSide
{
	internal class BasicAuthenticationProvider : IBasicAuthenticationProvider
	{
		public Task<BasicAuthentication> ProvideAsync()
		{
			return Task.FromResult(new BasicAuthentication("Admin", "Admin"));
		}
	}
}