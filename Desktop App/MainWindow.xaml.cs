using Microsoft.Win32;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace TradingPostOverview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string toolsFolderPath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\GUILD WARS 2\tools\TradingPostOverview";
        string dbFilePath = toolsFolderPath + "\\MyTradingPostData.db";

        public ObservableCollection<Item> Watchlist { get; set; } = new ObservableCollection<Item>();

        public MainWindow()
        {
            InitializeComponent();

            if (!Directory.Exists(toolsFolderPath))
            {
                Directory.CreateDirectory(toolsFolderPath);
            }
            DB_Handling.Helper.ImportDB(toolsFolderPath, dbFilePath);

            TestGetItems();
        }

        #region MenuLogic
        private void MenuItemImport_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Import Database...";
            openFileDialog.Filter = "Database file (*.db)|*.db";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                // TODO: Import Database
            }
        }

        private void MenuItemExport_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Database...";
            saveFileDialog.Filter = "Database file (*.db)|*.db";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog.FileName = "MyTradingPostData.db";
            if (saveFileDialog.ShowDialog() == true)
            {
                // TODO: Export Database
            }
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion

        async void TestGetItems()
        {
            progressBar.Visibility = Visibility.Visible;

            var testItems = new List<int>() { 28445, 12452, 93567, 70010, 29169, 29181 };

            foreach (var itemID in testItems)
            {
                Item item = await API.Request.GetItem(itemID);
                await API.Request.SetPrices(item);
                Watchlist.Add(item);
            }

            progressBar.Visibility = Visibility.Hidden;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // TODO: Write DB on closing?!
        }

        private async void APIStatus_Click(object sender, RoutedEventArgs e)
        {
            progressBar.Visibility = Visibility.Visible;
            MessageBox.Show(await API.Request.GetApiStatus(), "API Staus");
            progressBar.Visibility = Visibility.Hidden;
        }

    }
}
