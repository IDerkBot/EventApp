using EventApp.Models;
using EventApp.Models.Entity;
using EventApp.Views.Pages.EditPages;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EventApp.Views.Windows;

namespace EventApp.Views.Pages
{
    /// <summary>
    /// Interaction logic for RentPage.xaml
    /// </summary>
    public partial class RentPage : Page
    {
        public RentPage()
        {
            InitializeComponent();
        }

        private void BtnEdit_OnClick(object sender, RoutedEventArgs e) => PageManager.Navigate(new RentEditPage((sender as Button)?.DataContext as Rent));

        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            var items = DgRent.SelectedItems.Cast<Rent>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {items.Count} элементов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes) return;

            EventEntities.GetContext().Rents.RemoveRange(items);
            
            EventEntities.GetContext().SaveChanges();
            MessageBox.Show("Данные удалены!");
            DgRent.ItemsSource = EventEntities.GetContext().Rents.ToList();

        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e) => PageManager.Navigate(new RentEditPage());

        private void RentPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            DgRent.ItemsSource = EventEntities.GetContext().Rents.ToList();
        }

        private void BtnMore_OnClick(object sender, RoutedEventArgs e) => PageManager.Navigate(new RentInfoPage((sender as Button)?.DataContext as Rent));

        private void BtnReport_OnClick(object sender, RoutedEventArgs e)
        {
            new ReportWindow().Show();
        }
    }
}
