using EventApp.Models;
using EventApp.Models.Entity;
using System.Windows;
using System.Windows.Controls;

namespace EventApp.Pages.EditPages
{
	/// <summary>
	/// Логика взаимодействия для UserEditPage.xaml
	/// </summary>
	public partial class UserEditPage : Page
	{
		User _currentUser;
		public UserEditPage()
		{
			InitializeComponent();
			_currentUser = new User();
			DataContext = _currentUser;
		}
		public UserEditPage(User selectedUser)
		{
			InitializeComponent();
			_currentUser = selectedUser;
			DataContext = _currentUser;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (_currentUser.ID == 0) EventEntities.GetContext().Users.Add(_currentUser);
			EventEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные сохранены!");
			PageManager.GoBack();
		}
	}
}
