using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EventApp.Models;
using EventApp.Models.Entity;
using EventApp.Pages.EditPages;

namespace EventApp.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для TypeEvent.xaml
	/// </summary>
	public partial class TypeEventPage : Page
	{
		public TypeEventPage()
		{
			InitializeComponent();
		}
		private void BtnEdit_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new TypeEventEditPage((sender as Button)?.DataContext as TypeEvent));

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var typeEventsForRemoving = DGrid.SelectedItems.Cast<TypeEvent>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {typeEventsForRemoving.Count()} элементов?", "Внимание",
								MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				EventEntities.GetContext().TypeEvents.RemoveRange(typeEventsForRemoving);
				EventEntities.GetContext().SaveChanges();
				MessageBox.Show("Данные удалены!");
				DGrid.ItemsSource = EventEntities.GetContext().TypeEvents.ToList();
			}
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new TypeEventEditPage());

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			DGrid.ItemsSource = EventEntities.GetContext().TypeEvents.ToList();

		}
	}
}
