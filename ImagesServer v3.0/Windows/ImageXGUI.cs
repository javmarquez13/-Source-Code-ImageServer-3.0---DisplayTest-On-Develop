using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagedWimLib;

namespace ImagesServer_v3._0
{
    public partial class ImageXGUI : Form
    {
        private ApplyOrCapture _ApplyOrCapture;
        private OpenFlags _OpenFlags;
        private ExtractFlags _ExtractFlags;


        string _WimToInstall, _TargetPath;
        int _Index;
        float _elapsedTime = 0;

        public double Percent { get; set; }

        public enum ApplyOrCapture
        {
            Apply,
            Capture
        }

        public ImageXGUI(ApplyOrCapture ApplyOrCapture, int Index, string WimToInstall, string TargetPath, OpenFlags OpenFlags, ExtractFlags ExctracFlags)
        {
            InitializeComponent();
            RoundObjects();
            _ApplyOrCapture = ApplyOrCapture;
            _WimToInstall = WimToInstall;
            _TargetPath = TargetPath;
            _Index = Index;
            _OpenFlags = OpenFlags;          
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        void RoundObjects()
        {
            panel1.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 10, 10));
            progressBar1.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, progressBar1.Width, progressBar1.Height, 10, 10));
        }

        private void ImageXGUI_Load(object sender, EventArgs e)
        {
            this.Activated += AfterLoading;
        }

        private void AfterLoading(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            timer1.Start();
            timer2.Start();
            this.Activated -= AfterLoading;
            backgroundWorker1.RunWorkerAsync();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            _elapsedTime++;
            TimeSpan _tim = TimeSpan.FromSeconds(_elapsedTime);
            lblElapsedTime.Text = String.Format(@"Elapsed Time: {0:hh\:mm\:ss}", _tim);
            lblElapsedTime.Refresh();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                Percent = _ExtractProgress.CompletedBytes * 100 / _ExtractProgress.TotalBytes;
                progressBar1.Value = (int)Percent;
                lblPercent.Text = "Progress: " + Percent.ToString() + "%";
                lblPercent.Refresh();
                progressBar1.Refresh();
            }
            catch (Exception)
            {

            }

        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_ApplyOrCapture == ApplyOrCapture.Apply) ApplyWimLib(_Index, _WimToInstall, _TargetPath, _OpenFlags, _ExtractFlags);      
        }

        #region WIMLib



        void CaptureWimLib(CompressionType Type, string Source, string Name, string ConfigFile, AddFlags Flags, string PathToSaveImage, int IndexImage, WriteFlags WriteFlags)
        {
            try
            {
                using (Wim wim = Wim.CreateNewWim(Type))
                {
                    try
                    {
                        //wim.RegisterCallback(CallBackDelegate);
                        //wim.AddImage(@"c:\", "OS", null, AddFlags.Verbose);
                        //wim.Write(@"W:\NewWim_1.wim", 1, WriteFlags.CheckIntegrity, 0);

                        wim.RegisterCallback(CallBackDelegate);
                        wim.AddImage(Source, Name, ConfigFile, Flags);
                        wim.Write(PathToSaveImage, IndexImage, WriteFlags, 0);
                    }
                    finally
                    {
                        
                    }
                }

                lblEvents.Text = "The operation was successfully!";
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                lblHandleError.Text = ex.Message;
            }
        }

        void ApplyWimLib(int __Index, string __WimToInstall, string __TargetPath, OpenFlags __OpenFlags, ExtractFlags __ExtracFlags)
        {
            try
            {
                using (Wim wim = Wim.OpenWim(__WimToInstall, __OpenFlags, CallBackDelegate))
                {
                    try
                    {
                        wim.RegisterCallback(CallBackDelegate);                      
                        wim.ExtractImage(__Index, __TargetPath, __ExtracFlags);
                    }
                    finally
                    {
                        
                    }
                }

                lblEvents.Text = "The operation was successfully!";                
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                lblHandleError.Text = ex.Message;               
            }
        }


        ScanProgress _ScanProgress;
        WriteStreamsProgress _SreamProgress;
        IntegrityProgress _IntegrityProgress;
        VerifyImageProgress _VerifyImageProgress;
        VerifyStreamsProgress _VerifyStreamsProgress;
        ExtractProgress _ExtractProgress;

        private void BtnCloseFrom_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LblPercent_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }


        HandleErrorProgress _HandleErrorProgress;



        private CallbackStatus CallBackDelegate(ProgressMsg msg, object info, object progctx)
        {
            switch (msg)
            {
                case ProgressMsg.ScanBegin:

                    _ScanProgress = (ScanProgress)info;

                    lblFunctions.Text = "Scan Begin";
                    lblEvents.Text = _ScanProgress.Source + _ScanProgress.CurPath;

                    break;


                case ProgressMsg.ScanDEntry:

                    _ScanProgress = (ScanProgress)info;

                    lblFunctions.Text = "ScanDEntry";
                    lblEvents.Text =  _ScanProgress.CurPath;

                    break;

                case ProgressMsg.ScanEnd:

                    _ScanProgress = (ScanProgress)info;

                    lblFunctions.Text = "ScanEnd";

                    lblEvents.Text = _ScanProgress.CurPath;

                    break;

                case ProgressMsg.WriteStreams:

                    _SreamProgress = (WriteStreamsProgress)info;

                    lblFunctions.Text = "Write Strems";

                    lblEvents.Text = "Completed:" + _SreamProgress.CompletedStreams.ToString() + "  Competed Bytes:" + _SreamProgress.CompletedBytes.ToString();

                    break;

                case ProgressMsg.WriteMetadataBegin:
                    break;

                case ProgressMsg.WriteMetadataEnd:
                    break;

                case ProgressMsg.CalcIntegrity:

                    _IntegrityProgress = (IntegrityProgress)info;

                    lblFunctions.Text = "Calc Integrity";

                    lblEvents.Text = _IntegrityProgress.FileName;

                    break;

                case ProgressMsg.VerifyIntegrity:

                    _IntegrityProgress = (IntegrityProgress)info;

                    lblFunctions.Text = "Verifying Integrity";

                    lblEvents.Text =  _IntegrityProgress.FileName;

                    break;



                //Apply Image Events

                case ProgressMsg.BeginVerifyImage:

                    _VerifyImageProgress = (VerifyImageProgress)info;


                    lblFunctions.Text = "Begin Verifying Integrity";

                    lblEvents.Text = _VerifyImageProgress.WimFile;

                    break;

                case ProgressMsg.EndVerifyImage:

                    _VerifyImageProgress = (VerifyImageProgress)info;

                    lblFunctions.Text = "End Verify Integrity";

                    lblEvents.Text = _VerifyImageProgress.WimFile;

                    break;


                case ProgressMsg.VerifyStreams:

                    _VerifyStreamsProgress = (VerifyStreamsProgress)info;

                    lblFunctions.Text = "Verifying Streams";

                    lblEvents.Text = _VerifyImageProgress.WimFile;

                    break;


                case ProgressMsg.ExtractImageBegin:

                    _ExtractProgress = (ExtractProgress)info;

                    lblFunctions.Text = "Applying Begin";

                    lblEvents.Text = _ExtractProgress.Target + " " + _ExtractProgress.WimFileName;

                    break;


                case ProgressMsg.ExtractFileStructure:

                    _ExtractProgress = (ExtractProgress)info;

                    lblFunctions.Text = "Applying File Structure";

                    lblEvents.Text = _ExtractProgress.Target + " " + _ExtractProgress.WimFileName;

                    break;


                case ProgressMsg.ExtractStreams:

                    _ExtractProgress = (ExtractProgress)info;

                    lblFunctions.Text = "Applying Extract Streams";

                    lblEvents.Text = "Completed: " + _ExtractProgress.CompletedBytes.ToString() + "     Total: " + _ExtractProgress.TotalBytes.ToString();
                    break;

                case ProgressMsg.ExtractMetadata:

                    _ExtractProgress = (ExtractProgress)info;

                    lblFunctions.Text = "Applying Exctract Metadata";

                    lblEvents.Text = _ExtractProgress.Target + " " + _ExtractProgress.WimFileName;

                    break;

                case ProgressMsg.ExtractImageEnd:

                    _ExtractProgress = (ExtractProgress)info;

                    lblFunctions.Text = "Applying Exctract Image End";

                    lblEvents.Text =_ExtractProgress.Target + " " + _ExtractProgress.WimFileName;

                    break;

                case ProgressMsg.HandleError:

                    _HandleErrorProgress = (HandleErrorProgress)info;

                    lblFunctions.Text = "Handle Error";

                    lblHandleError.Text = _HandleErrorProgress.Path + " Error code: " + _HandleErrorProgress.ErrorCode.ToString();

                    return CallbackStatus.Abort;
            }


            Invoke((MethodInvoker)delegate{this.Refresh();});   
            
            return CallbackStatus.Continue;
        }

        #endregion

    }
}
