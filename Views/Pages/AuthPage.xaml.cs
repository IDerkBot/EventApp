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
			if (EventEntities.GetContext().Users.Any(x => x.Login == TbLogin.Text))
            {
                var user = EventEntities.GetContext().Users.Single(x => x.Login == TbLogin.Text);

                if (user.Password == PbPassword.Password)
                {
                    Data.Access = user.Access;
                    if (IsRemember.IsChecked == true) FileManager.SetConfig(new Config(user.Login, user.Password, true));
                    PageManager.Navigate(new MenuPage());
				}
                else
                    MessageBox.Show("Пароль не верный");
			}
			else
				MessageBox.Show("Логин или пароль введены не верно");
		}

		private void Reg_Click(object sender, RoutedEventArgs e)
		{
			PageManager.Navigate(new RegPage());
		}

        private void AuthPage_OnLoaded(object sender, RoutedEventArgs e)
        {
			var config = FileManager.GetConfig();
            if (!config.RememberMe) return;
            TbLogin.Text = config.Login;
            PbPassword.Password = config.Password;
            IsRemember.IsChecked = true;
		}
    }
}
