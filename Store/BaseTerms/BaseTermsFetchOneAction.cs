namespace OriinDic.Store.BaseTerms
{
    public record BaseTermsFetchOneAction
    {
        public long BaseTermId { get; }
        public string Token { get; } = string.Empty;
        public string BaseTermFetchedMessage { get; }

        public BaseTermsFetchOneAction(long baseTermId, string token, string baseTermFetchedMessage)
        {
            BaseTermId = baseTermId;
            Token = token;
            BaseTermFetchedMessage = baseTermFetchedMessage;
        }
    }
}