using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace OriinDic.Helpers
{
    public static class Const
    {
        //For tests koordynator, uzytkownik, tlumacz, super_user                               
#if RELEASE
    private const string ApiDomain = "https://slownik-oriin.kropleduszy.pl:8000/";
#elif DEBUGLOCAL
    private const string ApiDomain = "http://localhost:8000/";
#elif DOCKER
    private const string ApiDomain = "http://web:8000/";
#else
        private const string ApiDomain = "https://slownik-oriin.kropleduszy.pl:8000/";
#endif
        private const string ApiVersion = "api/v1/";
        private const string ApiDomainVersion = ApiDomain + ApiVersion;
        private const string ApiNoVersion = "api/";
        private const string ApiDomainNoVersion = ApiDomain + ApiNoVersion;

        internal const string ApiGetLanguages = ApiDomainVersion + "languages/";
        internal const string ApiUsers = ApiDomainVersion + "users/";
        internal const string ApiAddUser = ApiDomainNoVersion + "users/";
        internal const string ApiUsersMe = ApiUsers + "me/";
        internal const string ApiBaseTerms = ApiDomainVersion + "base_terms/";
        internal const string ApiComments = ApiDomainVersion + "comments/";
        internal const string ApiLinks = ApiDomainVersion + "links/";
        internal const string ApiTranslations = ApiDomainVersion + "translations/";
        internal const string ApiToken = ApiDomainNoVersion + "auth/token/login/";

        internal static readonly IEnumerable<long> BaseLanguagesList = new ReadOnlyCollectionBuilder<long>{PlLangId};                                         

        
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
        ///     Token zapisywany lokalnie
        /// </summary>
        internal const string TokenKey = "Token";

        /// <summary>
        ///     Token na serwerze
        /// </summary>
        internal const string TokenApiKey = "Token";

        /// <summary>
        ///     Użytkownik
        /// </summary>
        internal const string UserKey = "User";

        /// <summary>
        ///     Język aplikacji (UI)
        /// </summary>
        internal const string LanguageKey = "Language";

        /// <summary>
        /// Języki aplikacji (pobrane)
        /// </summary>
        internal const string LanguagesKey = "Languages";
        /// <summary>
        ///     Czy oktualny jest język bazowy
        /// </summary>
        internal const string CurrentBaseLangKey = "CurrentBaseLang";

        internal const string CurrentTranslations = "CurrentTranslations";
        

        /// <summary>
        ///     Ilość wierszy na stronę
        /// </summary>
        internal const string ItemsPerPageKey = "ItemsPerPage";


        internal const string RoleTranslator = "Translator";
        internal const string RoleCoordinator = "Coordinator";
        internal const string RoleSuperUser = "SuperUser";
        internal const string RoleAssistant = "Assistant";

        internal const string RolesEditors = RoleTranslator + ", " + RoleCoordinator + ", " + RoleSuperUser;
        internal const string RolesBaseEditors = RoleSuperUser;     //zmiana zgodnie uwagą Przemka
        internal const string RolesUsersEditors = RoleCoordinator + ", " + RoleSuperUser;
        internal const string EnLangSpeechCode = "en-GB";
        internal const string DeLangSpeechCode = "de-DE";
        internal const string PlLangSpeechCode = "pl-PL";

        public static readonly System.Text.Json.JsonSerializerOptions HttpClientOptions =
            new System.Text.Json.JsonSerializerOptions()
            {
                PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
                IgnoreReadOnlyProperties = true
            };

    }
}