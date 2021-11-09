using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using iFactoryInfo;

namespace ImagesServer_v3._0
{
    public partial class WinTracer : Form
    {
        public WinTracer()
        {
            InitializeComponent();
            RoundObjects();
            txtTracer.Enabled = false;
        }

        void RoundObjects()
        {
            btnExit.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btnExit.Width, btnExit.Height, 10, 10));
            txtEmployeNum.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, txtEmployeNum.Width, txtEmployeNum.Height, 10, 10));
            txtTracer.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, txtTracer.Width, txtTracer.Height, 10, 10));
            btn0.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btn0.Width, btn0.Height, 10, 10));
            btn1.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btn1.Width, btn1.Height, 10, 10));
            btn2.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btn2.Width, btn2.Height, 10, 10));
            btn3.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btn3.Width, btn3.Height, 10, 10));
            btn4.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btn4.Width, btn4.Height, 10, 10));
            btn5.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btn5.Width, btn5.Height, 10, 10));
            btn6.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btn6.Width, btn6.Height, 10, 10));
            btn7.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btn7.Width, btn7.Height, 10, 10));
            btn8.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btn8.Width, btn8.Height, 10, 10));
            btn9.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btn9.Width, btn9.Height, 10, 10));
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private void TxtEmployeNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                VerifyUserNT(txtEmployeNum.Text);                
            }
        }


        private void TxtTracer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {               
                GetUnitInfoFromIfactory(txtTracer.Text);
            }
        }


        void VerifyUserNT(string ID)
        {
            string _userResult = ConfigFiles.reader("IMAGES_SERVER", ID, Globals.PATH_USER_FILE);

            if(_userResult == "")
            {
                txtEmployeNum.Clear();
                txtEmployeNum.Focus();
                lblError.Text = "El usuario es invalido...";
                return;
            }

            Globals.USER_ID = ID;
            Globals.USER_NAME = _userResult;
            txtTracer.Enabled = true;
            txtTracer.Focus();
            _ControlActive = "txtTracer";
        }

        void GetUnitInfoFromIfactory(string tracer)
        {
            if (!Regex.IsMatch(tracer, @"^\d{8}"))
            {
                txtTracer.Clear();
                txtTracer.Focus();
                lblError.Text = "El tracer es invalido...";
                return;
            }

            lblError.Text = "";
            string[] _result = new iFactoryInfo.iFactoryInfo().GetSCMC(txtTracer.Text);

            if (_result[0] == "Serial Not Found")
            {
                txtTracer.Clear();
                txtTracer.Focus();
                lblError.Text = "El tracer es invalido...";
                return;
            }

            Globals.WIP = _result[0];
            Globals.CLASS = _result[1];
            Globals.MC = _result[2];
            Globals.TRACER = tracer;         
            DialogResult = DialogResult.OK;
        }

        private void WinTracer_Load(object sender, EventArgs e)
        {
            txtTracer.Focus();
        }

       
        #region Teclado en pantalla

        string _ControlActive = "txtEmployeNum";

        private void Btn1_Click(object sender, EventArgs e)
        {
            if(_ControlActive == "txtEmployeNum")
            {
                txtEmployeNum.Focus();
                SendKeys.Send(btn1.Text);
            }

            if (_ControlActive == "txtTracer")
            {
                txtTracer.Focus();
                SendKeys.Send(btn1.Text);
            }
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            if (_ControlActive == "txtEmployeNum")
            {
                txtEmployeNum.Focus();
                SendKeys.Send(btn2.Text);
            }

            if (_ControlActive == "txtTracer")
            {
                txtTracer.Focus();
                SendKeys.Send(btn2.Text);
            }
        }


        private void Btn3_Click(object sender, EventArgs e)
        {
            if (_ControlActive == "txtEmployeNum")
            {
                txtEmployeNum.Focus();
                SendKeys.Send(btn3.Text);
            }

            if (_ControlActive == "txtTracer")
            {
                txtTracer.Focus();
                SendKeys.Send(btn3.Text);
            }
        }


        private void Btn4_Click(object sender, EventArgs e)
        {
            if (_ControlActive == "txtEmployeNum")
            {
                txtEmployeNum.Focus();
                SendKeys.Send(btn4.Text);
            }

            if (_ControlActive == "txtTracer")
            {
                txtTracer.Focus();
                SendKeys.Send(btn4.Text);
            }
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            if (_ControlActive == "txtEmployeNum")
            {
                txtEmployeNum.Focus();
                SendKeys.Send(btn5.Text);
            }

            if (_ControlActive == "txtTracer")
            {
                txtTracer.Focus();
                SendKeys.Send(btn5.Text);
            }
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            if (_ControlActive == "txtEmployeNum")
            {
                txtEmployeNum.Focus();
                SendKeys.Send(btn6.Text);
            }

            if (_ControlActive == "txtTracer")
            {
                txtTracer.Focus();
                SendKeys.Send(btn6.Text);
            }
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            if (_ControlActive == "txtEmployeNum")
            {
                txtEmployeNum.Focus();
                SendKeys.Send(btn7.Text);
            }

            if (_ControlActive == "txtTracer")
            {
                txtTracer.Focus();
                SendKeys.Send(btn7.Text);
            }
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            if (_ControlActive == "txtEmployeNum")
            {
                txtEmployeNum.Focus();
                SendKeys.Send(btn8.Text);
            }

            if (_ControlActive == "txtTracer")
            {
                txtTracer.Focus();
                SendKeys.Send(btn8.Text);
            }
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            if (_ControlActive == "txtEmployeNum")
            {
                txtEmployeNum.Focus();
                SendKeys.Send(btn9.Text);
            }

            if (_ControlActive == "txtTracer")
            {
                txtTracer.Focus();
                SendKeys.Send(btn9.Text);
            }
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (_ControlActive == "txtEmployeNum")
            {
                txtEmployeNum.Focus();
                SendKeys.Send("{ENTER}");
            }

            if (_ControlActive == "txtTracer")
            {
                txtTracer.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void Btn0_Click(object sender, EventArgs e)
        {
            if (_ControlActive == "txtEmployeNum")
            {
                txtEmployeNum.Focus();
                SendKeys.Send(btn0.Text);
            }

            if (_ControlActive == "txtTracer")
            {
                txtTracer.Focus();
                SendKeys.Send(btn0.Text);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (_ControlActive == "txtEmployeNum")
            {
                txtEmployeNum.Focus();
                txtEmployeNum.Clear();
            }

            if (_ControlActive == "txtTracer")
            {
                txtTracer.Focus();
                txtTracer.Clear();
            }

        }

        private void TxtEmployeNum_Click(object sender, EventArgs e)
        {
            _ControlActive = "txtEmployeNum";
        }

        private void TxtTracer_Click(object sender, EventArgs e)
        {
            _ControlActive = "txtTracer";
        }

        #endregion


    }
}
