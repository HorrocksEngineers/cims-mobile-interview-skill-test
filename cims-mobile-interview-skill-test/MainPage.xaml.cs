namespace cims_mobile_interview_skill_test;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
        Shell.SetNavBarIsVisible(this, false);
        Shell.SetTabBarIsVisible(this, false);
        Shell.SetFlyoutItemIsVisible(this, false);
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior()
        {
            IsVisible = false
        });

		InitializeComponent();
	}

}

