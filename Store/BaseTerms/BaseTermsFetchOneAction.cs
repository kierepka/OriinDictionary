namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsFetchOneAction
    {
        public long BaseTermId { get; }

        public BaseTermsFetchOneAction(long baseTermId)
        {
            BaseTermId = baseTermId;
        }
    }
}