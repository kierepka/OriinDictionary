﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OriinDic.Models
{
    public class SearchItem
    {
        public string? BaseName { get; set; }
        public long? BaseTermId { get; set; }
        public string? BaseTermSlug { get; set; }
        public long? TranslateId { get; set; }
        public string? TranslateName { get; set; }
    }
}
