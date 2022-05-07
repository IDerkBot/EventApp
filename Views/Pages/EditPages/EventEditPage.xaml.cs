using EventApp.Models;
using EventApp.Models.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EventApp.Pages.EditPages
{
	/// <summary>
	/// Логика взаимодействия для EventEditPage.xaml
	/// </summary>
	public partial class EventEditPage : Page
	{
		private readonly Event _currentEvent;
		private readonly bool _isEditing;
		public EventEditPage()
		{
			InitializeComponent();
			CBCustomer.ItemsSource = EventEntities.GetContext().Customers.ToList();
			CBEquipment.ItemsSource = EventEntities.GetContext().Equipments.ToList();
			CBTypeEvent.ItemsSource = EventEntities.GetContext().TypeEvents.ToList();
			_currentEvent = new Event();
			DataContext = _currentEvent;
			_isEditing = false;
		}
		public EventEditPage(Event selectedEvent)
		{
			InitializeComponent();
			CBCustomer.ItemsSource = EventEntities.GetContext().Customers.ToList();
			CBEquipment.ItemsSource = EventEntities.GetContext().Equipments.ToList();
			CBTypeEvent.ItemsSource = EventEntities.GetContext().TypeEvents.ToList();
			_currentEvent = selectedEvent;
			DataContext = _currentEvent;
			_isEditing = true;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if(_isEditing == false) EventEntities.GetContext().Events.Add(_currentEvent);
			EventEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные сохранены!");
			PageManager.GoBack();
		}
	}
}
