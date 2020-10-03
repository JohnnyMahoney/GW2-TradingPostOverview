using Microsoft.Win32;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
#if DEBUG
        static string toolsFolderPath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\GUILD WARS 2\tools\TradingPostOverview-DEBUG";
#else
        static string toolsFolderPath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\GUILD WARS 2\tools\TradingPostOverview";
#endif
        static string dbFilePath = toolsFolderPath + "\\Records.db";

        public ObservableCollection<Item> Watchlist { get; set; } = new ObservableCollection<Item>();

        public MainWindow()
        {
            InitializeComponent();
            InitSelf();
            LoadDB();
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
        private async void APIStatus_Click(object sender, RoutedEventArgs e)
        {
            progressBar.Visibility = Visibility.Visible;
            MessageBox.Show(await API.Request.GetApiStatus(), "API Staus");
            progressBar.Visibility = Visibility.Hidden;
        }
        private void MenuItemRemove_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Currently DEBUG functionality: Reset DB instead of remove an item
            progressBar.Visibility = Visibility.Visible;
            Watchlist.Clear();
            File.Delete(dbFilePath);
            InitSelf();
            progressBar.Visibility = Visibility.Hidden;
        }
        private async void MenuItemAdd_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Currently DEBUG functionality: Load hardcoded items instead of add an item via it's ID
            progressBar.Visibility = Visibility.Visible;

            var testItems = new List<int>() { 28445, 12452, 93567, 70010, 29169, 29181 };

            foreach (var itemID in testItems)
            {
                Item item = await API.Request.GetItem(itemID);
                await item.SetIconAsByteArray();
                await API.Request.SetPrices(item);
                DataAccess.WriteDB(item, dbFilePath);
                Watchlist.Add(item);
            }

            progressBar.Visibility = Visibility.Hidden;

        }
        #endregion

        #region Functions
        void InitSelf()
        {
            if (!Directory.Exists(toolsFolderPath))
            {
                Directory.CreateDirectory(toolsFolderPath);
            }
            if (!File.Exists(dbFilePath))
            {
                File.Copy(".\\Records.db", dbFilePath);
            }

        }
        void LoadDB()
        {
            var items = DataAccess.LoadDB(dbFilePath);
            foreach (var item in items)
            {
                Watchlist.Add(item);
            }
        }
        #endregion
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
