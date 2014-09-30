using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;


namespace PortfolioEngineCore
{
    public class CapacityScenarios : PFEBase
    {

        #region Fields (1)

        private readonly SqlConnection _sqlConnection;

        #endregion Fields
        
        public CapacityScenarios(string basepath, string username, string pid, string company, string dbcnstring, SecurityLevels secLevel, bool bDebug = false)
            : base(basepath, username, pid, company, dbcnstring, secLevel, bDebug)
        {
            debug.AddMessage("Loading CapacityScenarios Class");
            _sqlConnection = _PFECN;
            _userWResID = Utilities.ResolveNTNameintoWResID(_sqlConnection, username);
        }

        public CapacityScenarios(string sBaseInfo)
            : base(sBaseInfo)
        {
            debug.AddMessage("Loading CapacityScenarios Class");
            _sqlConnection = _PFECN;
        }

        public bool RoleBasedCSAllowed()
        {
            bool bReply = false;
            try
            {

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();


                string cmdText = "SELECT CS_ROLE_BASED FROM  EPGP_CAPACITY_SETS ORDER BY CS_NAME";

                SqlCommand oCommand = new SqlCommand(cmdText, _sqlConnection);
                SqlDataReader reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    bReply = true;
                }
                reader.Close();

            }

            catch (Exception ex)
            {

            }
            return bReply;


        }

        public bool GetCapacityScenariosXML(out string sReply, bool CSRoleAllowed, string DeptUIDs)
        {
           sReply = "";
           try
           {
 
               if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
               _sqlConnection.Open();

               CStruct xCSA = new CStruct();
               CStruct xNode;
               xCSA.Initialize("CapacityScenarios");

               string cmdText = "SELECT ADM_PORT_COMMITMENTS_CB_ID  FROM EPG_ADMIN";

               SqlCommand oCommand = new SqlCommand(cmdText, _sqlConnection);
               SqlDataReader reader = oCommand.ExecuteReader();
               int CalID = -1;
               bool bIsNull = false;

               while (reader.Read())
               {
                   CalID = DBAccess.ReadIntValue(reader["ADM_PORT_COMMITMENTS_CB_ID"], out bIsNull);

                   if (bIsNull)
                       CalID = -1;
               }
               reader.Close();

               xCSA.CreateIntAttr("CB_ID", CalID);

               bool bPrivate = PrivateAllowed();

               cmdText = "SELECT CS_ID, CS_NAME, DEPT_UID";


               if (CSRoleAllowed)
                   cmdText += ", CS_ROLE_BASED ";
               else
                   cmdText += ", 0 AS CS_ROLE_BASED ";

               if (bPrivate)
                   cmdText += ", WRES_ID ";
               else
                   cmdText += ", 0 AS WRES_ID ";

               cmdText += " FROM  EPGP_CAPACITY_SETS  WHERE (DEPT_UID IS NULL OR DEPT_UID IN (" + DeptUIDs + ") )";

               if (bPrivate)
               {
                   cmdText += " AND (WRES_ID = 0 OR WRES_ID IS NULL OR WRES_ID = " + _userWResID.ToString() + ")";
               }
               
               cmdText += " ORDER BY CS_NAME";

               oCommand = new SqlCommand(cmdText, _sqlConnection);
               reader = oCommand.ExecuteReader();

               while (reader.Read())
               {
                   xNode = xCSA.CreateSubStruct("CapacityScenario");

                   int cs_id = DBAccess.ReadIntValue(reader["CS_ID"]);
                   string cs_name = DBAccess.ReadStringValue(reader["CS_NAME"]);
                   int role_mode = DBAccess.ReadIntValue(reader["CS_ROLE_BASED"]);
                   xNode.CreateIntAttr("ID", cs_id);
                   xNode.CreateStringAttr("Name", cs_name);
                   xNode.CreateIntAttr("RMODE", role_mode);
                   xNode.CreateIntAttr("DEPT", DBAccess.ReadIntValue(reader["DEPT_UID"]));

                   if (bPrivate)
                       xNode.CreateIntAttr("WRES", DBAccess.ReadIntValue(reader["WRES_ID"]));
                   else
                       xNode.CreateIntAttr("WRES", 0);
               }
               reader.Close();



               sReply = xCSA.XML();
               return true;
           }

           catch (Exception ex)
           {
              
           }
           return false;


      }

