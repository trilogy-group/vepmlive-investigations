using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure
{
    internal abstract class UpgradeStep : IUpgradeStep
    {
        #region Fields (3) 

        private readonly string _description;
        private readonly IList<string> _logs;
        private readonly string _name;

        #endregion Fields 

        #region Constructors (1) 

        protected UpgradeStep(SPWeb spWeb, bool isPfeSite)
        {
            Web = spWeb;
            IsPfeSite = isPfeSite;

            Type type = GetType();

            object[] attributes = type.GetCustomAttributes(typeof (UpgradeStepAttribute), true);
            if (!attributes.Any())
            {
                throw new Exception(type.Name + " does not implement UpgradeStepAttribute.");
            }

            var attribute = ((UpgradeStepAttribute) attributes.First());
            _name = attribute.Name;
            _description = attribute.Description;

            _logs = new List<string>();
        }

        #endregion Constructors 

        #region Properties (3) 

        protected bool IsPfeSite { get; private set; }

        public SPWeb Web { get; private set; }

        public virtual string Log
        {
            get
            {
                var stringBuilder = new StringBuilder();

                stringBuilder.AppendLine();
                stringBuilder.AppendLine("==================================================");
                stringBuilder.AppendLine(string.Format("STEP {0}: {1}", _name, _description.ToUpper()));
                stringBuilder.AppendLine("==================================================");

                foreach (string log in _logs)
                {
                    stringBuilder.AppendLine(log);
                }

                return stringBuilder.ToString();
            }
        }

        #endregion Properties 

        #region Methods (8) 

        // Public Methods (1) 

        public abstract bool Perform();
        // Protected Methods (6) 

        protected string GetListInfo(SPList spList)
        {
            return "List: " + spList.Title;
        }

        protected string GetWebInfo(SPWeb spWeb)
        {
            return string.Format(@"Web: {0} ({1})", spWeb.Title, spWeb.Url);
        }

        protected void LogMessage(string message, int indentLevel)
        {
            AddLog(string.Format(@"{0} -- {1}.", new String('\t', indentLevel), message));
        }

        protected void LogMessage(string message, MessageKind messageKind, int indentLevel)
        {
            string kind = string.Empty;

            switch (messageKind)
            {
                case MessageKind.SUCCESS:
                    kind = "+++ SUCCESS";
                    break;
                case MessageKind.FAILURE:
                    kind = "*** FAILURE";
                    break;
                case MessageKind.SKIPPED:
                    kind = "!!! SKIPPED";
                    break;
            }

            AddLog(string.Format(@"{0}{1}. {2}", new String('\t', indentLevel), kind, message));
        }

        protected void LogTitle(string message, int indentLevel)
        {
            AddLog(string.Format(@"{0}--- {1}{2}", new String('\t', indentLevel), message,
                !string.IsNullOrEmpty(message) ? "." : string.Empty));
        }

        protected void ResetFeature(KeyValuePair<Guid, string> feature, SPSite spSite)
        {
            LogTitle("Feature: " + feature.Value, 2);

            SPFeature spFeature = spSite.Features.FirstOrDefault(f => f.DefinitionId == feature.Key);

            if (spFeature != null)
            {
                LogTitle("Deactivating . . ", 4);
                spSite.Features.Remove(spFeature.DefinitionId);
            }

            LogTitle("Activating . . ", 4);
            spSite.Features.Add(feature.Key);

            LogMessage(string.Empty, MessageKind.SUCCESS, 3);
        }

        // Private Methods (1) 

        private void AddLog(string message)
        {
            _logs.Add(string.Format("[{0:MM/dd/yyyy hh:mm:ss tt}] {1}", DateTime.Now, message));
        }

        #endregion Methods 
    }
}