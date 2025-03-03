using MasterPolDesktop.Models;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MasterPolDesktop.ViewModels
{
    internal class AddChangePartnerVM : ViewModelBase
    {
        Partner _curentPartner;

        public Partner CurentPartner { get => _curentPartner; set => this.RaiseAndSetIfChanged( ref _curentPartner, value); }
        
        
        public List<PartnerType> Types => MainWindowViewModel.myConnection.PartnerTypes.ToList();

        PartnerType _selectedType;
        public PartnerType SelectedType { get => _selectedType; set => this.RaiseAndSetIfChanged ( ref _selectedType , value); }


        public AddChangePartnerVM() {
            CurentPartner = new Partner();
            SelectedType = new PartnerType() { IdType =0, TypeName = "Не определено"};
        }
        public AddChangePartnerVM(Partner partner)
        {
            CurentPartner = partner;
            SelectedType = partner.IdTypeCompanyNavigation;
        }

        public void GoBack() {
            MainWindowViewModel.Instance.PageContent = new PartnerList();
        }

        public async void SaveChange() {
            
            bool isCorectedName = CurentPartner.NameCompany != null && CurentPartner.NameCompany != " ";
            if (!isCorectedName) await MessageBoxManager.GetMessageBoxStandard("Ошибка", "Название компании не заполнено", ButtonEnum.Ok).ShowAsync();
            else {
                if (SelectedType.IdType != 0) await MessageBoxManager.GetMessageBoxStandard("Ошибка", "Выберите корректный тип партнера", ButtonEnum.Ok).ShowAsync();
                else {
                    bool isCorectedAddress = CurentPartner.LegalAddress != null && CurentPartner.LegalAddress != " ";
                    if (!isCorectedAddress) await MessageBoxManager.GetMessageBoxStandard("Ошибка", "Адрес компании не заполнен", ButtonEnum.Ok).ShowAsync();
                    else {
                        string patternFIO = @"^[А-Я][а-я]+\s[А-Я][а-я]+\s[А-Я][а-я]+$";
                        if (!Regex.IsMatch(CurentPartner.DirectorFullName, patternFIO)) await MessageBoxManager.GetMessageBoxStandard("Ошибка", "ФИО не правильно заполнено", ButtonEnum.Ok).ShowAsync();
                        else {
                            bool isCorectedPhone = (CurentPartner?.ContactPhone?.Any(c => c == '_') ?? false);
                            if (isCorectedPhone) await MessageBoxManager.GetMessageBoxStandard("Ошибка", "Телефон не полностью заполнен", ButtonEnum.Ok).ShowAsync();
                            else
                            {
                                string patternEmail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                                if (!Regex.IsMatch(CurentPartner.ContactPhone, patternEmail)) await MessageBoxManager.GetMessageBoxStandard("Ошибка", "Указан не верный email", ButtonEnum.Ok).ShowAsync();
                                else {

                                    if (CurentPartner.IdPartner == 0) { //add
                                        MainWindowViewModel.myConnection.Partners.Add(CurentPartner);
                                        MainWindowViewModel.myConnection.SaveChanges();
                                        MainWindowViewModel.Instance.PageContent = new PartnerList();
                                        await MessageBoxManager.GetMessageBoxStandard("Сообщение", "Партнер успешно добавлен!", ButtonEnum.Ok).ShowAsync();
                                    }
                                    else
                                    { //change
                                        MainWindowViewModel.myConnection.Update(CurentPartner);
                                        MainWindowViewModel.myConnection.SaveChanges();
                                        MainWindowViewModel.Instance.PageContent = new PartnerList();
                                        await MessageBoxManager.GetMessageBoxStandard("Сообщение", "Партнер успешно обновлен!", ButtonEnum.Ok).ShowAsync();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
