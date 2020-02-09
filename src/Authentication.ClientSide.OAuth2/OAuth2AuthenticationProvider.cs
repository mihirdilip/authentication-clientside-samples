using RestApi.Client.Authentication;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.ClientSide
{
	internal class OAuth2AuthenticationProvider : IOAuth2AuthenticationProvider
	{
		private readonly IRestTokenClient _tokenClient;

		public OAuth2AuthenticationProvider(IRestTokenClient tokenClient)
		{
			_tokenClient = tokenClient;
		}

		public async Task<OAuth2Authentication> ProvideAsync(CancellationToken cancellationToken)
		{
			// please note that this is just a sample and no time has been invested for any best practices.
			// do not use it as it is implemented here.

			var token = await _tokenClient.RequestTokenAsync(new PasswordCredentialsTokenRequest("alice", "alice"), cancellationToken).ConfigureAwait(false);

			//var revoke = await _tokenClient.RequestTokenAsync(new RevokeTokenRequest(token.AccessToken), cancellationToken);
			//var revoke1 = await _tokenClient.RequestTokenAsync(new RevokeTokenRequest(token.RefreshToken, TokenTypes.RefreshToken), cancellationToken);

			//var refreshedToken = await _tokenClient.RequestTokenAsync(new RefreshTokenRequest(token.RefreshToken), cancellationToken).ConfigureAwait(false);



			var auth = new OAuth2Authentication(token?.AccessToken);

			await Task.Delay(10000, cancellationToken);


			return auth;
		}
	}
}