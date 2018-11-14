using System.Collections.Generic;
using ch.igorgiovannini.Translawesome.Models;

namespace ch.igorgiovannini.Translawesome.Services
{
    public interface ITranslawesomeService
    {
        string GetTranslationByKey(string key, string language);

        void ReloadTranslations();

        IDictionary<string, string> GetTranslations(string language);
    }
}
