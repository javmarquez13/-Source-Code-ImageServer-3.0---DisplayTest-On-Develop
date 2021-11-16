using ManagedWimLib;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iFactoryInfo;
using System.Data;

namespace ImagesServer_v3._0
{
    class StaticFunctions
    {
        public static bool GetBuildType()
        {
            string _buildTypeDir = "";
            bool _buildTypeExist = false;

            string _buildtypeDirA = @"A:\build.typ";
            if (File.Exists(_buildtypeDirA)) _buildTypeDir = _buildtypeDirA;
            string _buildtypeDirB = @"B:\build.typ";
            if (File.Exists(_buildtypeDirB)) _buildTypeDir = _buildtypeDirB;
            string _buildtypeDirC = @"C:\build.typ";
            if (File.Exists(_buildtypeDirC)) _buildTypeDir = _buildtypeDirC;
            string _buildtypeDirD = @"D:\build.typ";
            if (File.Exists(_buildtypeDirD)) _buildTypeDir = _buildtypeDirD;
            string _buildtypeDirE = @"E:\build.typ";
            if (File.Exists(_buildtypeDirE)) _buildTypeDir = _buildtypeDirE;
            string _buildtypeDirF = @"F:\build.typ";
            if (File.Exists(_buildtypeDirF)) _buildTypeDir = _buildtypeDirF;
            string _buildtypeDirG = @"G:\build.typ";
            if (File.Exists(_buildtypeDirG)) _buildTypeDir = _buildtypeDirG;
            string _buildtypeDirH = @"H:\build.typ";
            if (File.Exists(_buildtypeDirH)) _buildTypeDir = _buildtypeDirH;
            string _buildtypeDirI = @"I:\build.typ";
            if (File.Exists(_buildtypeDirI)) _buildTypeDir = _buildtypeDirI;
            string _buildtypeDirJ = @"J:\build.typ";
            if (File.Exists(_buildtypeDirJ)) _buildTypeDir = _buildtypeDirJ;


            string[] _buildTypeArray = { "" };

            try
            {
                Globals.MAIN_DISK = _buildTypeDir.Substring(0, 1);
                Globals.BUILD_TYPE = File.ReadAllText(_buildTypeDir);
                _buildTypeArray = File.ReadAllLines(_buildTypeDir);
                Globals.TRACER = _buildTypeArray[0];
                _buildTypeExist = true;
            }
            catch (Exception)
            {
                _buildTypeExist = false;
            }

            return _buildTypeExist;
        }

        public static Tuple<string, bool> GetOS(string _class, string _mc)
        {
            string _dirFeatures = @"\\mxchim0pangea01\diskbld\feats\";
            string _OS = string.Empty;
            bool _MisanoFeature = false;
            string _FeatFileName = "feat" + _class;
            string[] _content = File.ReadAllLines(_dirFeatures + _FeatFileName);

            foreach (string _line in _content)
            {
                if (_line.Contains(_class + "-MC" + _mc))
                {
                    if (_line.Contains("F810") || _line.Contains("F812") || _line.Contains("F861")) _MisanoFeature = true;
                    if (_line.Contains("5801P099") || _line.Contains("5801P109")) _OS = "WIN7";
                    if (_line.Contains("5801P060")) _OS = "WIN7";
                    if (_line.Contains("5801P999")) _OS = "WIN7"; // NO OS
                    if (_line.Contains("5801P100")) _OS = "WIN10";
                    if (_line.Contains("5801P110")) _OS = "WIN10_P110";
                    break;
                }
            }
            return Tuple.Create(_OS, _MisanoFeature);
        }

        public static object PEFirmwareType()
        {
            RegistryKey key = Registry.LocalMachine.CreateSubKey(@"System\CurrentControlSet\Control"); //Function to review the BIOS CONFIGURATION 1=LEGACY 2=UEFI
            object value = key.GetValue("PEFirmwareType");         
            key.Close();

            return value;
        }

        public static string GetMotherBoardType()
        {
            string _ProductName = "";
            ManagementObjectSearcher _myBaseBoards = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");

            foreach (ManagementObject mybaseBoard in _myBaseBoards.Get())
            {
                _ProductName = mybaseBoard["Product"].ToString();
            }

            return _ProductName;
        }

        public static int ExternalExe(string FileName, string Args)
        {
            int _result = 0;
            Process _process = new Process();
            _process.StartInfo.FileName = FileName;
            _process.StartInfo.Arguments = Args;
            _process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            _process.Start();
            _process.WaitForExit();
            _result = _process.ExitCode;

            return _result;
        }

        public static string[] ListAllDrives()
        {
            List<string> _list = new List<string>();
            DriveInfo[] _DrivesInfo = DriveInfo.GetDrives();

            //get the full path to drive mapping
            string GetUNCPath(string path)
            {
                if (path.StartsWith(@"\\"))
                    return path;

                ManagementObject mo = new ManagementObject();
                mo.Path = new ManagementPath(string.Format("Win32_LogicalDisk='{0}'", path));

                //DriveType 4 = Network Drive
                if (Convert.ToUInt32(mo["DriveType"]) == 4)
                    return Convert.ToString(mo["ProviderName"]);
                else return path;
            }

            foreach (DriveInfo _driveInfo in _DrivesInfo)
            {
                DirectoryInfo dir = _driveInfo.RootDirectory;
                var unc = GetUNCPath(dir.FullName.Substring(0, 2));

                _list.Add(_driveInfo.Name + " " + unc);
            }
            return _list.ToArray();
        }

