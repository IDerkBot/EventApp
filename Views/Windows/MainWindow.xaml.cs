using System;
using System.Windows;
using EventApp.Models;
using EventApp.Views.Pages;

namespace EventApp.Views.Windows
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			PageManager.SetFrame(MainFrame);
			PageManager.Navigate(new AuthPage());
		}

		private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            BtnBack.Visibility = PageManager.CanGoBack() ? Visibility.Visible : Visibility.Hidden;
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			PageManager.GoBack();
		}
	}
}
