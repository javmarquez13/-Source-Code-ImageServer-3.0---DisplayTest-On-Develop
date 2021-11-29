using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagesServer_v3._0
{
    public partial class SCO_Incomming_Validation : Form
    {
        public SCO_Incomming_Validation()
        {
            InitializeComponent();
            RoundObjects();
            dgvTests.RowHeadersVisible = false;
            lblVersion.Text = Globals.VERSION;


            //JSON();
        }


        string SerialNumber;
        string PartNumber;

        void RoundObjects()
        {
            panel1.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 10, 10));
            BtnExit.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, BtnExit.Width, BtnExit.Height, 10, 10));        
            txtScaneo.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, txtScaneo.Width, txtScaneo.Height, 10, 10));
            dgvTests.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, dgvTests.Width, dgvTests.Height, 10, 10));
        }


        void JSONOpts2() 
        {

        }


        void JSON() 
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://stg.mfg1-chi.jabilapps.com/shop-floor/ifactory-custom-api/swagger/#/Material/post_material_save_serialized_material");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {


                string json = "{\"SerializedMaterials\": " + "[" +
                              "{\"customerName\":\"NCR\"," +
                              "\"materialName\":\"7703MC763\"," +
                              "\"plantCode\":\"US03\"," +
                              "\"serialNumber\":\"20-58926362\"}]}";

                streamWriter.Write(json);
            }


            //Check if the application can run on frameworks 4.7 or up on WindowsPE
            //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //{
            //    string json = new JavaScriptSerializer().Serialize(new
            //    {
            //        user = "Foo",
            //        password = "Baz"
            //    });

            //    streamWriter.Write(json);
            //}

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }


        private void txtScaneo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtScaneo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtScaneo.Enabled = false;
                SerialNumber = txtScaneo.Text;
                txtScaneo444.Focus();
            }
        }

        private void txtScaneo444_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PartNumber = txtScaneo444.Text;
                txtScaneo444.Enabled = false;
                MainFunction();
            }
        }

        private void SCO_Incomming_Validation_Load(object sender, EventArgs e)
        {
            
        }

        void MainFunction()
        {
            try 
            {
                bool Fail = false;

                DataTable DataFromPN = Globals.INCOMMING_DATA.AsEnumerable()
                .Where(r => r.Field<string>("PartNumber444") == PartNumber)
                .CopyToDataTable();

                long Actual_DiskSize = Globals.SSD_SIZE;
                ulong Actual_Ram = Globals.MEMORY_RAM;
                string Actual_CpuType = Globals.CPU_TYPE;

                ulong Expected_Ram = Convert.ToUInt64(DataFromPN.Rows[0]["RAM"]);
                long Expected_Sdd = Convert.ToInt64(DataFromPN.Rows[0]["SSD"]);
                string Expected_CPUType = DataFromPN.Rows[0]["CPU"].ToString();


                WriteDGV(true, DateTime.Now, "Serial Number", SerialNumber, "", "");
                WriteDGV(true, DateTime.Now, "Part Number", PartNumber, "", "");

                WriteDGV(true, DateTime.Now, "Actual Disk Size", Actual_DiskSize.ToString(), "", "");
                if (Actual_DiskSize <= Expected_Sdd * .1) WriteDGV(true, DateTime.Now, "Expected Disk Size", Expected_Sdd.ToString(), Expected_Sdd.ToString(), Convert.ToString(Expected_Sdd * .1));
                else 
                {
                    WriteDGV(false, DateTime.Now, "Expected Disk Size", Expected_Sdd.ToString(), Expected_Sdd.ToString(), Convert.ToString(Expected_Sdd * .1));
                    Fail = true;
                }                                  

                WriteDGV(true, DateTime.Now, "Actual Ram Size", Actual_Ram.ToString(), "", "");
                if (Actual_Ram <= Expected_Ram * .1) WriteDGV(true, DateTime.Now, "Expected Ram Size", Expected_Ram.ToString(), Expected_Ram.ToString(), Convert.ToString(Expected_Ram * .1));
                else 
                {
                    WriteDGV(false, DateTime.Now, "Expected Ram Size", Expected_Ram.ToString(), Expected_Ram.ToString(), Convert.ToString(Expected_Ram * .1));
                    Fail = true;
                }                            

                WriteDGV(true, DateTime.Now, "Actual CPU Type", Actual_CpuType.ToString(), "", "");
                if (Actual_CpuType.Contains(Expected_CPUType)) WriteDGV(true, DateTime.Now, "Expected CPU Type", Expected_CPUType.ToString(), "", "");
                else 
                {
                    WriteDGV(false, DateTime.Now, "Expected CPU Type", Expected_CPUType.ToString(), "", "");
                    Fail = true;
                }

                if (!Fail) DialogResult = DialogResult.OK;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
                txtScaneo.Clear();
                txtScaneo444.Clear();
                txtScaneo.Enabled = true;
                txtScaneo444.Enabled = true;
                txtScaneo.Focus();
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
    }
}
