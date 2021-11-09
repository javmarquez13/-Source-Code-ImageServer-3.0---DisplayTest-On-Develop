using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagesServer_v3._0
{
    class TestAndCustomOS
    {

        //LOGICA VIEJA TODO SE MIGRO A ATM_Images y SSCO_Images
        public static string _POSREADY7Skylake => "POS Ready 7 (32 Bit) XR7 Plus Compatible Skylake D370-1038-0100_01.00.00.02.wim";
        public static string _POS7_64bit => "POS7_64bit.wim"; 
        public static string _POSReady_2009 => "POSReady_2009.wim";
        public static string _POSReady7_32bit => "POSReady7_32bit.wim";
        public static string _WAL_R6LITE => "WAL_R6LITE.wim";
        public static string _Windows7ProfessionalEmbedded32Bit => "Windows 7 professional embedded 32 bit.wim";
        public static string _XR7_XR6_Win10_IoT_64b_2016 => "XR7-XR6_Win10-IoT-64b-2016_D370-1066_01.00.00.00.wim";
        public static string _XR7_XR6_Win7_PRO_EMBEDDED_64b => "XR7-XR6-Win7_PRO_EMBEDDED_64b_D370-1061_01.00.00.05.wim";
        public static string _7607_7703_Retail_Win10IoT_2019 => "7607_7703_Retail_Win10IoT_2019_v1809_64Bit_01.00.00.01.wim";
        public static string _7702_7603_Retail_Win10IoT_2019 => "7702_7603_Retail_Win10IoT_2019_v1809_64bit_01.00.00.00.wim";


        //Test images names for SSCOs
        public string _TestImage7703 { get; set; }
        public string _TestImage7702 { get; set; }
        public string _TestImage7358 { get; set; }
        public string _TestImage7362 { get; set; }
        public string _TestImage7350R6L { get; set; }
        public string _TestImage7350R5 { get; set; }

        public string _TestImageEstoril_Windows7 { get; set; }
        public string _TestImageEstoril_Windows10 { get; set; }
        public string _TestImageMisano_Estoril_Windows10_5801P110 { get; set; }
        public string _TestImageMisano_Windows7 { get; set; }
        public string _TestImageMisano_Windows10 { get; set; }
        public string _TestImageKabyLake_Windows10 { get; set; }

        public string ITM_Windows7 { get; set; }
        public string ITM_Windows10 { get; set; }


        public void GettingImages()
        {
            //ConfigFiles _ConfigFiles = new ConfigFiles();
            //string _configPath = @"\\mxchim0pangea01\AUTOMATION_SSCO\IMAGES_SERVER_2.0\ConfigFile\SetupTestImages.ini";
            //_TestImage7703 = ConfigFiles.reader("SSCO", "TestImage7703");
            //_TestImage7702 = ConfigFiles.reader("SSCO", "TestImage7702");
            //_TestImage7358 = ConfigFiles.reader("SSCO", "TestImage7358");
            //_TestImage7362 = ConfigFiles.reader("SSCO", "TestImage7362");
            //_TestImage7350R6L = ConfigFiles.reader("SSCO", "TestImage7350R6L");
            //_TestImage7350R5 = ConfigFiles.reader("SSCO", "TestImage7350R5");

            //_TestImageEstoril_Windows7 = ConfigFiles.reader("ATM", "TestImageEstoril_Windows7");
            //_TestImageEstoril_Windows10 = ConfigFiles.reader("ATM", "TestImageEstoril_Windows10");
            //_TestImageMisano_Windows7 = ConfigFiles.reader("ATM", "TestImageMisano_Windows7");
            //_TestImageMisano_Windows10 = ConfigFiles.reader("ATM", "TestImageMisano_Windows10");
            //_TestImageMisano_Estoril_Windows10_5801P110 = ConfigFiles.reader("ATM", "TestImageMisano_Estoril_Windows10_5801-P110");
            //_TestImageKabyLake_Windows10 = ConfigFiles.reader("ATM", "TestImageKabyLake_Windows10");

            //ITM_Windows7 = ConfigFiles.reader("ITM", "ITM_Windows7");
            //ITM_Windows10 = ConfigFiles.reader("ITM", "ITM_Windows10");
        }  
    }
}
     
       
    

