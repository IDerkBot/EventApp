using System.Windows.Controls;
using EventApp.Pages;
using EventApp.Views.Pages;

namespace EventApp.Models
{
	internal class PageManager
	{
        private static Frame MainFrame { get; set; }
        public static void SetFrame(Frame frame)
        {
            MainFrame = frame;
        }
        public static void Navigate(Page moveToPage)
        {
            MainFrame.Navigate(moveToPage);
        }
        public static void GoBack()
        {
            if (MainFrame.CanGoBack)
                MainFrame.GoBack();
        }
        public static bool CanGoBack()
        {
            return MainFrame.CanGoBack;
        }
        public static Page GetPage()
        {
            return MainFrame.Content as Page;
        }
    }
}