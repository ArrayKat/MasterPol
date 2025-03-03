using Avalonia.Controls;
using MasterPolDesktop.Models;
using ReactiveUI;

namespace MasterPolDesktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        UserControl _pageContent = new PartnerList();
        public UserControl PageContent { get => _pageContent; set => this.RaiseAndSetIfChanged(ref _pageContent, value); }

        public static _43pKolinichenkoUpContext myConnection = new _43pKolinichenkoUpContext();

        public static MainWindowViewModel Instance;
        public MainWindowViewModel() { Instance = this; }
    }
}
