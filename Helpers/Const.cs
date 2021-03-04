using OriinDic.Models;
using OriinDic.Pages;

using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace OriinDic.Helpers
{
    public static class Const
    {

        // ReSharper disable CommentTypo
        //For tests koordynator, uzytkownik, tlumacz, super_user                               
#if RELEASE
        private const string ApiDomain = "https://oriin.ga:8000/";
#elif DEBUGLOCAL
        private const string ApiDomain = "http://localhost:8000/";
#elif DOCKER
        private const string ApiDomain = "http://web:8000";
#elif PRZEMEK
        private const string ApiDomain = "https://slownik-oriin.kropleduszy.pl:8000/";
#else
        private const string ApiDomain = "https://oriin.ga:8000/";
#endif
        private const string ApiVersion = "api/v1/";
        private const string ApiDomainVersion = ApiDomain + ApiVersion;
        private const string ApiNoVersion = "api/";
        private const string ApiDomainNoVersion = ApiDomain + ApiNoVersion;

        internal const string GetLanguages = ApiDomainVersion + "languages/";
        internal const string Users = ApiDomainVersion + "users/";
        internal const string AddUser = ApiDomainNoVersion + "users/";
        internal const string UsersMe = Users + "me/";
        internal const string BaseTerms = ApiDomainVersion + "base_terms/";
        internal const string Comments = ApiDomainVersion + "comments/";
        internal const string Links = ApiDomainVersion + "links/";
        internal const string Translations = ApiDomainVersion + "translations/";
        internal const string Token = ApiDomainNoVersion + "auth/token/login/";

        internal const string PasswordChange = AddUser + "set_password/";

        internal const string PasswordReset = AddUser + "reset_password/";

        internal const string PasswordResetConfirm = AddUser + "reset_password_confirm/";
        internal const string UserCreationConfirm = AddUser + "activation/";


        internal static readonly List<Language> BaseLanguagesList  = new()
        {
            new Language { Code = PlLangShortcut, Id = PlLangId, Name = PlLangName, SpecialCharacters = PlSpecialChars}
        };



        internal const string PlLangName = "Polski";
        internal const string PlLangShortcut = "PL";
        internal const string PlSpecialChars = "ą,ć,ę,ł,ń,ó,ś,ź,ż;Ą,Ć,Ę,Ł,Ń,Ó,Ś,Ź,Ż";
        internal const string EnLangName = "English";
        internal const string EnLangShortcut = "EN";
        internal const string EnSpecialChars = "";

        internal const string FemaleGenderVal = "F";
        internal const string MaleGenderVal = "M";
        internal const string NoGenderVal = "-";
        
        internal const string PaginationBackName = "prev";
        internal const string PaginationNextName = "next";

        internal const long PlLangId = 1;
        internal const long EnLangId = 2;
        internal const long DeLangId = 3;
        internal const long DefaultItemsPerPage = 50;
        /// <summary>
        ///     Local stored token
        /// </summary>
        internal const string TokenKey = "Token";

        /// <summary>
        ///     Token on server side
        /// </summary>
        internal const string TokenApiKey = "Token";

        /// <summary>
        ///     User
        /// </summary>
        internal const string UserKey = "User";

        /// <summary>
        ///     Language set for UI 
        /// </summary>
        internal const string LanguageKey = "Language";

        /// <summary>
        ///  Stored languages from server
        /// </summary>
        internal const string LanguagesKey = "Languages";
        /// <summary>
        ///     Is actual language set
        /// </summary>
        internal const string CurrentBaseLangKey = "CurrentBaseLang";

        internal const string CurrentTranslations = "CurrentTranslations";

        
        internal const string PrimaryColor = "#0288D1";
        internal const string ThemeIsEnabled = "ThemeIsEnabled";
        internal const string ThemeIsRounded = "ThemeIsRounded";
        internal const string ThemePrimaryColor = "ThemePrimaryColor";
        

        /// <summary>
        ///     How many items per page
        /// </summary>
        internal const string ItemsPerPageKey = "ItemsPerPage";


        internal const string RoleTranslator = "Translator";
        internal const string RoleCoordinator = "Coordinator";
        internal const string RoleSuperUser = "SuperUser";
        internal const string RoleAssistant = "Assistant";

        internal const string RolesEditors = RoleTranslator + ", " + RoleCoordinator + ", " + RoleSuperUser;
        internal const string LinksAndComments = RolesEditors + ", " + RoleAssistant;
        internal const string RolesBaseEditors = RoleSuperUser;     
        internal const string RolesUsersEditors = RoleCoordinator + ", " + RoleSuperUser;
        internal const string EnLangSpeechCode = "en-GB";
        internal const string DeLangSpeechCode = "de-DE";
        internal const string PlLangSpeechCode = "pl-PL";

        public static readonly System.Text.Json.JsonSerializerOptions HttpClientOptions =
            new()
            {
                PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
                IgnoreReadOnlyProperties = true
            };
        internal const int ShownCharactersInTable = 30;
    }
}