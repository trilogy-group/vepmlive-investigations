using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml;

namespace EPMLiveCore.API
{
    internal abstract class ApplicationBase
    {
        protected string _id;
        protected int _maxErrorLevel = 0;
        protected DataTable _dtMessages = new DataTable();
        protected SqlConnection _cn;

        public DataTable DtMessages
        {
            get
            {
                return _dtMessages;
            }
        }

        public XmlDocument XmlMessages
        {
            get
            {
                XmlDocument docMessages = new XmlDocument();
                docMessages.LoadXml("<Messages/>");
                XmlNode ndParent = docMessages.FirstChild;

                foreach (DataRow dr in _dtMessages.Rows)
                {
                    XmlNode ndMessageRow = docMessages.CreateNode(XmlNodeType.Element, "MessageRow", docMessages.NamespaceURI);

                    XmlAttribute attr = docMessages.CreateAttribute("ID");
                    attr.Value = dr["ID"].ToString();
                    ndMessageRow.Attributes.Append(attr);

                    attr = docMessages.CreateAttribute("ErrorLevel");
                    attr.Value = dr["ErrorLevel"].ToString();
                    ndMessageRow.Attributes.Append(attr);

                    XmlNode ndMessage = docMessages.CreateNode(XmlNodeType.Element, "Message", docMessages.NamespaceURI);
                    ndMessage.InnerXml = "<![CDATA[" + System.Web.HttpUtility.HtmlEncode(dr["Message"].ToString()) + "]]>";

                    ndMessageRow.AppendChild(ndMessage);

                    ndMessage = docMessages.CreateNode(XmlNodeType.Element, "Details", docMessages.NamespaceURI);
                    ndMessage.InnerXml = "<![CDATA[" + System.Web.HttpUtility.HtmlEncode(dr["Details"].ToString()) + "]]>";

                    ndMessageRow.AppendChild(ndMessage);

                    XmlNode ndParentMessageRow = ndParent.SelectSingleNode("//MessageRow[@ID='" + dr["ParentID"].ToString() + "']");

                    if (ndParentMessageRow != null)
                        ndParentMessageRow.AppendChild(ndMessageRow);
                    else
                        ndParent.AppendChild(ndMessageRow);

                }


                return docMessages;
            }
        }

        public DataTable DtMessagesHTML
        {
            get
            {
                DataTable dt = DtMessages.Clone();
                foreach (DataRow dr in DtMessages.Rows)
                {
                    DataRow drNew = dt.Rows.Add(new object[] { dr[0], dr[1], dr[2], dr[3], dr[4], dr[5] });

                    for (int i = 0; i < int.Parse(drNew["Tabbing"].ToString()); i++)
                    {
                        drNew["Message"] = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + drNew["Message"].ToString();
                    }
                }
                return dt;
            }
        }

        public string Message
        {
            get
            {
                StringBuilder sbMessage = new StringBuilder();
                DataTable dt = DtMessagesHTML;
                foreach (DataRow dr in dt.Rows)
                {
                    sbMessage.Append(dr[3].ToString());
                    sbMessage.Append("...");

                    switch ((ErrorLevels)int.Parse(dr[2].ToString()))
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
                    }

                    if (dr[4].ToString().Length > 0)
                    {
                        sbMessage.Append(" (");
                        sbMessage.Append(dr[4].ToString());
                        sbMessage.Append(")");
                    }
                    sbMessage.Append("<br>");
                }

                return sbMessage.ToString();
            }
        }

        public int MaxErrorLevel
        {
            get
            {
                return _maxErrorLevel;
            }
        }

        protected ApplicationBase(string id, SqlConnection cn)
        {
            _id = id;
            _cn = cn;
            
            _dtMessages.Columns.Add(new DataColumn("ID", typeof(int)));
            _dtMessages.Columns.Add(new DataColumn("ParentID", typeof(int)));
            _dtMessages.Columns.Add(new DataColumn("ErrorLevel", typeof(int)));
            _dtMessages.Columns.Add(new DataColumn("Message", typeof(string)));
            _dtMessages.Columns.Add(new DataColumn("Details", typeof(string)));
            _dtMessages.Columns.Add(new DataColumn("Tabbing", typeof(string)));
        }
    }
}