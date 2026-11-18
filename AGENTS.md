# Working on CryptoClients.Net

Consumer guidance belongs to the [library skill](.claude/skills/cryptoclients-net/SKILL.md); [llms.txt](llms.txt) is the discovery index. This file describes repository development.

## Layout and implementation

- [Public interfaces](CryptoClients.Net/Interfaces), [V2 aggregate](CryptoClients.Net/Clients/ExchangeSharedApiClient.cs), and [REST/socket clients](CryptoClients.Net/Clients): capability discovery, native clients, and V1 compatibility.
- [Configuration](CryptoClients.Net/CryptoClientsConfiguration.cs), [builder](CryptoClients.Net/ClientConfigurationBuilder.cs), [models](CryptoClients.Net/Models), and [DI registration](CryptoClients.Net/ExtensionMethods/ServiceCollectionExtensions.cs): global/per-exchange options, credentials, environments, enablement, and service ownership.
- [Order-book factory](CryptoClients.Net/ExchangeOrderBookFactory.cs), [trackers](CryptoClients.Net/ExchangeTrackerFactory.cs), [cross-exchange books](CryptoClients.Net/OrderBook), [tests](CryptoClients.Net.UnitTests), and [examples](Examples/ReadMe.md).

Follow neighboring integrations for lazy initialization, enabled-exchange filters, options propagation, credentials, DI, cancellation, XML documentation, and nullability. Use `ConfigureAwait(false)` in library awaits where appropriate. Adding or changing an exchange requires reconciling interfaces, lazy client creation, configuration builder/options, credential mapping, discovery, factories, DI, and relevant tests. Check the referenced package's actual public APIs; common capability support is not universal.

Preserve per-exchange result identity and partial successes. V2 lookup must distinguish one preferred implementation per exchange from all implementations. Keep V1 compatibility separate from V2 and native access. Update serialization/configuration metadata when models or options change. Preserve unrelated package versions and release configuration.

## Build and validation

Use an SDK supporting the frameworks in the [project](CryptoClients.Net/CryptoClients.Net.csproj). It includes .NET 11, while the [existing CI workflow](.github/workflows/dotnet.yml) still selects SDK 10; that workflow needs a separate SDK update. Debug defaults to `netstandard2.0` and `net11.0`, but the tests target .NET 10, so use all frameworks for solution/test builds:

```powershell
dotnet restore CryptoClients.Net.sln -p:BuildAllFrameworks=true
dotnet build CryptoClients.Net.sln --no-restore -p:BuildAllFrameworks=true
dotnet test CryptoClients.Net.UnitTests/CryptoClients.Net.UnitTests.csproj --no-build -p:BuildAllFrameworks=true --filter "FullyQualifiedName~AiExampleCompileTests"
```

The documentation test compiles standalone programs without executing exchange calls. Run configuration/initialization tests relevant to implementation changes. Live shared REST/socket tests use `ManualRun` or `INTEGRATION=1`; do not enable them for documentation validation.

```powershell
dotnet build CryptoClients.Net/CryptoClients.Net.csproj -c Release -p:BuildAllFrameworks=true
dotnet pack CryptoClients.Net/CryptoClients.Net.csproj -c Release --no-build
```

Compile changed snippets with the local project and build the individual [console/API/Blazor and focused examples](Examples/ReadMe.md). The example solution also includes CryptoVisualizer mobile/browser projects requiring additional workloads; select the relevant project for ordinary API validation. Compilation does not run exchange operations.

## Documentation ownership

Maintain consumer routing in `.claude/skills/cryptoclients-net/references/api-surfaces.md`, snippets in `references/usage.md`, and distinct operational considerations in `references/safety.md`. `SKILL.md` routes to references; `CLAUDE.md` imports this file and `llms.txt` is a short link index.

Pack `.claude/skills/**` under `skills/`, without appending `%(RecursiveDir)`. Validate metadata, relative links/anchors, and changed snippets/examples. Inspect the NuGet archive for exactly five skill files under `skills/cryptoclients-net/`, matching source bytes. Label repository-source/example links within the skill as checkout-only so packaged guidance remains usable independently.
