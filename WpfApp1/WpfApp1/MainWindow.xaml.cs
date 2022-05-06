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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LaunchUri();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LaunchUri();
        }
        private async void LaunchUri()
        {
            string sPath = @"D:\butterfly.png";
            var file = await Windows.Storage.StorageFile.GetFileFromPathAsync(sPath);
            var sToken = Windows.ApplicationModel.DataTransfer.SharedStorageAccessManager.AddFile(file);

            var sUri = String.Format("ms-screensketch:edit?source=MyApp&isTemporary=false&sharedAccessToken={0}", sToken);
            bool bResult = await Windows.System.Launcher.LaunchUriAsync(new Uri(sUri));
            if (bResult)
            {
                // URI launched
            }
            else
            {
                // URI launch failed
            }
        }
    }
}
