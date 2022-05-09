using EventApp.Models.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EventApp.Views.Pages
{
    /// <summary>
    /// Interaction logic for RentInfoPage.xaml
    /// </summary>
    public partial class RentInfoPage : Page
    {
        private readonly Rent _currentRent;
        public RentInfoPage(Rent selectedRent)
        {
            InitializeComponent();
            _currentRent = selectedRent;
            DataContext = _currentRent;
        }

        private void RentInfoPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            LvEquipments.ItemsSource = EventEntities.GetContext().Rents.Single(x => x.ID == _currentRent.ID).Equipments.ToList();
        }
    }
}
