using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace cims_mobile_interview_skill_test.ViewModels;

public partial class DogFactsRowViewModel: ObservableObject
{
    private const int CollapsedLength = 64;

    public string FullText { get; }

    public DogFactsRowViewModel(string fullText)
    {
        FullText = fullText;
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DisplayText))]
    private bool _isExpanded;

    public string DisplayText =>
        IsExpanded || FullText.Length <= CollapsedLength
            ? FullText
            : FullText[..CollapsedLength] + "...";
    
    [RelayCommand]
    private void Toggle()
    {
        IsExpanded = !IsExpanded;
    }
}