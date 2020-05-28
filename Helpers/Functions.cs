using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Blazored.LocalStorage;
using Fluxor;
using OriinDic.Models;

namespace OriinDic.Helpers
{
    public static class Func
    {


        public static User GetCurrentUser(ISyncLocalStorageService localStorage) =>
            localStorage.GetItem<User>(Const.UserKey);
        



        public static List<string> Roles(this IEnumerable<Claim> claims)
        {
            return claims.Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();
        }

  

        public enum EnumPasswordOptions
        {
            Alphanum,
            All
        }    
        public static string CreatePassword(int length, EnumPasswordOptions options)
        {
            RNGCryptoServiceProvider rProvider = new RNGCryptoServiceProvider();
            StringBuilder res = new StringBuilder();
            byte[] random = new byte[1];
            using (rProvider)
            {
                while (0 < length--)
                {
                    var rndChar = '\0';
                    do
                    {
                        rProvider.GetBytes(random);
                        rndChar = (char)((random[0] % 92) + 33);
                    } while (options == EnumPasswordOptions.Alphanum && !char.IsLetterOrDigit(rndChar));
                    res.Append(rndChar);
                }
            }
            return res.ToString();
        }

        internal static string GetLangSpeech(long? languageId)
        {
            if (!languageId.HasValue) return Const.EnLangSpeechCode;
            return languageId.Value switch
            {
                Const.EnLangId => Const.EnLangSpeechCode,
                Const.PlLangId => Const.PlLangSpeechCode,
                Const.DeLangId => Const.DeLangSpeechCode,
                _ => Const.EnLangSpeechCode
            };
        }

    }
}