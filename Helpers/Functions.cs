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
    
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
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