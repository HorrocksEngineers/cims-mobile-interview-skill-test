using cims_mobile_interview_skill_test.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace cims_mobile_interview_skill_test.ViewModels;

public class LandingPageViewModel: ObservableObject
{
    #region Fields & properties

    private readonly IDogFactsService _dogFactsService;



    #endregion

    #region Constructor

    public LandingPageViewModel(IDogFactsService dogFactsService)
    {
        _dogFactsService = dogFactsService;
    }

    #endregion

    #region Commands


    #endregion

    #region Methods

    public async void OnAppearing()
    {

    }

    public void OnDisappearing()
    {

    }

    #endregion

    #region Helper Methods


    public bool IsCurrentlyOffline()
    {
        var networkAccess = Connectivity.NetworkAccess;

        return networkAccess != NetworkAccess.Internet &&
               networkAccess != NetworkAccess.ConstrainedInternet;
    }

    #endregion
}
