using MasterPolDesktop.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterPolDesktop.ViewModels
{
    public class PartnerListVM : ViewModelBase
    {
        List<Partner> partners;
        public List<Partner> Partners { get => partners; set => this.RaiseAndSetIfChanged(ref partners,value); }
        

        public PartnerListVM() {
            Partners = MainWindowViewModel.myConnection.Partners.Include(x=>x.IdTypeCompanyNavigation).ToList();
        }

        Partner _changePartner;
        public Partner ChangePartner { get => _changePartner; set { this.RaiseAndSetIfChanged(ref _changePartner, value); ChangeP(); } }
        public void ChangeP() {
            MainWindowViewModel.Instance.PageContent = new AddChangePartner(_changePartner);
        }
        public void AddP() {
            MainWindowViewModel.Instance.PageContent = new AddChangePartner();
        }
    }
}
