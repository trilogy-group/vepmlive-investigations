using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using EPMLiveIntegration;
using System.Data.SqlClient;


namespace EPMLiveCore.API.Integration
{
    public class SQL : EPMLiveIntegration.IIntegrator
    {
        public bool InstallIntegration(WebProperties WebProps, IntegrationLog Log, out string Message, string IntegrationKey, string APIUrl)
        {
            Message = "";
            return true;
        }

        public bool RemoveIntegration(WebProperties WebProps, IntegrationLog Log, out string Message, string IntegrationKey)
        {
            Message = "";
            return true;
        }


        public TransactionTable DeleteItems(WebProperties WebProps, DataTable Items, IntegrationLog Log)
        {
            TransactionTable table = new TransactionTable();

            SqlConnection cn = GetConnection(WebProps.Properties);
            cn.Open();

            foreach(DataRow dr in Items.Rows)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM " + WebProps.Properties["Table"] + " WHERE " + WebProps.Properties["IDColumn"] + "=@id", cn);
                    cmd.Parameters.AddWithValue("@id", dr["ID"].ToString());
                    cmd.ExecuteNonQuery();

                    table.AddRow(dr["SPID"].ToString(), dr["ID"].ToString(), TransactionType.DELETE);
                }
                catch {
                    table.AddRow(dr["SPID"].ToString(), dr["ID"].ToString(), TransactionType.FAILED);
                }

            }

