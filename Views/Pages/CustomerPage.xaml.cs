using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EventApp.Models;
using EventApp.Models.Entity;
using EventApp.Pages.EditPages;

namespace EventApp.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для CustomerPage.xaml
	/// </summary>
	public partial class CustomerPage : Page
	{
		public CustomerPage()
		{
			InitializeComponent();
		}

		private void BtnEdit_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new CustomerEditPage((sender as Button)?.DataContext as Customer));

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var customersForRemoving = DGrid.SelectedItems.Cast<Customer>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {customersForRemoving.Count()} элементов?", "Внимание",
								MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				EventEntities.GetContext().Customers.RemoveRange(customersForRemoving);
				EventEntities.GetContext().SaveChanges();
				MessageBox.Show("Данные удалены!");
				DGrid.ItemsSource = EventEntities.GetContext().Customers.ToList();
			}
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new CustomerEditPage());

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			DGrid.ItemsSource = EventEntities.GetContext().Customers.ToList();
		}
	}
}
