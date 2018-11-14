using System;
using System.Collections.Generic;
using ch.igorgiovannini.Translawesome.Caching;
using ch.igorgiovannini.Translawesome.Models;
using ch.igorgiovannini.Translawesome.Providers;
using Microsoft.Extensions.Caching.Memory;

namespace ch.igorgiovannini.Translawesome.Demo.Translations
{
	public class MemoryCacheService : ICacheService
    {
        private const string TRANSLAWESOME_CACHE_IDENTIFIER = "TranslawesomeCache";
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _cacheExpirationOptions;
        protected readonly ITranslationProvider TranslationProvider;

        public MemoryCacheService(ITranslationProvider translationProvider, IMemoryCache memoryCache)
        {
            TranslationProvider = translationProvider;
            _memoryCache = memoryCache;
            _cacheExpirationOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMonths(1),
                Priority = CacheItemPriority.NeverRemove
            };
        }

        public IList<Translation> RetrieveTranslationsCached()
        {
            if (!_memoryCache.TryGetValue(TRANSLAWESOME_CACHE_IDENTIFIER, out IList<Translation> cache))
            {
                cache = ReloadCache();
            }
            return cache;
        }

        public IList<Translation> ReloadCache()
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
