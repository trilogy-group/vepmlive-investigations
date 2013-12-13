using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPMLiveIntegration;
using System.Data;
using System.Collections;
using System.Net;
using System.Web.Services;
using System.Web.Services.Description;
using System.Xml.Serialization;
using System.Reflection;
using System.CodeDom;
using System.IO;
using System.CodeDom.Compiler;
using System.Text.RegularExpressions;

namespace EPMLiveCore.API.Integration
{
    public class Generic : EPMLiveIntegration.IIntegrator
    {
        private MethodInfo[] methodInfo;
        private ParameterInfo[] param;
        private Type service;

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
            TransactionTable trans = new TransactionTable();

            return trans;
        }

        public TransactionTable UpdateItems(WebProperties WebProps, DataTable Items, IntegrationLog Log)
        {
            TransactionTable trans = new TransactionTable();

            if(BuildWSDL(WebProps, Log))
            {
                MethodInfo Method = null;
                
                foreach(MethodInfo t in methodInfo)
                {
                    if(t.Name == WebProps.Properties["WSDLFunction"].ToString())
                    {
                        Method = t;
                        param = t.GetParameters();
                        break;
                    }
                }

                if(Method != null)
                {
                    foreach(DataRow drItem in Items.Rows)
                    {

                        try
                        {
                            Hashtable hshProps = GetItemHash(WebProps, drItem);

                            object[] param1 = new object[param.Length];

                            int i = 0;

                            foreach(var p in param)
                            {
                                param1[i++] = Convert.ChangeType(hshProps[p.Name], p.ParameterType);
                            }

                            Object obj = Activator.CreateInstance(service);
                            Object response = Method.Invoke(obj, param1);
                            try
                            {
                                if(WebProps.Properties["LogInfo"].ToString() == "True")
                                {
                                    Log.LogMessage("WSDL Response: " + response.ToString(), IntegrationLogType.Information);
                                }
                            }
                            catch { }
                        }
                        catch(Exception ex)
                        {
                            Log.LogMessage("Error sending item (" + drItem["SPID"].ToString() + "): " + ex.Message, IntegrationLogType.Error);
                        }
                    }
                }
                else
                {
                    Log.LogMessage("Could not find method", IntegrationLogType.Error);
                }
            }
            return trans;
        }



        public List<ColumnProperty> GetColumns(WebProperties WebProps, IntegrationLog Log, string ListName)
        {
            List<ColumnProperty> lstCols = new List<ColumnProperty>();

            string[] cols = WebProps.Properties["Fields"].ToString().Split(',');
            foreach(string col in cols)
            {
                ColumnProperty prop = new ColumnProperty();
                prop.ColumnName = col;
                prop.DiplayName = col;
                lstCols.Add(prop);
            }

            return lstCols;
        }

        public DataTable PullData(WebProperties WebProps, IntegrationLog Log, DataTable Items, DateTime LastSynch)
        {
            DataTable dt = new DataTable();


            return dt;
        }

        public DataTable GetItem(WebProperties WebProps, IntegrationLog Log, string ItemID, DataTable Items)
        {
            return Items;
        }

        public Dictionary<String, String> GetDropDownValues(WebProperties WebProps, IntegrationLog log, string Property, string ParentPropertyValue)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();

            switch(Property)
            {
                case "UserMapType":
                    props.Add("Email", "Email Address");
                    props.Add("Username", "Username");
                    props.Add("SPID", "SharePoint User ID");
                    break;
                case "AvailableSynchOptions":
                    props.Add("LI", "LI");
                    try
                    {
                        if(WebProps.Properties["WSDL"].ToString().Length > 0)
                        {
                            props.Add("LO", "LO");
                            props.Add("TI", "TI");
                        }
                    }
                    catch { }
                    break;
                case "WSDLFunction":
                    if(BuildWSDL(WebProps, log))
                    {
                        foreach(MethodInfo t in methodInfo)
                        {
                            if(t.Name == "Discover")
                                break;
                            props.Add(t.Name, t.Name);
                        }
                    }
                    else
                    {

                    }
                    break;
            }

