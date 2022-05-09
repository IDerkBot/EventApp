using EventApp.Models;
using EventApp.Models.Entity;
using EventApp.Views.Pages.EditPages;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EventApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для EquipmentPage.xaml
    /// </summary>
    public partial class EquipmentPage : Page
	{
		public EquipmentPage()
		{
			InitializeComponent();
		}

        private bool _view;
        private bool _load;

		private void BtnEdit_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new EquipmentEditPage((sender as Button)?.DataContext as Equipment));

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var equipmentsForRemoving = DgEquipment.SelectedItems.Cast<Equipment>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {equipmentsForRemoving.Count()} элементов?", "Внимание",
								MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				EventEntities.GetContext().Equipments.RemoveRange(equipmentsForRemoving);
				EventEntities.GetContext().SaveChanges();
				MessageBox.Show("Данные удалены!");
				DgEquipment.ItemsSource = EventEntities.GetContext().Equipments.ToList();
			}
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new EquipmentEditPage());

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
            DgEquipment.ItemsSource = EventEntities.GetContext().Equipments.ToList();
			LvEquipment.ItemsSource = EventEntities.GetContext().Equipments.ToList();
            _load = true;
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
			if (!_load) return;
            if (_view == false)
            {
                _view = true;
                LvEquipment.Visibility = Visibility.Visible;
                DgEquipment.Visibility = Visibility.Collapsed;
            }
            else
            {
                _view = false;
                LvEquipment.Visibility = Visibility.Collapsed;
                DgEquipment.Visibility = Visibility.Visible;
            }
		}
    }
}
