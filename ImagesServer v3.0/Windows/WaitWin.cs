using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagesServer_v3._0
{
    public partial class WaitWin : Form
    {
        public Action _Worker { get; set; }

        public WaitWin(Action Worker, string TaskOnProcess)
        {
            InitializeComponent();
            RoundObjects();
            if (Worker == null) throw new ArgumentNullException();

            _Worker = Worker;
            lblTaskOnProcess.Text = "PLEASE WAIT...\n \n" + TaskOnProcess;

            //lblTaskOnProcess.Left = (this.ClientSize.Width - lblTaskOnProcess.Width) / 2;
            //lblTaskOnProcess.Top = (this.ClientSize.Height - lblTaskOnProcess.Height) / 2;

            //progressBar1.Left = (this.ClientSize.Width - progressBar1.Width) / 2;
            //progressBar1.Top = (this.ClientSize.Height - progressBar1.Height + 100) / 2;
        }

        void RoundObjects()
        {
            progressBar1.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, progressBar1.Width, progressBar1.Height, 10, 10));
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(_Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
