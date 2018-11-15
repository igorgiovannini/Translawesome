# Translawesome
Library that provides the basic structure for managing translations from the desired source (custom providers: JSON files, InMemory database, MySQL, SQL Server, SQLite, ...) generating JSON files to be easily used in Angular (for example).

## Usage

Translawesome is a .NET Standard 2.0 library.

### 1. Create your own provider and cache services

To avoid a lot of I/O operations, a cache service has been taken in care.
Obviously every project has their needs and so you (developer) have to take care of this. In the demo project (ASP.NET Core) a MemoryCache has been implemented.

The developer needs to implement his wanted translation provider (for example from JSON files or from another desired source).


### 2. Register your providers

After you implemented your own providers, you obviously need to register them for dependency injection.

Example:

```csharp
 services.AddScoped<ITranslationProvider, MyCustomTranslationProvider>();
 services.AddScoped<ICacheService, MyMemoryCacheService>();
```

### 3. Register Translawesome service

Next you added your own providers, you need to register the Translawesome service.

```csharp
 services.AddScoped<ITranslawesomeService, TranslawesomeService>();
```

### 4. Use it as you want

You can now inject the TranslawesomeService where you need to use it.

Example:

```csharp
namespace ch.igorgiovannini.Translawesome.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationsController : ControllerBase
    {
        private readonly ITranslawesomeService _translawesomeService;

        public TranslationsController(ITranslawesomeService translawesomeService) {
            _translawesomeService = translawesomeService;
        }
    }
}
```

License
----

MIT

