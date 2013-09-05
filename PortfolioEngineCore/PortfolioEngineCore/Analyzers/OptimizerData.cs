using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;

namespace PortfolioEngineCore
{

    internal class PIData
    {
        public int PI_ID, PISelected;
        public DateTime StartDate, FinishDate;
        public string PI_Name;
        public string[] m_PI_Extra_data;
        public string[] m_PI_Format_Extra_data;

        public PIData(int arraysize)
        {
            m_PI_Extra_data = new string[arraysize + 1];
            m_PI_Format_Extra_data = new string[arraysize + 1];


        }
    }
    internal class Lookup
    {
        public string Name = "";
        public string Desc = "";
        public int UID = 0;
    };

    public class OptimizerData : PFEBase
    {

        #region Fields (1)
        private const int MAX_PI_EXTRA = 512;


        private const int EPK_FTYPE_DATE = 1;
        private const int EPK_FTYPE_INTEGER = 2;
        private const int EPK_FTYPE_NUMBER = 3;
        private const int EPK_FTYPE_CODE = 4;
        private const int EPK_FTYPE_URL = 6;
        private const int EPK_FTYPE_RES = 7;
        private const int EPK_FTYPE_CURRENCY = 8;
        private const int EPK_FTYPE_TEXT = 9;
        private const int EPK_FTYPE_PERCENT = 11;
        private const int EPK_FTYPE_YESNO = 13;
        private const int EPK_FTYPE_RTF = 19;
        private const int EPK_FTYPE_WORK = 20;
        private const int EPK_FTYPE_DURATION = 23;
        private const int EPK_FTYPE_OWNER = 12346;

        private readonly SqlConnection _sqlConnection;
        private Dictionary<int, string> m_stages = new Dictionary<int, string>();
        private List<PIData> m_PIs = new List<PIData>();

        private Dictionary<int, string> m_reses = new Dictionary<int, string>();
        private Dictionary<int, Lookup> m_codes = new Dictionary<int, Lookup>();

        private int m_SelFID = 0;
        private string m_Select_FieldName = "";


        private string[] m_sextra = new string[MAX_PI_EXTRA + 1];
        private string[] m_ExtraFieldNames = new string[MAX_PI_EXTRA + 1];
        private int[] m_fidextra = new int[MAX_PI_EXTRA + 1];
        private int[] m_ExtraFieldTypes = new int[MAX_PI_EXTRA + 1];
        private int m_Use_extra = 0;
        private int m_curr_pos = 0;
        private int m_curr_digits = 2;
        private string m_curr_sym = "$";


        #endregion Fields

        public OptimizerData(string basepath, string username, string pid, string company, string dbcnstring, SecurityLevels secLevel, bool bDebug = false)
            : base(basepath, username, pid, company, dbcnstring, secLevel, bDebug)
        {
            debug.AddMessage("Loading ModelSupport Class");
            _sqlConnection = _PFECN;
            _userWResID = Utilities.ResolveNTNameintoWResID(_sqlConnection, username);
        }

        public OptimizerData(string sBaseInfo)
            : base(sBaseInfo)
        {
            debug.AddMessage("Loading CostAnalyzerData Class");
            _sqlConnection = _PFECN;
        }

        public string GrabPidsFromTicket(string ticket)
        {

            string sCommand = "";
            int eStatus = 0;
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            string sGuids = "";
            string sGin = "";
            int i = 0;
            int lPid;
            string sPids = "";
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();


            sCommand = "SELECT DC_DATA FROM EPG_DATA_CACHE WHERE DC_TICKET = '" + ticket + "'";

            oCommand = new SqlCommand(sCommand, _sqlConnection);
            reader = oCommand.ExecuteReader();
            while (reader.Read())
            {
                sGuids = DBAccess.ReadStringValue(reader["DC_DATA"]);
            }
            reader.Close();
            reader = null;


            sGuids = sGuids.Replace(",", " ");
            sGuids = sGuids.ToUpper();
            sGuids = sGuids.Trim();


            while (sGuids.Length != 0)
            {
                sGin = "";

                i = sGuids.IndexOf(" ");

                if (i == -1)
                {
                    sGin = sGuids;
                    sGuids = "";
                }
                else
                {
                    sGin = sGuids.Substring(0, i);
                    sGuids = sGuids.Substring(i + 1);
                }

                if (sGin != "")
                {

                    sCommand = "SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE { fn UCASE(PROJECT_EXT_UID) }  = '" + sGin + "'";

                    oCommand = new SqlCommand(sCommand, _sqlConnection);
                    reader = oCommand.ExecuteReader();
                    lPid = 0;
                    while (reader.Read())
                    {
                        lPid = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                    }
                    reader.Close();
                    reader = null;

                    if (lPid != 0)
                    {
                         if (sPids == "")
                            sPids = lPid.ToString();
                        else
                            sPids = sPids + "," + lPid.ToString();
                    }

                }

            }
            return sPids;

        }

