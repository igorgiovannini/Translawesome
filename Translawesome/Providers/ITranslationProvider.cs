using System.Collections.Generic;
using ch.igorgiovannini.Translawesome.Models;

namespace ch.igorgiovannini.Translawesome.Providers
{
    public interface ITranslationProvider
    {
        IList<Translation> GetTranslations();
    }
}
