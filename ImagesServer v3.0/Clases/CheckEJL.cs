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
        public static Tuple<string, bool> IsCompleted_SSCOS(string _mainDisk, string _tracer)
        {
            string _ejl = "";
            bool _isComplete = false;

            try
            {
                _ejl = File.ReadAllText(_mainDisk + @":\Mavis\" + _tracer + ".ejl");
                if (_ejl.Contains("* ECHEC") && _ejl.Contains(_tracer)) _isComplete = true;
            }
            catch (Exception)
            {
                _isComplete = false;
            }

            return Tuple.Create(_ejl, _isComplete);
        }
    }
}
