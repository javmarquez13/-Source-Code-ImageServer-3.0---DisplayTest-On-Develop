using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagesServer_v3._0
{
    class Bootmgr
    {
        public string Identifier { get; set; }
        string Device { get; set; }
        string Description { get; set; }
        string ResumeObject { get; set; }
    }

   //set id = 17 override hidden partition
   //detail partition
   //Create partition efi size=500
   //Format quick fs=FAT32 label=EFI
   //Convert gtp


   class Diskpart
    {
        public Diskpart()
        {

        }

        public string BootMgrIdentifier { get; set; }
        public string BootMgrdevice { get; set; }
        public string BootMgrdescription { get; set; }
        public string BootMgrresumeObject { get; set; }
               
        public string DefaultIdentifier { get; set; }
        public string Defaultdevice { get; set; }
        public string Defaultdescription { get; set; }
        public string DefaultresumeObject { get; set; }
               
        public string ITMIdentifier { get; set; }
        public string ITMdevice { get; set; }
        public string ITMdescription { get; set; }
        public string ITMresumeObject { get; set; }


        Process p = new Process();

        void Perform_DiskPart()
        {
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;

            if (File.Exists(@"X:\Windows\System32\Diskpart.exe"))
                p.StartInfo.FileName = @"X:\Windows\System32\diskpart.exe";
            else
                p.StartInfo.FileName = @"C:\Windows\System32\diskpart.exe";

            p.StartInfo.RedirectStandardInput = true;
            p.Start();
        }

        public virtual string SendCommand(string Command_1)
        {
            Perform_DiskPart();
            p.StandardInput.WriteLine(Command_1);
            p.StandardInput.WriteLine("Exit");
            return p.StandardOutput.ReadToEnd();
        }

        public virtual string SendCommand(string Command_1, string Command_2)
        {
            Perform_DiskPart();
            p.StandardInput.WriteLine(Command_1);
            p.StandardInput.WriteLine(Command_2);
            p.StandardInput.WriteLine("Exit");

            return p.StandardOutput.ReadToEnd();
        }

        public virtual string SendCommand(string Command_1, string Command_2, string Command_3)
        {
            Perform_DiskPart();
            p.StandardInput.WriteLine(Command_1);
            p.StandardInput.WriteLine(Command_2);
            p.StandardInput.WriteLine(Command_3);
            p.StandardInput.WriteLine("Exit");

            return p.StandardOutput.ReadToEnd();
        }


        public virtual string SendCommand(string Command_1, string Command_2, string Command_3, string Command_4)
        {
            Perform_DiskPart();
            p.StandardInput.WriteLine(Command_1);
            p.StandardInput.WriteLine(Command_2);
            p.StandardInput.WriteLine(Command_3);
            p.StandardInput.WriteLine(Command_4);
            p.StandardInput.WriteLine("Exit");

            return p.StandardOutput.ReadToEnd();
        }

        public virtual string SendCommand(string Command_1, string Command_2, string Command_3, string Command_4, string Command_5)
        {
            Perform_DiskPart();
            p.StandardInput.WriteLine(Command_1);
            p.StandardInput.WriteLine(Command_2);
            p.StandardInput.WriteLine(Command_3);
            p.StandardInput.WriteLine(Command_4);
            p.StandardInput.WriteLine(Command_5);
            p.StandardInput.WriteLine("Exit");

            return p.StandardOutput.ReadToEnd();
        }

        public virtual string SendCommand(string Command_1, string Command_2, string Command_3, string Command_4, string Command_5, string Command_6)
        {
            Perform_DiskPart();
            p.StandardInput.WriteLine(Command_1);
            p.StandardInput.WriteLine(Command_2);
            p.StandardInput.WriteLine(Command_3);
            p.StandardInput.WriteLine(Command_4);
            p.StandardInput.WriteLine(Command_5);
            p.StandardInput.WriteLine(Command_6);
            p.StandardInput.WriteLine("Exit");

            return p.StandardOutput.ReadToEnd();
        }

        public virtual string SendCommand(string Command_1, string Command_2, string Command_3, string Command_4, string Command_5, string Command_6, string Command_7)
        {
            Perform_DiskPart();
            p.StandardInput.WriteLine(Command_1);
            p.StandardInput.WriteLine(Command_2);
            p.StandardInput.WriteLine(Command_3);
            p.StandardInput.WriteLine(Command_4);
            p.StandardInput.WriteLine(Command_5);
            p.StandardInput.WriteLine(Command_6);
            p.StandardInput.WriteLine(Command_7);
            p.StandardInput.WriteLine("Exit");

            return p.StandardOutput.ReadToEnd();
        }


        public virtual string SendCommand(string Command_1, string Command_2, string Command_3, string Command_4, string Command_5, string Command_6, string Command_7, string Command_8)
        {
            Perform_DiskPart();
            p.StandardInput.WriteLine(Command_1);
            p.StandardInput.WriteLine(Command_2);
            p.StandardInput.WriteLine(Command_3);
            p.StandardInput.WriteLine(Command_4);
            p.StandardInput.WriteLine(Command_5);
            p.StandardInput.WriteLine(Command_6);
            p.StandardInput.WriteLine(Command_7);
            p.StandardInput.WriteLine(Command_8);
            p.StandardInput.WriteLine("Exit");

            return p.StandardOutput.ReadToEnd();
        }

        public virtual string SendCommand(string Command_1, string Command_2, string Command_3, string Command_4, string Command_5, string Command_6, string Command_7, string Command_8, string Command_9)
        {
            Perform_DiskPart();
            p.StandardInput.WriteLine(Command_1);
            p.StandardInput.WriteLine(Command_2);
            p.StandardInput.WriteLine(Command_3);
            p.StandardInput.WriteLine(Command_4);
            p.StandardInput.WriteLine(Command_5);
            p.StandardInput.WriteLine(Command_6);
            p.StandardInput.WriteLine(Command_7);
            p.StandardInput.WriteLine(Command_8);
            p.StandardInput.WriteLine(Command_9);
            p.StandardInput.WriteLine("Exit");

            return p.StandardOutput.ReadToEnd();
        }


        public virtual string SendCommand(string Command_1, string Command_2, string Command_3, string Command_4, string Command_5, string Command_6, string Command_7, string Command_8, string Command_9, string Command_10)
        {
            Perform_DiskPart();
            p.StandardInput.WriteLine(Command_1);
            p.StandardInput.WriteLine(Command_2);
            p.StandardInput.WriteLine(Command_3);
            p.StandardInput.WriteLine(Command_4);
            p.StandardInput.WriteLine(Command_5);
            p.StandardInput.WriteLine(Command_6);
            p.StandardInput.WriteLine(Command_7);
            p.StandardInput.WriteLine(Command_8);
            p.StandardInput.WriteLine(Command_9);
            p.StandardInput.WriteLine(Command_10);
            p.StandardInput.WriteLine("Exit");

            return p.StandardOutput.ReadToEnd();
        }


        public List<string> GetVolumes()
        {
            List<string> _volumes = new List<string>();
            Process p = new Process();

            try
            {           
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardOutput = true;

                if (File.Exists(@"X:\Windows\System32\Diskpart.exe"))
                    p.StartInfo.FileName = @"X:\Windows\System32\diskpart.exe";
                else
                    p.StartInfo.FileName = @"C:\Windows\System32\diskpart.exe";

                p.StartInfo.RedirectStandardInput = true;
                p.Start();
                p.StandardInput.WriteLine("list volume");
                p.StandardInput.WriteLine("exit");
                string output = p.StandardOutput.ReadToEnd();


                string table = output.Split(new string[] { "DISKPART>" }, StringSplitOptions.None)[1];
                var rows = table.Split(new string[] { "\n" }, StringSplitOptions.None);
                for (int i = 3; i < rows.Length; i++)
                {
                    if (rows[i].Contains("Volume"))
                    {
                        int index = Int32.Parse(rows[i].Split(new string[] { " " }, StringSplitOptions.None)[3]);
                        string letter = rows[i].Split(new string[] { " " }, StringSplitOptions.None)[8];
                        string label = rows[i].Split(new string[] { " " }, StringSplitOptions.None)[11];
                        string Fs = rows[i].Split(new string[] { " " }, StringSplitOptions.None)[18];
                        string type = rows[i].Split(new string[] { " " }, StringSplitOptions.None)[21];
                        string size = rows[i].Split(new string[] { " " }, StringSplitOptions.None)[25] + rows[i].Split(new string[] { " " }, StringSplitOptions.None)[26];
                        string Status = rows[i].Split(new string[] { " " }, StringSplitOptions.None)[28];
                        string Info = rows[i].Split(new string[] { " " }, StringSplitOptions.None)[32];


                        //_volumes.Add($@"Volume " + index + " " + letter + " " + label + " " + Fs + " " + type + " " + size + " " + Status + " " + Info);
                        _volumes.Add(rows[i]);
                    }
                }
              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return _volumes;
        }


        public List<string> ListDisk()
        {
            List<string> _Disks = new List<string>();
            Process p = new Process();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;

            if (File.Exists(@"X:\Windows\System32\Diskpart.exe"))
                p.StartInfo.FileName = @"X:\Windows\System32\diskpart.exe";
            else
                p.StartInfo.FileName = @"C:\Windows\System32\diskpart.exe";

            p.StartInfo.RedirectStandardInput = true;
            p.Start();

            p.StandardInput.WriteLine("list Disk");
            p.StandardInput.WriteLine("exit");
            string output = p.StandardOutput.ReadToEnd();


            string table = output.Split(new string[] { "DISKPART>" }, StringSplitOptions.None)[1];
            var rows = table.Split(new string[] { "\n" }, StringSplitOptions.None);
            for (int i = 3; i < rows.Length; i++)
            {
                if (rows[i].Contains("Disk 0") || rows[i].Contains("Disk 1") || rows[i].Contains("Disk 2") | rows[i].Contains("Disk 3"))
                {
                    int index = Int32.Parse(rows[i].Split(new string[] { " " }, StringSplitOptions.None)[3]);
                    string Disk = rows[i].Split(new string[] { " " }, StringSplitOptions.None)[2] + " " +  rows[i].Split(new string[] { " " }, StringSplitOptions.None)[3];
                    string Status = rows[i].Split(new string[] { " " }, StringSplitOptions.None)[7];
                    string Size = rows[i].Split(new string[] { " " }, StringSplitOptions.None)[17] + rows[i].Split(new string[] { " " }, StringSplitOptions.None)[18];
                    string Free = rows[i].Split(new string[] { " " }, StringSplitOptions.None)[24] + rows[i].Split(new string[] { " " }, StringSplitOptions.None)[25];
                    _Disks.Add(rows[i]);
                }
            }

            return _Disks;
        }



        public virtual string BCDBoot(string Command_1)
        {
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.StartInfo.Arguments = Command_1;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;

            if (File.Exists(@"X:\Windows\System32\Bcdboot.exe"))
                p.StartInfo.FileName = @"X:\Windows\System32\Bcdboot.exe";
            else
                p.StartInfo.FileName = @"C:\Windows\System32\Bcdboot.exe";

            p.StartInfo.RedirectStandardInput = true;
            p.Start();
            p.WaitForExit();
            p.StandardOutput.ReadToEnd();

            int result = p.ExitCode;
            string Error = string.Empty;

            if (result != 0)
            {
                Error = "Exit Code Error: " + result.ToString() + " " + p.StandardOutput.ReadToEnd();
                MessageBox.Show(Error);
            }

            return Error;
        }


        public virtual string BCDEdit(string Command_1)
        {
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.StartInfo.Arguments = Command_1;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;

            if (File.Exists(@"X:\Windows\System32\Bcdboot.exe"))
                p.StartInfo.FileName = @"X:\Windows\System32\Bcdedit.exe";
            else
                p.StartInfo.FileName = @"C:\Windows\System32\Bcdedit.exe";

            p.StartInfo.RedirectStandardInput = true;
            p.Start();
            p.WaitForExit();
            string output = p.StandardOutput.ReadToEnd();

            string[] PARTITIONS = output.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);


            foreach(string PARTITION in PARTITIONS)
            {
                if (PARTITION.Contains("identifier"))
                {
                    if (PARTITION.Contains("{bootmgr}"))
                    {
                        BootMgrIdentifier = PARTITION.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1].TrimEnd();
                    }

                    if (PARTITION.Contains("{default}") || PARTITION.Contains("{current}"))
                    {
                        DefaultIdentifier = PARTITION.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1].TrimEnd();
                    }

                    if (PARTITION.Contains("identifier") && !PARTITION.Contains("{default}") && !PARTITION.Contains("{current}") && !PARTITION.Contains("{bootmgr}"))
                    {
                        ITMIdentifier = PARTITION.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1].TrimEnd();
                    }
                }
            }


            return output;
        }



    }
}
