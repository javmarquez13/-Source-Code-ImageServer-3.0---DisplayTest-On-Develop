using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.Media;
using Microsoft.Win32;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using iFactoryInfo;
using ManagedWimLib;

namespace ImagesServer_v3._0
{
    /// FIRST RELEASE BY FRANCISCO MARQUEZ 
    /// IMAGES SERVER v2.0
    /// 
    /// 30 OCTUBRE 2019
    /// FIRST RELEASE
    /// 2.0.0.1
    /// 
    /// 31 OCTUBRE 2019
    /// Se agrega imagen pboxStatus para visualizar marca good y marca bad en la instalacion de custom os.
    /// 2.0.0.2
    /// 
    /// 31 OCTUBRE 2019
    /// Se agrega function para instalar imagen de atms desde el servidor.
    /// 2.0.0.3
    /// 
    /// 31 OCTUBRE 2019
    /// Se agrega numero de empleado en la segunda posicion al C:\jabil\unitinfo\file.txt
    /// 2.0.0.4
    /// 
    /// 01 NOVIEMBRE 2019
    /// Se omite verificacion de step en ifactory para ahorrar tiempo en linea de produccion.
    /// 2.0.0.5
    /// 
    /// 
    /// 01 NOVIEMBRE 2019
    /// Se agrega candado a la instalcion de iamgen de prueba pidiendo primero el pass de hipot antes de instalarse
    /// 2.0.0.6
    /// 
    /// 
    /// 04 NOVIEMBRE 2019
    /// Mostrar la informacion del empleado al instalar CUSTOM OS
    /// 2.0.0.7
    /// 
    /// 
    /// 04 NOVIEMBRE 2019
    /// Se agrega candado para que el operador no de varios click en btnInstallTestImage y btnInstallCustomOS con animacion
    /// 2.0.0.8
    /// 
    /// 
    /// 05 NOVIEMBRE 2019
    /// Se agrega variables SITE, USER y FACTORY para capturar y aplicar imagen
    /// 2.0.0.9
    /// 
    /// 
    /// 05 NOVIEMBRE 2019
    /// Se agrega boton de refresh en capture y apply "private void btnCapture_Refresh_Click(object sender, EventArgs e) FillListAllDisk();" 
    /// 2.0.1.0
    /// 
    /// 06 NOVIEMBRE 2019
    /// Se agerga nuevos nombres a las imagenes de ATMs para estandarizar.
    /// 2.0.1.1
    /// 
    /// 
    /// 06 NOVIEMBRE 2019
    /// Se agrega confiramcion de BIOS MODE para ATMs
    /// 2.0.1.2
    /// 
    /// 07 NOVIEMBRE 2019
    /// Candado para verificacion del registro BIOS_MODE UEFI PARA WINDOWS10 y LEGACY PARA WINDOWS7
    /// 2.0.1.3
    /// 
    /// 11 NOVIEMBRE 2019
    /// Strech Image para pBoxStatus
    /// 2.0.1.4
    /// 
    /// 15 NOVIEMBRE 2019
    /// Se cambia la ruta para descarga de imagnes a MXCHIM0PANGAEA02 atms
    /// 2.0.1.5
    /// 
    /// 19 NOVIEMBRE 2019
    /// Se cambia la ruta para descarga de imagnes a MXCHIM0PANGAEA02 en sscos
    /// 2.0.1.6
    /// 
    /// 19 NOVIEMBRE 2019
    /// Se eliminan espacios en log custom os cuando la unidad falla al instalar imagen
    /// 2.0.1.7
    /// 
    /// 20 NOVIEMBRE 2019
    /// En vaidacion imagen 7703W10_TESTIMAGE_v1.8.1_UAT.wim 20 de noviembre 2019
    /// 2.0.1.8
    /// 
    /// 22 NOVIEMBRE 2019
    /// Se elimina prompt antes de instalar imagen
    /// 2.0.1.9
    /// 
    /// 25 NOVIEMBRE 2019
    /// En vaidacion imagen 7360R6_TESTIMAGE_v1.8.1_UAT.wim 25 NOVIEMBRE 2019
    /// 2.0.2.0
    /// 
    /// 25 NOVIEMBRE 2019
    /// En vaidacion imagen 7350R6LITE_TESTIMAGE_v1.8.1_PROD.wim 25 NOVIEMBRE 2019
    /// *PangaeaDownloader 1.4.5
    /// *Pangaea 1.8.1.0
    /// 2.0.2.1
    /// 
    /// 26 NOVIEMBRE 2019
    /// Se agrega condicion para seleccionar imagen 7703 para la tarjeta richmond y la clase 7360 nuevo MC 7360MC1043 
    /// 2.0.2.2
    /// 
    /// 26 NOVIEMBRE 2019
    /// Release 7703W10_TESTIMAGE_v1.8.1_PROD.WIM, 7360R6_TESTIMAGE_v1.8.1_PROD.WIM en produccion
    /// 2.0.2.3
    /// 
    /// 02 DICIEMBRE 2019
    /// Release 7350R6LITE_TESTIMAGE_v1.8.1_PROD.wim en produccion
    /// 2.0.2.4
    /// 
    /// 03 DICIEMBRE 2019
    /// Funcion para crear file UnitInfo en prueba de Core
    /// 2.0.2.5
    /// 
    /// 05 DICIEMBRE 2019
    /// Archivo de configuracion de imagenes SetupTestImage.ini \\mxchim0pangea01\AUTOMATION_SSCO\IMAGES_SERVER_2.0\ConfigFile\SetupTestImages.ini
    /// Verificacion de step FVT antes de cargar test image
    /// 2.0.2.6
    ///
    /// 
    /// 20 DICIEMBRE 2019
    /// Funcion para reportar el status en semaforo TEST IMAGE
    /// 2.0.2.7
    /// 
    /// 26 DICIEMBRE 2019
    /// Funcion para reportar el status en semaforo CUSTOMER IMAGE
    /// 2.0.2.8
    /// 
    /// 
    /// 26 DICIEMBRE 2019
    /// Clase GetSlotByIp identifica la ip y proporciona el slot fisico de la UUT
    /// 2.0.2.9
    /// 
    /// 08 ENERO 2020
    /// Funcion en winTracer.cs para seleccionar slot en layout de sscos
    /// 2.0.3.0
    /// 
    /// 08 ENERO 2020
    /// Se agrega #Slot al file JABIL\UnitInfo\fileUnitInfo.txt
    /// 2.0.3.1
    /// 
    /// 09 ENERO 2020
    /// Modificacion de ReportingSemaphore se agrega columna de color
    /// 2.0.3.2
    /// 
    /// 09 ENERO 2020
    /// Se agrega clase y mc a .xml de RerpotingSemaphore
    /// 2.0.3.3
    /// 
    /// 10 ENERO 2020
    /// Se agrega condicion para la instalacionde imagen 7607_7703_Retail_Win10IoT_2019_v1809_64Bit_01.00.00.01.wim
    /// 2.0.3.4
    /// 
    /// 06 FEBRERO 2020
    /// Se agrega columan operador a el xml ReporingSemaphore
    /// 2.0.3.5
    /// 
    /// 11 FEBRERO 2020
    /// Se agrega columna progress a el xml ReporingSemaphore
    /// 2.0.3.6
    /// 
    /// 21 FEBRERO 2020
    /// Se agrega teclado numero en pantalla
    /// 2.0.3.7
    /// 
    /// 11 MARZO 2020
    /// Se migran imagenes de prueba ATMS a MXCHIM0PANGEA01
    /// 2.0.3.8
    /// 
    /// 11 MARZO 2020
    /// Funcion para capturar y aplicar imagenes sin utilerias de NCR
    /// 2.0.3.9
    /// 
    /// 25 MARZO 2020
    /// Verificar EJL antes de instalar TEST IMAGE para elimianr duplicados de prueba en unidades.
    /// 2.0.4.0
    /// 
    /// 27 ABRIL 2020
    /// Password para aplicar, capturar y mapear drives.
    /// 2.0.4.1
    /// 
    /// 07 MAYO 2020
    /// Se agrega nueva imagen MISANO
    /// 2.0.4.2
    /// 
    /// 26 JUNIO 2020
    /// Se agrega condicion para buscar disco hasta la letra J en custom os
    /// 2.0.4.3
    /// 
    /// 26 JUNIO 2020
    /// Se agrega condicion para nuevo mc con feature 7360-F120 WIN10IOT_64
    /// 2.0.4.4
    /// 
    /// 28 JUNIO 2020
    /// Se agrega condicion para nuevo feature P060 WIN7 10083193 validacion con ese tracer
    /// 2.0.4.5
    /// 
    /// 28 JUNIO 2020
    /// Se agrega condicion para validar configuracion de bios en windows 7 baseboard misano fix.
    /// 2.0.4.6
    /// 
    /// REMOVED
    /// 28 JUNIO 2020
    /// Se agrega candado para verificar que el display coincida con el tracer indicado. Richmond 7703.
    /// **********
    /// 
    /// 
    /// 13 OCTUBRE 2020
    /// Se agrega try catch para verificar error al final de la imagen
    /// 2.0.4.7
    /// 
    /// 
    /// 16 OCTUBRE 2020
    /// Se remueve rutina para reportar xmllog al sempaforo
    /// 2.0.4.8
    /// 
    /// 
    /// 03 NOVIEMBRE 2020
    /// Se remueve rutina para reportar xmllog al semaforo
    /// 2.0.4.9
    /// 
    /// 
    /// 04 NOVIEMBRE 2020
    /// Se modifica funcion para cargado de imagens de ATM 5801P100 WIN10, 5801P099 WIN07, 5801P060 WIN07
    /// 2.0.5.0
    /// 
    /// 
    /// 05 NOVIEMBRE 2020
    /// Se agrega feature 5801P999 WIN07
    /// 2.0.5.1
    /// 
    /// 
    /// 05 ENERO 2021
    /// Rutina para borrar directorio si este esta existente  line 709 if (DirInfo.Exists) DirInfo.Delete(true);
    /// 2.0.5.2
    /// 
    /// 
    /// 06 ENERO 2021
    /// Rutina para borrar directorio si este esta existente  line 709 if (DirInfo.Exists) DirInfo.Delete(true); FIX
    /// 2.0.5.3
    /// 
    /// 
    /// 24 FEBRERO 2021
    /// Se agrega clase para mandar tars a equipo triligth y empezar su contrtuccion.
    /// 2.0.5.4
    /// 
    /// 
    /// 06 ABRIL 2021
    /// Se agrega nuevo feature para la identificacion de descarga de imagen WIN10 P110
    /// 2.0.5.5
    /// 
    /// 06 ABRIL 2021
    /// Se agrega nueva rutina para ITM
    /// 2.0.5.6
    /// 
    /// 07 ABRIL 2021
    /// Fix aplicacion no corre desde el starnet.cmf
    /// 2.0.5.7
    /// 
    /// 12 ABRIL 2021
    /// Se agrega nueva logica para la instalacion de imagenes en ATM, se incluye nuevo feature P110 TestImageEstorilMisano windows 10 2019
    /// 2.0.5.8
    /// 2.0.5.9
    /// 
    /// 14 ABRIL 2021
    /// Develop and implementation Image GUI Jabil for ITM Test
    /// 2.0.6.0
    /// 
    /// 19 ABRIL 2021
    /// Se acomoda lblresult
    /// 2.0.6.1
    /// 
    /// 20 ABRIL 2021
    /// Fix booteo UEFI con la nueva imagen de ATM P110
    /// 2.0.6.2
    /// 
    /// 22 ABRIL 2021
    /// Update functions Diskpart 
    /// 2.0.6.3
    /// 2.0.6.4
    /// 2.0.6.5
    /// 2.0.6.6
    /// 2.0.6.7
    /// 2.0.6.8
    /// 2.0.6.9
    /// 2.0.7.0
    /// 2.0.7.1  Ask Password when the application execution is outside the debug enviroment.
    /// 
    /// 
    /// 26 ABRIL 2021
    /// Cambio de rutina para instalacion de imagenes en SSCOS
    /// 2.0.7.2 Se agreaga variable INSTALL_IMAGE
    /// 2.0.7.3 Se cambia Rads ImageX por JImageX para minimizar tiempo de carga de imagen en sscos
    /// 2.0.7.4 Se renombra variable para imagen  7360 por 7702
    /// 2.0.7.5 Se renombra funcion SetupImages() por GettingImages()
    /// 2.0.7.6 Fix
    /// 2.0.7.7 Fix
    /// 2.0.7.8 Fix
    /// 2.0.7.9 Fix
    /// 2.0.8.0 Release JimageX to Prod (On Validation)
    /// 
    /// 
    /// 27 ABRIL 2021
    /// Improve Loading Windows WaitWin
    /// 2.0.8.1
    /// 
    /// 27 ABRIL 2021
    /// Improve iMAGEXUI interface 
    /// 2.0.8.2
    /// 
    /// 
    /// 27 ABRIL 2021
    /// Improve iMAGEXUI interface 
    /// 2.0.8.3
    /// 
    /// 30 ABRIL 2021
    /// Improve iMAGEXUI interface 
    /// 2.0.8.4
    /// 2.0.8.5
    /// 
    /// 30 ABRIL 2021
    /// Fix Erorr Image Win07 
    /// 2.0.8.6
    /// 
    /// 07 MAYO 2021
    /// FIX ISSUES RELEATED WITH BCDBOOT AND DISKPART
    /// 2.0.8.7
    /// 
    /// 07 MAYO 2021
    /// Added label Baseboard to show the user what type of mother board has into Core or Display unit.
    /// 2.0.8.8
    /// 
    /// 
    /// 12 MAYO 2021
    /// Improve some methods and functions for better source code understanding
    /// 2.0.8.9 Clean all warnings 
    /// 2.0.9.0 Clean functions and variables not used
    /// 
    /// 14 MAYO 2021
    /// Use this command to hide the D partition boot manager on windows set id=17 override ssco Test Image
    /// 2.0.9.1
    /// 
    /// 21 MAYO 2021
    /// Add feature for ATM 5801P109 as Windows 07 TestImage.
    /// 2.0.9.2
    /// 
    /// 
    /// 
    /// 25 MAYO 2021
    /// Add static function to validate image on test data ware house before to be installed.
    /// 2.0.9.3
    /// 
    /// 10 JUNIO 2021
    /// Release function to ITM on PRD
    /// 2.0.9.4
    /// 2.0.9.5
    /// 
    /// 11 JUNIO 2021 
    /// The matrix of script validation from through TestDataWareHouse has been commented due to the function not yet is ready 
    /// 2.0.9.6
    /// 
    /// 
    /// 15 JUNIO 2021 
    /// Fix download image WIN10 for ITM 
    /// 2.0.9.7
    /// 
    /// 21 JUNIO 2021 
    /// Replace getSerialMC dll old IT change servers.
    /// 2.0.9.8
    /// 2.0.9.9
    /// 
    /// 
    /// 23 JUNIO 2021 
    /// Added new baseboard type as MISANO=K for new feature instroduction 6688-F861 KABYLAKE CPU Intel Core i5-7500T Processor, 35W, Kaby Lake 
    /// 2.1.0.0
    /// 
    /// 24 JUNIO 2021 
    /// Added new image TestImageKabyLake_Windows10
    /// 2.1.0.1
    /// 
    /// 
    /// 31 AGOSTO 2021 
    /// Added new application for Display Test Station
    /// 3.0.0.0
    ///
    /// 
    /// 
    /// 15 AGOSTO 2021 
    /// New version first release to production
    /// 3.0.0.1
    /// 
    /// 
    /// 02 NOVEMBER
    /// SKIP HIPOT VALIDATION TO NEW IMPLEMENTATION DISPLAY STATION
    /// 3.0.0.2


