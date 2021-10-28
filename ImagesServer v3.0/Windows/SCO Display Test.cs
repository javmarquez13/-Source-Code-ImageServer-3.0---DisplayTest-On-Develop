using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace ImagesServer_v3._0
{
    public partial class SCODisplayTest : Form
    {
        public string _class { get; set; }
        public string _serialNumber { get; set; }
        public string _mc { get; set; }
        public string _tracer { get; set; }
        public string _ID { get; set; }
        public string _Name { get; set; }
        bool _testPass = true;

        string _CPUType;
        ulong _MemoryRamTotal;
        ulong _UpperLimit;
        ulong _LowerLimit;
        string _SNBaseBoard;
        string _ProductBaseBoard;
        string _macAdress;
        UInt64[] _size = new UInt64[4];
        string[] _slots = new string[4];
        int _loop = 0;

        private static ManagementObjectSearcher baseboardSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
        private static ManagementObjectSearcher motherboardSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_MotherboardDevice");
        private static ManagementObjectSearcher tpmModule = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Tpm");

        public SCODisplayTest() 
        {
            InitializeComponent();
            lblVersion.Text = Form1._version;
            InicializarDGV();
            RoundObjects();
            txtScaneo.Enabled = false;

            listView1.Scrollable = true;
            listView1.View = View.Details;

            ColumnHeader header = new ColumnHeader();
            header.Text = "FEATURES";
            header.Name = "FEATURES";
            header.Width = 300;
            listView1.Columns.Add(header);
        }

        void RoundObjects()
        {
            panel1.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 10, 10));
            BtnExit.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, BtnExit.Width, BtnExit.Height, 10, 10));
            listView1.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, listView1.Width, listView1.Height, 10, 10));
            txtScaneo.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, txtScaneo.Width, txtScaneo.Height, 10, 10));
            dgvTests.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, dgvTests.Width, dgvTests.Height, 10, 10));
        }


        void InicializarDGV()
        {
           //dgvTests.Columns.Add("Date", "Fecha");
           //dgvTests.Columns.Add("Test Name", "TestName");
           //dgvTests.Columns.Add("Measurement Name", "Measurement");
           //dgvTests.Columns.Add("Lower Limit", "LowerLimit");
           //dgvTests.Columns.Add("Upper Limit", "UpperLimit");
           //dgvTests.Columns.Add("Status", "Status");

           //dgvTests.Columns["Date"].Width = 200;
           //dgvTests.Columns["Test Name"].Width = 150;
           //dgvTests.Columns["Measurement Name"].Width = 300;
           //dgvTests.Columns["Lower Limit"].Width = 140;
           //dgvTests.Columns["Upper Limit"].Width = 140;
           //dgvTests.Columns["Status"].Width = 100;

           dgvTests.RowHeadersVisible = false;
        }

        private void SCODisplayTest_Load(object sender, EventArgs e)
        {
            _class        = Form1._class;
            _serialNumber = Form1._serialNumber;
            _mc           = Form1._mc;
            _tracer       = Form1._tracer;
            _ID           = Form1._ID;
            _Name         = Form1._Name;


            txtScaneo.Text = _tracer;
            this.Refresh();
            txtScaneo_KeyDown(sender, new KeyEventArgs(Keys.Enter));
        }

        private void txtScaneo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                //using (WaitWin waitWin = new WaitWin(MainFunction, "GETTING INFORMATION"))
                //{
                //    waitWin.ShowDialog(this);
                //}          
                MainFunction();
            }
        }


        void MainFunction()
        {
            string[] _Features = StaticFunctions.GetFeatsString(_class, _mc);
            string _featString = string.Join(_class, _Features);

            WriteDGV(_testPass, DateTime.Now, "FEATURES", _featString, "", "");

            List<string> _buildTyp = StaticFunctions.GetFeatsDecription(_class, _Features);


            foreach (string Feat in _buildTyp)
            {
                var listViewItem = new ListViewItem(Feat);
                listView1.Items.Add(listViewItem);
                this.Refresh();
            }



            //if (listView1.InvokeRequired)
            //{
            //    listView1.Invoke((MethodInvoker)delegate ()
            //    {
            //        foreach(string Feat in _buildTyp)
            //        {
            //            var listViewItem = new ListViewItem(Feat);
            //            listView1.Items.Add(listViewItem);
            //            SCODisplayTest.ActiveForm.Refresh();
            //        }      
            //    });
            //}

            #region TEST BASEBOARD TYPE
            _testPass = true;
            _ProductBaseBoard = GetProductBaseBoard;
            if (_buildTyp.Contains("7703_DISPLAY"))
            {
                if (_ProductBaseBoard == "Richmond") _testPass = true;
                else _testPass = false;
            }

            if (_buildTyp.Contains("7702_DISPLAY"))
            {
                if (_ProductBaseBoard == "Monaco") _testPass = true;
                else _testPass = false;
            }

            if (_buildTyp.Contains("7773_DISPLAY"))
            {
                if (_ProductBaseBoard == "Eldora") _testPass = true;
                else _testPass = false;
            }

            WriteDGV(_testPass, DateTime.Now, "BASEBOARD", _ProductBaseBoard, "", "");
            //if (!_testPass) goto End;

            #endregion

            #region TEST FOR CPU TYPE
            _testPass = true;
            _CPUType = CheckCPUType();
            if (_buildTyp.Contains("INTEL_CELERON") && _buildTyp.Contains("XR7_DISPLAY"))
            {
                if (_CPUType.Contains("G1820TE")) _testPass = true;
                else _testPass = false;
            }

            if (_buildTyp.Contains("INTEL_CELERON") && _buildTyp.Contains("7703_DISPLAY"))
            {
                if (_CPUType.Contains("G3900TE")) _testPass = true;
                else _testPass = false;
            }

            if (_buildTyp.Contains("INTEL_I3") && _buildTyp.Contains("XR7_DISPLAY"))
            {
                if (_CPUType.Contains("i3-4350t")) _testPass = true;
                else _testPass = false;
            }

            if (_buildTyp.Contains("INTEL_I3") && _buildTyp.Contains("7703_DISPLAY"))
            {
                if (_CPUType.Contains("i3-6100te")) _testPass = true;
                else _testPass = false;
            }

            if (_buildTyp.Contains("INTEL_I5") && _buildTyp.Contains("XR7_DISPLAY"))
            {
                if (_CPUType.Contains("4590t")) _testPass = true;
                else _testPass = false;
            }

            if (_buildTyp.Contains("INTEL_I5") && _buildTyp.Contains("7703_DISPLAY"))
            {
                if (_CPUType.Contains("7500TE")) _testPass = true;
                else _testPass = false;
            }
            WriteDGV(_testPass, DateTime.Now, "CPU", _CPUType, "", "");
            //if (!_testPass) goto End;
            #endregion

            #region TEST FOR RAM
            _testPass = true;
            ulong _MemoryRamTotal = GetMemoryRam();

            foreach (string _slot in _slots)
            {
                if (_slot == null) break;
                WriteDGV(_testPass, DateTime.Now, "MEMORY RAM", _slot + "=" + _size[_loop], "", "");
                _loop++;
            }

            //RAM 4GB
            if (!_buildTyp.Contains("EXTRA_4GB") && !_buildTyp.Contains("EXTRA_8GB") && !_buildTyp.Contains("SIXTEEN_GB_MEMORY") && !_buildTyp.Contains("8GB_MEMORY"))
            {
                _UpperLimit = 4500000000;
                _LowerLimit = 4000000000;

                if (_MemoryRamTotal <= _UpperLimit && _MemoryRamTotal >= _LowerLimit) _testPass = true;
                else _testPass = false;
            }


            //RAM 8GB
            if (_buildTyp.Contains("EXTRA_4GB") || _buildTyp.Contains("8GB_MEMORY") && !_buildTyp.Contains("EXTRA_8GB"))
            {
                _UpperLimit = 8800000000;
                _LowerLimit = 8000000000;

                if (_MemoryRamTotal <= _UpperLimit && _MemoryRamTotal >= _LowerLimit) _testPass = true;
                else _testPass = false;
            }


            //RAM 16GB
            if (_buildTyp.Contains("EXTRA_8GB") || _buildTyp.Contains("SIXTEEN_GB_MEMORY") && !_buildTyp.Contains("EXTRA_8GB"))
            {
                _UpperLimit = 17200000000;
                _LowerLimit = 16000000000;

                if (_MemoryRamTotal <= _UpperLimit && _MemoryRamTotal >= _LowerLimit) _testPass = true;
                else _testPass = false;
            }


            //RAM 24GB
            if (_buildTyp.Contains("EXTRA_8GB") && _buildTyp.Contains("SIXTEEN_GB_MEMORY"))
            {
                _UpperLimit = 25800000000;
                _LowerLimit = 24000000000;

                if (_MemoryRamTotal <= _UpperLimit && _MemoryRamTotal >= _LowerLimit) _testPass = true;
                else _testPass = false;
            }

            WriteDGV(_testPass, DateTime.Now, "MEMORY RAM", _MemoryRamTotal.ToString(), _LowerLimit.ToString(), _UpperLimit.ToString());
            //if (!_testPass) goto End;
            #endregion

            #region MATCH MAC ADRESS
            _macAdress = CheckWMIValue(@"ROOT\\CIMV2", @"Select * FROM Win32_NetworkAdapterConfiguration where IPEnabled=true", "MACAddress");
            new SendAttributes.SendAttributes().SendAttributesToiFactory("BASE-BOARD MAC-ADRESS", _macAdress, _serialNumber);
            WriteDGV(_testPass, DateTime.Now, "MAC ADRESS", _macAdress, "", "");

            _ProductBaseBoard = GetProductBaseBoard;
            new SendAttributes.SendAttributes().SendAttributesToiFactory("BASE-BOARD PRODUCT", _ProductBaseBoard, _serialNumber);
            WriteDGV(_testPass, DateTime.Now, "PRODUCT", _ProductBaseBoard, "", "");


            _SNBaseBoard = GetSNBaseBoard;
            new SendAttributes.SendAttributes().SendAttributesToiFactory("BASE-BOARD SERIAL NUMBER", _SNBaseBoard, _serialNumber);
            WriteDGV(_testPass, DateTime.Now, "SERIAL NUMBER", _SNBaseBoard, "", "");
            #endregion

            End:
            {
                if (!_testPass) WriteDGV(_testPass, DateTime.Now, "TEST FAIL", "ENSAMBLE INCORRECTO", "", "");
                if (_testPass)
                {
                    WriteDGV(_testPass, DateTime.Now, "TEST PASS", "ENSAMBLE CORRECTO", "", "");
                    System.Threading.Thread.Sleep(5000);
                    DialogResult = DialogResult.OK;
                }
                
            }
        }

        string CheckCPUType()
        {
            string CPU = string.Empty;
            try
            {
                var result_cpu = new ManagementObjectSearcher("select * from Win32_Processor").Get().Cast<ManagementObject>().First();
                CPU = ((string)result_cpu["Name"]).ToLower();
            }
            catch (Exception ex)
            {
                WriteDGV(false, DateTime.Now, "APP ISSUE", ex.Message, "", "");
            }
            return CPU;
        }

        ulong GetMemoryRam()
        {
            ulong MEMORY_RAM = 0;

            try
            {
                for (int i = 0; i < 4; i++)
                {
                    try
                    {
                        string tag = i.ToString();
                        var ram = new ManagementObjectSearcher("Select * from WIN32_PhysicalMemory WHERE Tag LIKE 'Physical Memory " + tag + "'").Get().Cast<ManagementObject>().First();
                        _size[i] = (UInt64)ram["Capacity"];
                        _slots[i] = (string)ram["DeviceLocator"];
                    }
                    catch (Exception e)
                    {
                        //_size[i] = 0;
                        //_slots[i] = "unknown";
                    }
                }

                MEMORY_RAM = _size[0] + _size[1] + _size[2] + _size[3];

                //  MEMORY_RAM = ComputerInfo.TotalPhysicalMemory;    
                //RegistryKey Rkey = Registry.LocalMachine;
                //Rkey = Rkey.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0");
                //CPU = (string)Rkey.GetValue("ProcessorNameString");
            }
            catch (Exception ex)
            {
                WriteDGV(false, DateTime.Now, "APP ISSUE", ex.Message, "", "");
            }

            return MEMORY_RAM;
        }

        string CheckWMIValue(string nameSpace, string query, string property)
        {
            try
            {
                string value = string.Empty;
                ObjectQuery WQL = new ObjectQuery(query);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(WQL);
                ManagementObjectCollection results = searcher.Get();
                foreach (ManagementObject mObject in results)
                {
                    foreach (PropertyData propertyItem in mObject.Properties)
                    {
                        if (propertyItem.Name.ToUpper() == property.ToUpper())
                        {
                            value = propertyItem.Value.ToString();
                            break;
                        }
                    }
                    if (value != string.Empty)
                    {
                        break;
                    }
                }
                return value;
            }
            catch (Exception exp)
            {
                throw;
            }
        }

        string GetProductBaseBoard
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        return queryObj["Product"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        string GetSNBaseBoard
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        return queryObj["SerialNumber"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        string GetTPMModule
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in tpmModule.Get())
                    {
                        return queryObj["Value"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }

        void WriteDGV(bool Status, DateTime date, string TestName, string MeasurementName, string LowerLimit, string UpperLimit)
        {
            string _PassFail = "FAIL";

            try
            {
                if (Status)
                {
                    _PassFail = "PASS";
                    dgvTests.Invoke(new MethodInvoker(delegate
                    {
                        dgvTests.Rows.Add(new Object[]
                        {
                          date, TestName, MeasurementName, LowerLimit, UpperLimit, _PassFail
                        });
                        dgvTests.Rows[dgvTests.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                        dgvTests.CurrentCell = dgvTests.Rows[dgvTests.Rows.Count - 1].Cells[0];
                        this.Update();
                    }));
                }

                if (!Status)
                {
                    _PassFail = "FAIL";
                    dgvTests.Invoke(new MethodInvoker(delegate
                    {
                        dgvTests.Rows.Add(new Object[]
                        {
                           date, TestName, MeasurementName, LowerLimit, UpperLimit, _PassFail
                        });
                        dgvTests.Rows[dgvTests.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Red;
                        dgvTests.CurrentCell = dgvTests.Rows[dgvTests.Rows.Count - 1].Cells[0];
                        this.Update();
                    }));
                }
            }
            catch (Exception ex)
            {
                dgvTests.Invoke(new MethodInvoker(delegate
                {

                    dgvTests.Rows.Add(new Object[]
                  {
                        date, "Application log", ex.Message, "", ""
                  });
                    dgvTests.Rows[dgvTests.Rows.Count - 1].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                    dgvTests.CurrentCell = dgvTests.Rows[dgvTests.Rows.Count - 1].Cells[0];
                    this.Update();

                }));

            }

            this.Refresh();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
