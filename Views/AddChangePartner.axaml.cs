using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MasterPolDesktop.Models;
using MasterPolDesktop.ViewModels;

namespace MasterPolDesktop;

public partial class AddChangePartner : UserControl
{
    public AddChangePartner()
    {
        InitializeComponent();
        DataContext = new AddChangePartnerVM();
    }
    public AddChangePartner(Partner partner)
    {
        InitializeComponent();
        DataContext = new AddChangePartnerVM(partner);
    }
}