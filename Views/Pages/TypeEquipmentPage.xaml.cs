using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EventApp.Models;
using EventApp.Models.Entity;
using EventApp.Pages.EditPages;

namespace EventApp.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для TypeEquipmentPage.xaml
	/// </summary>
	public partial class TypeEquipmentPage : Page
	{
		public TypeEquipmentPage()
		{
			InitializeComponent();
		}

		private void BtnEdit_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new TypeEquipmentEditPage((sender as Button)?.DataContext as TypeEquipment));

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var typeEquipmentsForRemoving = DGrid.SelectedItems.Cast<TypeEquipment>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {typeEquipmentsForRemoving.Count()} элементов?", "Внимание",
								MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				EventEntities.GetContext().TypeEquipments.RemoveRange(typeEquipmentsForRemoving);
				EventEntities.GetContext().SaveChanges();
				MessageBox.Show("Данные удалены!");
				DGrid.ItemsSource = EventEntities.GetContext().TypeEquipments.ToList();
			}
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new TypeEquipmentEditPage());

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			DGrid.ItemsSource = EventEntities.GetContext().TypeEquipments.ToList();
		}
	}
}
