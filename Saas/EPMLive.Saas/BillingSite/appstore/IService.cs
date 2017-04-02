using System;
using System.Collections.Generic;

namespace BillingSite.appstore
{
    public interface IService : IDisposable
    {
        #region Operations (2) 

        string Reterive(string id, IEnumerable<string> fields = null);

        void Save(string data, Dictionary<string, string> additionalData);

        #endregion Operations 
    }
}