      public bool DeleteCapacityScenario(int iCapacityID)
      {

          try
          {
              if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
              _sqlConnection.Open();

              string cmdText = "DELETE FROM EPGP_CAPACITY_SETVALUES WHERE CS_ID = " + iCapacityID.ToString();
              SqlCommand oCommand = new SqlCommand(cmdText, _sqlConnection);
              oCommand.ExecuteNonQuery();

              cmdText = "DELETE FROM EPGP_CAPACITY_SETS WHERE CS_ID = " + iCapacityID.ToString();
              oCommand = new SqlCommand(cmdText, _sqlConnection);
              oCommand.ExecuteNonQuery();
              return true;
          }

          catch (Exception ex)
          {
              
          }
          return false;

      }

      public int AddCapacityScenarioXML(string sScenarioName, bool bPriv, int deptID, int rmode)
      {

          if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
          _sqlConnection.Open();

          int maxid = 0;

          string cmdText = "SELECT MAX(CS_ID) AS MAXID FROM EPGP_CAPACITY_SETS";
          SqlCommand oCommand = new SqlCommand(cmdText, _sqlConnection);
          SqlDataReader reader = oCommand.ExecuteReader();

         while (reader.Read())
         {
            maxid = DBAccess.ReadIntValue(reader["MAXID"]);
         }
         reader.Close();

         ++maxid;

         bool bPrivate = PrivateAllowed();

         bool bCSRole = RoleBasedCSAllowed();


         if (bPrivate && bCSRole) 
              cmdText = "INSERT INTO EPGP_CAPACITY_SETS (CS_ID,  DEPT_UID, CS_NAME, WRES_ID, CS_ROLE_BASED) VALUES(" + maxid.ToString() + ", " + deptID.ToString() + " ," + DBAccess.PrepareText(sScenarioName) + "," + (bPriv ? _userWResID.ToString() : "0") + "," + rmode.ToString() + ")";
         else if (bPrivate && bCSRole == false)
              cmdText = "INSERT INTO EPGP_CAPACITY_SETS (CS_ID,  DEPT_UID, CS_NAME, WRES_ID) VALUES(" + maxid.ToString() + ", " + deptID.ToString() + " ," + DBAccess.PrepareText(sScenarioName) + "," + (bPriv ? _userWResID.ToString() : "0") + ")";
         else if (bCSRole)
             cmdText = "INSERT INTO EPGP_CAPACITY_SETS (CS_ID,  DEPT_UID, CS_NAME, CS_ROLE_BASED) VALUES(" + maxid.ToString() + ", " + deptID.ToString() + " ," + DBAccess.PrepareText(sScenarioName) + "," + rmode.ToString() + " )";
         else
              cmdText = "INSERT INTO EPGP_CAPACITY_SETS (CS_ID,  DEPT_UID, CS_NAME) VALUES(" + maxid.ToString() + ", " + deptID.ToString() + " ," + DBAccess.PrepareText(sScenarioName) + " )";
oCommand = new SqlCommand(cmdText, _sqlConnection);
           reader = oCommand.ExecuteReader();

           return maxid;
    
     }


