using Fluxor;

namespace OriinDic.Store.Languages
{
    public static class LanguagesReducers
    {
        [ReducerMethod]
        public static LanguagesState ReduceFetchDataAction(LanguagesState state, LanguagesFetchDataAction action) =>
            new LanguagesState(
                isLoading: true,
                languages: null,
                lastActionState: EActionState.FetchingData);

        [ReducerMethod]
        public static LanguagesState ReduceFetchDataResultAction(LanguagesState state, LanguagesFetchDataResultAction action) =>
            new LanguagesState(isLoading:false, languages: action.Languages, lastActionState: EActionState.FetchedData);

        [ReducerMethod]
        public static LanguagesState ReduceStoreLocalDataAction(LanguagesState state, LanguagesFetchDataStoreAction action) =>
            new LanguagesState(isLoading: false, languages: null, lastActionState:EActionState.LocalDataStoring );

        [ReducerMethod]
        public static LanguagesState ReduceStoreLocalDataResultAction(LanguagesState state, LanguagesFetchDataStoreResultAction action) =>
            new LanguagesState(isLoading: false, languages: action.Languages, lastActionState: EActionState.LocalDataStored);
    }
}