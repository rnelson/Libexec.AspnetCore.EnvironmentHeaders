# EnvironmentHeaders Middleware

![Build status](https://github.com/rnelson/Libexec.AspnetCore.EnvironmentHeaders/actions/workflows/dotnet.yml/badge.svg) ![License](https://img.shields.io/github/license/rnelson/Libexec.AspnetCore.EnvironmentHeaders%20) ![NuGet](https://img.shields.io/nuget/v/Libexec.AspnetCore.EnvironmentHeaders)

The EnvironmentHeaders middleware is a small ASP.NET Core middleware package that adds [a few response headers](https://github.com/rnelson/Libexec.AspnetCore.EnvironmentHeaders/blob/main/Libexec.AspnetCore.EnvironmentHeaders/EnvironmentHeaders.cs#L14-L19) to every request to aid in troubleshooting.

## Usage

To use this package, simply add `Libexec.AspnetCore.EnvironmentHeaders` to your project then call [`AddEnvironmentHeaders()`](https://github.com/rnelson/Libexec.AspnetCore.EnvironmentHeaders/blob/main/Libexec.AspnetCore.EnvironmentHeaders.Tests/Program.cs#L9-L12) and [`UseEnvironmentHeaders()`](https://github.com/rnelson/Libexec.AspnetCore.EnvironmentHeaders/blob/main/Libexec.AspnetCore.EnvironmentHeaders.Tests/Program.cs#L17) during initialization.

It is recommended you [do not include this middleware in production](https://github.com/rnelson/Libexec.AspnetCore.EnvironmentHeaders/blob/main/Libexec.AspnetCore.EnvironmentHeaders.Tests/Program.cs#L11).

## License

Released under the [MIT License](http://rnelson.mit-license.org).
