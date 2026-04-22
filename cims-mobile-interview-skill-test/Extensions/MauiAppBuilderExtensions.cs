using cims_mobile_interview_skill_test.Interfaces;
using cims_mobile_interview_skill_test.Services;
using cims_mobile_interview_skill_test.ViewModels;
using cims_mobile_interview_skill_test.Views;

namespace cims_mobile_interview_skill_test.Extensions;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder ConfigureViews(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<LandingPage>();

        return builder;
    }

    public static MauiAppBuilder ConfigureViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<LandingPageViewModel>();

        return builder;
    }

    public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IDogFactsService, DogFactsService>();

        return builder;
    }

}
