using Newtonsoft.Json;
using RestApi.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Authentication.ClientSide
{
	public static class Extensions
	{
		public static async Task ExecuteConsoleTestRequestAsync(this IRestClient client)
		{
			await ConsoleTestRequestAsync(client, "test", "Unauthenticated request").ConfigureAwait(false);
			await ConsoleTestRequestAsync(client, "test/with-auth", "Authenticated request").ConfigureAwait(false);
		}

		private static async Task ConsoleTestRequestAsync(IRestClient client, string url, string message)
		{
			var response = await client.GetAsync<List<string>>(url).ConfigureAwait(false);

			Console.WriteLine("================================================");
			Console.WriteLine("URL: " + url);
			Console.WriteLine(message);
			Console.WriteLine();
			Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));
			Console.WriteLine("================================================");
			Console.WriteLine();
			Console.WriteLine();
		}
	}
}
