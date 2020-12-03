﻿namespace OriinDic.Models
{
    public record SearchItem
    {
        public string? BaseName { get; set; }
        public long? BaseTermId { get; set; }
        public string? BaseTermSlug { get; set; }
        public long? TranslateId { get; set; }
        public string? TranslateName { get; set; }
    }
}
