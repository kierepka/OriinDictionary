using Fluxor;

namespace OriinDictionary7.Store.Languages;

public static class LanguagesReducers
{
    [ReducerMethod]
    public static LanguagesState ReduceFetchDataAction(LanguagesState state, LanguagesFetchDataAction action) =>
        new(
            isLoading: true,
            languages: state.Languages,
            lastActionState: EActionState.FetchingData);

    [ReducerMethod]
    public static LanguagesState ReduceFetchDataResultAction(LanguagesState state, LanguagesFetchDataResultAction action) =>
        new(isLoading: false,
                           languages: action.Languages,
                           lastActionState: EActionState.FetchedData);


    [ReducerMethod]
    public static LanguagesState ReduceStoreLocalDataResultAction(LanguagesState state, LanguagesFetchDataStoreResultAction action) =>
        new(isLoading: false,
                           languages: action.Languages,
                           lastActionState: EActionState.LocalDataStored);
}