﻿using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public record CommentAdd
    {
        [JsonPropertyName("translation_id")]
        public long TranslationId { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;

        public CommentAdd()
        {

        }
    }
}