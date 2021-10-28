using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ImagesServer_v3._0
{
    public partial class RemoveDongle : Form
    {
        public RemoveDongle()
        {
            InitializeComponent();

        }

        private void RemoveDongle_Load(object sender, EventArgs e)
        {

            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
            pictureBox1.Top = (this.ClientSize.Height - pictureBox1.Width) / 2;

        OK: {
                //poka-yoke remove dongle
            }
            MessageBox.Show("Remueva el usb para continuar...", "Server mapped successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bool _dongle = false;
            string _dongleA = @"A:\JABIL\DONGLE\";
            if (Directory.Exists(_dongleA)) _dongle = true;
            string _dongleB = @"B:\JABIL\DONGLE\";
            if (Directory.Exists(_dongleB)) _dongle = true;
            string _dongleC = @"C:\JABIL\DONGLE\";
            if (Directory.Exists(_dongleC)) _dongle = true;
            string _dongleD = @"D:\JABIL\DONGLE\";
            if (Directory.Exists(_dongleD)) _dongle = true;
            string _dongleE = @"E:\JABIL\DONGLE\";
            if (Directory.Exists(_dongleE)) _dongle = true;
            string _dongleF = @"F:\JABIL\DONGLE\";
            if (Directory.Exists(_dongleF)) _dongle = true;
            string _dongleG = @"G:\JABIL\DONGLE\";
            if (Directory.Exists(_dongleG)) _dongle = true;
            string _dongleH = @"H:\JABIL\DONGLE\";
            if (Directory.Exists(_dongleH)) _dongle = true;
            string _dongleI = @"I:\JABIL\DONGLE";
            if (Directory.Exists(_dongleI)) _dongle = true;
            string _dongleJ = @"J:\JABIL\DONGLE\";
            if (Directory.Exists(_dongleJ)) _dongle = true;

            if (_dongle) goto OK;

            lblStatus.Text = "Copying files...";
            CopyImagesServerToX();
            lblStatus.Text = "Initializing...";
            Form1 MainWin = new Form1();
            this.Hide();
            MainWin.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void CopyImagesServerToX()
        {
            string _from = @"\\mxchim0pangea01\AUTOMATION_SSCO\IMAGES_SERVER_2.0\Release\";
            string _to = @"X:\ImagesServer\";

            DirectoryInfo _dirInfo = new DirectoryInfo(_from);
            FileInfo[] _filesInfo = _dirInfo.GetFiles();

            try
            {
                foreach (FileInfo _file in _filesInfo)
                {
                    lblStatus.Text = "Copying file: " + _file.Name;
                    this.Refresh();
                    File.Copy(_file.FullName, _to + _file.Name, true);
                }
            }
            catch (Exception)
            {

            }
        }

        int MapNewDrive(string Args)
        {
            string _NetProc = "net.exe";
            int _result = ExternalExe(_NetProc, Args);
            return _result;
        }

        //Function to initialize an external application and wait for finish process and return the exit code from external application
        int ExternalExe(string FileName, string Args)
        {
            int _result = 0;
            Process _process = new Process();
            _process.StartInfo.FileName = FileName;
            _process.StartInfo.Arguments = Args;
            _process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            _process.Start();
            _process.WaitForExit();
            _result = _process.ExitCode;
            return _result;
        }
    }
}
