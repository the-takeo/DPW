using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DPW
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        Model model { get; set; }
        System.ComponentModel.BackgroundWorker bgWorker;

        public MainWindow()
        {
            InitializeComponent();

            model = new Model();
            this.DataContext = model;
        }

        private void btnFolder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.Desktop;

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                model.Folder = fbd.SelectedPath;
            }
        }

        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            startProgress();
            model.getUrls();

            bgWorker = new System.ComponentModel.BackgroundWorker();
            bgWorker.WorkerReportsProgress = true;
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.ProgressChanged += bgWorker_ProgressChanged;
            bgWorker.RunWorkerCompleted += bgWorker_RunWorkerCompleted;

            bgWorker.RunWorkerAsync();
        }

        void bgWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            System.Windows.MessageBox.Show("ダウンロードが完了しました。");

            model.SaveSetting();
            refleshView();
            endProgress();
        }

        void bgWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pb.Value = 100 * model.count / model.Urls.Count;
        }

        void bgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Download dl = new Download();

            //allPictureNum = model.Urls.Count;

            foreach (var url in model.Urls)
            {
                try { dl.StartDownload(url, model.Folder); }
                finally
                {
                    //バインドを検討
                    model.count++;
                    bgWorker.ReportProgress(model.count);
                }
            }
        }

        private void refleshView()
        {
            model.refleshUrls();
            pb.Value = 0;
        }

        private void startProgress()
        {
            tbUrl.IsEnabled = false;
            tbFolder.IsEnabled = false;
            btnFolder.IsEnabled = false;
            btnDownload.IsEnabled = false;
        }

        private void endProgress()
        {
            tbUrl.IsEnabled = true;
            tbFolder.IsEnabled = true;
            btnFolder.IsEnabled = true;
            btnDownload.IsEnabled = true;
        }


    }
}
