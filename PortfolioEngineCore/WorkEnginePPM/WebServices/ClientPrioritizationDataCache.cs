using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PortfolioEngineCore;


namespace ClientPrioritizationDataCache
{
    [Serializable()]
    public class PriItemDefn
    {
        public int fid, seq, uid;
        public string Name;
    }
    [Serializable()]
    public class PriWeight
    {
        public int rowfid, colfid;
        public double ratio;
    }
    [Serializable()]
    public class PriRowData
    {
        public List<Double> rowdata;
    }
    [Serializable()]
    public class PriGridData
    {
        public int NumCols;
        public List<PriRowData> griddata;
    }

    [Serializable()]
    public class ClientPrioritizationData
    {

        public List<PriItemDefn> m_oRows = null;
        public List<PriItemDefn> m_oCols = null;
        public Dictionary<string, PriWeight> m_oWeights = null;
 
        public void GrabPrioritizationData(SqlConnection conn)
        {
            int lfid = 0;
            int luid = 0;
            string sname = "";
            int lseq;
            double dweight;

            PriItemDefn pItem = null;
            PriWeight wItem = null;

            m_oRows = new List<PriItemDefn>();
            m_oCols = new List<PriItemDefn>();
            m_oWeights = new Dictionary<string, PriWeight>();

            string sCommand = "SELECT DISTINCT EPGP_CALCS.CL_RESULT, EPGP_CALCS.CL_UID, EPGC_FIELD_ATTRIBS.FA_NAME FROM EPGP_CALCS INNER JOIN EPGC_FIELD_ATTRIBS " +
                                " ON EPGP_CALCS.CL_RESULT = EPGC_FIELD_ATTRIBS.FA_FIELD_ID WHERE  (EPGP_CALCS.CL_PRI = 1) ORDER BY EPGC_FIELD_ATTRIBS.FA_NAME";

            SqlCommand oCommand = new SqlCommand(sCommand, conn);
            SqlDataReader reader = null;
 
            reader = oCommand.ExecuteReader();
            while (reader.Read())
            {
                lfid = DBAccess.ReadIntValue(reader["CL_RESULT"]);
                luid = DBAccess.ReadIntValue(reader["CL_UID"]);
                sname = DBAccess.ReadStringValue(reader["FA_NAME"]);

                pItem = new PriItemDefn();
                pItem.Name =  sname;
                pItem.fid = lfid;
                pItem.uid = luid;
                m_oRows.Add(pItem);
            }
            reader.Close();
            reader = null;

                     
 

 
            sCommand = "SELECT EPGP_PI_PRI_COMPONENTS.CC_COMPONENT, EPGP_PI_PRI_COMPONENTS.CC_SEQ, EPGC_FIELD_ATTRIBS.FA_NAME " +
                                " FROM EPGP_PI_PRI_COMPONENTS INNER JOIN " +
                                " EPGC_FIELD_ATTRIBS ON EPGP_PI_PRI_COMPONENTS.CC_COMPONENT = EPGC_FIELD_ATTRIBS.FA_FIELD_ID " +
                                " ORDER BY EPGP_PI_PRI_COMPONENTS.CC_SEQ";
            oCommand = new SqlCommand(sCommand, conn);
            reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                lfid = DBAccess.ReadIntValue(reader["CC_COMPONENT"]);
                lseq = DBAccess.ReadIntValue(reader["CC_SEQ"]);
                sname = DBAccess.ReadStringValue(reader["FA_NAME"]);

                pItem = new PriItemDefn();
                pItem.Name =  sname;
                pItem.seq = lseq;
                pItem.fid = lfid;

                m_oCols.Add(pItem);

             }
            reader.Close();
            reader = null;

            sCommand = "SELECT * FROM EPGP_PI_PRI_WEIGHTS ORDER BY CW_RESULT";
            oCommand = new SqlCommand(sCommand, conn);
   
            reader = oCommand.ExecuteReader();
            while (reader.Read())
            {
                lfid = DBAccess.ReadIntValue(reader["CW_RESULT"]);
                lseq = DBAccess.ReadIntValue(reader["CW_COMPONENT"]);
                dweight = DBAccess.ReadDoubleValue(reader["CW_RATIO"]);

                wItem = new PriWeight();

                wItem.rowfid = lfid;
                wItem.colfid = lseq;
                wItem.ratio = dweight;

                sname = lfid.ToString() + " " + lseq.ToString();

                m_oWeights.Add(sname, wItem);

            }
            reader.Close();
            reader = null;
        }

    }

}