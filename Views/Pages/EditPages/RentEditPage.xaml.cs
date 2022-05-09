using EventApp.Models.Entity;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EventApp.Models;

namespace EventApp.Views.Pages.EditPages
{
    /// <summary>
    /// Interaction logic for RentEditPage.xaml
    /// </summary>
    public partial class RentEditPage : Page
    {
        private readonly Rent _currentRent;
        public RentEditPage(Rent selectedRent = null)
        {
            InitializeComponent();
            _currentRent = selectedRent ?? new Rent();
            if(selectedRent == null) DpDateStart.SelectedDate = DateTime.Now;
            LvEquipments.ItemsSource = EventEntities.GetContext().Equipments.ToList();
            CbCustomers.ItemsSource = EventEntities.GetContext().Customers.ToList();
            DataContext = _currentRent;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if(_currentRent.CountDay == 0) return;
            if(_currentRent.Sum == 0.0m) return;
            if (TbCount.Text == "")
            {
                MessageBox.Show("Введите количество дней!");
                return;
            }
            if (_currentRent.ID == 0) EventEntities.GetContext().Rents.Add(_currentRent);
            EventEntities.GetContext().SaveChanges();
            MessageBox.Show("Данные сохранены!");
            PageManager.GoBack();
        }

        private void LvEquipments_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculateSum();
        }

        private void CalculateSum()
        {
            if (TbCount.Text == "") return;
            if (int.TryParse(TbCount.Text, out var count))
            {
                var selectedEquipments = LvEquipments.SelectedItems.Cast<Equipment>().ToList();
                var sum1 = selectedEquipments.Sum(x => x.Cost);

                var totalSum = sum1 * count;
                TbSum.Text = $"{totalSum}";
                _currentRent.Equipments = selectedEquipments;
                _currentRent.Sum = totalSum;
                _currentRent.CountDay = count;
            }
            else MessageBox.Show("Введите число без запятых и точек!");
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if(TbCount.Text == "") return;
            CalculateSum();
        }
    }
}
