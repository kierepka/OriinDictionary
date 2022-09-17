using OriinDictionary7.Models;

namespace OriinDictionary7.Store.BaseTerms;

public record BaseTermsAddAction
{
    public string Token { get; } = string.Empty;
    public BaseTerm BaseTerm { get; } = new();
    public string BaseTermAddedMessage { get; } = string.Empty;

    public BaseTermsAddAction(BaseTerm baseTerm, string token, string baseTermAddedMessage)
    {
        Token = token;
        BaseTermAddedMessage = baseTermAddedMessage;
        BaseTerm = baseTerm;
    }
}