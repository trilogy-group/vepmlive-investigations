using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using EPMLiveWebParts;
using Microsoft.SharePoint;

namespace TimeSheets
{
    public abstract partial class ApprovalBase : getgriditems
    {
        protected void AddCells(XmlNode nd, SPSite site, XmlNode ndListId, XmlNode ndItemId, int period, DataSet dsTSHours, ArrayList arr, string bgcolor, bool usecurrent, string strColumns, DataSet dsTimesheetTasks, DataSet dsTimesheetMeta, bool timeeditor, string[] strworktypes, bool timenotes, SqlConnection cn)
        {
            string rowId = nd.Attributes["id"].Value;
            string curUser = "";
            int firstDot = rowId.IndexOf(".", 75);
            curUser = rowId.Substring(firstDot + 1, rowId.LastIndexOf(".") - firstDot - 1);

            SqlCommand cmd = new SqlCommand("spTSgetTSHours", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", curUser);
            cmd.Parameters.AddWithValue("@siteguid", site.ID);
            cmd.Parameters.AddWithValue("@period_id", period);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dsTSHours);

            DataSet dsTotalHours = new DataSet();

            cmd = new SqlCommand("spTSGetTotalHoursForItem", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@listuid", ndListId.InnerText);
            cmd.Parameters.AddWithValue("@siteguid", site.ID);
            cmd.Parameters.AddWithValue("@itemid", ndItemId.InnerText);
            da = new SqlDataAdapter(cmd);
            da.Fill(dsTotalHours);

            AddColumn1(nd, arr);

            cmd = new SqlCommand("select ts_item_uid,submitted,approval_status from vwtstasks where list_uid=@listuid and item_id=@itemid and username=@username and period_id=@period_id", cn);
            cmd.Parameters.AddWithValue("@listuid", ndListId.InnerText);
            cmd.Parameters.AddWithValue("@itemid", ndItemId.InnerText);
            cmd.Parameters.AddWithValue("@username", curUser);
            cmd.Parameters.AddWithValue("@period_id", period);

            SqlDataReader drItem = cmd.ExecuteReader();

            AddColumn2(nd, arr);

            string ts_item_uid = Guid.Empty.ToString();

            if (drItem.Read())
            {
                ts_item_uid = drItem.GetGuid(0).ToString();

                AddCell1(drItem, nd);
            }

            AddCell2(drItem, nd);
            
            if (!usecurrent && drItem.GetBoolean(1))
            {
                string[] arrCols = strColumns.Split(',');
                XmlNodeList ndList = nd.SelectNodes("cell");

                for (int i = 0; i < ndList.Count; i++)
                {
                    string cell = ndList[i].OuterXml;
                    string colid = arrCols[i].Replace("<![CDATA[", "").Replace("]]>", "");
                    if (colid == "Project")
                    {
                        DataRow[] drs = dsTimesheetTasks.Tables[0].Select("ts_item_uid ='" + ts_item_uid + "'");
                        if (drs.Length > 0)
                        {
                            ndList[i].InnerText = drs[0]["project"].ToString();
                        }
                    }
                    else if (colid != "Title" && colid != "List" && colid != "Site" && colid != "")
                    {

                        DataRow[] drs = dsTimesheetMeta.Tables[0].Select("ts_item_uid='" + ts_item_uid + "' and columnname='" + colid + "'");
                        string colval = "";
                        if (drs.Length > 0)
                            colval = drs[0]["columnvalue"].ToString();

                        bool bIsIndicator = false;
                        try
                        {
                            SPField field = list.Fields.GetFieldByInternalName(colid);
                            if (field.Type == SPFieldType.Calculated && colval.ToLower().Contains(".gif"))
                            {
                                bIsIndicator = true;
                            }
                        }
                        catch { }

                        if (bIsIndicator)
                            ndList[i].InnerText = "<img src=\"/_layouts/images/" + colval + "\">";
                        else
                            ndList[i].InnerText = colval;

                    }

                }
            }
            drItem.Close();
            double total = 0;
            XmlNode newCol;
            foreach (DateTime dt in arr)
            {
                if (timeeditor)
                {
                    newCol = CreateCell(dsTSHours, ts_item_uid, strworktypes, dt, ref total);
                    
                    if (timenotes)
                    {
                        DataRow[] drs = dsTSHours.Tables[1].Select("ts_item_uid = '" + ts_item_uid + "' and TS_ITEM_DATE=#" + dt.ToString("MM/dd/yyy") + "#");
                        if (drs.Length > 0)
                        {
                            newCol.InnerText += "|N|" + drs[0]["TS_ITEM_NOTES"].ToString();
                        }
                        else
                        {
                            newCol.InnerText += "|N|";
                        }
                    }

                    if (newCol.InnerText.Length > 1)
                        newCol.InnerText = newCol.InnerText.Substring(1);

                    nd.InsertAfter(newCol, nd.SelectNodes("cell")[nd.SelectNodes("cell").Count - 1]);
                }
                else
                {
                    newCol = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
                    XmlAttribute attr = docXml.CreateAttribute("type");
                    attr.InnerText = "ro";
                    newCol.Attributes.Append(attr);
                    DataRow[] drs = dsTSHours.Tables[0].Select("ts_item_uid = '" + ts_item_uid + "' and TS_ITEM_DATE=#" + dt.ToString("MM/dd/yyyy") + "#");
                    if (drs.Length > 0)
                    {
                        newCol.InnerText = double.Parse(drs[0]["TS_ITEM_HOURS"].ToString()).ToString();
                        total += double.Parse(drs[0]["TS_ITEM_HOURS"].ToString());
                        nd.InsertAfter(newCol, nd.SelectNodes("cell")[nd.SelectNodes("cell").Count - 1]);
                    }
                    else
                    {
                        newCol.InnerText = "0";
                        nd.InsertAfter(newCol, nd.SelectNodes("cell")[nd.SelectNodes("cell").Count - 1]);
                    }
                }
            }

            newCol = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
            newCol.InnerText = total.ToString();
            XmlAttribute attrStyle1 = docXml.CreateAttribute("style");
            attrStyle1.Value = "background: #" + bgcolor + "; font-weight: bold";
            newCol.Attributes.Append(attrStyle1);
            nd.InsertAfter(newCol, nd.SelectNodes("cell")[nd.SelectNodes("cell").Count - 1]);

            XmlNode ndWork = nd.SelectSingleNode("userdata[@name='Work']");

            newCol = docXml.CreateNode(XmlNodeType.Element, "cell", docXml.NamespaceURI);
            if (dsTotalHours.Tables.Count > 0 && dsTotalHours.Tables[0].Rows.Count > 0)
            {
                newCol.InnerText = ndWork.InnerText + "|" + double.Parse(dsTotalHours.Tables[0].Rows[0][0].ToString()).ToString();
            }
            else
            {
                newCol.InnerText = ndWork.InnerText + "|0";
            }

            attrStyle1 = docXml.CreateAttribute("style");
            attrStyle1.Value = "background: #" + bgcolor + "; font-weight: bold";
            newCol.Attributes.Append(attrStyle1);
            nd.InsertAfter(newCol, nd.SelectNodes("cell")[nd.SelectNodes("cell").Count - 1]);
        }

        protected virtual void AddColumn1(XmlNode nd, ArrayList arr)
        {
            // empty default implementation
        }

        protected virtual void AddColumn2(XmlNode nd, ArrayList arr)
        {
            // empty default implementation
        }

        protected abstract void AddCell1(SqlDataReader drItem, XmlNode nd);

        protected virtual void AddCell2(SqlDataReader drItem, XmlNode nd)
        {
            // empty default implementation
        }

        protected abstract XmlNode CreateCell(DataSet dsTsHours, string tsItemUid, string[] strworktypes, DateTime dt, ref double total);
    }
}