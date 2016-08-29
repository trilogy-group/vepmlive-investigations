using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.JSGrid;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;

namespace EPMLiveWebParts
{


    public class GridDelegates
    {
        public GridDelegates PopulateGridRow(System.Collections.Generic.IEnumerable<GroupingNode> node)
        {   
            return new GridDelegates();
        }
    }
}
