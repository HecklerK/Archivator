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
using System.IO.Compression;
using System.Windows.Forms;

namespace Архиватор3000
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool okF = false, okD = false;
            var fd = new FolderBrowserDialog();
            var result = fd.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    TB.Text = fd.SelectedPath;
                    okF = true;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    TB.Text = null;
                    break;
            }
            SaveFileDialog sd = new SaveFileDialog();
            sd.FileName = "Document";
            sd.DefaultExt = ".zip";
            sd.Filter = "Zip documents (.zip)|*.zip";
            result = sd.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    TB.Text = sd.FileName;
                    okD = true;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    TB.Text = null;
                    break;
            }
            if (okF == true && okD == true)
            {
                string FileP = fd.SelectedPath;
                string PZ = sd.FileName;
                ZipFile.CreateFromDirectory(FileP, PZ);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool okF = false, okD = false;
            var fd = new OpenFileDialog();
            fd.DefaultExt = ".zip";
            fd.Filter = "Zip documents (.zip)|*.zip";
            var result = fd.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    TB.Text = fd.FileName;
                    okF = true;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    TB.Text = null;
                    break;
            }
            var fb = new FolderBrowserDialog();
            result = fb.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    TB.Text = fb.SelectedPath;
                    okD = true;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    TB.Text = null;
                    break;
            }
            string zipPath = fd.FileName;
            string extractPath = fb.SelectedPath;
            if (okF == true && okD == true)
            {
                using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Read))
                {
                    archive.ExtractToDirectory(extractPath);
                }
            }
        }
    }
}
