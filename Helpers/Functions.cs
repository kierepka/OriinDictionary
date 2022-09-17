using Blazored.LocalStorage;

using OriinDictionary7.Models;

using System.Security.Claims;

namespace OriinDictionary7.Helpers;

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

    public static string Truncate(this string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return value.Length <= maxLength ? value : $"{value.Substring(0, maxLength)}[..]";
    }

    public enum EnumPasswordOptions
    {
        Alphanum,
        All
    }

    private static Random random = new Random();

    public static string CreatePassword(int length, EnumPasswordOptions options)
    {
#if WINDOWS
        RNGCryptoServiceProvider rProvider = new();
        StringBuilder res = new();
        byte[] random = new byte[1];
        using (rProvider)
        {
            while (0 < length--)
            {
                char rndChar;
                do
                {
                    rProvider.GetBytes(random);
                    rndChar = (char)((random[0] % 92) + 33);
                } while (options == EnumPasswordOptions.Alphanum && !char.IsLetterOrDigit(rndChar));
                res.Append(rndChar);
            }
        }
        return res.ToString();
#else
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
#endif
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