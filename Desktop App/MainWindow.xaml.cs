using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
        string dbFolderPath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\GUILD WARS 2\tools";
        string dbName = "MyTradingPostData.db";
        public MainWindow()
        {
            if (!Directory.Exists(dbFolderPath))
            {
                Directory.CreateDirectory(dbFolderPath);
            }
            DB_Handling.Helper.ImportDB(dbFolderPath, dbName);
            
            InitializeComponent();
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

    }
}
