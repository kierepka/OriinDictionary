﻿using System;
using Fluxor;
using OriinDic.Models;

namespace OriinDic.Store.Languages
{
    public class LanguagesFeature : Feature<LanguagesState>
    {
        public override string GetName() => "Languages";

        protected override LanguagesState GetInitialState()
        {
            //TODO: dodać zczytywanie z localdata
            return new(false, Array.Empty<Language>(), EActionState.Initialized);
        } 
    }
}