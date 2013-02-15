using System;
using System.Xml.Linq;
using EPMLiveCore;
using Microsoft.SharePoint;
using PortfolioEngineCore;
using PortfolioEngineCore.Analyzers;
using WorkEnginePPM.Core;

namespace WorkEnginePPM.WebServices.Core
{
    internal class AnalyzerManager : BaseManager
    {
        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzerManager"/> class.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        public AnalyzerManager(SPWeb spWeb) : base(spWeb)
        {
        }

        #endregion Constructors 

        #region Methods (3) 

        // Private Methods (2) 

        /// <summary>
        /// Gets the base analyzer.
        /// </summary>
        /// <param name="securityLevel">The security level.</param>
        /// <param name="debug">if set to <c>true</c> [debug].</param>
        /// <returns></returns>
        private BaseAnalyzer GetBaseAnalyzer(SecurityLevels securityLevel, bool debug = false)
        {
            BaseAnalyzer baseAnalyzer = null;

            SPSecurity.RunWithElevatedPrivileges(
                () => { baseAnalyzer = InitilizeBaseAnalyzer(securityLevel, debug, Username); });

            return baseAnalyzer;
        }

        /// <summary>
        /// Initilizes the base analyzer.
        /// </summary>
        /// <param name="securityLevel">The security level.</param>
        /// <param name="debug">if set to <c>true</c> [debug].</param>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        private BaseAnalyzer InitilizeBaseAnalyzer(SecurityLevels securityLevel, bool debug, string username)
        {
            BaseAnalyzer baseAnalyzer;

            using (var site = new SPSite(Web.Site.ID))
            {
                SPWeb rootWeb = site.RootWeb;

                string basePath = CoreFunctions.getConfigSetting(rootWeb, "epkbasepath");
                string ppmId = CoreFunctions.getConfigSetting(rootWeb, "ppmpid");
                string ppmCompany = CoreFunctions.getConfigSetting(rootWeb, "ppmcompany");
                string ppmDbConn = CoreFunctions.getConfigSetting(rootWeb, "ppmdbconn");

                baseAnalyzer = new BaseAnalyzer(basePath, username, ppmId, ppmCompany, ppmDbConn, securityLevel, debug);
            }

            return baseAnalyzer;
        }

        // Internal Methods (1) 

        /// <summary>
        /// Generates the data ticket.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal string GenerateDataTicket(string data)
        {
            try
            {
                XDocument requestXml = XDocument.Parse(data);

                if (requestXml.Root == null)
                {
                    throw new Exception("Cannot find the root element.");
                }

                XElement ticketElement = requestXml.Root.Element("Ticket");

                if (ticketElement == null)
                {
                    throw new Exception("Cannot find the Ticket element.");
                }

                BaseAnalyzer baseAnalyzer = GetBaseAnalyzer(SecurityLevels.Base);

                ticketElement.Add(new XAttribute("Id", baseAnalyzer.GenerateDataTicket(ticketElement.Value)));

                return Response.Success(new XElement("Data", ticketElement).ToString());
            }
            catch (PFEException pfeException)
            {
                return Response.PfEFailure(pfeException);
            }
            catch (Exception exception)
            {
                return Response.Failure((int) APIError.GenerateDataTicket, exception);
            }
        }

        #endregion Methods 
    }
}