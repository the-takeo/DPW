/*
 * The MIT License (MIT)
 * 
 * Copyright (c) 2016 the-takeo
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DPW
{
    public partial class DPW : Form
    {
        public DPW()
        {
            InitializeComponent();

            loadSetting();
            refleshView();
        }

        private string Url
        {
            get { return tbUrl.Text; }
            set { tbUrl.Text = value; }
        }

        private string Folder
        {
            get { return tbFolder.Text; }
            set { tbFolder.Text = value; }
        }

        private int allPictureNum = 0;
        private int count = 0;

        private List<string> urls = new List<string>();
        private List<string> errorUrls = new List<string>();

        private void btnFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.Desktop;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Folder = fbd.SelectedPath;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            startProgress();

            urls = GetPictures.getPicturesUrl(Url, null);
            bgDownload.RunWorkerAsync();
        }

        private void bgDownload_DoWork(object sender, DoWorkEventArgs e)
        {
            Download dl = new Download();

            allPictureNum = urls.Count;

            foreach (var url in urls)
            {
                try { dl.StartDownload(url, Folder); }
                finally
                {
                    count++;
                    bgDownload.ReportProgress(count);
                }
            }

        }

        private void bgDownload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblProgress.Text = string.Format("{0}/{1}",
                count.ToString(), allPictureNum.ToString());

            pb.Value = 100 * count / allPictureNum;
        }

        private void bgDownload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("ダウンロードが完了しました。");

            saveSetting();
            refleshView();
            endProgress();
        }

        private void refleshView()
        {
            count = 0;
            allPictureNum = 0;
            lblProgress.Text = string.Format("{0}/{1}",
                count.ToString(), allPictureNum.ToString());
            pb.Value = 0;

            urls = new List<string>();
            errorUrls = new List<string>();
        }

        private void saveSetting()
        {
            Properties.Settings.Default.Url = Url;
            Properties.Settings.Default.Folder = Folder;
            Properties.Settings.Default.Save();
        }

        private void loadSetting()
        {
            Url = Properties.Settings.Default.Url;
            Folder = Properties.Settings.Default.Folder;
        }

        private void startProgress()
        {
            tbUrl.Enabled = false;
            tbFolder.Enabled = false;
            btnFolder.Enabled = false;
            btnStart.Enabled = false;
        }

        private void endProgress()
        {
            tbUrl.Enabled = true;
            tbFolder.Enabled = true;
            btnFolder.Enabled = true;
            btnStart.Enabled = true;
        }
    }
}
