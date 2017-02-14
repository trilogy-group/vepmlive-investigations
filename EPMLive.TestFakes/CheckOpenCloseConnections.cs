using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient.Fakes;

namespace EPMLive.TestFakes
{
    internal class CheckOpenCloseConnections : IDisposable
    {
        private int _openedconnection = 0;
        private int _closedconnection = 0;

        public CheckOpenCloseConnections()
        {
            ShimSqlConnection.ConstructorString = (instance, _string) => { };
            ShimSqlConnection.AllInstances.Open = (instance) => { _openedconnection++; };
            ShimSqlConnection.AllInstances.Close = (instance) => { _closedconnection++; };
        }

        public void Dispose()
        {
            Assert.IsTrue(_openedconnection <= _closedconnection, "Open method calling are greater than close methods");
        }
    }
}
