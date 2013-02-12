using System;
using System.Xml.Linq;
using Microsoft.SharePoint;

namespace EPMLiveCore.Infrastructure
{
    public interface ISPListItemManager : IDisposable
    {
        #region Data Members (2) 

        int BatchProcessLimit { get; set; }

        SPList ParentList { get; }

        #endregion Data Members 

        #region Operations (7) 

        XDocument Add(XDocument serializedListItems);

        XDocument Delete(XDocument serializedListItems);

        XDocument GetAll();

        XDocument GetAll(bool includeHidden);

        XDocument GetAll(bool includeHidden, bool includeReadOnly);

        bool ItemExists(int id);

        XDocument Update(XDocument serializedListItems);

        #endregion Operations 
    }
}