using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class BaseTerm
    {

        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("language_id")]
        public long LanguageId { get; set; }
        [JsonPropertyName("slug")]
        [Required]
        [StringLength(255, ErrorMessage = "Field too long (255 character limit).")]
        public string Slug { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        [Required]
        [StringLength(255, ErrorMessage = "Field too long (255 character limit).")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("synonyms")]
        public List<string> Synonyms { get; set; } = new List<string>();
        [JsonPropertyName("examples")]
        public List<string> Examples { get; set; } = new List<string>();
        [JsonPropertyName("definition")]
        public string Definition { get; set; } = string.Empty;
        [JsonPropertyName("last_edit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenNull)]
        public BaseTermLastEdit LastEdit { get; set; }
        [JsonPropertyName("last_edit_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenNull)]
        public long? LastEditId { get; set; }

        public BaseTerm()
        {
            
        }



        private List<Synonym> _synonyms = new List<Synonym>();

        public List<Synonym> GetSynonyms()
        {
            return Synonyms.Select(s => new Synonym(s)).ToList();
        }
        public void SetSynonyms(List<Synonym> l)
        {
            Synonyms = new List<string>();
            foreach (var s in l)
            {
                Synonyms.Add(s.Value);
            }
        }

        private List<Example> _examples = new List<Example>();
        public List<Example> GetExamples()
        {
            return Examples.Select(e => new Example(e)).ToList();
        }
        public void SetExamples(List<Example> l)
        {
            if (l == null) throw new ArgumentNullException(nameof(l));
            Examples = new List<string>();
            foreach (var e in l)
            {
                Examples.Add(e.Value);
            }
        }
    }
}