    ///<summary>
    /// IMAGES SERVER 2.0 APPLICATION DEVELOPED FOR CAPTURE AND DOWLONAD IMAGES VIA SERVER BY FRANCISCO MARQUEZ 
    ///</summary>
    public partial class Form1 : Form
    {
        public static string _version { get; set; }
        bool _DarkMode = true;
        public Form1()
        {
            InitializeComponent();
            RoundObjects();
            //label with the application version.
            _version = "v3.0.0.2";
            lblVersion.Text = _version;
        }

        #region Variables Globales

        public static string IMAGE_TO_INSTALL { get; set; }
        public static string _class { get; set; }
        public static string _serialNumber { get; set; }
        public static string _mc { get; set; }
        public static string _tracer { get; set; }
        public static string _ID { get; set; }
        public static string _Name { get; set; }

        string _RadsImage = @"X:\ImagingTools\RadsImageX.exe";
        string _ImageXUEFI = @"X:\windows\system32\imagexUFEI.exe";

        string _CaptureArgsStart = "/capture ";
        int seconds = 5;

        string _tempSubFolder = "";
        string _tempServer = "";
        string _tempDrive = "";


        //WIMLIB
        List<string> _AvailableVolumes = new List<string>();
        Diskpart Diskpart = new Diskpart();
        ImageXGUI JIMAGEX;


        string ATM_IMAGES = "T:"; //Pangaea 02
        string SSSCO_IMAGES_02 = "R:"; //Pangaea 02

        iFactoryInfo.iFactoryInfo _iFactoryInfo = new iFactoryInfo.iFactoryInfo();



        TestAndCustomOS _TestAndCustomOS = new TestAndCustomOS();

        //Diskpart Region
        enum DiskPartCommands
        {
            Clean,
            Shrink,
            CreatePartitionPrimary
        }

        DiskPartCommands _DiskPartCommands;



        #endregion

        #region Diseno de aplicacion

