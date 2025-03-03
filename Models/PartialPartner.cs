using MasterPolDesktop.ViewModels;
using MasterPolDesktop.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterPolDesktop.Models
{
    public partial class Partner
    {
        int? sale;

        //всех с id равному 1, при этом ссуммировав по определенному столбцу все значения.
        public int? TotalSumm => MainWindowViewModel.myConnection.PartnerProducts.Where(x => x.IdPartner == this.IdPartner).Sum(y=>y.CountProduct);

        public int Sale
        {
            get
            {
                if (TotalSumm < 10000) return 0;
                else if (TotalSumm >= 10000 && TotalSumm < 50000) return 5;
                else if (TotalSumm >= 50000 && TotalSumm < 300000) return 10;
                else return 15;
            }
        }

    }
}