        public string OptimizerLoadData(string sPIListIn)
        {
            bool bPMOAdmin = false; 
            
            try
            {
                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();



                if (_userWResID == 1)
                {
                    bPMOAdmin = true;
                }
                else
                {
                    bPMOAdmin = Security.CheckUserGlobalPermission(_dba, _userWResID, GlobalPermissionsEnum.gpOptimizerAnalyzer);
                }
                
                 if (sPIListIn == "")
                     return "";

                ReadStages(_sqlConnection);
                ReadExtraPifields(_sqlConnection);

                DateTime edate, ldate;
                ReadPILevelData(_sqlConnection, sPIListIn);

                ReadCurrencySettings(_sqlConnection);



            }

            catch (Exception ex)
            {

            }

            CStruct xRoot = new CStruct();
            CStruct xCurrency;
            CStruct xPerms;
            CStruct xFields;
            CStruct xField;
            CStruct xPIS;
            CStruct xPI;

            xRoot.Initialize("Optimizer");
            xPerms = xRoot.CreateSubStruct("Permissions");
            xPerms.CreateIntAttr("Allowed", (bPMOAdmin == true ? 1 : 0));


            xCurrency = xRoot.CreateSubStruct("Currency");
            xCurrency.CreateIntAttr("Pos", m_curr_pos);
            xCurrency.CreateIntAttr("Digits", m_curr_digits);
            xCurrency.CreateStringAttr("Sym", m_curr_sym);

            xFields = xRoot.CreateSubStruct("Fields");

            for (int xi = 1; xi <= m_Use_extra; xi++)
            {
                xField = xFields.CreateSubStruct("Field");

                xField.CreateIntAttr("FID", m_fidextra[xi]);
                xField.CreateIntAttr("FTYPE", m_ExtraFieldTypes[xi]);

                xField.CreateStringAttr("FName", m_ExtraFieldNames[xi]);

                if (m_ExtraFieldTypes[xi] == EPK_FTYPE_YESNO && m_ExtraFieldNames[xi] == "OptimizerFlag")
                     xField.CreateIntAttr("FOPTFLAG", 1);
                else
                    xField.CreateIntAttr("FOPTFLAG", 0);

                xField.CreateStringAttr("FExtra", m_sextra[xi]);
            }

            xPIS = xRoot.CreateSubStruct("Items");

            foreach (PIData oPI in m_PIs)
            {
                xPI = xPIS.CreateSubStruct("Item");
                xPI.CreateIntAttr("ID", oPI.PI_ID);
                xPI.CreateStringAttr("Name", oPI.PI_Name);
                xPI.CreateIntAttr("PISelected", oPI.PISelected);
                xPI.CreateDateAttr("Start", oPI.StartDate);
                xPI.CreateDateAttr("Finish", oPI.FinishDate);


                xFields = xPI.CreateSubStruct("Fields");

                for (int xi = 1; xi <= m_Use_extra; xi++)
                {
                    xField = xFields.CreateSubStruct("Field");
                    string sVal = FormatExportExtraData(oPI.m_PI_Extra_data[xi], m_ExtraFieldTypes[xi]);

                    xField.CreateStringAttr("Value", sVal);
                }
            }

            return xRoot.XML();

        }

        public bool GetOptimizerViewsXML(out string sReply)
        {
            sReply = "";
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            CStruct xRPE = new CStruct();
            xRPE.Initialize("Views");

            //string sCommand = "SELECT VIEW_GUID,VIEW_NAME,VIEW_PERSONAL,VIEW_DEFAULT FROM EPG_VIEWS WHERE VIEW_CONTEXT=30000 AND (WRES_ID=0 OR WRES_ID=" + this._userWResID.ToString() + ") ORDER BY VIEW_DEFAULT DESC,WRES_ID DESC,VIEW_NAME";
            string sCommand = "SELECT VIEW_DATA FROM EPG_VIEWS WHERE VIEW_CONTEXT=32100 AND (WRES_ID=0 OR WRES_ID=" + this._userWResID.ToString() + ") ORDER BY VIEW_DEFAULT DESC,WRES_ID DESC,VIEW_NAME";

            SqlCommand oCommand = new SqlCommand(sCommand, _sqlConnection);
            SqlDataReader reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                CStruct xView = new CStruct();
                //CStruct xView = xRPE.CreateSubStruct("View");
                //xView.CreateGuidAttr("ViewGUID", DBAccess.ReadGuidValue(reader["VIEW_GUID"]));
                //xView.CreateStringAttr("Name", DBAccess.ReadStringValue(reader["VIEW_NAME"]));
                //xView.CreateBooleanAttr("Personal", DBAccess.ReadBoolValue(reader["VIEW_PERSONAL"]));
                //xView.CreateBooleanAttr("Default", DBAccess.ReadBoolValue(reader["VIEW_DEFAULT"]));
                string sXML = DBAccess.ReadStringValue(reader["VIEW_DATA"]);
                if (sXML != string.Empty)
                {
                    xView.LoadXML(sXML);
                    xRPE.AppendSubStruct(xView);
                }
            }
            reader.Close();
            sReply = xRPE.XML();
            //        Exit_Function:
            return true; // (_dba.Status == StatusEnum.rsSuccess);
        }

