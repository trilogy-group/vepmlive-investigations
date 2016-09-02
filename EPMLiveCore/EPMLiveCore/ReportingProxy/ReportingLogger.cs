using System.Reflection;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.ReportingProxy
{
    public class ReportingLogger : ReportingProxyBase
    {
        #region Constructors (1) 

        public ReportingLogger(SPWeb spWeb) : base(spWeb) { }

        #endregion Constructors 

        #region Methods (1) 

        // Public Methods (1) 

        public void Log(SPList list, string message, string details, int level, int kind, string timerJobId)
        {
            try
            {
                object epmDataClass = GetEpmDataClass();
                MethodInfo methodInfo = GetMethod("LogStatus",
                    new[]
                    {
                        typeof (string), typeof (string), typeof (string), typeof (string), typeof (int), typeof (int),
                        typeof (string)
                    }, epmDataClass);

                methodInfo.Invoke(epmDataClass,
                    new object[] {list.ID, list.Title, message, details, level, kind, timerJobId});
            }
            catch { }
        }

        #endregion Methods 
    }
}