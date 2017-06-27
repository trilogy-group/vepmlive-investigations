using System;

namespace EPMLiveCore.Tests
{
    public static class TestCheck
    {
        public static IDisposable OpenCloseConnections
        {
            get
            {
                return new CheckOpenCloseConnections();
            }
        }
    }
}
