using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagesServer_v3._0
{
    class CheckEJL
    {
        //FUNCTION TO VERIFY THAT JOURNAL IS COMPLETED
        public static bool IsCompleted_SSCOS(string _mainDisk, string _tracer)
        {
            bool _isComplete = false;

            try
            {
                Globals.EJL = File.ReadAllText(_mainDisk + @":\Mavis\" + _tracer + ".ejl");
                if (Globals.EJL.Contains("* ECHEC") && Globals.EJL.Contains(_tracer)) _isComplete = true;
            }
            catch (Exception)
            {
                _isComplete = false;
            }

            return _isComplete;
        }
    }
}
