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
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public string Slug { get; set; } = string.Empty;
        
        [JsonPropertyName("name")]
        [Required]
        [StringLength(255, ErrorMessage = "Field too long (255 character limit).")]
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public string Name { get; set; } = string.Empty;
        
        [JsonPropertyName("synonyms")]
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public List<string> Synonyms { get; set; } = new List<string>();

        [JsonPropertyName("examples")]
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public List<string> Examples { get; set; } = new List<string>();
        
        [JsonPropertyName("definition")]
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public string Definition { get; set; } = string.Empty;

        [JsonPropertyName("last_edit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public BaseTermLastEdit? LastEdit { get; set; } = new BaseTermLastEdit();
        
        [JsonPropertyName("last_edit_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        // ReSharper disable once UnusedMember.Global
        public long? LastEditId { get; set; } = 0;

        // ReSharper disable once EmptyConstructor
        public BaseTerm()
        {
            
        }

        public IEnumerable<Synonym> GetSynonyms()
        {
            return Synonyms.Select(s => new Synonym(s)).ToList();
        }
/*
        public void SetSynonyms(IEnumerable<Synonym> l)
        {
            Synonyms = new List<string>();
            foreach (var s in l)
            {
                Synonyms.Add(s.Value);
            }
        }
*/

       
        public IEnumerable<Example> GetExamples()
        {
            return Examples.Select(e => new Example(e)).ToList();
        }
/*
        public void SetExamples(List<Example> l)
        {
            if (l == null) throw new ArgumentNullException(nameof(l));
            Examples = new List<string>();
            foreach (var e in l)
            {
                Examples.Add(e.Value);
            }
        }
*/
    }
}