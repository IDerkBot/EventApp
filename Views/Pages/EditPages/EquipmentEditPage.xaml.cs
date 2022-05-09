using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using EventApp.Models;
using EventApp.Models.Entity;

namespace EventApp.Views.Pages.EditPages
{
	/// <summary>
	/// Логика взаимодействия для EquipmentEditPage.xaml
	/// </summary>
	public partial class EquipmentEditPage : Page
	{
		private readonly Equipment _currentEquipment;
		public EquipmentEditPage()
		{
			InitializeComponent();
			_currentEquipment = new Equipment();
			DataContext = _currentEquipment;
			CbTypeEquipment.ItemsSource = EventEntities.GetContext().TypeEquipments.ToList();
		}
		public EquipmentEditPage(Equipment selectedEquipment)
		{
			InitializeComponent();
			_currentEquipment = selectedEquipment;
			DataContext = _currentEquipment;
			CbTypeEquipment.ItemsSource = EventEntities.GetContext().TypeEquipments.ToList();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if(_currentEquipment.ID == 0) EventEntities.GetContext().Equipments.Add(_currentEquipment);
			EventEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные сохранены!");
			PageManager.GoBack();
		}
        private void UIElement_OnDrop(object sender, DragEventArgs e)
        {
            SpView.Visibility = Visibility.Collapsed;
            ImageView.Visibility = Visibility.Visible;
            var filePath = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (filePath == null) return;
            _currentEquipment.Image = File.ReadAllBytes(filePath[0]);
            var ms = new MemoryStream(_currentEquipment.Image);
            var source = new BitmapImage();
            source.BeginInit();
            source.StreamSource = ms;
            source.EndInit();
            ImageView.Source = source;
        }
	}
}
