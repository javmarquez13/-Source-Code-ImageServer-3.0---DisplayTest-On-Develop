using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagesServer_v3._0
{
    class Globals
    {
        private static string _TRACER;
        private static string _WIP;
        private static string _CLASS;
        private static string _MC;
        private static string _USER_NAME;
        private static string _USER_ID;
        private static string _IMAGE_TO_INSTALL;
        private static string _BUILD_TYPE;
        private static string _EJL;
        private static string _MAIN_DISK;
        private static string _BASE_BOARD;

        private static bool _isAdmin;

        public static string TRACER
        {
            get
            {
                return _TRACER;       
            }
            set 
            {
                _TRACER = value;
            }
        }

        public static string WIP
        {
            get
            {
                return _WIP;
            }
            set
            {
                _WIP = value;
            }

        }

        public static string CLASS
        {
            get
            {
                return _CLASS;
            }
            set
            {
                _CLASS = value;
            }

        }

        public static string MC
        {
            get
            {
                return _MC;
            }
            set
            {
                _MC = value;
            }
        }

        public static string USER_NAME
        {
            get
            {
                return _USER_NAME;
            }
            set
            {
                _USER_NAME = value;
            }
        }

        public static string USER_ID
        {
            get
            {
                return _USER_ID;
            }
            set
            {
                _USER_ID = value;
            }
        }

        public static string IMAGE_TO_INSTALL
        {
            get
            {
                return _IMAGE_TO_INSTALL;
            }
            set
            {
                _IMAGE_TO_INSTALL = value;
            }

        }

        public static string BUILD_TYPE
        {
            get
            {
                return _BUILD_TYPE;
            }
            set
            {
                _BUILD_TYPE = value;
            }

        }

        public static string EJL
        {
            get
            {
                return _EJL;
            }
            set
            {
                _EJL = value;
            }
        }

        public static string MAIN_DISK
        {
            get
            {
                return _MAIN_DISK;
            }
            set
            {
                _MAIN_DISK = value;
            }
        }

        public static string BASE_BOARD
        {
            get
            {
                return _BASE_BOARD;
            }
            set
            {
                _BASE_BOARD = value;
            }
        }


        public static bool IS_ADMIN
        {
            get
            {
                return _isAdmin;
            }
            set
            {
                _isAdmin = value;
            }
        }

        public static string PATH_UNIT_INFO
        {
            get
            {
                return @":\JABIL\UnitInfo\";
            }     
        }

        public static string PATH_USER_FILE
        {
            get
            {
                return @"\\mxchim0pangea01\AUTOMATION_SSCO\Config Files\Users.ini";
            }
        }

        public static string PATH_TEST_CUSTOMOS
        {
            get
            {
                return @"\\mxchim0pangea01\AUTOMATION_SSCO\IMAGES_SERVER_2.0\ConfigFile\TestCustomOS.ini";
            }
        }
        public static string PATH_FEATURES
        {
            get
            {
                return @"\\mxchim0pangea01\diskbld\feats\";
            }
        }

    }
}
