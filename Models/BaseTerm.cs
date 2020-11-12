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
        public long Id { get; set; } = long.MinValue;

        [JsonPropertyName("language_id")]
        public long LanguageId { get; set; } = long.MinValue;

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
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public BaseTermLastEdit LastEdit { get; set; } = new BaseTermLastEdit();

        [JsonPropertyName("last_edit_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long LastEditId { get; set; } = long.MinValue;

        public BaseTerm()
        {
            
        }

        public List<Synonym> GetSynonyms()
        {
            return (Synonyms is null) ? new List<Synonym>() : Synonyms.Select(s => new Synonym(s)).ToList();
        }
        public void SetSynonyms(List<Synonym> l)
        {
            Synonyms = new List<string>();
            foreach (var s in l)
            {
                Synonyms.Add(s.Value);
            }
        }

       
        public List<Example> GetExamples()
        {
            return (Examples is null) ? new List<Example>() : Examples.Select(e => new Example(e)).ToList();
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