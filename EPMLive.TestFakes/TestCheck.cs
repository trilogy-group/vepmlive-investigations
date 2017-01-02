using System;

namespace EPMLive.TestFakes
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
