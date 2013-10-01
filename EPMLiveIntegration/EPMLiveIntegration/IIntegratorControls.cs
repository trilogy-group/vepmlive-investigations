using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPMLiveIntegration
{
    public enum IntegrationControlWindowStyle { FullWindow = 1, FullDialog, SmallDialog }

    public class IntegrationControl
    {
        public string Control;
        public string Image;
        public string Title;
        public IntegrationControlWindowStyle Window;
        public bool BItemLevel;
    }

    public interface IIntegratorControls
    {
        List<string> GetLocalControls(WebProperties WebProps, IntegrationLog Log);
        List<IntegrationControl> GetRemoteControls(WebProperties WebProps, IntegrationLog Log);
        string GetURL(WebProperties WebProps, IntegrationLog Log, string control, string ItemID);
        string GetControlCode(WebProperties WebProps, IntegrationLog Log, string ItemID, string Control);
    }
}

