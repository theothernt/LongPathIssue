using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LongPathIssue
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void CreateFolder(object sender, RoutedEventArgs e)
        {
            var success =  StorageHelper.CreateFolder();

            if (success)
            {
                await ShowDialog("Folder created!");
            }
            else
            {
                await ShowDialog("Unable to create folder");
            }
        }

        private async void CreateFile(object sender, RoutedEventArgs e)
        {
            var success = await StorageHelper.CreateFile();

            if (success)
            {
                await ShowDialog("File created!");
            }
            else
            {
                await ShowDialog("Unable to create file");
            }
        }

        private async Task ShowDialog(string message)
        {
            var messageDialog = new MessageDialog(message);
            await messageDialog.ShowAsync();
        }
    }
}
