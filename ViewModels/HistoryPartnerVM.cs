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
    internal class HistoryPartnerVM:ViewModelBase
    {
        //поле и свойство отображения историии покупок конкретного партнера.
        List<PartnerProduct> _historyLine;
        public List<PartnerProduct> HistoryLine { get => _historyLine; set => this.RaiseAndSetIfChanged(ref _historyLine, value); }

        /// <summary>
        /// Конструктор, кооры заполняет список истории конкретного партнера
        /// </summary>
        /// <param name="idPartner">id партнера</param>
        public HistoryPartnerVM(int idPartner) {
           HistoryLine = MainWindowViewModel.myConnection.PartnerProducts.Include(x=>x.IdProductNavigation).Where(x => x.IdPartner == idPartner).ToList();
        }

        /// <summary>
        /// Метод возврата на предыдующую страницу
        /// </summary>
        public void GoBack() {
            MainWindowViewModel.Instance.PageContent = new PartnerList();
        }
        
    }
}
