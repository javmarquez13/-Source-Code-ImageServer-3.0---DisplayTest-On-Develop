using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management;
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


        private static string _Version;
        public static string VERSION
        {
            get
            {
                return _Version;
            }
            set
            {
                _Version = value;
            }
        }


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









        private static DataTable _IncommingData;
        public static DataTable INCOMMING_DATA
        {
            get
            {
                return _IncommingData;
            }
            set
            {
                _IncommingData = value;
            }
        }

        public static string PATH_INCOMMING_DATA
        {
            get
            {
                return @"\\mxchim0pangea01\AUTOMATION_SSCO\IMAGES_SERVER_2.0\!IncommingData\IncommingData.xlsx";
            }
        }

        public static string CPU_TYPE
        {
            get
            {
                string CPU = string.Empty;
                var result_cpu = new ManagementObjectSearcher("select * from Win32_Processor").Get().Cast<ManagementObject>().First();
                return ((string)result_cpu["Name"]).ToLower();
            }
        }

        public static ulong MEMORY_RAM
        {
            get
            {
                UInt64[] _size = new UInt64[4];
                string[] _slots = new string[4];
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

                }

                return MEMORY_RAM;
            }
        }

        public static long SSD_SIZE
        {
            get
            {
                //ManagementScope scope = new ManagementScope(@"\\.\root\microsoft\windows\storage");
                ManagementScope scope = new ManagementScope(@"\\.\root\CIMV2");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                long Size = 0;
                scope.Connect();
                searcher.Scope = scope;

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Size =Convert.ToInt64(queryObj["Size"]);
                    break;
                }


                return Size;         
            }
        }
    }
}
