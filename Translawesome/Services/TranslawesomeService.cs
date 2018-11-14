using System;
using System.Collections.Generic;
using System.Linq;
using ch.igorgiovannini.Translawesome.Caching;
using ch.igorgiovannini.Translawesome.Models;

namespace ch.igorgiovannini.Translawesome.Services
{
    public class TranslawesomeService : ITranslawesomeService
    {
        private readonly ICacheService _cacheService;
        public TranslawesomeService(ICacheService cacheService)
        {
            _cacheService = cacheService;
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
            return _cacheService.RetrieveTranslationsCached();
        }

        public void ReloadTranslations()
        {
            _cacheService.ReloadCache();
        }
    }
}