      public bool GetCapacityScenarioValuesXML(int iCapacityID, out string sReply, out int statusvalue)
      {
          if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
          _sqlConnection.Open(); 
          
          sReply = "";
          statusvalue = 0;

          CStruct xCSA = new CStruct();
          xCSA.Initialize("CapacityScenarioValues");

          CStruct xError;
          CStruct xCSValues;
          CStruct xNode;
          xError = xCSA.CreateSubStruct("Error");

          if (iCapacityID < -1)
          {
              xError.CreateIntAttr("Value", 100);
              xError.CreateStringAttr("Desc", "Requested Capacity Scenario ID was less than -1");

          //    _dba.Status = StatusEnum.rsRequestInvalidParameter;
              statusvalue = (int) StatusEnum.rsPIResourceCalendarNotSet;
              sReply = xCSA.XML();
              return false;
          }


          string cmdText = "SELECT ADM_PORT_COMMITMENTS_CB_ID  FROM EPG_ADMIN";

          SqlCommand oCommand = new SqlCommand(cmdText, _sqlConnection);
          SqlDataReader reader = oCommand.ExecuteReader();
          int CalID = 0;
          bool bIsNull = false;

          while (reader.Read())
          {
              CalID = DBAccess.ReadIntValue(reader["ADM_PORT_COMMITMENTS_CB_ID"],out bIsNull);

              if (bIsNull)
                  CalID = -1;
          }
          reader.Close();


          if (CalID < 0)
          {
              xError.CreateIntAttr("Value", 101);
              xError.CreateStringAttr("Desc", "Planning Calendar has not been set.  Please contact your Administrator");
         //     _dba.Status = StatusEnum.rsPIResourceCalendarNotSet;
              statusvalue = (int)StatusEnum.rsPIResourceCalendarNotSet;
              sReply = xCSA.XML();
              return false;
          }


          cmdText = "SELECT CB_NAME FROM EPGP_COST_BREAKDOWNS WHERE CB_ID = " + CalID.ToString();


          oCommand = new SqlCommand(cmdText, _sqlConnection);
          reader = oCommand.ExecuteReader();

          string cal_name = "Timesheet Periods";

          while (reader.Read())
          {
              cal_name = DBAccess.ReadStringValue(reader["CB_NAME"]);

          }
          reader.Close();

          xCSValues = xCSA.CreateSubStruct("CS_Values");
          cmdText = "SELECT * from EPGP_CAPACITY_SETVALUES  WHERE CS_ID = " + iCapacityID.ToString() + " AND CB_ID = " +  CalID.ToString() + " ORDER BY ROLE_ID, BD_PERIOD";

          oCommand = new SqlCommand(cmdText, _sqlConnection);
          reader = oCommand.ExecuteReader();

          while (reader.Read())
          {
              int role_id = DBAccess.ReadIntValue(reader["ROLE_ID"]);
              int per_id = DBAccess.ReadIntValue(reader["BD_PERIOD"]);
              double dhours = DBAccess.ReadDoubleValue(reader["CS_AVAIL"]);
              double dftes = DBAccess.ReadDoubleValue(reader["CS_FTES"]);

              xNode = xCSValues.CreateSubStruct("CS_Value");
              xNode.CreateIntAttr("Per_ID", per_id);
              xNode.CreateIntAttr("Role_ID", role_id);
              xNode.CreateDoubleAttr("Hours", dhours);
              xNode.CreateDoubleAttr("FTEs", dftes);
                  
          }
          reader.Close();

          CStruct xCalendar;
          CStruct xPeriods;
          CStruct xPeriod;
          xCalendar = xCSA.CreateSubStruct("Calendar");

          xCalendar.CreateIntAttr("CalID", CalID);
          xCalendar.CreateStringAttr("CalName", cal_name);

     
          // Read in the PI Commitments calendar periods
          List<CPeriod> clnPeriods;
          if (DBCommon.GetPeriods(_dba, CalID, out clnPeriods) != StatusEnum.rsSuccess)
          {
              xError.CreateIntAttr("Value", 102);
              xError.CreateStringAttr("Desc", "Failed to load periods");
       //       statusvalue = (int)_dba.Status;
              sReply = xCSA.XML();
              return false;
          }
             

          xPeriods = xCalendar.CreateSubStruct("Periods");

          foreach (CPeriod oPeriod2 in clnPeriods)
          {
              xPeriod = xPeriods.CreateSubStruct("Period");
              xPeriod.CreateIntAttr("ID", oPeriod2.PeriodID);
              xPeriod.CreateStringAttr("Name", oPeriod2.PeriodName);
              xPeriod.CreateDateAttr("Start", oPeriod2.StartDate);
              xPeriod.CreateDateAttr("Finish", oPeriod2.FinishDate);
          }


          CStruct xCostCategoryRoles;

          if (DBCommon.GetCostCategoryRolesStruct(_dba, CalID, 1, out xCostCategoryRoles, false) != StatusEnum.rsSuccess)
          {
              xError.CreateIntAttr("Value", 103);
              xError.CreateStringAttr("Desc", "Failed to Cost Category Roles etc.");
     //         statusvalue = (int)_dba.Status;
              sReply = xCSA.XML();
 
              return false;
          }

          xCSA.AppendSubStruct(xCostCategoryRoles);

          sReply = xCSA.XML();

          return true; // (_dba.Status == StatusEnum.rsSuccess);
      }


