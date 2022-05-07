using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EventApp.Models;
using EventApp.Models.Entity;
using EventApp.Pages.EditPages;

namespace EventApp.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для UserPage.xaml
	/// </summary>
	public partial class UserPage : Page
	{
		public UserPage()
		{
			InitializeComponent();
		}

		private void BtnEdit_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new UserEditPage((sender as Button)?.DataContext as User));

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var usersForRemoving = DGrid.SelectedItems.Cast<User>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {usersForRemoving.Count()} элементов?", "Внимание",
								MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				EventEntities.GetContext().Users.RemoveRange(usersForRemoving);
				EventEntities.GetContext().SaveChanges();
				MessageBox.Show("Данные удалены!");
				DGrid.ItemsSource = EventEntities.GetContext().Users.ToList();
			}
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new UserEditPage());

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			DGrid.ItemsSource = EventEntities.GetContext().Users.ToList();

		}
	}
}
