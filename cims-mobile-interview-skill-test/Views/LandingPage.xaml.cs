using cims_mobile_interview_skill_test.ViewModels;

namespace cims_mobile_interview_skill_test.Views;

public partial class LandingPage : ContentPage
{
    #region Fields & properties

    public readonly LandingPageViewModel _viewModel;

    #endregion

    #region Constructor

    public LandingPage(LandingPageViewModel viewModel)
    {
        Shell.SetNavBarIsVisible(this, false);
        Shell.SetTabBarIsVisible(this, false);
        Shell.SetFlyoutItemIsVisible(this, false);
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior()
        {
            IsVisible = false
        });

        InitializeComponent();

        BindingContext = _viewModel = viewModel;
	}

    #endregion

    #region Methods

    protected override void OnAppearing()
    {
        base.OnAppearing();

        _viewModel?.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        _viewModel?.OnDisappearing();
    }

    #endregion

}