using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagedWimLib;

namespace ImagesServer_v3._0
{
    class StaticJImgaeX
    {

        public static DialogResult APPLY_JIMAGEX(int Index, string WimToInstall, string TargetPath)
        {
            ImageXGUI ImageXGUI = new ImageXGUI(ImageXGUI.ApplyOrCapture.Apply, Index, WimToInstall, TargetPath, OpenFlags.None, ExtractFlags.Ntfs);
            DialogResult _dr = ImageXGUI.ShowDialog();
            return _dr;
        }

        public static void CAPTURE_JIMAGEX()
        {

        }



        //function to apply image with radsimageX.exe
        public static int APPLY_RADSIMAGEX(string Image, string Reboot, string _ApplyMode)
        {
            string _RadsImage = @"X:\ImagingTools\RadsImageX.exe";
            string _ApplyArgStart = "/apply ";
            string _ApplyArgEnd = " 0";
            string _image = Image;
            int _result = 0;

            try
            {
                //_image = Reboot + _ApplyArgStart + _image + _ApplyArgEnd;
                _image = Reboot + _ApplyArgStart + _image + " " + _ApplyMode + _ApplyArgEnd;
                _result = StaticFunctions.ExternalExe(_RadsImage, _image);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return _result;
        }

    }
}
