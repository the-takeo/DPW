using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPW
{
    public class Model : System.ComponentModel.INotifyPropertyChanged
    {
        #region WPFデータバインド用

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(name));
            }
        }

        #endregion

        private string url_;
        private string folder_;
        private List<string> urls_;

        public string Url
        {
            get
            {
                return url_;
            }
            set
            {
                url_ = value;
                OnPropertyChanged("Url");
            }
        }
        public string Folder
        {
            get
            {
                return folder_;
            }
            set
            {
                folder_ = value;
                OnPropertyChanged("Folder");
            }
        }

        public List<string> Urls
        {
            get 
            {
                if (urls_ == null)
                { return GetPictures.getPicturesUrl(Url, null); }
                else
                { return urls_; }
            }
        }

        public int count { get; set; }

        public Model()
        { LoadSetting(); }

        public void LoadSetting()
        {
            Url = Properties.Settings.Default.Url;
            Folder = Properties.Settings.Default.Folder;
        }

        public void SaveSetting()
        {
            Properties.Settings.Default.Url = Url;
            Properties.Settings.Default.Folder = Folder;

            Properties.Settings.Default.Save();
        }

        public void refleshUrls()
        { urls_ = null; }

        public void getUrls()
        {
            urls_ = GetPictures.getPicturesUrl(Url, null);
        }
    }
}
