using OriinDictionary7.Models;

namespace OriinDictionary7.Store.BaseTerms;

public record BaseTermsUpdateAction
{
    public long BaseTermId { get; }
    public string Token { get; } = string.Empty;
    public BaseTerm BaseTerm { get; } = new();

    public BaseTermsUpdateAction(long baseTermId, BaseTerm baseTerm, string token)
    {
        BaseTermId = baseTermId;
        Token = token;
        BaseTerm = baseTerm;
    }
}