        public bool GetOptimizerViewXML(Guid guidView, out string sReply)
        {
            sReply = "";

            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            CStruct xView = new CStruct();
            //xView.Initialize("View");

            string sCommand = "SELECT VIEW_DATA FROM EPG_VIEWS WHERE VIEW_CONTEXT=32100 AND VIEW_GUID=@guid";
            //string sCommand = "SELECT WAU_UID,UINF_VIEWNAME,UINF_XML FROM EPGT_LOCALVIEWS WHERE UINF_VIEWNAME=" + _dba.PrepareText(sViewName) + " ORDER BY UINF_VIEWNAME";

            SqlCommand oCommand = new SqlCommand(sCommand, _sqlConnection);
            oCommand.Parameters.AddWithValue("@guid", guidView);
            SqlDataReader reader = oCommand.ExecuteReader();

            if (reader.Read())
            {
                //Guid guidView2 = DBAccess.ReadGuidValue(reader["VIEW_GUID"]);
                //string sName = DBAccess.ReadStringValue(reader["VIEW_NAME"]);
                //bool bPersonal = DBAccess.ReadBoolValue(reader["VIEW_PERSONAL"]);
                //bool bDefault = DBAccess.ReadBoolValue(reader["VIEW_DEFAULT"]);
                string sXML = DBAccess.ReadStringValue(reader["VIEW_DATA"]);
                if (sXML != string.Empty)
                    xView.LoadXML(sXML);
                //xView.SetIntAttr("ViewUID", nUID);
                //xView.SetStringAttr("Name", sName);
                //xView.SetBooleanAttr("Personal", bPersonal);
                //xView.SetBooleanAttr("Default", bDefault);
            }
            reader.Close();
            sReply = xView.XML(); ;
            //        Exit_Function:
            return true; // (_dba.Status == StatusEnum.rsSuccess);
        }

        public bool SaveOptimizerViewXML(Guid guidView, string sName, bool bPersonal, bool bDefault, string sData)
        {

            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            //SqlCommand cmd = new SqlCommand("DELETE FROM EPG_VIEWS WHERE VIEW_CONTEXT=30000 AND VIEW_UID=?",  _sqlConnection);
            //cmd.Parameters.AddWithValue("VIEW_UID", nViewUID);
            //int lRowsAffected = cmd.ExecuteNonQuery();
            string sCommand;
            sCommand = "UPDATE EPG_VIEWS SET VIEW_NAME=@vname,WRES_ID=@wres,VIEW_DEFAULT=@vdef,VIEW_DATA=@vdata,VIEW_CONTEXT=32100 WHERE VIEW_GUID=@guid";
            SqlCommand cmd = new SqlCommand(sCommand, _sqlConnection);
            cmd.Parameters.AddWithValue("@vname", sName);
            cmd.Parameters.AddWithValue("@wres", bPersonal ? this._userWResID : 0);
            cmd.Parameters.AddWithValue("@vdef", bDefault);
            cmd.Parameters.AddWithValue("@vdata", sData);
            cmd.Parameters.AddWithValue("@guid", guidView);
            int nRowsAffected = cmd.ExecuteNonQuery();

            if (nRowsAffected == 0)
            {
                sCommand = "INSERT INTO EPG_VIEWS (VIEW_GUID,VIEW_NAME,WRES_ID,VIEW_DEFAULT,VIEW_DATA,VIEW_CONTEXT) VALUES(@guid,@name,@wres,@def,@vdata,32100)";
                cmd = new SqlCommand(sCommand, _sqlConnection);
                cmd.Parameters.AddWithValue("@guid", guidView);
                cmd.Parameters.AddWithValue("@name", sName);
                cmd.Parameters.AddWithValue("@wres", bPersonal ? this._userWResID : 0);
                cmd.Parameters.AddWithValue("@def", bDefault);
                cmd.Parameters.AddWithValue("@vdata", sData);
                nRowsAffected = cmd.ExecuteNonQuery();
            }

            return true; // (_dba.Status == StatusEnum.rsSuccess);
        }

        public bool DeleteOptimizerViewXML(Guid guidView)
        {
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            string sCommand = "DELETE FROM EPG_VIEWS WHERE VIEW_GUID=@guid";
            SqlCommand cmd = new SqlCommand(sCommand, _sqlConnection);
            cmd.Parameters.AddWithValue("@guid", guidView);
            int nRowsAffected = cmd.ExecuteNonQuery();
            return true; // (_dba.Status == StatusEnum.rsSuccess);
        }

        public bool RenameOptimizerViewXML(Guid guidView, string sName)
        {
            string sCommand;
            CStruct xView = null;
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            sCommand = "SELECT VIEW_DATA FROM EPG_VIEWS WHERE VIEW_CONTEXT=32100 AND VIEW_GUID=@guid";
            //string sCommand = "SELECT WAU_UID,UINF_VIEWNAME,UINF_XML FROM EPGT_LOCALVIEWS WHERE UINF_VIEWNAME=" + _dba.PrepareText(sViewName) + " ORDER BY UINF_VIEWNAME";

            SqlCommand oCommand = new SqlCommand(sCommand, _sqlConnection);
            oCommand.Parameters.AddWithValue("@guid", guidView);
            SqlDataReader reader = oCommand.ExecuteReader();

            if (reader.Read())
            {
                string sXML = DBAccess.ReadStringValue(reader["VIEW_DATA"]);
                if (sXML != string.Empty)
                {
                    xView = new CStruct();
                    xView.LoadXML(sXML);
                }
            }
            reader.Close();

            if (xView == null)
                return false;

            xView.SetStringAttr("Name", sName);

            sCommand = "UPDATE EPG_VIEWS SET VIEW_NAME=@name,VIEW_DATA = @vdata WHERE VIEW_GUID=@guid";
            SqlCommand cmd = new SqlCommand(sCommand, _sqlConnection);
            cmd.Parameters.AddWithValue("@name", sName);
            cmd.Parameters.AddWithValue("@vdata", xView.XML());
            cmd.Parameters.AddWithValue("@guid", guidView);
            int nRowsAffected = cmd.ExecuteNonQuery();

            if (nRowsAffected == 0)
            {
                return false;
            }


            return true; // (_dba.Status == StatusEnum.rsSuccess);
        }

