using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Components;

using OriinDic.Models;

namespace OriinDic.Components
{
    public partial class Keyboard
    {

        [Parameter] public Language? MyLanguage { get; set; } = new Language();

        [Parameter] public string MyTextLoading { get; set; } = string.Empty;

        [Parameter] public EventCallback<string> OnKeyCallback { get; set; }

        [Parameter] public bool KeyboardVisible { get; set; } = false;


        private IEnumerable<List<string>> GetSpecialChars()
        {
            
            List<List<string>> returnList = new List<List<string>>();
            if (MyLanguage is null) return returnList;
            if (string.IsNullOrEmpty(MyLanguage.SpecialCharacters)) return returnList;
            

            if (MyLanguage.SpecialCharacters.Contains(';'))
            {
                var firstList = MyLanguage.SpecialCharacters.Split(';');
                returnList.AddRange(firstList.Select(s => s.Split(",").ToList()));
            }
            else
            {
                returnList.Add(MyLanguage!.SpecialCharacters!.Split(",").ToList());
            }
          
            return returnList;


        }
        public Keyboard()
        {
        }

    }
}