namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsFetchOneSlugAction
    {
        public string Slug { get; }

        public BaseTermsFetchOneSlugAction(string slug)
        {
            Slug = slug;
        }
    }
}