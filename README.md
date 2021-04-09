# Mantasflowers Backend

ASP.NET Core driven backend for university project.

## Azure

[![Build Status](https://dev.azure.com/mantasflowers/mantasflowers/_apis/build/status/mantasflowers.Mantasflowers.Backend?branchName=master)](https://dev.azure.com/mantasflowers/mantasflowers/_build/latest?definitionId=1&branchName=master)
[![Deploy status](https://vsrm.dev.azure.com/mantasflowers/_apis/public/Release/badge/eee312b1-e5f6-4f3a-96c5-9d3b03ad2770/1/1)](https://dev.azure.com/mantasflowers/mantasflowers/_release)

## How to run locally

1. Make sure .NET 5 (Core) SDK/Runtime is intalled
2. Either install SQL Server instance (e.g. [SQL Server Express LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15)) or use IN_MEMORY database (see [How to use IN_MEMORY database](#How-to-use-IN_MEMORY-database))
2. Navigate to /src/Mantasflowers.WebApi
3. Run `dotnet run`
10. Alternatively use Dockerfile

## How to use IN_MEMORY database

1. In [appsettings.Development.json](src/Mantasflowers.WebApi/appsettings.Development.json) find
```json
"Database": {
    // ...
    "IsInMemory": "False"
  },
```
2. Change `IsInMemory` to `"True"`

## License
[GPL-3.0](https://www.gnu.org/licenses/gpl-3.0.html)