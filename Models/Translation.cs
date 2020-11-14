using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public class Translation
    {
        [JsonPropertyName("id")]
        public long Id { get; set; } = 0;

        [JsonPropertyName("base_term_id")]
        public long BaseTermId { get; set; } = 0;

        [JsonPropertyName("language_id")]
        public long LanguageId { get; set; } = 0;

        [JsonPropertyName("current")]
        public bool Current { get; set; } = false;

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
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TranslationLastEdit LastEdit { get; set; } = new TranslationLastEdit();

        [JsonPropertyName("last_approval")]
        public TranslationApproval LastApproval { get; set; } = new TranslationApproval();

        [JsonPropertyName("last_edit_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? LastEditId { get; set; } = 0;

        [JsonPropertyName("last_approval_id")]
        public long? LastApprovalId { get; set; } = 0;

        public Translation()
        {

        }

        public List<Synonym> GetSynonyms()
        {
            return Synonyms.Select(s => new Synonym(s)).ToList();
        }
        public void SetSynonyms(IEnumerable<Synonym> l)
        {
            Synonyms = new List<string>();
            foreach (var s in l)
            {
                Synonyms.Add(s.Value);
            }
        }
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