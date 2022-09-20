using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OriinDictionary7.Models;

public record BaseTerm
{

    [JsonPropertyName("id")]
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
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
    public List<string> Synonyms { get; set; } = new();

    [JsonPropertyName("examples")]
    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
    public List<string> Examples { get; set; } = new();

    [JsonPropertyName("definition")]
    // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
    public string Definition { get; set; } = string.Empty;

    [JsonPropertyName("chart_code")]
    public string ChartCode { get; set; } = string.Empty;

    [JsonPropertyName("last_edit")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
    public BaseTermLastEdit? LastEdit { get; set; } = new();

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
        return Synonyms?.Select(s => new Synonym(s)).ToList() ?? new List<Synonym>();
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
        return Examples?.Select(e => new Example(e)).ToList() ?? new List<Example>();
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