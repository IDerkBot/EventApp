using System.Windows;
using System.Windows.Controls;
using EventApp.Models;

namespace EventApp.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для Menu.xaml
	/// </summary>
	public partial class MenuPage : Page
	{
		public MenuPage()
		{
			InitializeComponent();
            BtnUserMovePage.Visibility = Data.IsDirector() ? Visibility.Visible : Visibility.Collapsed;
            BtnTypeEquipmentMovePage.Visibility = Data.IsDirector() ? Visibility.Visible : Visibility.Collapsed;
        }

        private void BtnCustomerMovePage_OnClick(object sender, RoutedEventArgs e) =>
            PageManager.Navigate(new CustomerPage());

        private void BtnEquipmentMovePage_OnClick(object sender, RoutedEventArgs e) =>
            PageManager.Navigate(new EquipmentPage());

        private void BtnTypeEquipmentMovePage_OnClick(object sender, RoutedEventArgs e) =>
            PageManager.Navigate(new TypeEquipmentPage());

        private void BtnUserMovePage_OnClick(object sender, RoutedEventArgs e) =>
            PageManager.Navigate(new UserPage());

        private void BtnRentMovePage_OnClick(object sender, RoutedEventArgs e) =>
            PageManager.Navigate(new RentPage());

    }
}
