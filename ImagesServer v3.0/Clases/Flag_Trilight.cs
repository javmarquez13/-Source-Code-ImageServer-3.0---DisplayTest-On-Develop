using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ImagesServer_v3._0
{
    class Flag_Trilight
    {       
        public static void SEND_TARS(string _TRACER, DateTime _DATE, string _STEP, string _RESOURCE, string _PATH_TARS)
        {
            using (StreamWriter sw = File.CreateText(_PATH_TARS + _TRACER + "_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".txt"))
            {
                sw.WriteLine("TRACER=" +_TRACER);
                sw.WriteLine("DATE=" + _DATE.ToString());
                sw.WriteLine("STEP_NAME="+ _STEP);
                sw.WriteLine("RESOURCE=" + _RESOURCE);
                sw.Close();
            }
        }
    }
}
