namespace DPW
{
    partial class DPW
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.bgDownload = new System.ComponentModel.BackgroundWorker();
            this.gbUrl = new System.Windows.Forms.GroupBox();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.lvlFolder = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.tbFolder = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.gbFolder = new System.Windows.Forms.GroupBox();
            this.btnFolder = new System.Windows.Forms.Button();
            this.gbUrl.SuspendLayout();
            this.gbFolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgDownload
            // 
            this.bgDownload.WorkerReportsProgress = true;
            this.bgDownload.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgDownload_DoWork);
            this.bgDownload.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgDownload_ProgressChanged);
            this.bgDownload.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgDownload_RunWorkerCompleted);
            // 
            // gbUrl
            // 
            this.gbUrl.Controls.Add(this.tbUrl);
            this.gbUrl.Controls.Add(this.lblUrl);
            this.gbUrl.Location = new System.Drawing.Point(12, 12);
            this.gbUrl.Name = "gbUrl";
            this.gbUrl.Size = new System.Drawing.Size(550, 80);
            this.gbUrl.TabIndex = 0;
            this.gbUrl.TabStop = false;
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(70, 24);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(464, 31);
            this.tbUrl.TabIndex = 4;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(11, 27);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(53, 24);
            this.lblUrl.TabIndex = 2;
            this.lblUrl.Text = "URL";
            // 
            // lvlFolder
            // 
            this.lvlFolder.AutoSize = true;
            this.lvlFolder.Location = new System.Drawing.Point(11, 27);
            this.lvlFolder.Name = "lvlFolder";
            this.lvlFolder.Size = new System.Drawing.Size(72, 24);
            this.lvlFolder.TabIndex = 3;
            this.lvlFolder.Text = "Folder";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(368, 217);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(94, 24);
            this.lblProgress.TabIndex = 8;
            this.lblProgress.Text = "100/100";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbFolder
            // 
            this.tbFolder.Location = new System.Drawing.Point(89, 24);
            this.tbFolder.Name = "tbFolder";
            this.tbFolder.Size = new System.Drawing.Size(394, 31);
            this.tbFolder.TabIndex = 5;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(468, 184);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 57);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(12, 184);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(450, 30);
            this.pb.TabIndex = 7;
            // 
            // gbFolder
            // 
            this.gbFolder.Controls.Add(this.btnFolder);
            this.gbFolder.Controls.Add(this.lvlFolder);
            this.gbFolder.Controls.Add(this.tbFolder);
            this.gbFolder.Location = new System.Drawing.Point(12, 98);
            this.gbFolder.Name = "gbFolder";
            this.gbFolder.Size = new System.Drawing.Size(550, 80);
            this.gbFolder.TabIndex = 1;
            this.gbFolder.TabStop = false;
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(489, 24);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(55, 31);
            this.btnFolder.TabIndex = 6;
            this.btnFolder.Text = "...";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // DPW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 251);
            this.Controls.Add(this.gbFolder);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.gbUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DPW";
            this.ShowIcon = false;
            this.Text = "DownloadPicturesFromWebPage";
            this.gbUrl.ResumeLayout(false);
            this.gbUrl.PerformLayout();
            this.gbFolder.ResumeLayout(false);
            this.gbFolder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgDownload;
        private System.Windows.Forms.GroupBox gbUrl;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label lvlFolder;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.TextBox tbFolder;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.GroupBox gbFolder;
        private System.Windows.Forms.Button btnFolder;
    }
}

