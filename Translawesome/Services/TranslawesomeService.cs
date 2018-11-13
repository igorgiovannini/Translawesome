using System;
using System.Collections.Generic;
using System.Linq;
using ch.igorgiovannini.Translawesome.Models;
using ch.igorgiovannini.Translawesome.Providers;
using Microsoft.Extensions.Caching.Memory;

namespace ch.igorgiovannini.Translawesome.Services
{
    public class TranslawesomeService : ITranslawesomeService
    {
        private const string TRANSLAWESOME_CACHE_IDENTIFIER = "TranslawesomeCache";
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _cacheExpirationOptions;
        protected readonly ITranslationProvider TranslationProvider;

        public TranslawesomeService(ITranslationProvider translationProvider, IMemoryCache memoryCache)
        {
            TranslationProvider = translationProvider;
            _memoryCache = memoryCache;
            _cacheExpirationOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMonths(1),
                Priority = CacheItemPriority.NeverRemove
            };
        }

        public string GetTranslationByKey(string key, string language)
        {
            var translation = GetTranslations().FirstOrDefault(t => t.Key.Equals(key) && t.Language.Equals(language));
            return translation?.Value ?? key;
        }

        public IDictionary<string, string> GetTranslations(string language) {
            return GetTranslations().Where(t => t.Language.Equals(language)).ToDictionary(t => t.Key,
                                                                                          t => t.Value,
                                                                                          StringComparer.OrdinalIgnoreCase);
        }

        protected IList<Translation> GetTranslations()
        {
            if (!_memoryCache.TryGetValue(TRANSLAWESOME_CACHE_IDENTIFIER, out IList<Translation> cache))
            {
                cache = ReloadTranslations();
            }
            return cache;
        }

        public IList<Translation> ReloadTranslations()
        {
            _memoryCache.Remove(TRANSLAWESOME_CACHE_IDENTIFIER);
            var cache = TranslationProvider.GetTranslations();
            _memoryCache.Set(TRANSLAWESOME_CACHE_IDENTIFIER, cache, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMonths(1),
                Priority = CacheItemPriority.NeverRemove
            });
            return cache;
        }
    }
}
