using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImagesServer_v3._0
{
    class DesignGlobals
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
        (
        int nLeftRect,     // x-coordinate of upper-left corner
        int nTopRect,      // y-coordinate of upper-left corner
        int nRightRect,    // x-coordinate of lower-right corner
        int nBottomRect,   // y-coordinate of lower-right corner
        int nWidthEllipse, // width of ellipse
        int nHeightEllipse // height of ellipse
        );


        public static Color BackGroundDarkMode
        {
            get
            {
                return Color.FromArgb(16, 29, 37);
            }
        }

        public static Color ForeGroundDarkMode
        {
            get
            {
                return Color.WhiteSmoke;
            }
        }

        public static Color BackGroundWhiteMode
        {
            get
            {
                return Color.White;
            }
        }

        public static Color ForeGroundWhiteMode
        {
            get
            {
                return Color.Black ;
            }
        }
    }
}
