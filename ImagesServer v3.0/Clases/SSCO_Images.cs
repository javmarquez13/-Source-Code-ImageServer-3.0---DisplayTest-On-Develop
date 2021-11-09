using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagesServer_v3._0
{
    class SSCO_Images
    {
        private static string TEST_IMAGES_SSCO = "TEST_IMAGES_SSCO";
        private static string CUSTOM_OS_SSCO = "CUSTOM_OS_SSCO";


        public static string TestImage7350R6L
        {
            get
            {
                return ConfigFiles.reader(TEST_IMAGES_SSCO, "TestImage7350R6L", Globals.PATH_TEST_CUSTOMOS);
            }
        }

        public static string TestImage7350R5
        {
            get
            {
                return ConfigFiles.reader(TEST_IMAGES_SSCO, "TestImage7350R5", Globals.PATH_TEST_CUSTOMOS);
            }
        }

        public static string TestImage7702
        {
            get
            {
                return ConfigFiles.reader(TEST_IMAGES_SSCO, "TestImage7702", Globals.PATH_TEST_CUSTOMOS);
            }
        }
        public static string TestImage7703
        {
            get
            {
                return ConfigFiles.reader("SSCO", "TestImage7703", Globals.PATH_TEST_CUSTOMOS);
            }
        }

        public static string TestImage7772
        {
            get
            {
                return ConfigFiles.reader(TEST_IMAGES_SSCO, "TestImage7772", Globals.PATH_TEST_CUSTOMOS);
            }
        }

        public static string TestImage7773
        {
            get
            {
                return ConfigFiles.reader(TEST_IMAGES_SSCO, "TestImage7773", Globals.PATH_TEST_CUSTOMOS);
            }
        }

        public static List<string> CustomOS
        {
            get
            {
                return ConfigFiles.GetKeys(CUSTOM_OS_SSCO);
            }
        }
    }
}
