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
        // Лист партнеров
        List<Partner> partners;
        public List<Partner> Partners { get => partners; set => this.RaiseAndSetIfChanged(ref partners,value); }

        //Поле и свойство конкрутного партнера - нужно для того, что бы сохранить и передать данного партнера в качестве аргумента другому методу
        Partner _changePartner;
        public Partner ChangePartner { get => _changePartner; set { this.RaiseAndSetIfChanged(ref _changePartner, value); ChangeP(); } }


        /// <summary>
        /// Конструктор, который заполняет лист партнеров при открытии страницы
        /// </summary>
        public PartnerListVM() {
            Partners = MainWindowViewModel.myConnection.Partners.Include(x=>x.IdTypeCompanyNavigation).ToList();
        }

        /// <summary>
        /// Метод изменения пользователя, передает в качестве аргумента - выбранного партнера
        /// </summary>
        public void ChangeP() {
            MainWindowViewModel.Instance.PageContent = new AddChangePartner(_changePartner);
        }

        /// <summary>
        /// Метод добавления нового партнера - не передает в метод AddChangePartner никаких аргументов
        /// </summary>
        public void AddP() {
            MainWindowViewModel.Instance.PageContent = new AddChangePartner();
        }
        /// <summary>
        /// Метод, который перекидывает на страницу с отображением истории покупок определенного партнера
        /// </summary>
        /// <param name="idPartner"></param>
        public void History(int idPartner) {
            MainWindowViewModel.Instance.PageContent = new HistoryPartner(idPartner);
        }
    }
}
