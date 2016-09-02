using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EPMLiveWebParts
{
    public class GridViewSession
    {
        private class GridSession
        {
            public Guid ViewId;
            public string Columns;
            public string Groups;
            public int Page;

            public GridSession(Guid View)
            {
                ViewId = View;
                Columns = "";
                Groups = "";
                Page = 0;
            }
        }

        private GridSession GS;

        public GridViewSession(Guid ViewId)
        {
            if (HttpContext.Current.Session["ViewSession"] == null)
            {
                HttpContext.Current.Session["ViewSession"] = new GridSession(ViewId);
            }

            GS = HttpContext.Current.Session["ViewSession"] as GridSession;

            if (GS.ViewId != ViewId)
            {
                GS = new GridSession(ViewId);
                HttpContext.Current.Session["ViewSession"] = GS;
            }
        }

        public string Columns
        {
            get
            {
                return GS.Columns;
            }
            set
            {
                GS.Columns = value;
                HttpContext.Current.Session["ViewSession"] = GS;
            }
        }

        public string Groups
        {
            get
            {
                return GS.Groups;
            }
            set
            {
                GS.Groups = value;
                HttpContext.Current.Session["ViewSession"] = GS;
            }
        }

        public int Page
        {
            get
            {
                return GS.Page;
            }
            set
            {
                GS.Page = value;
                HttpContext.Current.Session["ViewSession"] = GS;
            }
        }
    }
}
