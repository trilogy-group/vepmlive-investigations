using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPMLiveIntegration
{
    public enum IntegrationControlWindowStyle { FullWindow = 1, FullDialog, SmallDialog, IFrame }

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
        List<string> GetEmbeddedItemControls(WebProperties WebProps, IntegrationLog Log);
        List<IntegrationControl> GetPageButtons(WebProperties WebProps, IntegrationLog Log, bool GlobalButtons);
        string GetURL(WebProperties WebProps, IntegrationLog Log, string control, string ItemID);
        string GetControlCode(WebProperties WebProps, IntegrationLog Log, string ItemID, string Control);
        string GetProxyResult(WebProperties WebProps, IntegrationLog Log, string ItemID, string Control, string Property);
    }
}

