using System;
using System.Collections.Generic;
using ch.igorgiovannini.Translawesome.Models;

namespace ch.igorgiovannini.Translawesome.Caching
{
    public interface ICacheService
    {
        IList<Translation> RetrieveTranslationsCached();

        IList<Translation> ReloadCache();
    }
}
