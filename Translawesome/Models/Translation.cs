using System.ComponentModel.DataAnnotations;

namespace ch.igorgiovannini.Translawesome.Models
{
    public class Translation
    {
        [Key]
        public string Language { get; set; }
        [Key]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
