using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPMLiveIntegration
{
    public class IntegrationControl
    {
        public IntegrationControl(string Control, string URL)
        {
            this.Control = Control;
            this.URL = URL;
        }

        public string Control;
        public string URL;
    }

    public interface IIntegratorControls
    {
        List<IntegrationControl> GetControls(WebProperties WebProps, IntegrationLog Log);
        string GetURL(WebProperties WebProps, IntegrationLog Log, string control, string url);
    }
}

