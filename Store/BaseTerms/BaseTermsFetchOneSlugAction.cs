namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsFetchOneSlugAction
    {
        public string Slug { get; init; }
        public string Token { get; init; }

        public BaseTermsFetchOneSlugAction(string slug, string token)
        {
            Slug = slug;
            Token = token;
        }
    }
}