using System.Collections.ObjectModel;
using cims_mobile_interview_skill_test.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel;

namespace cims_mobile_interview_skill_test.ViewModels;

public partial LandingPageViewModel: ObservableObject
{
    private readonly IDogFactsService _dogFactsService;

    [ObservableProperty]
    private ObservableCollection<DogFactsRowViewModel> _facts = new();

    [ObservableProperty]
    private bool _hasFacts;

    [ObservableProperty]
    private bool _showEmptyState;

    #endregion

    #region Constructor

    public LandingPageViewModel(IDogFactsService dogFactsService)
    {
        _dogFactsService = dogFactsService;
    }

    public async void OnAppearing()
    {
        await LoadFactsAsync();
    }

    public void OnDisappearing()
    {

    }

    [RelayCommand]
    private async Task RefreshFacts()
    {
        await LoadFactsAsync();
    }

    private async Task LoadFactsAsync()
    {
        var bodies = await _dogFactsService.GetFactsAsync();

        void ApplyResults()
        {
            Facts = new ObservableCollection<DogFactRowViewModel>(
                bodies.Select(text => new DogFactRowViewModel(text))
            );

            HasFacts = Facts.Count > 0;
            ShowEmptyState = !HasFacts;
        }

        if (MainThread.IsMainThread)
            ApplyResults();
        else
            MainThread.BeginInvokeOnMainThread(ApplyResults);
    }

    public bool IsCurrentlyOffline()
    {
        var networkAccess = Connectivity.NetworkAccess;

        return networkAccess != NetworkAccess.Internet &&
               networkAccess != NetworkAccess.ConstrainedInternet;
    }

    #endregion
}