            return props;
        }

        public bool TestConnection(WebProperties WebProps, IntegrationLog Log, out string Message)
        {
            Message = "";
            return true;
        }

        private bool BuildWSDL(WebProperties WebProps, IntegrationLog Log)
        {
            try
            {

                Uri uri = new Uri(WebProps.Properties["WSDL"].ToString());
                //byte[] byteArray = Encoding.ASCII.GetBytes(WebProps.Properties["WSDL"].ToString()); 
                //MemoryStream stream = new MemoryStream(byteArray); 
                WebRequest webRequest = WebRequest.Create(uri);
                System.IO.Stream stream = webRequest.GetResponse().GetResponseStream();

                ServiceDescription sd = ServiceDescription.Read(stream);
                string sdName = sd.Services[0].Name;

                // Initialize a service description servImport
                ServiceDescriptionImporter servImport = new ServiceDescriptionImporter();
                servImport.AddServiceDescription(sd, String.Empty, String.Empty);
                servImport.ProtocolName = "Soap";
                servImport.CodeGenerationOptions = CodeGenerationOptions.GenerateProperties;

                CodeNamespace nameSpace = new CodeNamespace();
                CodeCompileUnit codeCompileUnit = new CodeCompileUnit();
                codeCompileUnit.Namespaces.Add(nameSpace);

                ServiceDescriptionImportWarnings warnings = servImport.Import(nameSpace, codeCompileUnit);

                if (warnings == 0)
                {
                    StringWriter stringWriter = new StringWriter(System.Globalization.CultureInfo.CurrentCulture);
                    Microsoft.CSharp.CSharpCodeProvider prov = new Microsoft.CSharp.CSharpCodeProvider();
                    prov.GenerateCodeFromNamespace(nameSpace, stringWriter, new CodeGeneratorOptions());

                    string[] assemblyReferences = new string[2] { "System.Web.Services.dll", "System.Xml.dll" };
                    CompilerParameters param = new CompilerParameters(assemblyReferences);
                    param.GenerateExecutable = false;
                    param.GenerateInMemory = true;
                    param.TreatWarningsAsErrors = false;
                    param.WarningLevel = 4;

                    CompilerResults results = new CompilerResults(new TempFileCollection());
                    results = prov.CompileAssemblyFromDom(param, codeCompileUnit);
                    Assembly assembly = results.CompiledAssembly;
                    service = assembly.GetType(sdName);

                    methodInfo = service.GetMethods();
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.LogMessage(ex.Message, IntegrationLogType.Error);
            }
            return false;
        }

        private Hashtable GetItemHash(WebProperties WebProps, DataRow drItem)
        {
            Hashtable hshProps = new Hashtable();


            string wsdlmap = WebProps.Properties["WSDLMap"].ToString();

            if(wsdlmap != "")
            {
                string[] sWSDLProps = wsdlmap.Replace("\r\n", "\n").Split('\n');
                foreach(string sWSDLProp in sWSDLProps)
                {
                    string wprop = sWSDLProp.Substring(0, sWSDLProp.IndexOf("="));
                    string wval = sWSDLProp.Substring(sWSDLProp.IndexOf("=") + 1);

                    if(wval.StartsWith("*"))//Array of Fields
                    {
                        string newVal = "<Items><Item><Fields>";
                        wval = wval.Substring(1);
                        string[] sFieldList = wval.Split(',');
                        foreach(string sField in sFieldList)
                        {
                            try
                            {
                                if(drItem.Table.Columns.Contains(sField))
                                {
                                    newVal += "<Field Name=\"" + sField + "\"><![CDATA[" + drItem[sField].ToString() + "]]></Field>";
                                }
                                //hshProps.Add(sField, drItem[sField].ToString());
                            }
                            catch { }
                        }
                        newVal = newVal + "</Fields></Item></Items>";
                        hshProps.Add(wprop, newVal);
                    }
                    else//Field
                    {

                        foreach(Match match in Regex.Matches(wval, @"\[\w*\]"))
                        {
                            try
                            {
                                string sfield = match.Value.Trim(']').Trim('[');
                                wval = wval.Replace(match.Value, drItem[sfield].ToString());
                            }
                            catch { }
                        }

                        try
                        {
                            hshProps.Add(wprop, wval);
                        }
                        catch { }
                    }
                }
            }
            return hshProps;
        }
    }
}