        void RoundObjects()
        {
            BtnExit.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, BtnExit.Width, BtnExit.Height, 10, 10));
            BtnMinimize.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, BtnMinimize.Width, BtnMinimize.Height, 10, 10));


            btnTab1.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btnTab1.Width, btnTab1.Height, 10, 10));
            btnTab2.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btnTab2.Width, btnTab2.Height, 10, 10));
            btnTab3.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btnTab3.Width, btnTab3.Height, 10, 10));
            btnTab4.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btnTab4.Width, btnTab4.Height, 10, 10));
            btnTab5.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btnTab5.Width, btnTab5.Height, 10, 10));

            panel_1.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, panel_1.Width, panel_1.Height, 10, 10));
            panel_2.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, panel_2.Width, panel_2.Height, 10, 10));
            panel_3.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, panel_3.Width, panel_3.Height, 10, 10));


            btnTestImage_sscos.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btnTestImage_sscos.Width, btnTestImage_sscos.Height, 15, 15));
            btnCustomOS_sscos.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btnCustomOS_sscos.Width, btnCustomOS_sscos.Height, 15, 15));


            //Apply Windows
            lbImagesServer_apply.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, lbImagesServer_apply.Width, lbImagesServer_apply.Height, 10, 10));
            lbImagesToApply_apply.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, lbImagesToApply_apply.Width, lbImagesToApply_apply.Height, 10, 10));
            lvVolumes.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, lvVolumes.Width, lvVolumes.Height, 10, 10));
            txtWimInfo_Apply.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, txtWimInfo_Apply.Width, txtWimInfo_Apply.Height, 10, 10));
            btnApply_Back.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btnApply_Back.Width, btnApply_Back.Height, 10, 10));
            btnApplyJImagex.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btnApplyJImagex.Width, btnApplyJImagex.Height, 10, 10));
            btn_ImagexApply.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btn_ImagexApply.Width, btn_ImagexApply.Height, 10, 10));
            btnApply_Refresh.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btnApply_Refresh.Width, btnApply_Refresh.Height, 10, 10));

            //capture windows
            lvDescription_capture.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, lvDescription_capture.Width, lvDescription_capture.Height, 10, 10));
            lvPartition_capture.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, lvPartition_capture.Width, lvPartition_capture.Height, 10, 10));
            lbSaveImage_capture.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, lbSaveImage_capture.Width, lbSaveImage_capture.Height, 10, 10));
            lvFilesView_capture.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, lvFilesView_capture.Width, lvFilesView_capture.Height, 10, 10));
            txtImageName_capture.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, txtImageName_capture.Width, txtImageName_capture.Height, 10, 10));
            btnCapture_capture.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btnCapture_capture.Width, btnCapture_capture.Height, 10, 10));
            btnCaptureJImagex.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btnCaptureJImagex.Width, btnCaptureJImagex.Height, 10, 10));
            btnCaptureImageX.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btnCaptureImageX.Width, btnCaptureImageX.Height, 10, 10));
            btnCapture_Refresh.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btnCapture_Refresh.Width, btnCapture_Refresh.Height, 10, 10));

            //diskpart
            lvVolumes_Diskpart.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, lvVolumes_Diskpart.Width, lvVolumes_Diskpart.Height, 10, 10));
            panel_1_Diskpart.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, panel_1_Diskpart.Width, panel_1_Diskpart.Height, 10, 10));
            panel_1_Diskpart.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, panel_1_Diskpart.Width, panel_1_Diskpart.Height, 10, 10));
            btnRefresh_Diskpart.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btnRefresh_Diskpart.Width, btnRefresh_Diskpart.Height, 10, 10));
            btnDiskPartFunction.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btnDiskPartFunction.Width, btnDiskPartFunction.Height, 10, 10));


            //NetworkDrives windows
            panel2_NetworkDrives.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, panel2_NetworkDrives.Width, panel2_NetworkDrives.Height, 10, 10));
            lbAllDrives_settings.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, lbAllDrives_settings.Width, lbAllDrives_settings.Height, 10, 10));
            panel1_NetWorkDrives.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, panel1_NetWorkDrives.Width, panel1_NetWorkDrives.Height, 10, 10));
            btnMap_settings.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btnMap_settings.Width, btnMap_settings.Height, 10, 10));
            btnRefreshDrives_settings.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, btnRefreshDrives_settings.Width, btnRefreshDrives_settings.Height, 10, 10));
            txtUser_settings.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, txtUser_settings.Width, txtUser_settings.Height, 10, 10));
            txtPassword_settings.Region = Region.FromHrgn(DesignGlobals.CreateRoundRectRgn(0, 0, txtPassword_settings.Width, txtPassword_settings.Height, 10, 10));
        }

        void DarkMode()
        {
            this.BackColor = DesignGlobals.BackGroundDarkMode;



            this.Refresh();
        }


        void WhiteMode()
        {
            this.BackColor = DesignGlobals.BackGroundWhiteMode;


            this.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (_DarkMode)
            {
                WhiteMode();
                _DarkMode = false;
            }
            else
            {
                DarkMode();
                _DarkMode = true;
            }           
        }




        #endregion

        #region Eventos Aplicaion

        private void Form1_Load(object sender, EventArgs e)
        {
            StaticFunctions.GlobalInitWimLib();
            lblResult.Text = "";

            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.Region = new Region(new RectangleF(this.tabPage1.Left, this.tabPage1.Top, this.tabPage1.Width, this.tabPage1.Height));

            _TestAndCustomOS.GettingImages();

            //simulate click 
            using (WaitWin waitWin = new WaitWin(RefreshItems, "UPDATING INFORMATION"))
            {
                waitWin.ShowDialog(this);
            }
            
            //initialize listviews
            InitListViews();
            FillListAllDisk();

            //initialize settings capture mode  
            if (Properties.Settings.Default._captureMode == "Site")
            {
                rbtnSite_capture.Checked = true;
            }
            if (Properties.Settings.Default._captureMode == "User")
            {
                rbtnUser_catpure.Checked = true;
            }
            if (Properties.Settings.Default._captureMode == "Factory")
            {
                rbtnFactory_capture.Checked = true;
            }

            //initialize settings apply mode       
            if (Properties.Settings.Default._applyMode == "Site")
            {
                rbtnSite_apply.Checked = true;
            }
            if (Properties.Settings.Default._applyMode == "User")
            {
                rbtnUser_apply.Checked = true;
            }
            if (Properties.Settings.Default._applyMode == "Factory")
            {
                rbtnFactory_apply.Checked = true;
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnCustomOS_sscos_Click(object sender, EventArgs e)
        {
            //Disable button while the function is running
            btnCustomOS_sscos.Enabled = false;

            InstallCustomOS();

            //Enable button when the function will be completed
            btnCustomOS_sscos.Enabled = true;
        }

        private void BtnTestImage_sscos_Click(object sender, EventArgs e)
        {
            btnTestImage_sscos.Enabled = false;
         
            string _BaseBoard = StaticFunctions.GetMotherBoardType();
        
            lblBaseBoard.Text = "BASE BOARD: " + _BaseBoard.ToUpper();

            if (_BaseBoard == "Estoril" || _BaseBoard == "Misano" || _BaseBoard == "Misano-K")
            {
                InstallTestImageATM();
                btnTestImage_sscos.Enabled = true;
                return;
            }

            if (_BaseBoard == "Pocono" || _BaseBoard == "Monaco" || _BaseBoard == "Richmond" || _BaseBoard == "Eldora" || _BaseBoard == "8079")
            {               
                InstallTestImageSSCO();
                btnTestImage_sscos.Enabled = true;
                return;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            seconds--;
            if (seconds == 0) timer1.Stop();
            lblResult.Text = "El equipo se reniciara en: " + seconds.ToString();
        }

        private void LvFilesView_capture_Click(object sender, EventArgs e)
        {
            var fisrtSelectionedItem = lbSaveImage_capture.Text;
            string[] split = fisrtSelectionedItem.Split(' ');
            string _root = split[0];
            string _path = split[1];
            var SecondSelectedItem = lvFilesView_capture.SelectedItems[0];
            string _subFolder = SecondSelectedItem.Text;
            _tempSubFolder = _tempSubFolder + "\\" + _subFolder;
            _subFolder = _path + "\\" + _tempSubFolder;

            ListAllFilesFromServer(_subFolder, true);
        }

        private void LbSaveImage_capture_SelectedIndexChanged(object sender, EventArgs e)
        {
            _tempSubFolder = "";
            _tempServer = lbSaveImage_capture.Text;
            _tempServer = _tempServer.Substring(0, 2);
            ListAllFilesFromServer(lbSaveImage_capture.Text, false);
        }

        private void LvDescription_capture_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _tempDrive = lvDescription_capture.SelectedItems[0].Text;
            }
            catch (Exception)
            {

            }
        }

        private void BtnCapture_capture_Click(object sender, EventArgs e)
        {
            if (txtImageName_capture.Text == "") return;
            if (_tempServer == "") return;
            if (_tempDrive == "") return;

            ManagementObjectSearcher _myDisks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            ManagementObjectCollection _disks = _myDisks.Get();
            List<ManagementObject> moList = _disks.Cast<ManagementObject>().ToList();
            string _dName = moList[Convert.ToInt32(_tempDrive)]["Model"].ToString();
            string _size = moList[Convert.ToInt32(_tempDrive)]["Size"].ToString();


            string _label = "You are about to capture the 1 partition on drive " + _tempDrive + " " + "[" + _dName + "]" + " " + "to " + _tempServer + "\\" + txtImageName_capture.Text;

            DialogResult dr = new DialogResult();
            dr = MessageBox.Show(_label, "Capture image", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.OK) CaptureRadsImage(_tempDrive, txtImageName_capture.Text, _tempServer, Properties.Settings.Default._captureMode);
        }

        private void RbtnSite_capture_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default._captureMode = "SITE";
            Properties.Settings.Default.Save();
        }

        private void RbtnUser_catpure_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default._captureMode = "USER";
            Properties.Settings.Default.Save();

        }

        private void RbtnFactory_capture_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default._captureMode = "FACTORY";
            Properties.Settings.Default.Save();
        }

        private void BtnCapture_Refresh_Click(object sender, EventArgs e)
        {
            FillListAllDisk();

            string[] _result = StaticFunctions.ListAllDrives();

            lbAllDrives_settings.Items.Clear();
            lbImagesServer_apply.Items.Clear();
            lbSaveImage_capture.Items.Clear();

            foreach (string _drive in _result)
            {
                lbAllDrives_settings.Items.Add(_drive);
                lbImagesServer_apply.Items.Add(_drive);
                lbSaveImage_capture.Items.Add(_drive);
            }
        }

        private void BtnApply_Refresh_Click(object sender, EventArgs e)
        {
            using (WaitWin waitWin = new WaitWin(RefreshItems, "UPDATING INFORMATION"))
            {
                waitWin.ShowDialog(this);
            }
        }

        private void BtnRefresh_Diskpart_Click(object sender, EventArgs e)
        {
            using (WaitWin waitWin = new WaitWin(RefreshItems, "UPDATING INFORMATION"))
            {
                waitWin.ShowDialog(this);
            }
        }

        private void LbImagesServer_apply_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetImagesFilesFromSever(lbImagesServer_apply.Text);
        }

        private void BtnApply_apply_Click(object sender, EventArgs e)
        {
            if (lbImagesToApply_apply.SelectedIndex == -1) return;
            StaticJImgaeX.APPLY_RADSIMAGEX(lbImagesToApply_apply.Text, "/reboot ", Properties.Settings.Default._applyMode);
        }

        private void RbtnSite_apply_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default._applyMode = "SITE";
            Properties.Settings.Default.Save();
        }

        private void RbtnUser_apply_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default._applyMode = "USER";
            Properties.Settings.Default.Save();
        }

        private void RbtnFactory_apply_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default._applyMode = "FACTORY";
            Properties.Settings.Default.Save();
        }

        private void BtnRefreshDrives_settings_Click(object sender, EventArgs e)
        {
            using (WaitWin waitWin = new WaitWin(RefreshItems, "UPDATING INFORMATION"))
            {
                waitWin.ShowDialog(this);
            }
        }

        private void BtnMap_settings_Click(object sender, EventArgs e)
        {
            if (cbLetter_settings.SelectedIndex == -1) return;
            if (txtServer_settings.Text == "") return;
            if (cbDomain_settings.Text == "") return;
            if (txtUser_settings.Text == "") return;
            if (txtPassword_settings.Text == "") return;

            int _result = MapNewDrive(cbLetter_settings.Text, txtServer_settings.Text, cbDomain_settings.Text, txtUser_settings.Text, txtPassword_settings.Text);

            if (_result != 0) MessageBox.Show("Invalid Mapping network. " + cbLetter_settings.Text + txtServer_settings.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_result == 0) MessageBox.Show("OK to Mapping network. " + cbLetter_settings.Text + txtServer_settings.Text, "Done", MessageBoxButtons.OK, MessageBoxIcon.None);

            txtServer_settings.Clear();
            txtUser_settings.Clear();
            txtPassword_settings.Clear();

            BtnRefreshDrives_settings_Click(sender, e);
        }

        private void BtnRemoveDrive_settings_Click(object sender, EventArgs e)
        {
            if (cbLetterToRemove_settings.SelectedIndex == -1) return;

            int _result = StaticFunctions.RemoveDrive(cbLetterToRemove_settings.Text);

            if (_result != 0) MessageBox.Show("Invalid Mapping network. " + cbLetter_settings.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (_result == 0) MessageBox.Show("OK to remove network. " + cbLetterToRemove_settings.Text, "Done", MessageBoxButtons.OK, MessageBoxIcon.None);

            BtnRefreshDrives_settings_Click(sender, e);
        }

        private void BtnCaptureImageX_Click(object sender, EventArgs e)
        {
            if (txtImageName_capture.Text == "") return;
            if (_tempServer == "") return;
            if (_tempDrive == "") return;

            ManagementObjectSearcher _myDisks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            ManagementObjectCollection _disks = _myDisks.Get();
            List<ManagementObject> moList = _disks.Cast<ManagementObject>().ToList();
            string _dName = moList[Convert.ToInt32(_tempDrive)]["Model"].ToString();


            string _label = "You are about to capture the 1 partition on drive " + _tempDrive + " " + "[" + _dName + "]" + " " + "to " + _tempServer + "\\" + txtImageName_capture.Text;


            using (ManagementClass devs = new ManagementClass(@"Win32_Diskdrive"))
            {
                ManagementObjectCollection moc = devs.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    foreach (ManagementObject b in mo.GetRelated("Win32_DiskPartition"))
                    {
                        foreach (ManagementBaseObject c in b.GetRelated("Win32_LogicalDisk"))
                        {
                            _tempDrive = c["Name"].ToString();
                        }

                    }
                }
            }

            //string _args = "/capture" + " " + _tempDrive + " " + _tempServer + "\\" + txtImageName_capture.Text + " " + "\"" + string.Concat(txtImageName_capture.Text.Reverse().Skip(4).Reverse()) + "\"" + " " + "/verify";
            //MessageBox.Show("/capture" +" "+ _tempDrive +" "+ _tempServer +"\\"+ txtImageName_capture.Text + " " + "\"" + string.Concat(txtImageName_capture.Text.Reverse().Skip(4).Reverse()) + "\"" + " " + "/verify");

            DialogResult dr = new DialogResult();
            dr = MessageBox.Show(_label, "Capture image", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.OK) CaptureImageX(_tempDrive, _tempServer, txtImageName_capture.Text);
        }

        private void Btn_ImagexApply_Click(object sender, EventArgs e)
        {
            if (lbImagesToApply_apply.SelectedIndex == -1) return;
            this.TopMost = false;
            ApplyImgImageX(lbImagesToApply_apply.Text);
            this.TopMost = true;
            MessageBox.Show(lbImagesToApply_apply.Text + " has been applied correctly" + "\n" + "Now you can reboot the system.");
        }

        private void BtnTab2_Click(object sender, EventArgs e)
        {
            string ExecuteLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            if (ExecuteLocation == "\\\\mxchim0pangea01\\AUTOMATION_SSCO\\IMAGES_SERVER_2.0\\Debug" || ExecuteLocation == "Y:\\IMAGES_SERVER_2.0\\Debug")
            {
                tabControl1.SelectedTab = tabPage3;
                return;
            }

            DialogResult dr = new DialogResult();
            AdminUser Admin = new AdminUser();

            dr = Admin.ShowDialog();
            if (dr != DialogResult.OK) return;

            tabControl1.SelectedTab = tabPage3;
        }

        private void BtnTab3_Click(object sender, EventArgs e)
        {
            string ExecuteLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            if (ExecuteLocation == "\\\\mxchim0pangea01\\AUTOMATION_SSCO\\IMAGES_SERVER_2.0\\Debug" || ExecuteLocation == "Y:\\IMAGES_SERVER_2.0\\Debug")
            {
                tabControl1.SelectedTab = tabPage4;
                return;
            }

            DialogResult dr = new DialogResult();
            AdminUser Admin = new AdminUser();

            dr = Admin.ShowDialog();
            if (dr != DialogResult.OK) return;

            tabControl1.SelectedTab = tabPage4;
        }

        private void BtnTab4_Click(object sender, EventArgs e)
        {
            string ExecuteLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            if (ExecuteLocation == "\\\\mxchim0pangea01\\AUTOMATION_SSCO\\IMAGES_SERVER_2.0\\Debug" || ExecuteLocation == "Y:\\IMAGES_SERVER_2.0\\Debug")
            {
                tabControl1.SelectedTab = tabPage2;
                return;
            }

            DialogResult dr = new DialogResult();
            AdminUser Admin = new AdminUser();

            dr = Admin.ShowDialog();
            if (dr != DialogResult.OK) return;

            tabControl1.SelectedTab = tabPage2;
        }

        private void BtnTab5_Click(object sender, EventArgs e)
        {
            string ExecuteLocation = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            if (ExecuteLocation == "\\\\mxchim0pangea01\\AUTOMATION_SSCO\\IMAGES_SERVER_2.0\\Debug" || ExecuteLocation == "Y:\\IMAGES_SERVER_2.0\\Debug")
            {
                tabControl1.SelectedTab = tabPage5;
                return;
            }

            DialogResult dr = new DialogResult();
            AdminUser Admin = new AdminUser();

            dr = Admin.ShowDialog();
            if (dr != DialogResult.OK) return;

            tabControl1.SelectedTab = tabPage5;
        }

        private void LvFilesView_capture_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }

        private void BtnTab1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }
        private void btnTab1_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void LvFilesView_capture_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                ListView.SelectedListViewItemCollection selectedItems = lvFilesView_capture.SelectedItems;
                String text = "";
                foreach (ListViewItem item in selectedItems)
                {
                    text += item.Text;
                }
                Clipboard.SetText(text);
            }


            if (e.KeyCode == Keys.Back)
            {
                LbSaveImage_capture_SelectedIndexChanged(sender, e);
            }

            if (e.KeyCode == Keys.Enter)
            {
                LvFilesView_capture_Click(sender, e);
            }
        }

        private void CBoxListDisk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cBoxListDisk.Text)) cBoxDiskpart_Commands.Enabled = true;
        }

        private void LvVolumes_Diskpart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CBoxDiskpart_Commands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxDiskpart_Commands.Text == "Clean")
            {
                _DiskPartCommands = DiskPartCommands.Clean;
            }

            if (cBoxDiskpart_Commands.Text == "Shrink")
            {
                txtSizeDiskpart.Enabled = true;
                _DiskPartCommands = DiskPartCommands.Shrink;
            }

            if (cBoxDiskpart_Commands.Text == "Create Partition Primary")
            {
                cBoxLetterDiskpart.Enabled = true;
                txtLabelDiskpart.Enabled = true;
                txtSizeDiskpart.Enabled = true;
                checkBox1.Enabled = true;
                _DiskPartCommands = DiskPartCommands.CreatePartitionPrimary;
            }

            btnDiskPartFunction.Enabled = true;
            btnDiskPartFunction.Text = cBoxDiskpart_Commands.Text;
        }

        private void BtnDiskPartFunction_Click(object sender, EventArgs e)
        {
            string _result = string.Empty;
            int _SelectedDisk = 0;
            DialogResult _dr = DialogResult.Cancel;

            switch (_DiskPartCommands)
            {
                case DiskPartCommands.Clean:

                    _dr = MessageBox.Show("Estas seguro que quieres hacer un Clean al disco. \n Todas las particiones existentes seran eliminadas. \n Estas seguro?", cBoxListDisk.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                    if (_dr == DialogResult.OK)
                    {
                        void CommandClean()
                        {
                            if (cBoxListDisk.Text.Contains("Disk 0")) _SelectedDisk = 0;
                            if (cBoxListDisk.Text.Contains("Disk 1")) _SelectedDisk = 1;
                            if (cBoxListDisk.Text.Contains("Disk 2")) _SelectedDisk = 2;
                            if (cBoxListDisk.Text.Contains("Disk 3")) _SelectedDisk = 3;

                            _result = Diskpart.SendCommand("Select Disk " + _SelectedDisk.ToString(), "Clean");
                        }

                        using (WaitWin waitWin = new WaitWin(CommandClean, "CLEANING" + " " + cBoxListDisk.Text)) waitWin.ShowDialog(this);
                    }

                    if (_dr == DialogResult.Cancel) using (WaitWin waitWin = new WaitWin(RefreshItems, "CANCELING ACTION")) waitWin.ShowDialog(this);
                    if (_dr == DialogResult.OK) using (WaitWin waitWin = new WaitWin(RefreshItems, "UPDATING INFORMATION")) waitWin.ShowDialog(this);

                    break;

                case DiskPartCommands.Shrink:

                    if (string.IsNullOrEmpty(lvVolumes_Diskpart.Text))
                    {
                        _dr = DialogResult.Cancel;
                        MessageBox.Show("Must select a simple volume...", "Missing Argument", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                        _dr = MessageBox.Show("Estas seguro que quieres hacer un Shrink al volumen \n \n" + lvVolumes_Diskpart.Text + "\n" + "Size=" + txtSizeDiskpart.Text, cBoxListDisk.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                    if (_dr == DialogResult.OK)
                    {
                        void CommandShrink()
                        {
                            if (cBoxListDisk.Text.Contains("Disk 0")) _SelectedDisk = 0;
                            if (cBoxListDisk.Text.Contains("Disk 1")) _SelectedDisk = 1;
                            if (cBoxListDisk.Text.Contains("Disk 2")) _SelectedDisk = 2;
                            if (cBoxListDisk.Text.Contains("Disk 3")) _SelectedDisk = 3;

                            _result = Diskpart.SendCommand("Select Disk " + _SelectedDisk.ToString(),
                                                           "Select " + lvVolumes_Diskpart.Text.Substring(0, 10).TrimStart().TrimEnd(),
                                                           "Shrink desired=" + txtSizeDiskpart.Text);
                        }

                        using (WaitWin waitWin = new WaitWin(CommandShrink, "SHRINK VOLUME" + " " + lvVolumes_Diskpart.Text)) waitWin.ShowDialog(this);
                    }

                    if (_dr == DialogResult.Cancel) using (WaitWin waitWin = new WaitWin(RefreshItems, "CANCELING ACTION")) waitWin.ShowDialog(this);
                    if (_dr == DialogResult.OK) using (WaitWin waitWin = new WaitWin(RefreshItems, "UPDATING INFORMATION")) waitWin.ShowDialog(this);


                    break;

                case DiskPartCommands.CreatePartitionPrimary:

                    if (string.IsNullOrEmpty(cBoxLetterDiskpart.Text)) return;
                    if (string.IsNullOrEmpty(txtLabelDiskpart.Text)) return;

                    void CommandCreatePartitionPrimary()
                    {
                        int _Volume = 0;

                        if (cBoxListDisk.Text.Contains("Disk 0")) _SelectedDisk = 0;
                        if (cBoxListDisk.Text.Contains("Disk 1")) _SelectedDisk = 1;
                        if (cBoxListDisk.Text.Contains("Disk 2")) _SelectedDisk = 2;
                        if (cBoxListDisk.Text.Contains("Disk 3")) _SelectedDisk = 3;

                        List<string> volumes = Diskpart.GetVolumes();

                        if (volumes.Count > 0) _Volume = volumes.Count;

                        if (string.IsNullOrEmpty(txtSizeDiskpart.Text))
                        {
                            _dr = MessageBox.Show("Crearas una particion primaria \n Letter=" + cBoxLetterDiskpart.Text + ": \n Label=" + txtLabelDiskpart.Text + "\n Size=Full Disk Size", cBoxListDisk.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                            if (_dr == DialogResult.OK)
                            {
                                _result = Diskpart.SendCommand("Select Disk " + _SelectedDisk.ToString(),
                                    "Create Partition Primary",
                                    "Select volume " + _Volume.ToString(),
                                    "assign letter=" + cBoxLetterDiskpart.Text,
                                    "format fs=ntfs quick label=" + txtLabelDiskpart.Text);

                                if (checkBox1.Checked)
                                {
                                    _result = Diskpart.SendCommand("Select Disk 0",
                                                              "Select volume " + _Volume.ToString(),
                                                              "Active");
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(txtSizeDiskpart.Text))
                        {
                            _dr = MessageBox.Show("Crearas una particion primaria \n Letter=" + cBoxLetterDiskpart.Text + ": \n Label=" + txtLabelDiskpart.Text + "\n Size=" + txtSizeDiskpart.Text, cBoxListDisk.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                            if (_dr == DialogResult.OK)
                            {
                                _result = Diskpart.SendCommand("Select Disk " + _SelectedDisk.ToString(),
                                                   "Create Partition Primary size=" + txtSizeDiskpart.Text,
                                                   "Select volume " + _Volume.ToString(),
                                                   "assign letter=" + cBoxLetterDiskpart.Text,
                                                   "format fs=ntfs quick label=" + txtLabelDiskpart.Text);

                                if (checkBox1.Checked)
                                {
                                    _result = Diskpart.SendCommand("Select Disk 0",
                                                              "Select volume " + _Volume.ToString(),
                                                              "Active");
                                }
                            }
                        }
                    }

                    using (WaitWin waitWin = new WaitWin(CommandCreatePartitionPrimary, "CREATING PARTITION PRIMARY" + " " + cBoxListDisk.Text)) waitWin.ShowDialog(this);

                    if (_dr == DialogResult.Cancel) using (WaitWin waitWin = new WaitWin(RefreshItems, "CANCELING ACTION")) waitWin.ShowDialog(this);
                    if (_dr == DialogResult.OK) using (WaitWin waitWin = new WaitWin(RefreshItems, "UPDATING INFORMATION")) waitWin.ShowDialog(this);

                    break;
            }
        }

        private void LbImagesToApply_apply_SelectedIndexChanged(object sender, EventArgs e)
        {

            string WimSelected = string.Empty;
           
            WimSelected = lbImagesToApply_apply.Text.Replace('"', '\\').Remove(lbImagesToApply_apply.Text.Length - 1, 1);
            cBoxImageCount_apply.Items.Clear();

            MessageBox.Show(WimSelected);

            try
            {
                using (Wim wim = Wim.OpenWim(WimSelected, OpenFlags.None))
                {
                    try
                    {
                        WimInfo info = wim.GetWimInfo();
                        string xmlData = wim.GetXmlData();
                        txtWimInfo_Apply.Text = xmlData;

                        for (int i = 1; i <= info.ImageCount; i++)
                        {
                            cBoxImageCount_apply.Items.Add(i.ToString());
                        }
                    }
                    finally
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                txtWimInfo_Apply.Text = ex.Message;
            }





        }

        private void BtnApplyJImagex_Click(object sender, EventArgs e)
        {
            if (lvVolumes.SelectedIndex == -1) return;
            if (lbImagesToApply_apply.SelectedIndex == -1) return;
            if (cBoxImageCount_apply.SelectedIndex == -1) return;

            DialogResult _dr = DialogResult.Cancel;
            string WimToInstall = lbImagesToApply_apply.Text.Replace('"', '\\').Remove(lbImagesToApply_apply.Text.Length - 1, 1);
            string TargetPath = lvVolumes.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[2] + ":";


            _dr = MessageBox.Show("Aplicaras la imagen: \n \n" + WimToInstall + "\n \n INDEX: " + cBoxImageCount_apply.Text + "\n \n En el Volumen: " + TargetPath + "\n \nEstas seguro?", "APLICACION DE IMAGEN", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (_dr == DialogResult.OK)
            {
                _dr = StaticJImgaeX.APPLY_JIMAGEX(Convert.ToInt16(cBoxImageCount_apply.Text), WimToInstall, TargetPath);

                Diskpart.BCDBoot(TargetPath + @"\Windows /s " + "D:"); //bcdboot C:\Windows /s D:
            }
            else
                using (WaitWin waitWin = new WaitWin(RefreshItems, "CANCELING ACTION")) waitWin.ShowDialog(this);
        }

        #endregion

        #region Funciones  Aplicacion
        //FUNCTION TO GET SERIAL NUMBER, MC NUMBER BY TRACER NUMBER
        Tuple<string, string, string, string, string, string, bool> UnitInfoFromIfactory()
        {
            DialogResult dr = new DialogResult();
            WinTracer winTracer = new WinTracer();
            string _Class = "";
            string _SerialNumber = "";
            string _McNumber = "";
            string _tracer = "";
            string _ID = "";
            string _Name = "";

            bool _flag = false;


            dr = winTracer.ShowDialog();
            this.Refresh();

            if (dr == DialogResult.OK)
            {
                _Class = winTracer.CLASS;
                _SerialNumber = winTracer.SERIALNUMBER;
                _McNumber = winTracer.MC;
                _tracer = winTracer.TRACER;
                _ID = winTracer.IDNumber;
                _Name = winTracer.IDName;                

                lblTracer.Text = "TRACER: " + _tracer;
                lblSN.Text = "SERIAL NUMBER: " + _SerialNumber;
                lblClass.Text = "CLASS: " + _Class;
                lblMC.Text = "MC: " + _McNumber;
                lblID.Text = "#ID: " + _ID;
                lblName.Text = "Name: " + _Name;

                _flag = true;
            }
            return Tuple.Create(_Class, _SerialNumber, _McNumber, _tracer, _ID, _Name, _flag);
        }

        //FUNCION TO INSTAL TEST IMAGE FOR SSCOS
        void InstallTestImageSSCO()
        {
            bool _flag              = false;
            string result          = string.Empty;
            //int _result             = 0;
            DialogResult _dr = DialogResult.Abort;

            var items = UnitInfoFromIfactory();
            _class        = items.Item1;
            _serialNumber = items.Item2;
            _mc           = items.Item3;
            _tracer       = items.Item4;
            _ID           = items.Item5;
            _Name         = items.Item6;
            _flag         = items.Item7;


            if (string.IsNullOrEmpty(_tracer)) return;

            SCODisplayTest DisplayTest = new SCODisplayTest();
            if (DisplayTest.ShowDialog() == DialogResult.Abort) return;

            this.Refresh();
                
            var _items        = StaticFunctions.GetBuildType();
            string _mainDisk  = _items.Item3;
            string _BaseBoard = StaticFunctions.GetMotherBoardType();


            if (!_flag) return;

            var _items2         = CheckEJL.IsCompleted_SSCOS(_mainDisk, _tracer);
            string _ejl         = _items2.Item1;
            bool _isCompleteEjl = _items2.Item2;


            if (_isCompleteEjl)
            {
                MessageBox.Show("Unidad con log : " + _tracer + ".ejl" + " completo" + "\n" + "\n" + "\n" + "Contacte a Ingenieria de pruebas...", "OnError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CheckStepProcess.CheckStep(_serialNumber, "CUSTOM OS"))
            {
                MessageBox.Show("Unidad con PASS de CUSTOM OS" + "\n" + "\n" + "\n" + "Contacte a Ingenieria de pruebas...", "OnError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CheckStepProcess.CheckStep(_serialNumber, "FVT"))
            {
                MessageBox.Show("Unidad con PASS de FVT" + "\n" + "\n" + "\n" + "Contacte a Ingenieria de pruebas...", "OnError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (!CheckStepProcess.CheckStep(_serialNumber, "HIPOT"))
            //{
            //    MessageBox.Show("Unidad sin PASS de HIPOT" + "\n" + "\n" + "\n" + "Contacte a Ingenieria de pruebas...", "OnError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}


            if (_BaseBoard == "Pocono" && _class == "7350")     
            {
                IMAGE_TO_INSTALL = _TestAndCustomOS._TestImage7350R5; 
                goto FoundIt;
            }

            if (_BaseBoard == "Monaco" && _class == "7350")
            {
                IMAGE_TO_INSTALL = _TestAndCustomOS._TestImage7350R6L;
                goto FoundIt;
            }
            if (_BaseBoard == "Monaco" && _class == "7358")
            {
                IMAGE_TO_INSTALL = _TestAndCustomOS._TestImage7358;
                goto FoundIt;
            }

            if (_BaseBoard == "Richmond" && _class == "7358" || _BaseBoard == "Richmond" && _class == "7360")
            {
                IMAGE_TO_INSTALL = _TestAndCustomOS._TestImage7703;            
                goto FoundIt;
            }

            if (_BaseBoard == "Monaco" && _class == "7360")
            {
                IMAGE_TO_INSTALL = _TestAndCustomOS._TestImage7702;              
                goto FoundIt;
            }

            if (_BaseBoard == "Monaco" && _class == "7362")
            {
                IMAGE_TO_INSTALL = _TestAndCustomOS._TestImage7702;
                goto FoundIt;
            }

            OnError:
            {
                lblImageName.Text = "COMPATIBLE IMAGE NOT FOUND TO " + _BaseBoard.ToUpper() + " MOTHERBOARD";
                MessageBox.Show("NO SE HA ENCONTRADO IMAGEN DE PRUEBA PARA ESTA UNIDAD." + "\n" + "\n" + "\n" + "CONTACTA A INGENIERIA DE PRUEBAS!", "OnError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            FoundIt:
            {
                lblImageName.Text = IMAGE_TO_INSTALL;

                //OLD LOGIC TO INSTALL TEST IMAGE
                //_result = ApplyRadsImage(SSSCO_IMAGES_02 + "\"" + IMAGE_TO_INSTALL + "\"", "", Properties.Settings.Default._applyMode);


                //IMPLEMENTATION TESTDATAWAREHOUSE MATRIZ DE PROGRAMA PENDIENTE EL DESARROLLO
                //if (!StaticFunctions.IsUpToDateTDWH(IMAGE_TO_INSTALL))
                //{
                //    lblImageName.Text = "LA IMAGEN DE PRUEBA NO ES LA ACTUAL EN TEST DATA WARE HOUSE";
                //    MessageBox.Show("NO SE INSTALARA IMAGEN DEBIDO A QUE NO ESTA LIBERADA EN TEST DATA WARE HOUSE." + "\n" + "\n" + "\n" + "CONTACTA A INGENIERIA DE PRUEBAS!", "OnError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                           
                void SetupDisk()
                {
                    result = Diskpart.SendCommand("Select Disk 0", "Clean");

                    result = Diskpart.SendCommand("Select Disk 0",
                                                  "Create Partition Primary size=359",
                                                  "Select partition 1",
                                                  "assign letter=D",
                                                  "format fs=ntfs quick label=System",
                                                  "Active");  ///not active

                    result = Diskpart.SendCommand("Select Disk 0",
                                                  "Select partition 2",
                                                  "Create Partition Primary",
                                                  "assign letter=C",
                                                  "format fs=ntfs quick label=OS");

                    //result = Diskpart.SendCommand("Select Disk 0",
                    //                              "Select volume 1",
                    //                              "Active");
                }

                using (WaitWin waitWin = new WaitWin(SetupDisk, "BUILDING DISK PARTITIONS")) waitWin.ShowDialog();

                //_dr = StaticJImgaeX.APPLY_JIMAGEX(1, SSSCO_IMAGES_02 + IMAGE_TO_INSTALL, "D:");

                _dr = StaticJImgaeX.APPLY_JIMAGEX(2, SSSCO_IMAGES_02 + IMAGE_TO_INSTALL, "C:");


                //result = Diskpart.BCDBoot(@"C:\Windows /s C:"); working
                result = Diskpart.BCDBoot(@"C:\Windows /s D:");

                result = Diskpart.SendCommand("Select Disk 0",
                                              "Select volume 0",
                                              "set id=17 override");
            }

            //if (_result != 0)
            if (_dr == DialogResult.Abort)
            {
                MessageBox.Show(lblImageName.Text + " No ha sido instalada correctamente...", "OnError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblResult.ForeColor = Color.Red;
                lblResult.Text = "TEST IMAGE: No ha sido instalada correctamente...";
                return;
            }
            //if (_result == 0)
            if (_dr == DialogResult.OK)
            {
                lblResult.ForeColor = Color.Green;
                lblResult.Text = "TEST IMAGE: Se instalo correctamente!";
            }

            try
            {
                char letter = 'A';
                string _pathUnitInfo = @":\JABIL\";
                while (letter < 'Z')
                {
                    if (Directory.Exists(letter + _pathUnitInfo))
                    {
                        _pathUnitInfo = letter + _pathUnitInfo + @"UnitInfo\";
                        break;
                    }
                    else
                        letter++;
                }

                DirectoryInfo DirInfo = new DirectoryInfo(_pathUnitInfo);

                if (DirInfo.Exists)
                {
                    DirectoryInfo _dirFilesInfo = new DirectoryInfo(_pathUnitInfo);
                    FileInfo[] _files = _dirFilesInfo.GetFiles();
                    foreach (FileInfo _file in _files)
                    {
                        _file.Delete();
                    }
                }

                if (!DirInfo.Exists) DirInfo.Create();

                using (StreamWriter sw = File.CreateText(_pathUnitInfo + _tracer + "_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".txt"))
                {
                    sw.WriteLine(_tracer);
                    sw.WriteLine(_ID);
                    sw.WriteLine(_Name);
                    sw.WriteLine("0"); //defualt 0 
                    sw.Close();
                }

                //reboot
                StaticFunctions.RebootUnit();
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //FUNCTION TO INSTALL TEST IMAGE FOR ATMS
        void InstallTestImageATM()
        {
            string IMAGE_TO_INSTALL = string.Empty;
            string _class           = string.Empty;
            string _serialNumber    = string.Empty;
            string _mc              = string.Empty;
            string _tracer          = string.Empty;
            string _ID              = string.Empty;
            string _Name            = string.Empty;
            string _OS              = string.Empty;
            bool _flag              = false;
            int _result             = 0;
            //bool _ITM             = false;
            string _BaseBoard       = string.Empty;
            bool _MisanoFeature     = false;
            string result           = string.Empty;
            //int _result           = 0;
            DialogResult _dr        = DialogResult.Abort;


            var items     = UnitInfoFromIfactory();
            _class        = items.Item1;
            _serialNumber = items.Item2;
            _mc           = items.Item3;
            _tracer       = items.Item4;
            _ID           = items.Item5;
            _Name         = items.Item6;
            _flag         = items.Item7;

            if (!_flag) return;

            _BaseBoard = StaticFunctions.GetMotherBoardType(); //GETTING THE BASEBOARD TYPE

            var items2 = StaticFunctions.GetOS(_class, _mc);

            _OS            = items2.Item1;
            _MisanoFeature = items2.Item2;

            object value = StaticFunctions.PEFirmwareType(); //Function to review the BIOS CONFIGURATION 1=LEGACY 2=UEFI

            switch (_OS)
            {
                case "WIN7":

                    if (_BaseBoard == "Estoril" && !_MisanoFeature)
                        IMAGE_TO_INSTALL = _TestAndCustomOS._TestImageEstoril_Windows7;

                    if (_BaseBoard == "Misano" && _MisanoFeature)
                        IMAGE_TO_INSTALL = _TestAndCustomOS._TestImageMisano_Windows7;

                    if (_BaseBoard == "Misano-K" && _MisanoFeature)
                        IMAGE_TO_INSTALL = _TestAndCustomOS._TestImageMisano_Windows7;

                    if (Convert.ToInt32(value) != 1)
                    {
                        lblImageName.Text = IMAGE_TO_INSTALL;
                        MessageBox.Show("La configuracion del Bios no es la correcta!" + "\n" + "\n" + "CONFIGURACION ACTUAL: BIOS_MODE=UEFI" + "\n" + "\n" + "CONFIGURACION ESPERADA: BIOS_MODE=LEGACY", "OnError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblResult.ForeColor = Color.Red;
                        lblResult.Text = "TEST IMAGE: Revise configuracion: BIOS_MODE=LEGACY";
                        pBoxStatus.Visible = true;
                        pBoxStatus.Image = Properties.Resources.BadMark;
                        return;
                    }
                    break;

                case "WIN10":
                    if (_BaseBoard == "Estoril" && !_MisanoFeature)
                        IMAGE_TO_INSTALL = _TestAndCustomOS._TestImageEstoril_Windows10;

                    if (_BaseBoard == "Misano" && _MisanoFeature)
                        IMAGE_TO_INSTALL = _TestAndCustomOS._TestImageMisano_Windows10;

                    if (_BaseBoard == "Misano-K" && _MisanoFeature)
                        IMAGE_TO_INSTALL = _TestAndCustomOS._TestImageKabyLake_Windows10;

                    if (Convert.ToInt32(value) != 2)
                    {
                        lblImageName.Text = IMAGE_TO_INSTALL;
                        MessageBox.Show("La configuracion del Bios no es la correcta!" + "\n" + "\n" + "CONFIGURACION ACTUAL: BIOS_MODE=LEGACY" + "\n" + "\n" + "CONFIGURACION ESPERADA: BIOS_MODE=UEFI", "OnError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblResult.ForeColor = Color.Red;
                        lblResult.Text = "TEST IMAGE: Revise configuracion: BIOS_MODE=UEFI";
                        pBoxStatus.Visible = true;
                        pBoxStatus.Image = Properties.Resources.BadMark;
                        return;
                    }
                    break;


                case "WIN10_P110":

                    IMAGE_TO_INSTALL = _TestAndCustomOS._TestImageMisano_Estoril_Windows10_5801P110;

                    if (Convert.ToInt32(value) != 2)
                    {
                        lblImageName.Text = IMAGE_TO_INSTALL;
                        MessageBox.Show("La configuracion del Bios no es la correcta!" + "\n" + "\n" + "CONFIGURACION ACTUAL: BIOS_MODE=LEGACY" + "\n" + "\n" + "CONFIGURACION ESPERADA: BIOS_MODE=UEFI", "OnError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblResult.ForeColor = Color.Red;
                        lblResult.Text = "TEST IMAGE: Revise configuracion: BIOS_MODE=UEFI";
                        pBoxStatus.Visible = true;
                        pBoxStatus.Image = Properties.Resources.BadMark;
                        return;
                    }

                    break;

                default:
                    lblImageName.Text = "COMPATIBLE IMAGE NOT FOUND TO " + _BaseBoard.ToUpper() + " MOTHERBOARD";
                    MessageBox.Show("NO SE HA ENCONTRADO IMAGEN DE PRUEBA PARA ESTA UNIDAD." + "\n" + "\n" + "\n" + "CONTACTA A INGENIERIA DE PRUEBAS!", "OnError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            //APPLY IMAGE FOUNDED IT
            lblImageName.Text = IMAGE_TO_INSTALL;
            _result = StaticJImgaeX.APPLY_RADSIMAGEX(ATM_IMAGES + "\"" + IMAGE_TO_INSTALL + "\"", "", Properties.Settings.Default._applyMode);


            if (_result != 0)
            {
                MessageBox.Show(lblImageName.Text + " No ha sido instalada correctamente...", "OnError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblResult.ForeColor = Color.Red;
                lblResult.Text = "TEST IMAGE: No ha sido instalada correctamente...";
                pBoxStatus.Visible = true;
                pBoxStatus.Image = Properties.Resources.BadMark;
                return;
            }

            if (_result == 0)
            {
                lblResult.ForeColor = Color.Green;
                lblResult.Text = "TEST IMAGE: Se instalo correctamente!";
                pBoxStatus.Visible = true;
                pBoxStatus.Image = Properties.Resources.GoodMark;
            }

            char letter = 'A';
            string _pathUnitInfo = @":\Pangaea\ExternalExecutables\USBDeviceNCRChecker\";
            while (letter < 'Z')
            {
                if (Directory.Exists(letter + _pathUnitInfo))
                {
                    _pathUnitInfo = letter + _pathUnitInfo + @"UnitInfo\";
                    break;
                }
                else
                    letter++;
            }

            DirectoryInfo DirInfo = new DirectoryInfo(_pathUnitInfo);

            if (!DirInfo.Exists) DirInfo.Create();

            using (StreamWriter sw = File.CreateText(_pathUnitInfo + "UnitInfo" + ".txt"))
            {
                sw.WriteLine(_tracer);
                sw.WriteLine(_ID);
                sw.Close();
            }

            //This function only apply for units that are Interactive Teller Machine ITM            
            var ItemsFromITM = StaticFunctions.IsITM(_class, _mc);
            if (ItemsFromITM.Item1 && ItemsFromITM.Item2)
            {              
                void SetupDisk()
                {
                    result = Diskpart.SendCommand("Select Disk 0",
                                                  "Select partition 2",
                                                  "Shrink desired=100000",
                                                  "Create Partition Primary size=100000",
                                                  "Select partition 3",
                                                  "assign letter=K",
                                                  "format fs=ntfs quick label=ITM");
                }
                using (WaitWin waitWin = new WaitWin(SetupDisk, "BUILDING DISK PARTITIONS FOR ITM OS | " + ItemsFromITM.Item3)) waitWin.ShowDialog();

                switch (_OS)
                {
                    case "WIN7":
                        lblImageName.Text = _TestAndCustomOS.ITM_Windows7;
                        _dr = StaticJImgaeX.APPLY_JIMAGEX(2, _TestAndCustomOS.ITM_Windows7, "K:");
                        break;

                    case "WIN10":
                        lblImageName.Text = _TestAndCustomOS.ITM_Windows10;
                        _dr = StaticJImgaeX.APPLY_JIMAGEX(1, _TestAndCustomOS.ITM_Windows10, "K:");
                        break;
                }
    
                if (_dr == DialogResult.OK)
                {
                    lblResult.ForeColor = Color.Green;
                    lblResult.Text = lblResult.Text + "\n" + "ITM IMAGE: Se instalo correctamente!";
                    pBoxStatus.Visible = true;
                    pBoxStatus.Image = Properties.Resources.GoodMark;
                }

                if (_dr == DialogResult.Abort)
                {
                    MessageBox.Show(lblImageName.Text + " No ha sido instalada correctamente...", "OnError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblResult.ForeColor = Color.Red;
                    lblResult.Text = lblResult.Text + "\n" + "ITM IMAGE: No ha sido instalada correctamente...";
                    pBoxStatus.Visible = true;
                    pBoxStatus.Image = Properties.Resources.BadMark;
                    return;
                }
            }

            //At the end up the unit will be restarted
            StaticFunctions.RebootUnit();
            timer1.Start();
        }

        //FUNCTION TO INSTALL CUSTOM OS FOR SSCOS
        void InstallCustomOS()
        {
            string IMAGE_TO_INSTALL = string.Empty;
            string _buildtyp        = string.Empty;
            string _tracer          = string.Empty;
            string[] _InfoUnit      = { };
            int _result             = 0;
            string _imageInstalled  = string.Empty;
            string _LOG             = string.Empty;
            string _Status          = string.Empty;
            string _mainDisk        = string.Empty;
            string _ejl             = string.Empty;
            bool _isCompleteEjl     = false;
            bool _buildTypeExist    = false;
            string _dirUnitInfo     = @":\JABIL\UnitInfo\";
            string _userFile        = @"\\mxchim0pangea01\AUTOMATION_SSCO\Config Files\Users.ini";

            var items       = StaticFunctions.GetBuildType();
            _buildtyp       = items.Item1;
            _tracer         = items.Item2;
            _mainDisk       = items.Item3;
            _buildTypeExist = items.Item4;

            _InfoUnit            = _iFactoryInfo.GetSCMC(_tracer);
            string _serialNumber = _InfoUnit[0];
            string _class        = _InfoUnit[1];
            string _mc           = _InfoUnit[2];

            //UNIT INFO
            lblTracer.Text = "TRACER: " + _tracer;
            lblSN.Text     = "SERIAL NUMBER: " + _serialNumber;
            lblClass.Text  = "CLASS: " + _class;
            lblMC.Text     = "MC: " + _mc;


            //EMPLOYE INFO
            DirectoryInfo _dirInfo = new DirectoryInfo(_mainDisk + _dirUnitInfo);
            FileInfo[] _filesInfo  = _dirInfo.GetFiles();
            string[] _unitInfo     = File.ReadAllLines(_filesInfo[0].FullName);

            lblID.Text   = _unitInfo[1];
            lblName.Text = ConfigFiles.reader("IMAGES_SERVER", _unitInfo[1], _userFile);

            if (!_buildTypeExist)
            {
                MessageBox.Show("Unidad sin build.typ : " + "\n" + "\n" + "\n" + "Contacte a Ingenieria de pruebas...", "OnError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var _items2 = CheckEJL.IsCompleted_SSCOS(_mainDisk, _tracer);
            _ejl = _items2.Item1;
            _isCompleteEjl = _items2.Item2;

            //if (!_isCompleteEjl)
            //{
            //    MessageBox.Show("Unidad con log : " + _tracer + ".ejl" + " incompleto" + "\n" + "\n" + "\n" + "Contacte a Ingenieria de pruebas...", "OnError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if (_buildtyp.Contains("POSREADY2009_32") || _buildtyp.Contains("POS_READY_2009"))
            {
                IMAGE_TO_INSTALL = TestAndCustomOS._POSReady_2009;
                goto FoundIt;             
            }

            if (_buildtyp.Contains("WALMART_OS") || _buildtyp.Contains("WALMART_R6LITE_OS"))
            {              
                IMAGE_TO_INSTALL = TestAndCustomOS._WAL_R6LITE;
                goto FoundIt;
            }

            if (_buildtyp.Contains("POSREADY7_64"))
            {
                IMAGE_TO_INSTALL = TestAndCustomOS._POS7_64bit;
                goto FoundIt;
            }

            if (_buildtyp.Contains("WINDOWS7PRO_32"))
            {
                IMAGE_TO_INSTALL = TestAndCustomOS._Windows7ProfessionalEmbedded32Bit;
                goto FoundIt;
            }

            if (_buildtyp.Contains("WIN10_64") || _buildtyp.Contains("WIN10_64_VALUE") || _buildtyp.Contains("WIN10_64_ENTERPRISE"))
            {
                IMAGE_TO_INSTALL = TestAndCustomOS._XR7_XR6_Win10_IoT_64b_2016;
                goto FoundIt;
            }

            if (_buildtyp.Contains("WIN7_PEOS_32"))
            {
                IMAGE_TO_INSTALL = TestAndCustomOS._Windows7ProfessionalEmbedded32Bit;
                goto FoundIt;
            }

            if (_buildtyp.Contains("WIN7_PEOS_64"))
            {
                IMAGE_TO_INSTALL = TestAndCustomOS._XR7_XR6_Win7_PRO_EMBEDDED_64b;
                goto FoundIt;
            }

            if (_buildtyp.Contains("WIN10_EEOS_64"))
            {
                IMAGE_TO_INSTALL = TestAndCustomOS._XR7_XR6_Win10_IoT_64b_2016;
                goto FoundIt;
            }

            if (_buildtyp.Contains("POSREADY7_32") && !_buildtyp.Contains("SKYLAKE"))
            {
                IMAGE_TO_INSTALL = TestAndCustomOS._POSReady7_32bit;
                goto FoundIt;
            }

            if (_buildtyp.Contains("POSREADY7_32") && _buildtyp.Contains("SKYLAKE"))
            {
                IMAGE_TO_INSTALL = TestAndCustomOS._POSREADY7Skylake;
                goto FoundIt;
            }

            if (_buildtyp.Contains("POS_READY_7EMB"))
            {
                IMAGE_TO_INSTALL = TestAndCustomOS._POSReady7_32bit;
                goto FoundIt;
            }

            if (_buildtyp.Contains("WIN10IOT_64") && _buildtyp.Contains("SKYLAKE"))
            {
                IMAGE_TO_INSTALL = TestAndCustomOS._7607_7703_Retail_Win10IoT_2019;
                goto FoundIt;
            }

            if (_buildtyp.Contains("WIN10IOT_64"))
            {
                IMAGE_TO_INSTALL = TestAndCustomOS._7702_7603_Retail_Win10IoT_2019;
                goto FoundIt;
            }

            lblImageName.Text = "";
            MessageBox.Show("NO SE HA ENCONTRADO IMAGEN CUSTOM OS PARA ESTA UNIDAD." + "\n" + "\n" + "\n" + "CONTACTA A INGENIERIA DE PRUEBAS!", "OnError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;

            FoundIt:
            {
                _imageInstalled = IMAGE_TO_INSTALL;
                lblImageName.Text = "IMAGE: " + IMAGE_TO_INSTALL;
                _result = StaticJImgaeX.APPLY_RADSIMAGEX(SSSCO_IMAGES_02 + "\"" + IMAGE_TO_INSTALL + "\"", "", Properties.Settings.Default._applyMode);
            }


            if (_result == 0)
            {
                _Status = "PASS";

                _LOG = "TRACER=" + _tracer + "\n" +
                       "DATE=" + DateTime.Now.ToString() + "\n" +
                       "CUSTOM_OS=" + _imageInstalled + "\n" +
                       "STATUS=" + _Status + "\n" +
                       _buildtyp;

                lblResult.ForeColor = Color.Green;
                lblResult.Text = "CUSTOM OS: YA PUEDE DESCONECTAR LA UNIDAD!";
                pBoxStatus.Visible = true;
                pBoxStatus.Image = Properties.Resources.GoodMark;
            }

            if (_result != 0)
            {
                _Status = "FAIL";
                _LOG = "TRACER=" + _tracer + "\n" +
                       "DATE=" + DateTime.Now.ToString() + "\n" +
                       "CUSTOM_OS=" + _imageInstalled + "\n" +
                       "STATUS=" + _Status + "\n" +
                       _buildtyp;

                lblResult.ForeColor = Color.Red;
                lblResult.Text = "CUSTOM OS: No ha sido instalada correctamente...";
                pBoxStatus.Visible = true;
                pBoxStatus.Image = Properties.Resources.BadMark;
            }


            string outputPath = "";
            string reportLog = @"\\mxchim0pangea01\SSCO_IMAGESLogs\";
            string _LOG_DIR_BK = @"\\MXCHIM0PANGEA01\SSCO_IMAGES\logs\Images\";
            outputPath = _LOG_DIR_BK + DateTime.Now.ToString("MM_yyyy_dd") + @"\" + DateTime.Now.ToString("HH") + @"\";
            DirectoryInfo DirInfo = new DirectoryInfo(outputPath);

            if (!DirInfo.Exists)
            {
                DirInfo.Create();
            }

            //create a backup logs in \\mxchim0pangea01\ssco_images\Logs\images\
            using (StreamWriter sw = File.CreateText(outputPath + _tracer + "_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".txt"))
            {
                _LOG = _LOG.Replace("\n", Environment.NewLine);
                sw.WriteLine(_LOG);
                sw.Close();
            }

            //create a log in \\mxchim0pangea01\SSCO_IMAGESLogs\ to report ifactory step
            using (StreamWriter sw = File.CreateText(reportLog + _tracer + "_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ".txt"))
            {
                _LOG = _LOG.Replace("\n", Environment.NewLine);
                sw.WriteLine(_LOG);
                sw.Close();
            }

            Flag_Trilight.SEND_TARS(_tracer, DateTime.Now, "BU Arrival", "RESOURCE=SBUTT01TE01", @"\\mxchim0pangea01\AUTOMATION_SSCO\TRILIGHT\InProcess\");
        }

        void TemporalFunctionForITM()
        {
            string result = string.Empty;

            void Command()
            {
                result = Diskpart.SendCommand("Select Disk 0", "Clean");

                result = Diskpart.SendCommand("Select Disk 0",
                                              "Create Partition Primary size=359",
                                              "Select partition 1",
                                              "assign letter=D",
                                              "format fs=ntfs quick label=System");

                result = Diskpart.SendCommand("Select Disk 0",
                                              "Select partition 2",
                                              "Create Partition Primary",
                                              "assign letter=C",
                                              "format fs=ntfs quick label=OS");

                //result = Diskpart.SendCommand("Select Disk 0",
                //                              "Select volume 1",
                //                              "Shrink desired=100000",
                //                              "Create Partition Primary size=100000",
                //                              "Select partition 3",
                //                              "assign letter=I",
                //                              "format fs=ntfs quick label=ITM");

                //result = Diskpart.SendCommand("Select Disk 0",
                //                             "Select volume 2",
                //                             "Active");

                result = Diskpart.SendCommand("Select Disk 0",
                                              "Select volume 1",
                                              "Active");
            }

            using (WaitWin waitWin = new WaitWin(Command, "DISKPART COMMANDS")) waitWin.ShowDialog();

           

            JIMAGEX = new ImageXGUI(ImageXGUI.ApplyOrCapture.Apply, 1, SSSCO_IMAGES_02 + _TestAndCustomOS._TestImage7703, "D:", OpenFlags.None, ExtractFlags.Ntfs);
            JIMAGEX.ShowDialog();


            JIMAGEX = new ImageXGUI(ImageXGUI.ApplyOrCapture.Apply, 2, SSSCO_IMAGES_02 + _TestAndCustomOS._TestImage7703, "C:", OpenFlags.None, ExtractFlags.Ntfs);
            JIMAGEX.ShowDialog();
       


            //JIMAGEX = new ImageXGUI(ImageXGUI.ApplyOrCapture.Apply, 1, ATM_IMAGES + _TestImageEstoril_Windows10, "F:", OpenFlags.CheckIntegrity, ExtractFlags.None);
            //JIMAGEX.ShowDialog();

            //JIMAGEX = new ImageXGUI(ImageXGUI.ApplyOrCapture.Apply, 1, ITM_Windows10, "I:", OpenFlags.CheckIntegrity, ExtractFlags.CompactLZX);
            //JIMAGEX.ShowDialog();


            result = Diskpart.BCDBoot(@"C:\Windows");
            //MessageBox.Show(result);
            //ExternalExe(_bcdBoot, @"C:\Windows");
            //ExternalExe(_bcdBoot, @"I:\windows");

            //result = Diskpart.BCDEdit(" ");
            //result = Diskpart.BCDEdit("/set " + Diskpart.DefaultIdentifier + " description PARTITION_PANGAEA");
            //result = Diskpart.BCDEdit("/set " + Diskpart.ITMIdentifier + " description PARTITION_ITM");

            return;
        }

        //FUNCTION TO INITIALIZE LIST VIEWS
        private void InitListViews()
        {
            // Add columns
            lvDescription_capture.View = View.Details;
            lvDescription_capture.Columns.Add("Drive", 50, HorizontalAlignment.Left);
            lvDescription_capture.Columns.Add("Description", 180, HorizontalAlignment.Left);
            lvDescription_capture.Columns.Add("Size", 100, HorizontalAlignment.Left);
            lvDescription_capture.Columns.Add("Partitions", 65, HorizontalAlignment.Left);

            lvPartition_capture.View = View.Details;
            lvPartition_capture.Columns.Add("Partition", 60, HorizontalAlignment.Left);
            lvPartition_capture.Columns.Add("Type", 100, HorizontalAlignment.Left);
            lvPartition_capture.Columns.Add("Size", 100, HorizontalAlignment.Left);
            lvPartition_capture.Columns.Add("Used", 100, HorizontalAlignment.Left);

            lvFilesView_capture.View = View.Details;
            lvFilesView_capture.Columns.Add("File", 250, HorizontalAlignment.Left);
            lvFilesView_capture.Columns.Add("Size", 150, HorizontalAlignment.Left);
            lvFilesView_capture.Columns.Add("Date", 200, HorizontalAlignment.Left);
        }

        //FUNCTION TO LIST ALL FILES INSADE OF FOLDER
        void ListAllFilesFromServer(string Server, bool SubFolder)
        {
            //string[] split = Server.Split(' ');
            //string _root = split[0];
            //string _path = split[1];
            string _ServerDir = string.Empty;
            if (!SubFolder) _ServerDir = Server.Substring(0, 2);
            if (SubFolder) _ServerDir = Server;

            try
            {
                DirectoryInfo _dirInfo = new DirectoryInfo(_ServerDir);
                //DirectoryInfo _dirInfo = new DirectoryInfo(_path);
                DirectoryInfo[] _dircInfo = _dirInfo.GetDirectories();
                FileInfo[] _filesInfo = _dirInfo.GetFiles();
                //FileInfo[] _filesInfo = _dirInfo.GetFiles("*.wim"); origi

                lvFilesView_capture.Items.Clear();

                foreach (DirectoryInfo _directoryInfo in _dircInfo)
                {
                    var item = new ListViewItem(new[] { _directoryInfo.Name, "", _directoryInfo.CreationTime.ToString() });
                    lvFilesView_capture.Items.Add(item);
                }

                foreach (FileInfo _fileInfo in _filesInfo)
                {
                    var item = new ListViewItem(new[] { _fileInfo.Name, _fileInfo.Length.ToString(), _fileInfo.CreationTime.ToString() });
                    lvFilesView_capture.Items.Add(item);
                }
            }
            catch (Exception)
            {

            }
        }

        //FUNCTION TO FILL LIST VIEW WITH ALL DEVICES CONNECTED IN CPU
        void FillListAllDisk()
        {
            try
            {
                ManagementObjectSearcher _myDisks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                lvDescription_capture.Items.Clear();
                lvPartition_capture.Items.Clear();
                foreach (ManagementObject myDisk in _myDisks.Get())
                {
                    var item = new ListViewItem(new[] { myDisk["Index"].ToString(), myDisk["Model"].ToString(), myDisk["Size"].ToString(), myDisk["Partitions"].ToString() });
                    var item2 = new ListViewItem(new[] { myDisk["Partitions"].ToString(), myDisk["MediaType"].ToString(), myDisk["Size"].ToString(), "" });
                    lvDescription_capture.Items.Add(item);
                    lvPartition_capture.Items.Add(item2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool subFolder = false;
        string _ServerDir = string.Empty;
        DirectoryInfo _dirInfo = null;

        void GetImagesFilesFromSever(string Server)
        {           
            try
            {                
                lbImagesToApply_apply.Items.Clear();
                lbImagesServer_apply.Items.Clear();

                if (!subFolder)
                {
                    _ServerDir = Server.Substring(0, 2);
                    _dirInfo = new DirectoryInfo(_ServerDir);    
                    
                }
                else
                {
                    _dirInfo = new DirectoryInfo(_ServerDir + "\\" + Server + "\\");
                }

      
                FileInfo[] _filesInfo = _dirInfo.GetFiles("*.wim");
                DirectoryInfo[] _directoriesInfo = _dirInfo.Root.GetDirectories().Where(x => !x.Attributes.HasFlag(FileAttributes.Hidden)).ToArray();

                //_ServerDir + "\\" + dirInfo.Name + "\\"
                foreach (DirectoryInfo dirInfo in _directoriesInfo) lbImagesServer_apply.Items.Add(dirInfo.Name);


                if (!subFolder)
                {
                    foreach (FileInfo _fileInfo in _filesInfo) lbImagesToApply_apply.Items.Add(_ServerDir + "\"" + _fileInfo.Name + "\"");                  
                     subFolder = true;
                }
                else
                {
                    
                    foreach (FileInfo _fileInfo in _filesInfo) lbImagesToApply_apply.Items.Add(_ServerDir + "\"" + Server + @"\" + _fileInfo.Name + "\"");
                    this.Refresh();
                }            
            }

            catch (Exception) { } 
        }

        void RefreshItems()
        {
            InitializeObjectsDiskpart();

            string[] _result = StaticFunctions.ListAllDrives();

            lbAllDrives_settings.Items.Clear();
            lbImagesServer_apply.Items.Clear();
            lbSaveImage_capture.Items.Clear();
            lvVolumes.Items.Clear();
            lvVolumes_Diskpart.Items.Clear();
            cBoxListDisk.Items.Clear();
            txtLabelDiskpart.Clear();
            txtSizeDiskpart.Clear();
            cBoxLetterDiskpart.Text = string.Empty;

            foreach (string _drive in _result)
            {
                lbAllDrives_settings.Items.Add(_drive);
                lbImagesServer_apply.Items.Add(_drive);
                lbSaveImage_capture.Items.Add(_drive);
            }

            List<string> volumes = Diskpart.GetVolumes();
            foreach (string volume in volumes)
            {
                lvVolumes.Items.Add(volume);
                lvVolumes_Diskpart.Items.Add(volume);
            }

            List<string> disks = Diskpart.ListDisk();
            foreach (string disk in disks)
            {
                cBoxListDisk.Items.Add(disk);
            }
        }
        
        void CaptureImageX(string Drive, string Path, string ImageName)
        {
            //imagex.exe /capture c: z:\BK-CL1.wim "BK-CL1" /verify example to use the imagex in winPENET
            this.TopMost = false;
            int _result = 0;

            try
            {
                string _InputArgs = "/capture " + Drive + " " + Path + "\\" + ImageName + " " + "\"" + string.Concat(ImageName.Reverse().Skip(4).Reverse()) + "\"" + " " + "/verify";

                _result = StaticFunctions.ExternalExe(_ImageXUEFI, _InputArgs);

                if (_result != 0) MessageBox.Show("La imagen no pudo ser capturada...");
                if (_result == 0) MessageBox.Show("Se capturo la imagen correctamente!");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.TopMost = true;
        }

        int ApplyImgImageX(string Image)  //function to apply image with ImageX.exe
        {
            //new image X
            string _image = Image;
            int _result = 0;

            //Image = Image.Insert(2, "\\");

            try
            {
                string _args = "/apply " + Image + " 1" + " I:";
                _result = StaticFunctions.ExternalExe(_ImageXUEFI, _args);
                MessageBox.Show(_result.ToString());
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return _result;
        }

        void CaptureRadsImage(string Drive, string ImageName, string Path, string CaptureMode)
        {
            //RadsImageX.exe /capture 0 D:\Name.wim Site or User example
            string _driveNumber = Drive + " ";
            string _imageName = ImageName;
            string _path = Path;
            string _captureMode = CaptureMode;
            string _Args = "";
            int _result = 0;

            try
            {
                _Args = _CaptureArgsStart + _driveNumber + _path + "\"" + _imageName + "\"" + " " + _captureMode;
                _result = StaticFunctions.ExternalExe(_RadsImage, _Args);

                if (_result == 1) MessageBox.Show("La imagen no pudo ser capturada...");
                if (_result == 0) MessageBox.Show("Se capturo la imagen correctamente!");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ///<summary>
        /// Function to map a new drive 
        ///</summary>
        int MapNewDrive(string letterDrive, string Server, string Domain, string User, string Password)
        {
            //net use Z: "\\mxchim0pangea01\ATM_IMAGES" /USER:Jabil\Testsystems Mav1sATMGl0bal
            string _NetProc = "net.exe";
            string _args1 = "use ";
            string _args2 = "/USER:";
            Server = "\"" + Server + "\"";
            string _ArgsToMap = _args1 + letterDrive + " " + Server + " " + _args2 + Domain + User + " " + Password;

            int _result = StaticFunctions.ExternalExe(_NetProc, _ArgsToMap);

            return _result;
        }


        ///<summary>
        /// This function show all disk connected into device
        ///</summary>
        void ListAllDisk()
        {
            ManagementObjectSearcher _myDisks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject myDisk in _myDisks.Get())
            {
                MessageBox.Show(myDisk["Model"].ToString());
            }
        }

        void InitializeObjectsDiskpart()
        {
            cBoxDiskpart_Commands.Enabled = false;
            cBoxLetterDiskpart.Enabled = false;
            txtLabelDiskpart.Enabled = false;
            txtSizeDiskpart.Enabled = false;
            btnDiskPartFunction.Enabled = false;
            checkBox1.Enabled = false;
        }

        private void btnApply_Back_Click(object sender, EventArgs e)
        {
            subFolder = false;
            RefreshItems();
        }


    }
    #endregion
}
