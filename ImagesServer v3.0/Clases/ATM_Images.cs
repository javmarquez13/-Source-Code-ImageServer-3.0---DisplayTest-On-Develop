using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagesServer_v3._0
{
    class ATM_Images
    {
        private static string TEST_IMAGES_ATM = "TEST_IMAGES_ATM";
        private static string ITM_IMAGES = "ITM_IMAGES";

        public static string TestImageMisano_Estoril_Windows10_5801_P110
        {
            get
            {
                return ConfigFiles.reader(TEST_IMAGES_ATM, "TestImageMisano_Estoril_Windows10_5801-P110", Globals.PATH_TEST_CUSTOMOS);
            }
        }

        public static string TestImageEstoril_Windows7
        {
            get
            {
                return ConfigFiles.reader(TEST_IMAGES_ATM, "TestImageEstoril_Windows7", Globals.PATH_TEST_CUSTOMOS);
            }
        }

        public static string TestImageEstoril_Windows10
        {
            get
            {
                return ConfigFiles.reader(TEST_IMAGES_ATM, "TestImageEstoril_Windows10", Globals.PATH_TEST_CUSTOMOS);
            }
        }

        public static string TestImageMisano_Windows7
        {
            get
            {
                return ConfigFiles.reader(TEST_IMAGES_ATM, "TestImageMisano_Windows7", Globals.PATH_TEST_CUSTOMOS);
            }
        }

        public static string TestImageMisano_Windows10
        {
            get
            {
                return ConfigFiles.reader(TEST_IMAGES_ATM, "TestImageMisano_Windows10", Globals.PATH_TEST_CUSTOMOS);
            }
        }

        public static string TestImageKabyLake_Windows10
        {
            get
            {
                return ConfigFiles.reader(TEST_IMAGES_ATM, "TestImageKabyLake_Windows10", Globals.PATH_TEST_CUSTOMOS);
            }
        }





        public static string TestImageWin10IoT_2019_v1809
        {
            get
            {
                return ConfigFiles.reader(TEST_IMAGES_ATM, "TestImageWin10IoT_2019_v1809", Globals.PATH_TEST_CUSTOMOS);
            }
        }

        public static string TestImageWin10IoT_2016_v1607
        {
            get
            {
                return ConfigFiles.reader(TEST_IMAGES_ATM, "TestImageWin10IoT_2016_v1607", Globals.PATH_TEST_CUSTOMOS);
            }
        }

        public static string TestImageWindows7
        {
            get
            {
                return ConfigFiles.reader(TEST_IMAGES_ATM, "TestImageWindows7", Globals.PATH_TEST_CUSTOMOS);
            }
        }

        private static string TEST_IMAGES_ATM_FEATURES = "TEST_IMAGES_ATM_FEATURES";
        public static List<string> ATM_TestImage
        {
            get
            {
                return ConfigFiles.GetKeys(TEST_IMAGES_ATM_FEATURES);
            }
        }


        public static string ITM_Windows7
        {
            get
            {
                return ConfigFiles.reader(ITM_IMAGES, "ITM_Windows7", Globals.PATH_TEST_CUSTOMOS);
            }
        }

        public static string ITM_Windows10
        {
            get
            {
                return ConfigFiles.reader(ITM_IMAGES, "ITM_Windows10", Globals.PATH_TEST_CUSTOMOS);
            }
        }

        public static bool ITM_ACTIVE
        {
            get
            {
                return Convert.ToBoolean(ConfigFiles.reader(ITM_IMAGES, "ITM_ACTIVE", Globals.PATH_TEST_CUSTOMOS));
            }
        }
    }
}
