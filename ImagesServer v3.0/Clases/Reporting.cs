using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace ImagesServer_v3._0
{
    class Reporting
    {
        DataTable _tableXML;
        DataSet _ds;
        //string LOG = @"C:\XML\";
        string LOG = @"\\mxchim0pangea01\AUTOMATION_SSCO\Config Files\xml\";

        public void XMLSSCO()
        {
            _tableXML = new DataTable("SEMAPHORE_SSCO");
            _tableXML.Columns.Add("DATE");
            _tableXML.Columns.Add("OPERATOR");
            _tableXML.Columns.Add("TRACER");
            _tableXML.Columns.Add("CLASSMC");
            _tableXML.Columns.Add("SLOT");
            _tableXML.Columns.Add("IPADRESS");
            _tableXML.Columns.Add("STATUS");
            _tableXML.Columns.Add("COLOR");
            _tableXML.Columns.Add("PROGRESS");
        }

        public void CreateXML(string START_TIME, string OPERATOR, string TRACER, string CLASSMC, string SLOT, string IPADRESS, string STATUS, string COLOR, string PROGRESS)
        {
            _tableXML.Rows.Add(START_TIME, OPERATOR, TRACER, CLASSMC, SLOT, IPADRESS, STATUS, COLOR, PROGRESS);

            _ds = new DataSet("SEMAPHORE");
            _ds.Tables.Add(_tableXML);
            string XML = _ds.GetXml();
            File.WriteAllText(LOG + TRACER + ".XML", XML);
            _ds.Tables.Remove(_tableXML);
        }
    }
}
