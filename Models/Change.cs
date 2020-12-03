﻿using System.Text.Json.Serialization;

namespace OriinDic.Models
{
    public record Change 
    {
        [JsonPropertyName("after")]
        // ReSharper disable once UnusedMember.Global
        public BaseTerm After { get; set; } = new BaseTerm();

        [JsonPropertyName("before")]
        // ReSharper disable once UnusedMember.Global
        public BaseTerm Before { get; set; } = new BaseTerm();

        public Change()
        {

        }
    }
}
