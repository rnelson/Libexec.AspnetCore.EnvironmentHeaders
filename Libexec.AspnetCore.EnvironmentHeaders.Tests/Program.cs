using System.Diagnostics.CodeAnalysis;
using Libexec.AspnetCore.EnvironmentHeaders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

// ReSharper disable once HeapView.ClosureAllocation
var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddEnvironmentHeaders(config =>
{
	config.EnvironmentHeadersEnabled = builder.Environment.IsDevelopment();
});

using var app = builder.Build();

app.UseRouting();
app.UseEnvironmentHeaders();

app.MapGet("/", ctx => ctx.Response.WriteAsync($"Hello from {ctx.Request.Path}"));

app.Run();

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public partial class Program;