      public bool SaveCapacityScenario(int iCapacityID, string sXLMDataIn)
      {

          if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
          _sqlConnection.Open(); 
          
          if (iCapacityID <= 0)
          {

           //   _dba.Status = StatusEnum.rsRequestInvalidParameter;
              return false;
          }


          CStruct xDataIn = new CStruct();
          if (xDataIn.LoadXML(sXLMDataIn) == false)
          {

         //     _dba.Status = StatusEnum.rsRequestInvalidParameter;
              return false;
          }


          string cmdText = "SELECT ADM_PORT_COMMITMENTS_CB_ID  FROM EPG_ADMIN";

          SqlCommand oCommand = new SqlCommand(cmdText, _sqlConnection);
          SqlDataReader reader = oCommand.ExecuteReader();
          int CalID = 0;
          bool bIsNull = false;

          while (reader.Read())
          {
              CalID = DBAccess.ReadIntValue(reader["ADM_PORT_COMMITMENTS_CB_ID"], out bIsNull);

              if (bIsNull)
                  CalID = -1;
          }
          reader.Close();


          if (CalID < 0)
          {
       //       _dba.Status = StatusEnum.rsPIResourceCalendarNotSet;
              return false;
          }

  //        SqlTransaction transaction = _sqlConnection.BeginTransaction();
 


          cmdText = "DELETE FROM EPGP_CAPACITY_SETVALUES WHERE CS_ID = " + iCapacityID.ToString();
          oCommand = new SqlCommand(cmdText, _sqlConnection);
//          oCommand.Transaction = transaction;
          oCommand.ExecuteNonQuery();

          List<CStruct> clnCSData = xDataIn.GetList("CS_Value");

          if (clnCSData != null)
          {
              cmdText = "INSERT INTO EPGP_CAPACITY_SETVALUES (CS_ID, CB_ID, DEPT_UID, BD_PERIOD, ROLE_ID, CS_AVAIL, CS_FTES) " +
                                   " VALUES(" + iCapacityID.ToString() + "," + CalID.ToString() + ",0,@prd,@roleid,@hrs,@ftes)";
              oCommand = new SqlCommand(cmdText, _sqlConnection);
  //            oCommand.Transaction = transaction;

              SqlParameter pPRD_ID = oCommand.Parameters.Add("@prd", SqlDbType.Int);
              SqlParameter pROLE_ID = oCommand.Parameters.Add("@roleid", SqlDbType.Int);
              SqlParameter pCMH_HOURS = oCommand.Parameters.Add("@hrs", SqlDbType.Decimal);
              SqlParameter pCMH_FTES = oCommand.Parameters.Add("@ftes", SqlDbType.Decimal);
              

              foreach (CStruct xI in clnCSData)
              {

                  pPRD_ID.Value = xI.GetIntAttr("Per_ID");
                  pROLE_ID.Value = xI.GetIntAttr("Role_ID");

                  pCMH_HOURS.Value = xI.GetDoubleAttr("Hours", 0);
                  pCMH_FTES.Value = (int) xI.GetDoubleAttr("FTEs", 0);
                  int lRowsAffected = oCommand.ExecuteNonQuery();
              }
          }


          return true; // (_dba.Status == StatusEnum.rsSuccess);

      }



