using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Libexec.AspnetCore.EnvironmentHeaders.Tests;

public class HeaderTests : IClassFixture<WebApplicationFactory<Program>>
{
	private readonly WebApplicationFactory<Program> _factory;

	public HeaderTests(WebApplicationFactory<Program> factory)
	{
		_factory = factory ?? throw new ArgumentNullException(nameof(factory));
	}

	[Theory]
	[InlineData("/")]
	public async Task ContainsHeaders(string url)
	{
		var client = _factory.CreateClient();
		var response = await client.GetAsync(url);

		response.EnsureSuccessStatusCode();

		const string prefix = "X-EnvHeaders-";
		var expectedHeaders = new[]
			{ "ServerName", "RunningAs", "CurrentDirectory", "Command", "Version-OS", "Version-Runtime" };

		foreach (var suffix in expectedHeaders)
		{
			var header = $"{prefix}{suffix}";
			
			Assert.True(response.Headers.Contains($"{header}"));
			Assert.False(string.IsNullOrWhiteSpace(response.Headers.GetValues($"{header}")
				.FirstOrDefault()));
		}
	}
}