        public bool GetOptimizerStratagiesXML(string ListID, out string sReply)
        {
            sReply = "";
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            CStruct xStratagies = new CStruct();
            xStratagies.Initialize("Stratagies");

            // create the no statagy stratagy!

            CStruct xStratagy = xStratagies.CreateSubStruct("Stratagy");
            xStratagy.CreateStringAttr("StratagyGUID", "0");
            xStratagy.CreateStringAttr("Name", "- None -");
            xStratagy.CreateStringAttr("Default", "1");
            xStratagy.CreateStringAttr("Personal", "0");

            CStruct xPerformance = xStratagy.CreateSubStruct("Performance");
            xPerformance.CreateStringAttr("Title", "");
            xPerformance.CreateStringAttr("Value", "");
            xPerformance.CreateStringAttr("TFID", "0");
 
            xStratagy.CreateSubStruct("Fields");
 






            string sCommand = "SELECT VIEW_DATA FROM EPG_VIEWS WHERE VIEW_CONTEXT=32110 AND (WRES_ID=0 OR WRES_ID=" + this._userWResID.ToString() + ") ORDER BY VIEW_DEFAULT DESC,WRES_ID DESC,VIEW_NAME";

            SqlCommand oCommand = new SqlCommand(sCommand, _sqlConnection);
            SqlDataReader reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                xStratagy = new CStruct();

                string sXML = DBAccess.ReadStringValue(reader["VIEW_DATA"]);
                if (sXML != string.Empty)
                {
                    xStratagy.LoadXML(sXML);

                    if (xStratagy.GetStringAttr("ListID") == ListID)
                        xStratagies.AppendSubStruct(xStratagy);
                }
            }
            reader.Close();
            sReply = xStratagies.XML();
            //        Exit_Function:
            return true; // (_dba.Status == StatusEnum.rsSuccess);
        }

  

        public bool GetOptimizerStratagyXML(Guid guidView, out string sReply)
        {
            sReply = "";

            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            CStruct xStratagy = new CStruct();

            string sCommand = "SELECT VIEW_DATA FROM EPG_VIEWS WHERE VIEW_CONTEXT=32110 AND VIEW_GUID=@guid";
     
            SqlCommand oCommand = new SqlCommand(sCommand, _sqlConnection);
            oCommand.Parameters.AddWithValue("@guid", guidView);
            SqlDataReader reader = oCommand.ExecuteReader();

            if (reader.Read())
            {
                //Guid guidView2 = DBAccess.ReadGuidValue(reader["VIEW_GUID"]);
                //string sName = DBAccess.ReadStringValue(reader["VIEW_NAME"]);
                //bool bPersonal = DBAccess.ReadBoolValue(reader["VIEW_PERSONAL"]);
                //bool bDefault = DBAccess.ReadBoolValue(reader["VIEW_DEFAULT"]);
                string sXML = DBAccess.ReadStringValue(reader["VIEW_DATA"]);
                if (sXML != string.Empty)
                    xStratagy.LoadXML(sXML);
                //xView.SetIntAttr("ViewUID", nUID);
                //xView.SetStringAttr("Name", sName);
                //xView.SetBooleanAttr("Personal", bPersonal);
                //xView.SetBooleanAttr("Default", bDefault);
            }
            reader.Close();
            sReply = xStratagy.XML(); ;
            //        Exit_Function:
            return true; // (_dba.Status == StatusEnum.rsSuccess);
        }

        public bool SaveOptimizerStratagyXML(Guid guidStratagy, string sName, bool bPersonal, bool bDefault, string sData)
        {

            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            string sCommand;
            sCommand = "UPDATE EPG_VIEWS SET VIEW_NAME=@vname,WRES_ID=@wres,VIEW_DEFAULT=@vdef,VIEW_DATA=@vdata,VIEW_CONTEXT=32110 WHERE VIEW_GUID=@guid";
            SqlCommand cmd = new SqlCommand(sCommand, _sqlConnection);
            cmd.Parameters.AddWithValue("@vname", sName);
            cmd.Parameters.AddWithValue("@wres", bPersonal ? this._userWResID : 0);
            cmd.Parameters.AddWithValue("@vdef", bDefault);
            cmd.Parameters.AddWithValue("@vdata", sData);
            cmd.Parameters.AddWithValue("@guid", guidStratagy);
            int nRowsAffected = cmd.ExecuteNonQuery();

            if (nRowsAffected == 0)
            {
                sCommand = "INSERT INTO EPG_VIEWS (VIEW_GUID,VIEW_NAME,WRES_ID,VIEW_DEFAULT,VIEW_DATA,VIEW_CONTEXT) VALUES(@guid,@name,@wres,@def,@vdata,32110)";
                cmd = new SqlCommand(sCommand, _sqlConnection);
                cmd.Parameters.AddWithValue("@guid", guidStratagy);
                cmd.Parameters.AddWithValue("@name", sName);
                cmd.Parameters.AddWithValue("@wres", bPersonal ? this._userWResID : 0);
                cmd.Parameters.AddWithValue("@def", bDefault);
                cmd.Parameters.AddWithValue("@vdata", sData);
                nRowsAffected = cmd.ExecuteNonQuery();
            }

            return true; // (_dba.Status == StatusEnum.rsSuccess);
        }

        public bool DeleteOptimizerStratagyXML(Guid guidStratagy)
        {
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            string sCommand = "DELETE FROM EPG_VIEWS WHERE VIEW_GUID=@guid";
            SqlCommand cmd = new SqlCommand(sCommand, _sqlConnection);
            cmd.Parameters.AddWithValue("@guid", guidStratagy);
            int nRowsAffected = cmd.ExecuteNonQuery();
            return true; // (_dba.Status == StatusEnum.rsSuccess);
        }

        public bool RenameOptimizerStratagyXML(Guid guidStratagy, string sName)
        {
            string sCommand;
            CStruct xStratagy = null;
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            sCommand = "SELECT VIEW_DATA FROM EPG_VIEWS WHERE VIEW_CONTEXT=32110 AND VIEW_GUID=@guid";
            //string sCommand = "SELECT WAU_UID,UINF_VIEWNAME,UINF_XML FROM EPGT_LOCALVIEWS WHERE UINF_VIEWNAME=" + _dba.PrepareText(sViewName) + " ORDER BY UINF_VIEWNAME";

            SqlCommand oCommand = new SqlCommand(sCommand, _sqlConnection);
            oCommand.Parameters.AddWithValue("@guid", guidStratagy);
            SqlDataReader reader = oCommand.ExecuteReader();

            if (reader.Read())
            {
                string sXML = DBAccess.ReadStringValue(reader["VIEW_DATA"]);
                if (sXML != string.Empty)
                {
                    xStratagy = new CStruct();
                    xStratagy.LoadXML(sXML);
                }
            }
            reader.Close();

            if (xStratagy == null)
                return false;

            xStratagy.SetStringAttr("Name", sName);

            sCommand = "UPDATE EPG_VIEWS SET VIEW_NAME=@name,VIEW_DATA = @vdata WHERE VIEW_GUID=@guid";
            SqlCommand cmd = new SqlCommand(sCommand, _sqlConnection);
            cmd.Parameters.AddWithValue("@name", sName);
            cmd.Parameters.AddWithValue("@vdata", xStratagy.XML());
            cmd.Parameters.AddWithValue("@guid", guidStratagy);
            int nRowsAffected = cmd.ExecuteNonQuery();

            if (nRowsAffected == 0)
            {
                return false;
            }


            return true; // (_dba.Status == StatusEnum.rsSuccess);
        }

        public void CommitOptimizerStratagy(string sFname, string sIn, string sOut)
        {
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            if (sFname == "")
                return;

            SqlCommand oCommand = null;
            string sCommand = "";

            if (sIn != "")
            {
                sCommand = "UPDATE EPGP_PROJECT_INT_VALUES SET " + sFname + "=1 WHERE (PROJECT_ID IN (" + sIn + "))";
                oCommand = new SqlCommand(sCommand, _sqlConnection);
                oCommand.ExecuteNonQuery();

            }

            if (sOut != "")
            {

                sCommand = "UPDATE EPGP_PROJECT_INT_VALUES SET " + sFname + "=0 WHERE (PROJECT_ID IN (" + sOut + "))";
                oCommand = new SqlCommand(sCommand, _sqlConnection);
                oCommand.ExecuteNonQuery();

            }


        }
        private void ReadCurrencySettings(SqlConnection oDataAccess)
        {
            SqlCommand oCommand = null;
            SqlDataReader reader = null;

            string sCommand = "";
            int i = 0;
            m_stages = new Dictionary<int, string>();

            sCommand = "SELECT ADM_CURRENCY_DIGITS, ADM_CURRENCY_POSITION, ADM_CURRENCY_SYMBOL FROM  EPG_ADMIN";

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                m_curr_pos = DBAccess.ReadIntValue(reader["ADM_CURRENCY_POSITION"]);
                m_curr_digits = DBAccess.ReadIntValue(reader["ADM_CURRENCY_DIGITS"]);
                m_curr_sym = DBAccess.ReadStringValue(reader["ADM_CURRENCY_SYMBOL"]);
            }
            reader.Close();
            reader = null;
        }
        private void ReadStages(SqlConnection oDataAccess)
        {
            SqlCommand oCommand = null;
            SqlDataReader reader = null;

            string sCommand = "";
            int i = 0;
            m_stages = new Dictionary<int, string>();

            sCommand = "SELECT  STAGE_ID, STAGE_NAME From EPGP_STAGES";
            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read())
            {

                i = DBAccess.ReadIntValue(reader["STAGE_ID"]);
                sCommand = DBAccess.ReadStringValue(reader["STAGE_NAME"]);
                m_stages.Add(i, sCommand);
            }
            reader.Close();
            reader = null;
        }
        private void ReadExtraPifields(SqlConnection oDataAccess)
        {

            SqlCommand oCommand = null;
            SqlDataReader reader = null;

            string sCommand = "";
            int i = 0;
            int ftabextra = 0;
            int fintabextra = 0;


            //            sCommand = "Select rd.*,FIELD_FORMAT,FA_TABLE_ID,FA_FIELD_IN_TABLE,at.FA_FORMAT, fl.FIELD_NAME_SQL, at.FA_NAME, fl.FIELD_NAME AS Expr1" +
            //                       " From EPGP_RD_FIELDS rd  Left Join EPGT_FIELDS fl On fl.FIELD_ID=rd.FIELD_ID  Left Join EPGC_FIELD_ATTRIBS at On at.FA_FIELD_ID=rd.FIELD_ID Where CONTEXT_ID = 101";

            sCommand =
                "Select t.* From EPGT_FIELDS t Left Join  EPGP_RD_FIELDS r On t.FIELD_ID=r.FIELD_ID And CONTEXT_ID=101 " +
                " Where t.FIELD_ID IN (9901,9902,9904,9911,9928,9950,9922,9925,9930)";

            // need to read these and munge them into the arrays that were used before
            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read() && i <= MAX_PI_EXTRA)
            {

                int fldtype = DBAccess.ReadIntValue(reader["FIELD_FORMAT"]);


                if (OptimizeThisType(fldtype))
                {
                    ++i;

                    m_fidextra[i] = DBAccess.ReadIntValue(reader["FIELD_ID"]);

                    m_ExtraFieldNames[i] = "";

                    if (m_ExtraFieldNames[i] == "")
                        m_ExtraFieldNames[i] = DBAccess.ReadStringValue(reader["FIELD_NAME"]);

                    m_ExtraFieldNames[i] = m_ExtraFieldNames[i].Replace("%", "Percent");

                    if (m_fidextra[i] == 9911)
                        m_ExtraFieldTypes[i] = 9911;
                            //   ' change Stage from an integer (2) to a special text field (9911)
                    else if (m_ExtraFieldTypes[i] == 0)
                        m_ExtraFieldTypes[i] = DBAccess.ReadIntValue(reader["FIELD_FORMAT"]);


                    m_sextra[i] = DBAccess.ReadStringValue(reader["FIELD_NAME_SQL"]);

                }

            }
            reader.Close();
            reader = null;

            sCommand = "SELECT     rd.CONTEXT_ID, at.FA_FIELD_ID, rd.FIELD_NAME, rd.FIELD_SELECT, fl.FIELD_FORMAT, at.FA_TABLE_ID, at.FA_FIELD_IN_TABLE, at.FA_FORMAT, fl.FIELD_NAME_SQL,  " +
                "  at.FA_NAME, fl.FIELD_NAME AS Expr1 FROM  EPGC_FIELD_ATTRIBS AS at LEFT OUTER JOIN EPGP_RD_FIELDS AS rd ON rd.FIELD_ID = at.FA_FIELD_ID AND rd.CONTEXT_ID = 101 LEFT OUTER JOIN " +
                " EPGT_FIELDS AS fl ON fl.FIELD_ID = rd.FIELD_ID WHERE     (at.FA_TABLE_ID = 201) AND (at.FA_FORMAT = 4 OR at.FA_FORMAT = 13 OR at.FA_FORMAT = 7) OR " +
                " (at.FA_TABLE_ID = 202) OR (at.FA_TABLE_ID = 203) OR (at.FA_TABLE_ID = 205)";

            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();

            while (reader.Read() && i <= MAX_PI_EXTRA)
            {
                ++i;

                m_fidextra[i] = DBAccess.ReadIntValue(reader["FA_FIELD_ID"]);

                m_ExtraFieldNames[i] = "";

                if (m_ExtraFieldNames[i] == "")
                    m_ExtraFieldNames[i] = DBAccess.ReadStringValue(reader["FA_NAME"]);

                if (m_ExtraFieldNames[i] == "")
                    m_ExtraFieldNames[i] = DBAccess.ReadStringValue(reader["Expr1"]);


                m_ExtraFieldNames[i] = m_ExtraFieldNames[i].Replace("%", "Percent");

                m_ExtraFieldTypes[i] = DBAccess.ReadIntValue(reader["FIELD_FORMAT"]);

                if (m_fidextra[i] == 9911)
                    m_ExtraFieldTypes[i] = 9911;     //   ' change Stage from an integer (2) to a special text field (9911)
                else if (m_ExtraFieldTypes[i] == 0)
                    m_ExtraFieldTypes[i] = DBAccess.ReadIntValue(reader["FA_FORMAT"]);


                m_sextra[i] = DBAccess.ReadStringValue(reader["FIELD_NAME_SQL"]);

                if (m_sextra[i] == "")
                {
                    ftabextra = DBAccess.ReadIntValue(reader["FA_TABLE_ID"]);
                    fintabextra = DBAccess.ReadIntValue(reader["FA_FIELD_IN_TABLE"]);

                    string stab = "";
                    string sfnam = "";

                    GetCFFieldName(ftabextra, fintabextra, out stab, out sfnam);
                    m_sextra[i] = sfnam;
                }

            }
            reader.Close();
            reader = null;

            m_Use_extra = i;
        }
        private void ReadPILevelData(SqlConnection oDataAccess, string sPIList)
        {
            SqlCommand oCommand = null;
            SqlDataReader reader = null;
            Lookup oItem = null;


            string sCommand = "";

            m_PIs = new List<PIData>();


            sCommand = "SELECT  EPGP_PROJECTS.PROJECT_ID,  EPGP_PROJECTS.PROJECT_START_DATE,  EPGP_PROJECTS.PROJECT_FINISH_DATE,  EPGP_PROJECTS.PROJECT_NAME ";

            if (m_SelFID == 0)
                sCommand = sCommand + ",1 AS XYZZY ";
            else
                sCommand = sCommand + "," + m_Select_FieldName + " AS XYZZY ";


            for (int i = 1; i <= m_Use_extra; i++)
                sCommand = sCommand + "," + m_sextra[i];

            string sCodes = "";
            string sRes = "";


            sCommand = sCommand + " From EPGP_PROJECTS "
                        + " left join EPGP_PROJECT_INT_VALUES on EPGP_PROJECTS.PROJECT_ID=EPGP_PROJECT_INT_VALUES.PROJECT_ID"
                        + " left join EPGP_PROJECT_TEXT_VALUES on EPGP_PROJECTS.PROJECT_ID=EPGP_PROJECT_TEXT_VALUES.PROJECT_ID"
                        + " left join EPGP_PROJECT_NTEXT_VALUES on EPGP_PROJECTS.PROJECT_ID=EPGP_PROJECT_NTEXT_VALUES.PROJECT_ID"
                        + " left join EPGP_PROJECT_DEC_VALUES on EPGP_PROJECTS.PROJECT_ID=EPGP_PROJECT_DEC_VALUES.PROJECT_ID"
                        + " left join EPGP_PROJECT_DATE_VALUES on EPGP_PROJECTS.PROJECT_ID=EPGP_PROJECT_DATE_VALUES.PROJECT_ID"
                        + " Where  EPGP_PROJECTS.PROJECT_ID in (" + sPIList + ")";


            oCommand = new SqlCommand(sCommand, oDataAccess);
            reader = oCommand.ExecuteReader();
            PIData oPI;



            while (reader.Read())
            {
                oPI = new PIData(MAX_PI_EXTRA);
                oPI.PI_ID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                oPI.PI_Name = DBAccess.ReadStringValue(reader["PROJECT_NAME"]);
                oPI.StartDate = DBAccess.ReadDateValue(reader["PROJECT_START_DATE"]);
                oPI.FinishDate = DBAccess.ReadDateValue(reader["PROJECT_FINISH_DATE"]);




                oPI.PISelected = DBAccess.ReadIntValue(reader["XYZZY"]);

                if (oPI.PISelected != 0)
                    oPI.PISelected = 1;

                object obj = null;

                for (int i = 1; i <= m_Use_extra; i++)
                {
                    obj = reader[4 + i];

                    if (m_fidextra[i] == 9911)
                    {
                        int xi = 0;
                        if (!obj.Equals(System.DBNull.Value))
                            xi = Convert.ToInt32(obj);
                        else
                            xi = 0;

                        string stageval;

                        if (m_stages.TryGetValue(xi, out stageval))
                            oPI.m_PI_Extra_data[i] = stageval;
                        else
                            oPI.m_PI_Extra_data[i] = "";
                    }
                    else
                        oPI.m_PI_Extra_data[i] = MyFormat(obj, m_ExtraFieldTypes[i], ref sCodes, ref sRes);
                }
                m_PIs.Add(oPI);
            }
            reader.Close();
            reader = null;

            sCodes = sCodes.Replace(" ", "");
            sRes = sRes.Replace(" ", "");

            m_codes = new Dictionary<int, Lookup>();
            m_reses = new Dictionary<int, string>();

            // ' Now read Code and resource values....

            if (sCodes != "")
            {

                sCommand = "SELECT LV_UID, LV_VALUE, LV_FULLVALUE From EPGP_LOOKUP_VALUES WHERE LV_UID IN (" + sCodes + ")";

                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    oItem = new Lookup();

                    oItem.UID = DBAccess.ReadIntValue(reader["LV_UID"]);
                    oItem.Name = DBAccess.ReadStringValue(reader["LV_VALUE"]);
                    oItem.Desc = DBAccess.ReadStringValue(reader["LV_FULLVALUE"]);
                    m_codes.Add(oItem.UID, oItem);

                }
                reader.Close();
                reader = null;
            }

            if (sRes != "")
            {

                sCommand = "SELECT WRES_ID, RES_NAME FROM  EPG_RESOURCES WHERE WRES_ID IN (" + sRes + ")";

                oCommand = new SqlCommand(sCommand, oDataAccess);
                reader = oCommand.ExecuteReader();
                int resid;
                string resname;
                while (reader.Read())
                {
                    resid = DBAccess.ReadIntValue(reader["WRES_ID"]);
                    resname = DBAccess.ReadStringValue(reader["RES_NAME"]);
                    m_reses.Add(resid, resname);

                }
                reader.Close();
                reader = null;
            }
        }

        private void GetCFFieldName(int lTableID, int lFieldID, out string sTable, out string sField)
        {
            switch ((CustomFieldDBTable)lTableID)
            {
                case CustomFieldDBTable.ResourceINT:
                    sTable = "EPGC_RESOURCE_INT_VALUES";
                    sField = "RI_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ResourceTEXT:
                    sTable = "EPGC_RESOURCE_TEXT_VALUES";
                    sField = "RT_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ResourceDEC:
                    sTable = "EPGC_RESOURCE_DEC_VALUES";
                    sField = "RC_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ResourceNTEXT:
                    sTable = "EPGC_RESOURCE_NTEXT_VALUES";
                    sField = "RN_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ResourceDATE:
                    sTable = "EPGC_RESOURCE_DATE_VALUES";
                    sField = "RD_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ResourceMV:
                    sTable = "EPGC_RESOURCE_MV_VALUES";
                    sField = "MVR_UID";
                    break;
                case CustomFieldDBTable.PortfolioINT:
                    sTable = "EPGP_PROJECT_INT_VALUES";
                    sField = "PI_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.PortfolioTEXT:
                    sTable = "EPGP_PROJECT_TEXT_VALUES";
                    sField = "PT_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.PortfolioDEC:
                    sTable = "EPGP_PROJECT_DEC_VALUES";
                    sField = "PC_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.PortfolioNTEXT:
                    sTable = "EPGP_PROJECT_NTEXT_VALUES";
                    sField = "PN_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.PortfolioDATE:
                    sTable = "EPGP_PROJECT_DATE_VALUES";
                    sField = "PD_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.Program:
                    sTable = "EPGP_PI_PROGS";
                    sField = "PROG_UID";
                    break;
                case CustomFieldDBTable.ProjectINT:
                    sTable = "EPGX_PROJ_INT_VALUES";
                    sField = "XI_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ProjectTEXT:
                    sTable = "EPGX_PROJ_TEXT_VALUES";
                    sField = "XT_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ProjectDEC:
                    sTable = "EPGX_PROJ_DEC_VALUES";
                    sField = "XC_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ProjectNTEXT:
                    sTable = "EPGX_PROJ_NTEXT_VALUES";
                    sField = "XN_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ProjectDATE:
                    sTable = "EPGX_PROJ_DATE_VALUES";
                    sField = "XD_" + lFieldID.ToString("000");
                    break;
                case CustomFieldDBTable.ProgramText:
                    sTable = "EPGP_PI_PROGS";
                    sField = "PROG_PI_TEXT" + lFieldID.ToString("0");
                    break;
                case CustomFieldDBTable.TaskWIINT:
                    sTable = "EPGP_PI_WORKITEMS";
                    sField = "WORKITEM_FLAG" + lFieldID.ToString("0");
                    break;
                case CustomFieldDBTable.TaskWITEXT:
                    sTable = "EPGP_PI_WORKITEMS";
                    sField = "WORKITEM_CTEXT" + lFieldID.ToString("0");
                    break;
                case CustomFieldDBTable.TaskWIDEC:
                    sTable = "EPGP_PI_WORKITEMS";
                    sField = "WORKITEM_NUMBER" + lFieldID.ToString("0");
                    break;
                default:
                    sTable = "Unknown Table";
                    sField = "";
                    break;
            }

        }
        private string MyFormat(object obj, int lt, ref string sCodes, ref string sRes)
        {



            switch (lt)
            {
                case EPK_FTYPE_DATE:
                    DateTime dt;

                    dt = DBAccess.ReadDateValue(obj);

                    if (dt == DateTime.MinValue)
                        return "";

                    string rs = dt.ToString("MM/dd/yyyy");
                    return rs;


                case EPK_FTYPE_INTEGER:
                case EPK_FTYPE_NUMBER:
                case EPK_FTYPE_CURRENCY:
                case EPK_FTYPE_PERCENT:
                case EPK_FTYPE_YESNO:
                case EPK_FTYPE_WORK:
                case EPK_FTYPE_DURATION:

                    long i;

                    i = (long)DBAccess.ReadDecimalValue(obj);
                    return i.ToString();

                case EPK_FTYPE_URL:
                case EPK_FTYPE_TEXT:
                case EPK_FTYPE_RTF:
                    return DBAccess.ReadStringValue(obj);

                case EPK_FTYPE_CODE:
                    int c;

                    c = DBAccess.ReadIntValue(obj);

                    if (sCodes.IndexOf(" " + c.ToString() + " ") == -1)
                    {
                        if (sCodes == "")
                            sCodes = " " + c.ToString() + " ";
                        else
                            sCodes = sCodes + ", " + c.ToString() + " ";
                    }

                    return c.ToString();

                case EPK_FTYPE_RES:
                    int r;

                    r = DBAccess.ReadIntValue(obj);

                    if (sRes.IndexOf(" " + r.ToString() + " ") == -1)
                    {
                        if (sRes == "")
                            sRes = " " + r.ToString() + " ";
                        else
                            sRes = sRes + ", " + r.ToString() + " ";
                    }

                    return r.ToString();
            }
            return "";
        }

        private string FormatExportExtraData(string sIn, int lt)
        {
            switch (lt)
            {


                case EPK_FTYPE_YESNO:
                    if (sIn == "1")
                        return "Yes";
                    else
                         return "No";
  

                case EPK_FTYPE_DATE:
                case EPK_FTYPE_INTEGER:
                case EPK_FTYPE_NUMBER:
                case EPK_FTYPE_CURRENCY:
                case EPK_FTYPE_PERCENT:
                case EPK_FTYPE_WORK:
                case EPK_FTYPE_DURATION:
                case EPK_FTYPE_URL:
                case EPK_FTYPE_TEXT:
                case EPK_FTYPE_RTF:
                    return sIn;

                case EPK_FTYPE_CODE:
                    int c;
                    Lookup sCode;

                    try
                    {
                        c = int.Parse(sIn);

                        if (m_codes.TryGetValue(c, out sCode))
                            return sCode.Name;

                    }
                    catch (Exception ex)
                    {
                        
                    }

                    return "";

                case EPK_FTYPE_RES:
                    int r;
                    string sRes;

                    try
                    {
                        r = int.Parse(sIn);

                        if (m_reses.TryGetValue(r, out sRes))
                            return sRes;

                    }
                    catch (Exception ex)
                    {
                        
                    }

                    return "";

            }
            return "";
        }

        private bool OptimizeThisType(int fldtype)
        {

            switch (fldtype)
            {
                case EPK_FTYPE_DATE:
                    return false;

                case EPK_FTYPE_INTEGER:
                case EPK_FTYPE_NUMBER:
                case EPK_FTYPE_CURRENCY:
                case EPK_FTYPE_PERCENT:
                case EPK_FTYPE_YESNO:
                case EPK_FTYPE_WORK:
                case EPK_FTYPE_DURATION:
                case EPK_FTYPE_URL:
                case EPK_FTYPE_TEXT:
                case EPK_FTYPE_RTF:
                case EPK_FTYPE_CODE:
                    return true;

                case EPK_FTYPE_RES:
                    return false;


            }
            return false;
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

 


        private string FormatSQLDateTime(DateTime dt)
        {
            return "CONVERT(DATETIME, '" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "', 102)";
        }
    }



}

