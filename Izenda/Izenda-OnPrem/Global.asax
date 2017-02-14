<%@ Application Language="C#" %>
<%@ Import Namespace="Izenda.AdHoc" %>
<%@ Import Namespace="Izenda.AdHoc.Database" %>

<script RunAt="server">
    [Serializable]
    public class CustomAdHocConfig : DatabaseAdHocConfig
    {
        public static void InitializeReporting()
        {
            HttpSessionState session = HttpContext.Current.Session;
            if (session == null)
                return;
            if (session["reportinginitialized"] != null && session["reportinginitialized"].ToString() == "yes")
                return;
            session["reportinginitialized"] = "yes";

            AdHocSettings.LicenseKey = ConfigurationManager.AppSettings["IzendaLicenseKey"];
            AdHocSettings.DashboardViewer = "Dashboards.aspx";
            AdHocSettings.AdHocConfig = new CustomAdHocConfig();
            AdHocSettings.ChartLimit = 100;
            AdHocSettings.ChartingEngine = ChartingEngine.HtmlChart;
            AdHocSettings.UseColumnNameForDashboardCommonFilters = false;

            if (HttpContext.Current.Session["ConnectionString"] != null)
            {
                AdHocSettings.SqlServerConnectionString = HttpContext.Current.Session["ConnectionString"].ToString();

            }
        }

        public override void ProcessDataSet(System.Data.DataSet ds, string reportPart)
        {
            if (!string.IsNullOrEmpty(reportPart))
            {



                //foreach (System.Data.DataColumn item in ds.Tables[0].Columns)
                //{
                //    TypeCode _typeCode = Type.GetTypeCode(item.DataType);
                //    switch (_typeCode)
                //    {
                //        case TypeCode.DateTime:

                //            // Consoledate.WriteLine("Numeric");
                //            break;
                //        default:
                //            break;
                //    }
                //}
                System.Collections.Generic.List<string> col = new System.Collections.Generic.List<string>();

                foreach (System.Data.DataRow dataRow in ds.Tables[0].Rows)
                {
                    foreach (System.Data.DataColumn item in ds.Tables[0].Columns)
                    {
                        TypeCode _typeCode = Type.GetTypeCode(item.DataType);

                        switch (_typeCode)
                        {
                            case TypeCode.Byte:
                            case TypeCode.SByte:
                            case TypeCode.Int16:
                            case TypeCode.UInt16:
                            case TypeCode.Int32:
                            case TypeCode.UInt32:
                            case TypeCode.Int64:
                            case TypeCode.UInt64:
                            case TypeCode.Single:
                            case TypeCode.Double:
                            case TypeCode.Decimal:
                                // Console.WriteLine("Numeric");
                                break;
                            case TypeCode.Boolean:
                                // Console.WriteLine("Bool");
                                break;
                            case TypeCode.DateTime:
                                break;
                            case TypeCode.String:
                                if (dataRow[item.ColumnName] != DBNull.Value)
                                    dataRow[item.ColumnName] = dataRow[item.ColumnName].ToString().Replace(";#", ";");
                                break;
                            case TypeCode.Empty:
                                //  Console.WriteLine("Null");
                                break;
                            default:    // TypeCode.DBNull, TypeCode.Char and TypeCode.Object
                                        // Console.WriteLine("Unknown");
                                break;
                        }

                    }

                }
            }
            base.ProcessDataSet(ds, reportPart);
        }


        public override void ConfigureSettings()
        {
            if (HttpContext.Current.Session["ConnectionString"] != null)
            {
                AdHocSettings.SqlServerConnectionString = HttpContext.Current.Session["ConnectionString"].ToString();

                if (HttpContext.Current.Session["StorageConnectionString"] != null)
                    SavedReportsDriver = new Izenda.AdHoc.Database.MSSQLDriver(HttpContext.Current.Session["StorageConnectionString"].ToString());
            }
           
            AdHocSettings.ShowModifyButton = true;
            AdHocSettings.ShowDesignLinks = true;
            AdHocSettings.CurrentUserIsAdmin = false;
            AdHocSettings.CurrentUserIsGlobalAdministrator = false;

            //AdHocSettings.DataCacheInterval=0;
            AdHocSettings.SharedWithValues = new string[] { "Report Writers", "Report Viewers" };
            AdHocSettings.DefaultSharingRights = "View Only";
            AdHocSettings.DefaultVisibilityForNonAdmins = "Report Viewers";
            AdHocSettings.GenerateThumbnails = true;
            AdHocSettings.ChartingEngine = ChartingEngine.HtmlChart;
            AdHocSettings.Formats.Add(DateTime.Now.ToString("dd/MM/yyyy"), "{0:dd/MM/yyyy}");
            AdHocSettings.Formats.Add(DateTime.Now.ToString("dd-MM-yyyy"), "{0:dd-MM-yyyy}");
            AdHocSettings.Formats.Add(DateTime.Now.ToString("MM-dd-yyyy"), "{0:MM-dd-yyyy}");
            string pagename = System.IO.Path.GetFileName(HttpContext.Current.Request.PhysicalPath).ToLower();
            if (pagename != "default" && pagename != "timeout")
            {
                if (HttpContext.Current.Session["UserName"] == null)
                {
                    HttpContext.Current.Response.Redirect("timeout.aspx");
                }
            }
        }

        public override void PostLogin()
        {

            AdHocSettings.GenerateThumbnails = true;
            AdHocSettings.CurrentUserRoles = new string[] { HttpContext.Current.Session["Role"].ToString() };
            AdHocSettings.CurrentUserTenantId = HttpContext.Current.Session["webid"].ToString();
            AdHocSettings.CurrentUserIsAdmin = false;
            AdHocSettings.CurrentUserIsGlobalAdministrator = false;
            AdHocSettings.CurrentUserName = HttpContext.Current.Session["UserName"].ToString();
            AdHocSettings.SqlServerConnectionString = HttpContext.Current.Session["ConnectionString"].ToString();

            if (HttpContext.Current.Session["StorageConnectionString"] != null)
                SavedReportsDriver = new Izenda.AdHoc.Database.MSSQLDriver(HttpContext.Current.Session["StorageConnectionString"].ToString());

            AdHocSettings.CurrentUserIsAdmin = false;
            AdHocSettings.CurrentUserIsGlobalAdministrator = false;
            AdHocSettings.ShowModifyButton = false;
            AdHocSettings.ShowDesignLinks = false;
        }
    }
</script>
