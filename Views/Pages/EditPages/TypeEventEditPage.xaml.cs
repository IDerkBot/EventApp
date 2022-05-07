using EventApp.Models;
using EventApp.Models.Entity;
using System.Windows;
using System.Windows.Controls;

namespace EventApp.Pages.EditPages
{
	/// <summary>
	/// Логика взаимодействия для TypeEventEditPage.xaml
	/// </summary>
	public partial class TypeEventEditPage : Page
	{
		TypeEvent _currentTypeEvent;
		public TypeEventEditPage()
		{
			InitializeComponent();
			_currentTypeEvent = new TypeEvent();
			DataContext = _currentTypeEvent;
		}
		public TypeEventEditPage(TypeEvent selectedTypeEvent)
		{
			InitializeComponent();
			_currentTypeEvent = selectedTypeEvent;
			DataContext = _currentTypeEvent;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (_currentTypeEvent.ID == 0) EventEntities.GetContext().TypeEvents.Add(_currentTypeEvent);
			EventEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные сохранены!");
			PageManager.GoBack();
		}
	}
}
