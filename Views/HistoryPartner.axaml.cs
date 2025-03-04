using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MasterPolDesktop.ViewModels;

namespace MasterPolDesktop;

public partial class HistoryPartner : UserControl
{
    public HistoryPartner(int idPartner)
    {
        InitializeComponent();
        DataContext = new HistoryPartnerVM(idPartner);
    }
}