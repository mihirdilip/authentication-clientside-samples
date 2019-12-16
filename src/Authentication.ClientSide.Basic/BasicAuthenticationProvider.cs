using System.Threading.Tasks;
using RestApi.Client.Authentication;

namespace Authentication.ClientSide.Basic
{
	internal class BasicAuthenticationProvider : IBasicAuthenticationProvider
	{
		public Task<BasicAuthentication> ProvideAsync()
		{
			return Task.FromResult(new BasicAuthentication("Admin", "Admin"));
		}
	}
}