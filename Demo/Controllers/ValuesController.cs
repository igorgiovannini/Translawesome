using System.Collections.Generic;
using ch.igorgiovannini.Translawesome.Services;
using Microsoft.AspNetCore.Mvc;

namespace ch.igorgiovannini.Translawesome.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ITranslawesomeService _translawesomeService;

        public ValuesController(ITranslawesomeService translawesomeService) {
            _translawesomeService = translawesomeService;
        }

        [HttpGet("{key}")]
        public ActionResult<string> GetTranslation(string key, string language)
        {
            return _translawesomeService.GetTranslationByKey(key, language);
        }

        [HttpGet]
        public ActionResult<IDictionary<string, string>> GetTranslations(string language)
        {
            return Ok(_translawesomeService.GetTranslations(language));
        }
    }
}
