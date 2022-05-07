using EventApp.Models;
using EventApp.Models.Entity;
using System.Windows;
using System.Windows.Controls;

namespace EventApp.Pages.EditPages
{
	/// <summary>
	/// Логика взаимодействия для TypeEquipmentEditPage.xaml
	/// </summary>
	public partial class TypeEquipmentEditPage : Page
	{
		TypeEquipment _currentTypeEquipment;
		public TypeEquipmentEditPage()
		{
			InitializeComponent();
			_currentTypeEquipment = new TypeEquipment();
			DataContext = _currentTypeEquipment;
		}
		public TypeEquipmentEditPage(TypeEquipment selectedTypeEquipment)
		{
			InitializeComponent();
			_currentTypeEquipment = selectedTypeEquipment;
			DataContext = _currentTypeEquipment;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (_currentTypeEquipment.ID == 0) EventEntities.GetContext().TypeEquipments.Add(_currentTypeEquipment);
			EventEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные сохранены!");
			PageManager.GoBack();
		}
	}
}