        public static int RemoveDrive(string letter)
        {
            string _NetProc = "net.exe";
            string _ArgsToRemove = @"use " + letter + " " + "/delete";
            int _result = ExternalExe(_NetProc, _ArgsToRemove);
            return _result;
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public static void GlobalInitWimLib()
        {
            string ExecuteLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string arch = System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
            if (arch.Contains("64"))
                Wim.GlobalInit(ExecuteLocation + @"\x64\libwim-15.dll");
            else
                Wim.GlobalInit(ExecuteLocation + @"\x86\libwim-15.dll");
        }

        ///<summary>
        /// Function to generate array variable with features
        /// <para>return the build.typ as an array variable</para>
        ///</summary>
        public static string[] GetFeatsString(string Class, string Mc)
        {
            string[] _Lines = { "" };
            string[] _split = { "" };
            string _pathFeats = @"\\mxchim0pangea01\diskbld\feats\Feat";
            string[] _featureString = { "" };

            int i = 0;
            int _space = 15;

            try
            {
                _Lines = File.ReadAllLines(_pathFeats + Class);

                foreach (string _line in _Lines)
                {
                    if (!_line.Contains("#"))
                    {
                        _split = _line.Split(' ');
                        i = _space - _split[0].Length;

                        if (_split[0].Contains(Class + "-MC" + Mc))
                        {
                            _featureString = _split[i].Split(new[] { Class }, StringSplitOptions.None);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
            }

            return _featureString;
        }

        ///<summary>
        /// Function to generate array variable with features like build.typ
        /// <para>return the build.typ as an array variable</para>
        ///</summary>
        public static List<string> GetFeatsDecription(string ClassMc, string[] features)
        {
            string _pathFeaturesDescription = @"\\mxchim0pangea01\diskbld\stdcore\feature.txt";
            List<string> _buildTypeList = new List<string>();

            try
            {
                foreach (string feat in features)
                {
                    if (feat != "")
                    {
                        string _DescriptionFeat = File.ReadAllLines(_pathFeaturesDescription).Where(x => x.Contains(feat.ToUpper() + " " + ClassMc)).FirstOrDefault();

                        string[] _split = _DescriptionFeat.Split(' ');
                        string FeatClass = _split[0] + " " + _split[1];
                        List<string> _splitDescriptions = new List<string>();
                        int loop = 0;
                        _splitDescriptions = _split.ToList();

                        foreach (string featB in _splitDescriptions)
                        {
                            if (featB != "00FF" && featB != "000A" && loop >= 2)
                            {
                                _buildTypeList.Add(featB);
                            }

                            loop++;
                        }
                    }
                }
            }
            catch (Exception)
            {
               
            }

            return _buildTypeList;
        }

        ///<summary>
        /// This function validate the currenct image on PRD into TDWH
        /// <para>The returned item1 Indicate if the units is an Interactive Teller Machine</para>
        ///</summary>
        public static bool IsUpToDateTDWH(string IMAGE_TO_INSTALL)
        {
            iFactoryInfo.iFactoryInfo _TestDataWareHouseQuery = new iFactoryInfo.iFactoryInfo();
            DataSet ds = _TestDataWareHouseQuery.GetMatrizProgramTDW("114", 1);
            DataTable dt = ds.Tables[0];

            return dt.Rows.Cast<DataRow>().Any(r => r.ItemArray.Any(c => c.ToString().Contains(IMAGE_TO_INSTALL)));
        }


        ///<summary>
        /// This Method validate if the unit is a Interactive Teller Machine \n
        /// <para>The returned item1 Indicate if the units is an Interactive Teller Machine</para>
        /// The returned item2 indicate if the function is active into ini file
        /// The returned item 3 indicate the feature for item Found
        ///</summary>
        public static Tuple<bool, bool, string> IsITM(string _class, string _mc)
        {
            //path for de features
            bool _ITM = false;
            bool _ITMActive = false;
            string _FeatureFind = string.Empty;
            string _FeatFileName = "feat" + _class;
            string _dirFeatures = @"\\mxchim0pangea01\diskbld\feats\";
            string _iniFile = @"\\mxchim0pangea01\AUTOMATION_SSCO\IMAGES_SERVER_2.0\ConfigFile\TestCustomOS.ini";//se agrega testcustom.ini
            string _strIniFile = File.ReadAllText(_iniFile);

            _ITMActive = ATM_Images.ITM_ACTIVE;

            string[] _splitStrIniFile = _strIniFile.Split(new string[] {"[ITM_FEATURES]"}, StringSplitOptions.RemoveEmptyEntries);
            string[] _ITMFeatures = _splitStrIniFile[1].Split(new string[] {"\n"}, StringSplitOptions.RemoveEmptyEntries).Where(x => x != "\r").ToArray();
            string[] _content = File.ReadAllLines(_dirFeatures + _FeatFileName);

            foreach (string _line in _content)
            {
                if (_line.Contains(_class + "-MC" + _mc))
                {
                    foreach(string ITMFeat in _ITMFeatures)
                    {
                        string toFind = ITMFeat.TrimEnd();

                        if (_line.Contains(toFind))
                        {
                            _ITM = true;
                            _FeatureFind = toFind;
                            break;
                        }
                    }
                    break;
                }
            }

            return Tuple.Create(_ITM, _ITMActive, _FeatureFind);
        
}


        ///<summary>
        /// This Function reboot the unit after 6 seconds
        ///</summary>
        public static void RebootUnit()
        {
            Process.Start("shutdown.exe", "-r -t 6");
        }
    }
}
