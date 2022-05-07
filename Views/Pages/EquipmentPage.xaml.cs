using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EventApp.Models;
using EventApp.Models.Entity;
using EventApp.Pages.EditPages;

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

		private void BtnEdit_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new EquipmentEditPage((sender as Button).DataContext as Equipment));

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var equipmentsForRemoving = DGrid.SelectedItems.Cast<Equipment>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {equipmentsForRemoving.Count()} элементов?", "Внимание",
								MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				EventEntities.GetContext().Equipments.RemoveRange(equipmentsForRemoving);
				EventEntities.GetContext().SaveChanges();
				MessageBox.Show("Данные удалены!");
				DGrid.ItemsSource = EventEntities.GetContext().Equipments.ToList();
			}
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new EquipmentEditPage());

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			DGrid.ItemsSource = EventEntities.GetContext().Equipments.ToList();

		}
	}
}
