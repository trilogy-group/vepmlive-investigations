using System;
using System.Collections.Generic;

namespace EPMLiveCore.Infrastructure
{
    public interface IGridViewManager : IDisposable
    {
        #region Data Members (2) 

        string Key { get; }

        List<GridView> List { get; }

        #endregion Data Members 

        #region Operations (6) 

        void Add(GridView gridView);

        GridView FindBy(string id);

        void Initialize();

        void Remove(GridView gridView);

        void Update(GridView gridView);

        bool ValidateAuthorization(string loginName);

        #endregion Operations 
    }
}