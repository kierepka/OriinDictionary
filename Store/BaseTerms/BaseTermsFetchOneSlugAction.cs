namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsFetchOneSlugAction
    {
        public string Slug { get; init; } = string.Empty;
        public string Token { get; init; } = string.Empty;

        public BaseTermsFetchOneSlugAction(string slug, string token)
        {
            Slug = slug;
            Token = token;
        }
    }
}