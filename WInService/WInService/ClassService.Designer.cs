using System.IO;

namespace WInService
{
    partial class Service2
    {
        FileInfo f;
        StreamWriter writer;
        FileSystemWatcher watcher;

        public Service2()
        {
            InitializeComponent();

            f = new FileInfo(@"\C:\Users\kanstantsin.karatkev\source\repos\Richter\MultiDomains\Log.txt");
            writer = f.CreateText();

            watcher = new
                FileSystemWatcher(@"\C:\Users\kanstantsin.karatkev\source\repos\Richter\MultiDomains\Log.txt");

            watcher.Created += WatcherChanged;

        }
        void WatcherChanged(object sender, FileSystemEventArgs e)
        {
            writer.WriteLine("Directory changed({0}): {1}", e.ChangeType, e.FullPath);
            writer.Flush();
        }
        protected override void OnStart(string[] args)
        {

        }
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.ServiceName = "Service2";
        }

        #endregion
    }
}
