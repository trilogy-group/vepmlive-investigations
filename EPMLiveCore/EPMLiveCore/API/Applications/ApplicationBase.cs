using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Web;
using System.Xml;

namespace EPMLiveCore.API
{
    internal abstract class ApplicationBase
    {
        protected SqlConnection _cn;
        protected DataTable _dtMessages = new DataTable();
        protected string _id;
        protected int _maxErrorLevel = 0;

        protected ApplicationBase(string id, SqlConnection connection)
        {
            _id = id;
            _cn = connection;

            _dtMessages.Columns.Add(new DataColumn("ID", typeof(int)));
            _dtMessages.Columns.Add(new DataColumn("ParentID", typeof(int)));
            _dtMessages.Columns.Add(new DataColumn("ErrorLevel", typeof(int)));
            _dtMessages.Columns.Add(new DataColumn("Message", typeof(string)));
            _dtMessages.Columns.Add(new DataColumn("Details", typeof(string)));
            _dtMessages.Columns.Add(new DataColumn("Tabbing", typeof(string)));
        }

        public DataTable DtMessages
        {
            get { return _dtMessages; }
        }

        public XmlDocument XmlMessages
        {
            get
            {
                var docMessages = new XmlDocument();
                docMessages.LoadXml("<Messages/>");
                var ndParent = docMessages.FirstChild;

                foreach (DataRow dataRow in _dtMessages.Rows)
                {
                    var ndMessageRow = docMessages.CreateNode(XmlNodeType.Element, "MessageRow", docMessages.NamespaceURI);

                    var attr = docMessages.CreateAttribute("ID");
                    attr.Value = dataRow["ID"].ToString();
                    ndMessageRow.Attributes.Append(attr);

                    attr = docMessages.CreateAttribute("ErrorLevel");
                    attr.Value = dataRow["ErrorLevel"].ToString();
                    ndMessageRow.Attributes.Append(attr);

                    var ndMessage = docMessages.CreateNode(XmlNodeType.Element, "Message", docMessages.NamespaceURI);
                    ndMessage.InnerXml = $"<![CDATA[{HttpUtility.HtmlEncode(dataRow["Message"].ToString())}]]>";

                    ndMessageRow.AppendChild(ndMessage);

                    ndMessage = docMessages.CreateNode(XmlNodeType.Element, "Details", docMessages.NamespaceURI);
                    ndMessage.InnerXml = $"<![CDATA[{HttpUtility.HtmlEncode(dataRow["Details"].ToString())}]]>";

                    ndMessageRow.AppendChild(ndMessage);

                    var ndParentMessageRow = ndParent.SelectSingleNode("//MessageRow[@ID='" + dataRow["ParentID"] + "']");

                    if (ndParentMessageRow != null)
                    {
                        ndParentMessageRow.AppendChild(ndMessageRow);
                    }
                    else
                    {
                        ndParent.AppendChild(ndMessageRow);
                    }
                }

                return docMessages;
            }
        }

        public DataTable DtMessagesHTML
        {
            get
            {
                var dataTable = DtMessages.Clone();
                foreach (DataRow dataRow in DtMessages.Rows)
                {
                    var drNew = dataTable.Rows.Add(dataRow[0], dataRow[1], dataRow[2], dataRow[3], dataRow[4], dataRow[5]);

                    for (var i = 0; i < int.Parse(drNew["Tabbing"].ToString()); i++)
                    {
                        drNew["Message"] = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + drNew["Message"];
                    }
                }
                return dataTable;
            }
        }

        public string Message
        {
            get
            {
                var sbMessage = new StringBuilder();
                var dt = DtMessagesHTML;
                foreach (DataRow dataRow in dt.Rows)
                {
                    sbMessage.Append(dataRow[3]);
                    sbMessage.Append("...");

                    switch ((ErrorLevels)int.Parse(dataRow[2].ToString()))
                    {
                        case ErrorLevels.NoError:
                        case ErrorLevels.Skip:
                            sbMessage.Append("Success");
                            break;
                        case ErrorLevels.Warning:
                            sbMessage.Append("Warning");
                            break;
                        case ErrorLevels.Error:
                            sbMessage.Append("Failed");
                            break;
                        default:
                            Trace.WriteLine("ArgumentOutOfRangeException dataRow[2]");
                            break;
                    }

                    if (dataRow[4].ToString().Length > 0)
                    {
                        sbMessage.Append(" (");
                        sbMessage.Append(dataRow[4]);
                        sbMessage.Append(")");
                    }
                    sbMessage.Append("<br>");
                }

                return sbMessage.ToString();
            }
        }

        public int MaxErrorLevel
        {
            get { return _maxErrorLevel; }
        }
    }
}