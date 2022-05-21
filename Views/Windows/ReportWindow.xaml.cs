using EventApp.Models.Entity;
using System.Linq;
using System.Windows;

namespace EventApp.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (DpStart.SelectedDate == null || DpEnd.SelectedDate == null)
            {
                MessageBox.Show("Выберите даты");
                return;
            }
            else
            {
                var orders = EventEntities.GetContext().Rents
                    .Where(x => x.DateStart >= DpStart.SelectedDate && x.DateStart <= DpEnd.SelectedDate).ToList();
                TblCount.Text = $"Количество заказов: {orders.Count}";
                TblSum.Text = $"Сумма: {orders.Sum(x => x.Sum)}";
            }
        }
    }
}
