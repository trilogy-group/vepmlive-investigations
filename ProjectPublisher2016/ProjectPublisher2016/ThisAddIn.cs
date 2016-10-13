using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using MSProject = Microsoft.Office.Interop.MSProject;
using Office = Microsoft.Office.Core;

namespace ProjectPublisher2016
{
    public partial class ThisAddIn
    {
        public Connect c;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            c = new Connect();
            c.app = this.Application;
            c.StartUp();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            System.GC.Collect();

            System.GC.WaitForPendingFinalizers();

            System.GC.Collect();

            System.GC.WaitForPendingFinalizers();
        }

        public static void NAR(object o)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
            }
            catch { }
            finally
            {
                o = null;
            }
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
