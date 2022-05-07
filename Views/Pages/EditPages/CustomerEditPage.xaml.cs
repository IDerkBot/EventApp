using System.Windows;
using System.Windows.Controls;
using EventApp.Models;
using EventApp.Models.Entity;

namespace EventApp.Pages.EditPages
{
	/// <summary>
	/// Логика взаимодействия для CustomerEditPage.xaml
	/// </summary>
	public partial class CustomerEditPage : Page
	{
		Customer _currentCustomer;
		public CustomerEditPage()
		{
			InitializeComponent();
			_currentCustomer = new Customer();
			DataContext = _currentCustomer;
		}
		public CustomerEditPage(Customer selectedCustomer)
		{
			InitializeComponent();
			_currentCustomer = selectedCustomer;
			DataContext = _currentCustomer;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if(_currentCustomer.ID == 0) EventEntities.GetContext().Customers.Add(_currentCustomer);
			EventEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные сохранены!");
			PageManager.GoBack();
		}
	}
}
