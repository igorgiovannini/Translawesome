using System.ComponentModel.DataAnnotations;

namespace ch.igorgiovannini.Translawesome.Models
{
    public class Translation
    {
        public string Language { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
