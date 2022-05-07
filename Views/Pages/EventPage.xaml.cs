using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EventApp.Models;
using EventApp.Models.Entity;
using EventApp.Pages.EditPages;

namespace EventApp.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для EventPage.xaml
	/// </summary>
	public partial class EventPage : Page
	{
		public EventPage()
		{
			InitializeComponent();
		}

		private void BtnEdit_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new EventEditPage((sender as Button)?.DataContext as Event));

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var eventsForRemoving = DGrid.SelectedItems.Cast<Event>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {eventsForRemoving.Count()} элементов?", "Внимание",
								MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				EventEntities.GetContext().Events.RemoveRange(eventsForRemoving);
				EventEntities.GetContext().SaveChanges();
				MessageBox.Show("Данные удалены!");
				DGrid.ItemsSource = EventEntities.GetContext().Events.ToList();
			}
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new EventEditPage());

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			DGrid.ItemsSource = EventEntities.GetContext().Events.ToList();
		}
	}
}
