using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;

namespace EPMLiveSynch
{
    public abstract class SyncItemBaseType
    {
        private object[] oParams;
        private SPWeb oCurrWeb;
        private SPWeb oFromWeb;
        private SPWeb oToWeb;
        private string sConn = null;
        private string sCollectionResults = "";
        protected string sSiteResults = "";
        private string sLeftPadding = "";
        protected bool bCreateNewList = false;
        protected char[] chrCRSeparator = new char[] { '\r' };
        protected char[] chrNewlineSeparator = new char[] { '\n' };
        protected char[] chrPipeSeparator = new char[] { '|' };
        protected char[] chrColonSeparator = new char[] { ':' };
        protected char[] chrSemiColonSeparator = new char[] { ';' };
        protected char[] chrCommaSeparator = new char[] { ',' };
        protected string[] strHTML_BR_Separator = new string[] { "<br>" };
        protected SyncType enSyncType = SyncType.List;
        private string sSyncItems;

        protected internal object[] Params
        {
            set { oParams = value; }
        }

        protected internal string ConnectionString
        {
            get { return sConn; }
            set { sConn = value; }
        }

        protected internal SPWeb CurrWeb
        {
            get { return oCurrWeb; }
            set { oCurrWeb = value; }
        }

        protected internal SPWeb FromWeb
        {
            get { return oFromWeb; }
            set { oFromWeb = value; }
        }

        protected internal SPWeb ToWeb
        {
            get { return oToWeb; }
            set { oToWeb = value; }
        }

        protected internal bool CreateNewList
        {
            get { return bCreateNewList; }
            set { bCreateNewList = value; }
        }

        protected internal string Results
        {
            get { return sCollectionResults; }
            set { sCollectionResults = value; }
        }

        protected internal string SyncItems
        {
            get { return sSyncItems; }
            set { sSyncItems = value; }
        }

        public enum SyncType : int
        {
            List = 1,
            Template = 2
        }

        protected internal SyncType SynchronizationType
        {
            get { return enSyncType; }
            set { enSyncType = value; }
        }

        protected internal abstract bool Sync();
    }
}
