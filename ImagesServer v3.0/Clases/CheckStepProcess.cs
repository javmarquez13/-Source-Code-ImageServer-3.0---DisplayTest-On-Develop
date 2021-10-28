using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iFactoryInfo;

namespace ImagesServer_v3._0
{
    class CheckStepProcess
    {    
        public static bool CheckStep(string SerialNumber, string StepToCheck)
        {
            iFactoryInfo.iFactoryInfo _UnitHistory = new iFactoryInfo.iFactoryInfo();
            int Loops = 1;
            int numSteps = 0;
            string STEP = "";
            string STATUS = "";
            string DATE = "";
            bool STEPVAL1 = false;
            DataSet ds;
            DataTable dt;

            try
            {
                ds = _UnitHistory.GetHistory(SerialNumber);
                dt = ds.Tables[0];
                numSteps = dt.Rows.Count;
                numSteps = numSteps - 1;

                while (Loops <= numSteps)
                {
                    var varDate = dt.Rows[Loops]["ArrivalTime"];
                    DATE = varDate.ToString();
                    var varStep = dt.Rows[Loops]["ProcessName"];
                    STEP = varStep.ToString();
                    var varStepStatus = dt.Rows[Loops]["ProcessResult"];
                    STATUS = varStepStatus.ToString();

                    if (STEP == StepToCheck && STATUS == "Passed") STEPVAL1 = true;
                    Loops = Loops + 1;
                    System.Threading.Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return STEPVAL1;
        }
    }
}
