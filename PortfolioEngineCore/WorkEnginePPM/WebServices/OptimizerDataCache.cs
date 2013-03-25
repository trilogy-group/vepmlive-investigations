using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Linq;
using WorkEnginePPM;
using PortfolioEngineCore;


namespace OptmizerDataCache
{
    [Serializable()]
    internal class clsOptPIData
    {
        public int id, PI_ID, PI_Selected, PI_Mode;
        public DateTime StartDate, FinishDate;
        public string PI_Name;
        public List<string> m_PI_Extra_data;



        public clsOptPIData()
        {
            m_PI_Extra_data = new List<string>();

        }
    }
    [Serializable()]
    internal class clsOptFieldDelf
    {

        public int id, fid, ftype;
        public string fname, fextra;

    }
    [Serializable()]
    public class clsOptmizerDataCache
    {

        private string m_ticket = "";
        private string m_Pids = "";
        private string m_viewsxml = "";
        private string m_Stratagiesxml = "";
        private string m_commitflagname = "";
        private int m_curr_pos = 0;
        private int m_curr_digits = 2;
        private string m_curr_sym = "$";

        private List<clsOptFieldDelf> m_fielddef = null;
        private List<clsOptPIData> m_PIList = null;

        public clsOptmizerDataCache()
        {

            
        }

        public void CaptureOptData(string sxml, string sticket, string spids)
        {
            m_ticket = sticket;
            m_Pids = spids;
            m_fielddef = new List<clsOptFieldDelf>();
            m_PIList = new List<clsOptPIData>();
            m_commitflagname = "";

            CStruct xRoot = new CStruct();
            CStruct xFields;
            CStruct xCurrency;
            CStruct xItems;

            if (xRoot.LoadXML(sxml) == false)
                return;

           xCurrency = xRoot.GetSubStruct("Currency");

            if (xCurrency != null)
            {
                m_curr_pos = xCurrency.GetIntAttr("Pos");
                m_curr_digits = xCurrency.GetIntAttr("Digits");
                m_curr_sym = xCurrency.GetStringAttr("Sym");
            }



            xFields = xRoot.GetSubStruct("Fields");
            xItems = xRoot.GetSubStruct("Items");

            if (xFields == null)
                return;

            List<CStruct> oFields = xFields.GetList("Field");
            List<CStruct> oitems = xItems.GetList("Item");

            foreach (CStruct oNode in oFields)
            {
                clsOptFieldDelf ofld = new clsOptFieldDelf();

                ofld.id = m_fielddef.Count;
                ofld.fid = oNode.GetIntAttr("FID");
                ofld.ftype = oNode.GetIntAttr("FTYPE");
                ofld.fname = oNode.GetStringAttr("FName");
                ofld.fextra = oNode.GetStringAttr("FExtra");

                if (oNode.GetIntAttr("FOPTFLAG") == 1)
                {
                    m_commitflagname = ofld.fextra;
                }

                m_fielddef.Add(ofld);

            }

            foreach (CStruct oNode in oitems)
            {
                clsOptPIData opi = new clsOptPIData();

   
                
                opi.id = m_PIList.Count;


                opi.PI_ID = oNode.GetIntAttr("ID");
                opi.PI_Selected = oNode.GetIntAttr("PISelected");
                opi.PI_Mode = 3;

                opi.PI_Name = oNode.GetStringAttr("Name");

                opi.StartDate = oNode.GetDateAttr("Start");
                opi.FinishDate = oNode.GetDateAttr("Finish");


                xFields = oNode.GetSubStruct("Fields");
                oFields = xFields.GetList("Field");

                foreach (CStruct ofNode in oFields)
                {
                    string sfval = ofNode.GetStringAttr("Value");

                    opi.m_PI_Extra_data.Add(sfval);

                }

                m_PIList.Add(opi);

            }

 


        }

        public string GetProjectsGrid()
        {

            OptTopGrid oGrid = new OptTopGrid();
            string s;
            oGrid.InitializeGridLayout(m_fielddef, m_curr_pos, m_curr_digits, m_curr_sym);
            int i = 0;


            oGrid.FinalizeGridLayout();
            oGrid.InitializeGridData();


            foreach (clsOptPIData opi in m_PIList)
            {
                ++i;
                oGrid.AddDetailRow(opi, i, m_fielddef);
            }

            s = oGrid.GetString();

            return s;


        }

        public void SetPIStatusModeChange(string schanged)
        {

            int pid = StripNum(ref schanged);
            int mode = StripNum(ref schanged);
            int selled = StripNum(ref schanged);
 
            foreach (clsOptPIData opi in m_PIList)
            {
                if (opi.PI_ID == pid)
                {
                    opi.PI_Mode = mode;
                    opi.PI_Selected = selled;
                    break;
                }

            }

        }


        public void UpdateFilteredList(string sPIList)
        {
            sPIList = " " + sPIList + " ";

            foreach (clsOptPIData opi in m_PIList)
            {
                int pid = opi.PI_ID;

                if (sPIList.IndexOf(" " + pid.ToString() + " ") != -1)
                {
                    opi.PI_Selected = 1;
                }
                else
                {
                    opi.PI_Selected = 0;
                }
            }
        }


        public string  ReturnCommitflagName()
        {
            return m_commitflagname;
        }

        public void StashViews(string sViews)
        {
            m_viewsxml = sViews;
        }

        public void StashStratagies(string sStratagies)
        {
            m_Stratagiesxml = sStratagies;
        }

        private int StripNum(ref string sin)
        {
            int i = 0;
            string sval = "";

            sin = sin.Trim();
            i = sin.IndexOf(" ");

            if (i == -1)
            {
                sval = sin;
                sin = "";
            }
            else
            {
                sval = sin.Substring(0, i);
                sin = sin.Substring(i + 1); //, sin.Length - i);
            }

            return int.Parse(sval);
        }

    }
}