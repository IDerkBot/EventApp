using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EventApp.Models;
using EventApp.Models.Entity;

namespace EventApp.Pages.EditPages
{
	/// <summary>
	/// Логика взаимодействия для EquipmentEditPage.xaml
	/// </summary>
	public partial class EquipmentEditPage : Page
	{
		Equipment _currentEquipment;
		public EquipmentEditPage()
		{
			InitializeComponent();
			_currentEquipment = new Equipment();
			DataContext = _currentEquipment;
			CBTypeEquipment.ItemsSource = EventEntities.GetContext().TypeEquipments.ToList();
		}
		public EquipmentEditPage(Equipment selectedEquipment)
		{
			InitializeComponent();
			_currentEquipment = selectedEquipment;
			DataContext = _currentEquipment;
			CBTypeEquipment.ItemsSource = EventEntities.GetContext().TypeEquipments.ToList();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if(_currentEquipment.ID == 0) EventEntities.GetContext().Equipments.Add(_currentEquipment);
			EventEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные сохранены!");
			PageManager.GoBack();
		}
	}
}
