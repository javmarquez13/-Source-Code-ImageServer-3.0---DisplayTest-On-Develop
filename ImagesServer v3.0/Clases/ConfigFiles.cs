using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ImagesServer_v3._0
{
    class ConfigFiles
    {     
        public class configFiles
        {
            [DllImport("kernel32")]
            public static extern int GetPrivateProfileString(string seccion, string llave, string def, StringBuilder StrBuilder, int size, string filepath);

            [DllImport("kernel32")]
            public static extern long WritePrivateProfileString(string seccion, string llave, string valor, string filepath);
        }


        public static string reader(string _seccion, string _llave, string _filePath)
        {
            string _result;
            StringBuilder _builder = new StringBuilder();
            configFiles.GetPrivateProfileString(_seccion, _llave, "", _builder, _builder.MaxCapacity, _filePath);
            _result = _builder.ToString();
            return _result;
        }

        public static void write(string _seccion, string _llave, string _valor, string _filePath)
        {
           configFiles.WritePrivateProfileString(_seccion, _llave, _valor, _filePath);
        }
    }
}