      public bool SaveCapacityScenarioData(string sCSDataXML, out string sReply, out int statusvalue)
      {
          if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
          _sqlConnection.Open();

          sReply = "";
          statusvalue = 0;


          CStruct xSaveData = new CStruct();

          xSaveData.LoadXML(sCSDataXML);

          string sCapName = xSaveData.GetStringAttr("Name");
          int iCapacityID = xSaveData.GetIntAttr("ID");
          int wRes = xSaveData.GetIntAttr("WRES");
          int DeptID = xSaveData.GetIntAttr("DEPT");
          int rmode = xSaveData.GetIntAttr("RMODE");


          if (iCapacityID == -1)
          {

              iCapacityID = AddCapacityScenarioXML(sCapName, wRes != 0, DeptID, rmode);
          }

          CStruct CSValues = xSaveData.GetSubStruct("CS_Values");


          CStruct xCSA = new CStruct();
          xCSA.Initialize("CSID");
          xCSA.CreateIntAttr("Value", iCapacityID);
          sReply = xCSA.XML();

          if (SaveCapacityScenario(iCapacityID, CSValues.XML()) == false)
          {
              return false;

          }






          return true;

      }




      public bool SaveCurrentScenarioData(string sSaveToName, string sCSDataXML)
      {
          if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
          _sqlConnection.Open();

          int curid = 0;
          string sname;
          int iID;

          string cmdText = "SELECT CS_ID FROM EPGP_CAPACITY_SETS WHERE CS_NAME = " + DBAccess.PrepareText(sSaveToName);
          SqlCommand oCommand = new SqlCommand(cmdText, _sqlConnection);
          SqlDataReader reader = oCommand.ExecuteReader();

          CStruct xSaveData = new CStruct();

          xSaveData.LoadXML(sCSDataXML);

          int wRes = xSaveData.GetIntAttr("WRES");
          int DeptID = xSaveData.GetIntAttr("DEPT");
          int rmode = xSaveData.GetIntAttr("RMODE");

          while (reader.Read())
          {
               curid = DBAccess.ReadIntValue(reader["CS_ID"]);
          }
          reader.Close();

          if (curid == 0)
          {
              curid = AddCapacityScenarioXML(sSaveToName, wRes != 0, DeptID, rmode);
          }

          SaveCapacityScenario(curid, sCSDataXML);


          return true;

      }

      public string GetListTicket(string sList, bool bIsPIList)
      {
          if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
          _sqlConnection.Open();

          string sExt = "";
          string cmdText = "";
          SqlCommand oCommand;

          try
          {
              if (bIsPIList == true)
              {


                  cmdText = "SELECT  PROJECT_EXT_UID FROM  EPGP_PROJECTS WHERE (PROJECT_ID IN (" + sList + "))";

                  oCommand = new SqlCommand(cmdText, _sqlConnection);
                  SqlDataReader reader = oCommand.ExecuteReader();

                  while (reader.Read())
                  {
                      if (sExt != "")
                          sExt += ",";

                      sExt += DBAccess.ReadStringValue(reader["PROJECT_EXT_UID"]);
                  }
                  reader.Close();
              }
              else
                  sExt = sList;

              if (sExt != "")
              {

                  Guid newticket = Guid.NewGuid();


                  cmdText = "INSERT INTO EPG_DATA_CACHE ( DC_TICKET, DC_TIMESTAMP, DC_DATA) " +
                                        " VALUES(@pticket,@ptimest,@pdta)";
                  oCommand = new SqlCommand(cmdText, _sqlConnection);

                  SqlParameter pTicketID = oCommand.Parameters.Add("@pticket", SqlDbType.UniqueIdentifier);
                  SqlParameter pTimestampID = oCommand.Parameters.Add("@ptimest", SqlDbType.DateTime);
                  SqlParameter pDataID = oCommand.Parameters.Add("@pdta", SqlDbType.NText);


                  pTicketID.Value = newticket;
                  pTimestampID.Value = DateTime.Now;
                  pDataID.Value = sExt;

                  int lRowsAffected = oCommand.ExecuteNonQuery();



                  return newticket.ToString();
              }
             

              return "";

          }

          catch (Exception ex)
          {


              return "";
          }


      }


      private bool PrivateAllowed()
      {
          bool bReply = false;
          try
          {
              string cmdText = "SELECT WRES_ID FROM  EPGP_CAPACITY_SETS";

              SqlCommand oCommand = new SqlCommand(cmdText, _sqlConnection);
              SqlDataReader reader = oCommand.ExecuteReader();

              while (reader.Read())
              {
                  bReply = true;
              }
              reader.Close();

          }

          catch (Exception ex)
          {

          }
          return bReply;


      }




    }
}
