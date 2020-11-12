using Fluxor;

namespace OriinDic.Store.BaseTerms
{
    public class BaseTermsFeature: Feature<BaseTermsState>
    {
        public override string GetName() => "BaseTerms";

        protected override BaseTermsState GetInitialState()  => new BaseTermsState();
    }
}