            return table;
        }

        public TransactionTable UpdateItems(WebProperties WebProps, DataTable Items, IntegrationLog Log)
        {
            TransactionTable trans = new TransactionTable();

            SqlConnection cn = GetConnection(WebProps.Properties);
            cn.Open();

            foreach(DataRow drItem in Items.Rows)
            {
                string curID = drItem["ID"].ToString();
                string SPPID = drItem["SPID"].ToString();

                try
                {
                    if(curID == "")
                    {
                        trans.AddRow(SPPID, InsertRow(WebProps, drItem, Log, cn), TransactionType.INSERT);
                    }
                    else
                    {
                        
                        SqlCommand cmd = new SqlCommand("SELECT * FROM " + WebProps.Properties["Table"] + " WHERE " + WebProps.Properties["IDColumn"] + "=@id", cn);
                        cmd.Parameters.AddWithValue("@id", curID);
                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        if(ds.Tables[0].Rows.Count > 0)
                        {
                            trans.AddRow(SPPID, UpdateRow(WebProps, drItem, Log, cn), TransactionType.UPDATE);
                        }
                        else
                        {
                            trans.AddRow(SPPID, InsertRow(WebProps, drItem, Log, cn), TransactionType.INSERT);
                        }
                    }
                }
                catch(Exception ex)
                {
                    Log.LogMessage(ex.Message, IntegrationLogType.Error);
                    trans.AddRow(SPPID, curID, TransactionType.FAILED);
                }
            }
            cn.Close();
            return trans;
        }


        public List<ColumnProperty> GetColumns(WebProperties WebProps, IntegrationLog Log, string ListName)
        {
            List<ColumnProperty> lstCols = new List<ColumnProperty>();


            SqlConnection cn = GetConnection(WebProps.Properties);
            cn.Open();
            SqlCommand cmd = new SqlCommand("select name from sys.columns where object_id = object_id('" + WebProps.Properties["Table"].ToString().Replace("'", "''") + "')", cn);

            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                ColumnProperty prop = new ColumnProperty();
                prop.ColumnName = dr.GetString(0);
                prop.DiplayName = dr.GetString(0);
                prop.DefaultListColumn = GetDefaultColumn(ListName, dr.GetString(0));
                lstCols.Add(prop);
            }
            dr.Close();
            
            cn.Close();
           

            return lstCols;

        }

        public DataTable PullData(WebProperties WebProps, IntegrationLog Log, DataTable Items, DateTime LastSynch)
        {
            SqlConnection cn = GetConnection(WebProps.Properties);
            cn.Open();

            string cols = WebProps.Properties["IDColumn"].ToString();

            string where = "";
            try
            {
                where = WebProps.Properties["Where"].ToString();
            }
            catch { }

            foreach(DataColumn dc in Items.Columns)
            {
                if(dc.ColumnName != "ID")
                {
                    cols += "," + dc.ColumnName;
                }
            }

            string sql = "SELECT " + cols + " FROM " + WebProps.Properties["Table"];
            if(where != "")
            {
                sql += " Where " + where.Replace("'", "''");
            }

            SqlCommand cmd = new SqlCommand(sql, cn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            cn.Close();

            ds.Tables[0].Columns[WebProps.Properties["IDColumn"].ToString()].ColumnName = "ID";

            return ds.Tables[0];
        }

        public DataTable GetItem(WebProperties WebProps, IntegrationLog Log, string ItemID, DataTable Items)
        {

            SqlConnection cn = GetConnection(WebProps.Properties);
            cn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM " + WebProps.Properties["Table"] + " WHERE " + WebProps.Properties["IDColumn"] + " = '" + ItemID + "'", cn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            if(ds.Tables[0].Rows.Count > 0)
            {

                DataRow dr = ds.Tables[0].Rows[0];

                ArrayList arrRow = new ArrayList();
                arrRow.Add(ItemID);

                foreach(DataColumn dc in Items.Columns)
                {

                    if(dc.ColumnName != "ID")
                    {
                        try
                        {
                            arrRow.Add(dr[dc.ColumnName].ToString());
                        }catch{arrRow.Add("");}
                    }

                }

                Items.Rows.Add((string[])arrRow.ToArray(typeof(string)));

            }

            cn.Close();

            return Items;
        }

        public Dictionary<String, String> GetDropDownValues(WebProperties WebProps, IntegrationLog log, string Property, string ParentPropertyValue)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();

            SqlConnection cn = GetConnection(WebProps.Properties);
            cn.Open();
            
            switch(Property)
            {
                case "Table":
                    SqlCommand cmd = new SqlCommand("select name from sys.tables", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read())
                        props.Add(dr.GetString(0), dr.GetString(0));
                    dr.Close();
                    break;
                case "UserMapType":
                    props.Add("EmailAddress", "Email Address");
                    break;
                case "AvailableSynchOptions":
                    props.Add("LI", "LI");
                    props.Add("TI", "TI");
                    props.Add("TO", "TO");
                    break;
            }
            
            cn.Close();

            return props;
        }

        public bool TestConnection(WebProperties WebProps, IntegrationLog Log, out string Message)
        {
            try
            {
                Message = "";
                SqlConnection cn = GetConnection(WebProps.Properties);
                cn.Open();
                cn.Close();
                return true;
            }
            catch(Exception ex){
                Message = "Error: " + ex.Message;
                return false;
            }
        }




        private string GetDefaultColumn(string list, string column)
        {
            if(list == "Project Center")
            {
            }
            else if(list == "Issues")
            {
                switch(column)
                {
                    case "Name":
                        return "Title";
                    case "Start":
                        return "StartDate";
                    default:
                        return column;
                }
            }

            return "";
        }

        private SqlConnection GetConnection(Hashtable Properties)
        {
            return new SqlConnection("Server=" + Properties["Server"] + ";Database=" + Properties["Database"] + ";Trusted_Connection=True");
        }


        private string InsertRow(WebProperties WebProps, DataRow Item, IntegrationLog Log, SqlConnection cn)
        {
            

            string paramnames = "";
            string paramvalues = "";

            ArrayList arrparams = new ArrayList();
   
            foreach(DataColumn dc in Item.Table.Columns)
            {
                if(dc.ColumnName != "ID" && dc.ColumnName != "SPID")
                {
                    paramnames += dc.ColumnName + ",";
                    paramvalues += "@" + dc.ColumnName + ",";
                    if(Item[dc.ColumnName].ToString() == "")
                        arrparams.Add(new SqlParameter("@" + dc.ColumnName, DBNull.Value));
                    else
                        arrparams.Add(new SqlParameter("@" + dc.ColumnName, Item[dc.ColumnName].ToString()));
                }
            }

            try
            {
                if(WebProps.Properties["SPColumn"].ToString() != "")
                {
                    paramnames += WebProps.Properties["SPColumn"] + ",";
                    paramvalues += "@" + WebProps.Properties["SPColumn"] + ",";
                    arrparams.Add(new SqlParameter("@" + WebProps.Properties["SPColumn"], Item["SPID"].ToString()));
                }
            }
            catch { }

            string sql = "INSERT INTO " + WebProps.Properties["Table"] + "(" + paramnames.Trim(',') + ") OUTPUT Inserted." + WebProps.Properties["IDColumn"] + " VALUES (" + paramvalues.Trim(',') + ")";

            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddRange(arrparams.ToArray(typeof(SqlParameter)));
            object o = cmd.ExecuteScalar();

            return o.ToString();
        }

        private string UpdateRow(WebProperties WebProps, DataRow Item, IntegrationLog Log, SqlConnection cn)
        {
            string paramnames = "";

            ArrayList arrparams = new ArrayList();

            foreach(DataColumn dc in Item.Table.Columns)
            {
                if(dc.ColumnName != "ID" && dc.ColumnName != "SPID")
                {
                    paramnames += dc.ColumnName + " = @" + dc.ColumnName + ",";
                    if(Item[dc.ColumnName].ToString() == "")
                        arrparams.Add(new SqlParameter("@" + dc.ColumnName, DBNull.Value));
                    else
                        arrparams.Add(new SqlParameter("@" + dc.ColumnName, Item[dc.ColumnName].ToString()));

                }
            }

            try
            {
                if(WebProps.Properties["SPColumn"].ToString() != "")
                {
                    paramnames += WebProps.Properties["SPColumn"] + " = @" + WebProps.Properties["SPColumn"] + ",";
                    arrparams.Add(new SqlParameter("@" + WebProps.Properties["SPColumn"], Item["SPID"].ToString()));
                }
            }
            catch { }

            string sql = "UPDATE " + WebProps.Properties["Table"] + " Set " + paramnames.Trim(',') + " WHERE " + WebProps.Properties["IDColumn"] + " =@id";

            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddRange(arrparams.ToArray(typeof(SqlParameter)));
            cmd.Parameters.AddWithValue("@id", Item["ID"].ToString());
            object o = cmd.ExecuteScalar();

            return Item["ID"].ToString();
        }
    }
}
