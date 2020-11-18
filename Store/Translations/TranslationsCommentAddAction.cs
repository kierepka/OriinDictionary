﻿using OriinDic.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OriinDic.Store.Translations
{
    
    public class TranslationsCommentAddAction
    {
        public string Token { get; init; } = string.Empty;
        public Comment Comment { get; init; } = new Comment();

        public long TranslationId { get; init; } = 0;

        public TranslationsCommentAddAction(Comment comment, string token, long translationId)
        {
            Token = token;
            Comment = comment;
            TranslationId = translationId;
        }
    }
    
}
