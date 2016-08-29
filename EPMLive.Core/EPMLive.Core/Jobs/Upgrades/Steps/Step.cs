using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.Upgrades.Steps
{
    public abstract class Step : IStep
    {
        #region Fields (5) 

        protected readonly string Data;
        protected readonly SPSite SPSite;
        protected readonly SPWeb SPWeb;
        private readonly int _stepNumber;
        protected List<string> Logs;
        protected bool bIsPfe = false;

        #endregion Fields 

        #region Methods (5) 

        // Protected Methods (4) 

        protected void LogMessage(string message)
        {
            AddLog(message);
        }

        protected void LogMessage(string preFix, string message, int status)
        {
            switch(status)
            {
                case 2:
                    AddLog(preFix + "\tSKIPPED: " + message);
                    break;
                case 3:
                    AddLog(preFix + "\t***ERROR: " + message);
                    break;
                default:
                    AddLog(preFix + "\tSUCCESS: " + message);
                    break;
            }
        }

        protected void LogMessage(string message, SPWeb spWeb)
        {
            AddLog(string.Empty);
            AddLog(string.Format("--- {0}", message));
            AddLog(string.Format("--- WEB: {0}. ID: {1}, URL: {2}", spWeb.Title, spWeb.ID.ToString().ToUpper(),
                                 spWeb.Url));
            AddLog(string.Empty);
        }

        protected void LogMessage(string message, SPWeb spWeb, SPList spList)
        {
            AddLog(string.Format("--- {0}", message));
            AddLog(string.Format("--- WEB: {0}. ID: {1}, URL: {2}", spWeb.Title, spWeb.ID.ToString().ToUpper(),
                                 spWeb.Url));
            AddLog(string.Format("--- LIST: {0}. ID: {1}", spList.Title, spList.ID.ToString().ToUpper()));
        }

        // Private Methods (1) 

        private void AddLog(string message)
        {
            Logs.Add(string.Format("[{0:MM/dd/yyyy hh:mm:ss tt}] {1}", DateTime.Now, message));
        }

        #endregion Methods 

        #region Implementation of IStep

        protected Step(SPWeb spWeb, string data, int stepNumber, bool bispfe)
        {
            SPSite = spWeb.Site;
            SPWeb = spWeb;
            Data = data;
            _stepNumber = stepNumber;
            bIsPfe = bispfe;

            Logs = new List<string>();
        }

        public virtual string Log
        {
            get
            {
                var stringBuilder = new StringBuilder();

                stringBuilder.AppendLine("==================================================");
                stringBuilder.AppendLine(string.Format("STEP ({0}): {1}", _stepNumber, Description.ToUpper()));
                stringBuilder.AppendLine("==================================================");
                foreach (string log in Logs)
                {
                    stringBuilder.AppendLine(log);
                }

                return stringBuilder.ToString();
            }
        }


        public abstract string Description { get; }

        public abstract bool Perform();

        #endregion
    }
}