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

        public string CLASS { get; set; }
        public string SERIALNUMBER { get; set; }
        public string MC { get; set; }
        public string TRACER { get; set; }

        public string IDNumber { get; set; }
        public string IDName { get; set; }
        public int SlotID { get; set; }

        iFactoryInfo.iFactoryInfo _UnitInfo = new iFactoryInfo.iFactoryInfo();
        ConfigFiles _ConfigFiles = new ConfigFiles();
        string _userFile = @"\\mxchim0pangea01\AUTOMATION_SSCO\Config Files\Users.ini";

        public WinTracer()
        {
            InitializeComponent();
            RoundObjects();
            txtTracer.Enabled = false;
            this.CLASS = null;
            this.SERIALNUMBER = null;
            this.MC = null;
            this.TRACER = null;
            this.IDNumber = null;
            this.IDName = null;
            this.SlotID = 0;
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
            string _userResult = ConfigFiles.reader("IMAGES_SERVER", ID, _userFile);

            if(_userResult == "")
            {
                txtEmployeNum.Clear();
                txtEmployeNum.Focus();
                lblError.Text = "El usuario es invalido...";
                return;
            }

            IDNumber = ID;
            IDName = _userResult;
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
            string[] _result = _UnitInfo.GetSCMC(txtTracer.Text);

            if (_result[0] == "Serial Not Found")
            {
                txtTracer.Clear();
                txtTracer.Focus();
                lblError.Text = "El tracer es invalido...";
                return;
            }

            //if (SlotID == 0 && !_result[1].Contains("66"))
            //{
            //    txtTracer.Clear();
            //    txtTracer.Focus();
            //    lblError.Text = "Slot no seleccionado...";
            //    return;
            //}

            SERIALNUMBER = _result[0];
            CLASS = _result[1];
            MC = _result[2];
            TRACER = tracer;         
            DialogResult = DialogResult.OK;
        }

        private void WinTracer_Load(object sender, EventArgs e)
        {
            txtTracer.Focus();
        }



        //Slots
        private void Slot1_Click(object sender, EventArgs e)
        {
            SlotID = 1;
            UserSelectSlot(SlotID);
        }

        private void Slot2_Click(object sender, EventArgs e)
        {
            SlotID = 2;
            UserSelectSlot(SlotID);
        }

        private void Slot3_Click(object sender, EventArgs e)
        {
            SlotID = 3;
            UserSelectSlot(SlotID);
        }

        private void Slot4_Click(object sender, EventArgs e)
        {
            SlotID = 4;
            UserSelectSlot(SlotID);
        }

        private void Slot5_Click(object sender, EventArgs e)
        {
            SlotID = 5;
            UserSelectSlot(SlotID);
        }

        private void Slot6_Click(object sender, EventArgs e)
        {
            SlotID = 6;
            UserSelectSlot(SlotID);
        }

        private void Slot7_Click(object sender, EventArgs e)
        {
            SlotID = 7;
            UserSelectSlot(SlotID);
        }

        private void Slot8_Click(object sender, EventArgs e)
        {
            SlotID = 8;
            UserSelectSlot(SlotID);
        }

        private void Slot9_Click(object sender, EventArgs e)
        {
            SlotID = 9;
            UserSelectSlot(SlotID);
        }

        private void Slot10_Click(object sender, EventArgs e)
        {
            SlotID = 10;
            UserSelectSlot(SlotID);
        }

        private void Slot11_Click(object sender, EventArgs e)
        {
            SlotID = 11;
            UserSelectSlot(SlotID);
        }

        private void Slot12_Click(object sender, EventArgs e)
        {
            SlotID = 12;
            UserSelectSlot(SlotID);
        }

        private void Slot13_Click(object sender, EventArgs e)
        {
            SlotID = 13;
            UserSelectSlot(SlotID);
        }

        private void Slot14_Click(object sender, EventArgs e)
        {
            SlotID = 14;
            UserSelectSlot(SlotID);
        }

        private void Slot15_Click(object sender, EventArgs e)
        {
            SlotID = 15;
            UserSelectSlot(SlotID);
        }

        private void Slot16_Click(object sender, EventArgs e)
        {
            SlotID = 16;
            UserSelectSlot(SlotID);
        }

        private void Slot17_Click(object sender, EventArgs e)
        {
            SlotID = 17;
            UserSelectSlot(SlotID);
        }

        private void Slot18_Click(object sender, EventArgs e)
        {
            SlotID = 18;
            UserSelectSlot(SlotID);
        }

        Color _colorDark = Color.FromArgb(16, 29, 37);
        void UserSelectSlot(int Slot)
        {
            if(Slot == 1)
            {
                slot1.BackColor = Color.LightGreen;
                slot2.BackColor = _colorDark;
                slot3.BackColor = _colorDark;
                slot4.BackColor = _colorDark;
                slot5.BackColor = _colorDark;
                slot6.BackColor = _colorDark;
                slot7.BackColor = _colorDark;
                slot8.BackColor = _colorDark;
                slot9.BackColor = _colorDark;
                slot10.BackColor = _colorDark;
                slot11.BackColor = _colorDark;
                slot12.BackColor = _colorDark;
                slot13.BackColor = _colorDark;
                slot14.BackColor = _colorDark;
                slot15.BackColor = _colorDark;
                slot16.BackColor = _colorDark;
                slot17.BackColor = _colorDark;
                slot18.BackColor = _colorDark;
            }

            if (Slot == 2)
            {
                slot1.BackColor = _colorDark;
                slot2.BackColor = Color.LightGreen;
                slot3.BackColor = _colorDark;
                slot4.BackColor = _colorDark;
                slot5.BackColor = _colorDark;
                slot6.BackColor = _colorDark;
                slot7.BackColor = _colorDark;
                slot8.BackColor = _colorDark;
                slot9.BackColor = _colorDark;
                slot10.BackColor = _colorDark;
                slot11.BackColor = _colorDark;
                slot12.BackColor = _colorDark;
                slot13.BackColor = _colorDark;
                slot14.BackColor = _colorDark;
                slot15.BackColor = _colorDark;
                slot16.BackColor = _colorDark;
                slot17.BackColor = _colorDark;
                slot18.BackColor = _colorDark;
            }

            if (Slot == 3)
            {
                slot1.BackColor = _colorDark;
                slot2.BackColor = _colorDark;
                slot3.BackColor = Color.LightGreen;
                slot4.BackColor = _colorDark;
                slot5.BackColor = _colorDark;
                slot6.BackColor = _colorDark;
                slot7.BackColor = _colorDark;
                slot8.BackColor = _colorDark;
                slot9.BackColor = _colorDark;
                slot10.BackColor =_colorDark;
                slot11.BackColor =_colorDark;
                slot12.BackColor =_colorDark;
                slot13.BackColor =_colorDark;
                slot14.BackColor =_colorDark;
                slot15.BackColor =_colorDark;
                slot16.BackColor =_colorDark;
                slot17.BackColor =_colorDark;
                slot18.BackColor =_colorDark;
            }

            if (Slot == 4)
            {
                slot1.BackColor = _colorDark;
                slot2.BackColor = _colorDark;
                slot3.BackColor = _colorDark;
                slot4.BackColor = Color.LightGreen;
                slot5.BackColor = _colorDark;
                slot6.BackColor = _colorDark;
                slot7.BackColor = _colorDark;
                slot8.BackColor = _colorDark;
                slot9.BackColor = _colorDark;
                slot10.BackColor =_colorDark;
                slot11.BackColor =_colorDark;
                slot12.BackColor =_colorDark;
                slot13.BackColor =_colorDark;
                slot14.BackColor =_colorDark;
                slot15.BackColor =_colorDark;
                slot16.BackColor =_colorDark;
                slot17.BackColor =_colorDark;
                slot18.BackColor = _colorDark;
            }

            if (Slot == 5)
            {
                slot1.BackColor = _colorDark;
                slot2.BackColor = _colorDark;
                slot3.BackColor = _colorDark;
                slot4.BackColor = _colorDark;
                slot5.BackColor = Color.LightGreen;
                slot6.BackColor = _colorDark;
                slot7.BackColor = _colorDark;
                slot8.BackColor = _colorDark;
                slot9.BackColor = _colorDark;
                slot10.BackColor =_colorDark;
                slot11.BackColor =_colorDark;
                slot12.BackColor =_colorDark;
                slot13.BackColor =_colorDark;
                slot14.BackColor =_colorDark;
                slot15.BackColor =_colorDark;
                slot16.BackColor =_colorDark;
                slot17.BackColor =_colorDark;
                slot18.BackColor = _colorDark;
            }

            if (Slot == 6)
            {
                slot1.BackColor = _colorDark;
                slot2.BackColor = _colorDark;
                slot3.BackColor = _colorDark;
                slot4.BackColor = _colorDark;
                slot5.BackColor = _colorDark;
                slot6.BackColor = Color.LightGreen;
                slot7.BackColor = _colorDark;
                slot8.BackColor = _colorDark;
                slot9.BackColor = _colorDark;
                slot10.BackColor =_colorDark;
                slot11.BackColor =_colorDark;
                slot12.BackColor =_colorDark;
                slot13.BackColor =_colorDark;
                slot14.BackColor =_colorDark;
                slot15.BackColor =_colorDark;
                slot16.BackColor =_colorDark;
                slot17.BackColor =_colorDark;
                slot18.BackColor = _colorDark;
            }

            if (Slot == 7)
            {
                slot1.BackColor = _colorDark;
                slot2.BackColor = _colorDark;
                slot3.BackColor = _colorDark;
                slot4.BackColor = _colorDark;
                slot5.BackColor = _colorDark;
                slot6.BackColor = _colorDark;
                slot7.BackColor = Color.LightGreen;
                slot8.BackColor = _colorDark;
                slot9.BackColor = _colorDark;
                slot10.BackColor =_colorDark;
                slot11.BackColor =_colorDark;
                slot12.BackColor =_colorDark;
                slot13.BackColor =_colorDark;
                slot14.BackColor =_colorDark;
                slot15.BackColor =_colorDark;
                slot16.BackColor =_colorDark;
                slot17.BackColor =_colorDark;
                slot18.BackColor = _colorDark;
            }

            if (Slot == 8)
            {
                slot1.BackColor = _colorDark;
                slot2.BackColor = _colorDark;
                slot3.BackColor = _colorDark;
                slot4.BackColor = _colorDark;
                slot5.BackColor = _colorDark;
                slot6.BackColor = _colorDark;
                slot7.BackColor = _colorDark;
                slot8.BackColor = Color.LightGreen;
                slot9.BackColor = _colorDark;
                slot10.BackColor =_colorDark;
                slot11.BackColor =_colorDark;
                slot12.BackColor =_colorDark;
                slot13.BackColor =_colorDark;
                slot14.BackColor =_colorDark;
                slot15.BackColor =_colorDark;
                slot16.BackColor =_colorDark;
                slot17.BackColor =_colorDark;
                slot18.BackColor = _colorDark;
            }

            if (Slot == 9)
            {
                slot1.BackColor = _colorDark;
                slot2.BackColor = _colorDark;
                slot3.BackColor = _colorDark;
                slot4.BackColor = _colorDark;
                slot5.BackColor = _colorDark;
                slot6.BackColor = _colorDark;
                slot7.BackColor = _colorDark;
                slot8.BackColor = _colorDark;
                slot9.BackColor = Color.LightGreen;
                slot10.BackColor =_colorDark;
                slot11.BackColor =_colorDark;
                slot12.BackColor =_colorDark;
                slot13.BackColor =_colorDark;
                slot14.BackColor =_colorDark;
                slot15.BackColor =_colorDark;
                slot16.BackColor =_colorDark;
                slot17.BackColor =_colorDark;
                slot18.BackColor = _colorDark;
            }

            if (Slot == 10)
            {
                slot1.BackColor =_colorDark;
                slot2.BackColor =_colorDark;
                slot3.BackColor =_colorDark;
                slot4.BackColor =_colorDark;
                slot5.BackColor =_colorDark;
                slot6.BackColor =_colorDark;
                slot7.BackColor =_colorDark;
                slot8.BackColor =_colorDark;
                slot9.BackColor = _colorDark;
                slot10.BackColor = Color.LightGreen;
                slot11.BackColor =_colorDark;
                slot12.BackColor =_colorDark;
                slot13.BackColor =_colorDark;
                slot14.BackColor =_colorDark;
                slot15.BackColor =_colorDark;
                slot16.BackColor =_colorDark;
                slot17.BackColor =_colorDark;
                slot18.BackColor = _colorDark;
            }

            if (Slot == 11)
            {
                slot1.BackColor =_colorDark;
                slot2.BackColor =_colorDark;
                slot3.BackColor =_colorDark;
                slot4.BackColor =_colorDark;
                slot5.BackColor =_colorDark;
                slot6.BackColor =_colorDark;
                slot7.BackColor =_colorDark;
                slot8.BackColor =_colorDark;
                slot9.BackColor = _colorDark;
                slot10.BackColor = _colorDark;
                slot11.BackColor = Color.LightGreen;
                slot12.BackColor = _colorDark;
                slot13.BackColor = _colorDark;
                slot14.BackColor = _colorDark;
                slot15.BackColor = _colorDark;
                slot16.BackColor = _colorDark;
                slot17.BackColor = _colorDark;
                slot18.BackColor = _colorDark;
            }

            if (Slot == 12)
            {
                slot1.BackColor = _colorDark;
                slot2.BackColor = _colorDark;
                slot3.BackColor = _colorDark;
                slot4.BackColor = _colorDark;
                slot5.BackColor = _colorDark;
                slot6.BackColor = _colorDark;
                slot7.BackColor = _colorDark;
                slot8.BackColor = _colorDark;
                slot9.BackColor = _colorDark;
                slot10.BackColor =_colorDark;
                slot11.BackColor = _colorDark;
                slot12.BackColor = Color.LightGreen;
                slot13.BackColor = _colorDark;
                slot14.BackColor = _colorDark;
                slot15.BackColor = _colorDark;
                slot16.BackColor = _colorDark;
                slot17.BackColor = _colorDark;
                slot18.BackColor = _colorDark;
            }

            if (Slot == 13)
            {
                slot1.BackColor =_colorDark;
                slot2.BackColor =_colorDark;
                slot3.BackColor =_colorDark;
                slot4.BackColor =_colorDark;
                slot5.BackColor =_colorDark;
                slot6.BackColor =_colorDark;
                slot7.BackColor =_colorDark;
                slot8.BackColor =_colorDark;
                slot9.BackColor = _colorDark;
                slot10.BackColor = _colorDark;
                slot11.BackColor = _colorDark;
                slot12.BackColor = _colorDark;
                slot13.BackColor = Color.LightGreen;
                slot14.BackColor = _colorDark;
                slot15.BackColor = _colorDark;
                slot16.BackColor = _colorDark;
                slot17.BackColor = _colorDark;
                slot18.BackColor = _colorDark;
            }

            if (Slot == 14)
            {
                slot1.BackColor =_colorDark;
                slot2.BackColor =_colorDark;
                slot3.BackColor =_colorDark;
                slot4.BackColor =_colorDark;
                slot5.BackColor =_colorDark;
                slot6.BackColor =_colorDark;
                slot7.BackColor =_colorDark;
                slot8.BackColor =_colorDark;
                slot9.BackColor = _colorDark;
                slot10.BackColor = _colorDark;
                slot11.BackColor = _colorDark;
                slot12.BackColor = _colorDark;
                slot13.BackColor = _colorDark;
                slot14.BackColor = Color.LightGreen;
                slot15.BackColor = _colorDark;
                slot16.BackColor = _colorDark;
                slot17.BackColor = _colorDark;
                slot18.BackColor = _colorDark;
            }

            if (Slot == 15)
            {
                slot1.BackColor = _colorDark;
                slot2.BackColor = _colorDark;
                slot3.BackColor = _colorDark;
                slot4.BackColor = _colorDark;
                slot5.BackColor = _colorDark;
                slot6.BackColor = _colorDark;
                slot7.BackColor = _colorDark;
                slot8.BackColor = _colorDark;
                slot9.BackColor = _colorDark;
                slot10.BackColor =_colorDark;
                slot11.BackColor =_colorDark;
                slot12.BackColor =_colorDark;
                slot13.BackColor =_colorDark;
                slot14.BackColor = _colorDark;
                slot15.BackColor = Color.LightGreen;
                slot16.BackColor =_colorDark;
                slot17.BackColor =_colorDark;
                slot18.BackColor =_colorDark;
            }

            if (Slot == 16)
            {
                slot1.BackColor = _colorDark;
                slot2.BackColor = _colorDark;
                slot3.BackColor = _colorDark;
                slot4.BackColor = _colorDark;
                slot5.BackColor = _colorDark;
                slot6.BackColor = _colorDark;
                slot7.BackColor = _colorDark;
                slot8.BackColor = _colorDark;
                slot9.BackColor = _colorDark;
                slot10.BackColor =_colorDark;
                slot11.BackColor =_colorDark;
                slot12.BackColor =_colorDark;
                slot13.BackColor =_colorDark;
                slot14.BackColor =_colorDark;
                slot15.BackColor =_colorDark;
                slot16.BackColor = Color.LightGreen;
                slot17.BackColor = _colorDark;
                slot18.BackColor = _colorDark;
            }

            if (Slot == 17)
            {
                slot1.BackColor = _colorDark;
                slot2.BackColor = _colorDark;
                slot3.BackColor = _colorDark;
                slot4.BackColor = _colorDark;
                slot5.BackColor = _colorDark;
                slot6.BackColor = _colorDark;
                slot7.BackColor = _colorDark;
                slot8.BackColor = _colorDark;
                slot9.BackColor = _colorDark;
                slot10.BackColor =_colorDark;
                slot11.BackColor =_colorDark;
                slot12.BackColor =_colorDark;
                slot13.BackColor =_colorDark;
                slot14.BackColor =_colorDark;
                slot15.BackColor =_colorDark;
                slot16.BackColor = _colorDark;
                slot17.BackColor = Color.LightGreen;
                slot18.BackColor = _colorDark;
            }

            if (Slot == 18)
            {
                slot1.BackColor = _colorDark;
                slot2.BackColor = _colorDark;
                slot3.BackColor = _colorDark;
                slot4.BackColor = _colorDark;
                slot5.BackColor = _colorDark;
                slot6.BackColor = _colorDark;
                slot7.BackColor = _colorDark;
                slot8.BackColor = _colorDark;
                slot9.BackColor = _colorDark;
                slot10.BackColor =_colorDark;
                slot11.BackColor =_colorDark;
                slot12.BackColor =_colorDark;
                slot13.BackColor =_colorDark;
                slot14.BackColor =_colorDark;
                slot15.BackColor =_colorDark;
                slot16.BackColor =_colorDark;
                slot17.BackColor = _colorDark;
                slot18.BackColor = Color.LightGreen;
            }
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
