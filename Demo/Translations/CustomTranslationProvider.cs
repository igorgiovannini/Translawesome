using System.Collections.Generic;
using ch.igorgiovannini.Translawesome.Models;
using ch.igorgiovannini.Translawesome.Providers;

namespace ch.igorgiovannini.Translawesome.Demo.Translations
{
	public class CustomTranslationProvider : ITranslationProvider
    {
        public IList<Translation> GetTranslations()
        {
            return new List<Translation> {
                new Translation {
                    Key = "test",
                    Value = "test in ita",
                    Language = "it-CH"
                },
                new Translation {
                    Key = "test",
                    Value = "test in de",
                    Language = "de-CH"
                }, new Translation {
                    Key = "test",
                    Value = "test in fra",
                    Language = "fr-CH"
                }
            };
        }
    }
}
