using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EventApp.Models;
using EventApp.Models.Entity;

namespace EventApp.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для RegPage.xaml
	/// </summary>
	public partial class RegPage : Page
	{
		public RegPage()
		{
			InitializeComponent();
		}

		private void Reg_Click(object sender, RoutedEventArgs e)
		{
			if (EventEntities.GetContext().Users.Any(x => x.Login == Login.Text))
			{
				MessageBox.Show("Пользователь уже существует");
			}
			else
			{
				EventEntities.GetContext().Users.Add(new User() { Login = Login.Text, Password = Password.Password });
				EventEntities.GetContext().SaveChanges();
				PageManager.GoBack();
			}
		}
	}
}
