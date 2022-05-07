using EventApp.Models;
using EventApp.Models.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EventApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
	{
		public AuthPage()
		{
			InitializeComponent();
		}
		private void Auth_Click(object sender, RoutedEventArgs e)
		{
			if (EventEntities.GetContext().Users.Any(x => x.Login == Login.Text && x.Password == Password.Password))
			{
				PageManager.Navigate(new MenuPage());
			}
			else
			{
				MessageBox.Show("Логин или пароль введены не верно");
			}
		}

		private void Reg_Click(object sender, RoutedEventArgs e)
		{
			PageManager.Navigate(new RegPage());
		}
	}
}
