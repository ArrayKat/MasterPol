using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MasterPolDesktop.ViewModels;

namespace MasterPolDesktop;

public partial class PartnerList : UserControl
{
    public PartnerList()
    {
        InitializeComponent();
        DataContext = new PartnerListVM();
    }
}