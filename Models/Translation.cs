using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public record Translation
    {
        [JsonPropertyName("id")]
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public long Id { get; set; } = 0;

        [JsonPropertyName("base_term_id")]
        public long BaseTermId { get; set; }

        [JsonPropertyName("language_id")]
        public long LanguageId { get; set; }

        [JsonPropertyName("current")]
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public bool Current { get; set; } = false;

        [JsonPropertyName("name")]
        [Required]
        [StringLength(255, ErrorMessage = "Field too long (255 character limit).")]
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("synonyms")] 
        // ReSharper disable once MemberCanBePrivate.Global
        public List<string> Synonyms { get; set; } = new List<string>();

        [JsonPropertyName("examples")] 
        // ReSharper disable once MemberCanBePrivate.Global
        public List<string> Examples { get; set; } = new List<string>();

        [JsonPropertyName("definition")]
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public string Definition { get; set; } = string.Empty;

        [JsonPropertyName("last_edit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public TranslationLastEdit LastEdit { get; set; } = new TranslationLastEdit();

        [JsonPropertyName("last_approval")]
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public TranslationApproval LastApproval { get; set; } = new TranslationApproval();

        [JsonPropertyName("last_edit_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        // ReSharper disable once UnusedMember.Global
        public long? LastEditId { get; set; } = 0;

        [JsonPropertyName("last_approval_id")]
        // ReSharper disable once UnusedMember.Global
        public long? LastApprovalId { get; set; } = 0;

        // ReSharper disable once UnusedMember.Global
        public List<Synonym> GetSynonyms()
        {
            return Synonyms.Select(s => new Synonym(s)).ToList();
        }
        // ReSharper disable once UnusedMember.Global
        public void SetSynonyms(IEnumerable<Synonym> l)
        {
            Synonyms = new List<string>();
            foreach (var s in l)
            {
                Synonyms.Add(s.Value);
            }
        }
        // ReSharper disable once UnusedMember.Global
        public List<Example> GetExamples()
        {
            return Examples.Select(e => new Example(e)).ToList();
        }
        // ReSharper disable once UnusedMember.Global
        public void SetExamples(List<Example> l)
        {
            if (l == null) throw new ArgumentNullException(nameof(l));
            Examples = new List<string>();
            foreach (var e in l)
            {
                Examples.Add(e.Value);
            }
        }

        public Translation()
        {

        }
    }
}