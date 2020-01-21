using RestApi.Client.Authentication;
using System.Threading.Tasks;

namespace Authentication.ClientSide
{
	internal class BearerAuthenticationProvider : IBearerAuthenticationProvider
	{
		private readonly IRestTokenClient _tokenClient;

		public BearerAuthenticationProvider(IRestTokenClient tokenClient)
		{
			_tokenClient = tokenClient;
		}

		public async Task<BearerAuthentication> ProvideAsync()
		{
			// please note that this is just a sample and no time has been invested for any best practices.
			// do not use it as it is implemented here.

			var token = await _tokenClient.RequestTokenAsync(new PasswordCredentialsTokenRequest("alice", "alice")).ConfigureAwait(false);
			return new BearerAuthentication(token?.AccessToken);
		}
	}
}