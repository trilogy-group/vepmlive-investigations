using System;
using System.ComponentModel;

namespace WorkEnginePPM.DataServiceModules
{
    public delegate void DSMProgressChangedEventHandler(object sender, DSMProgressChangedEventHandlerArgs args);
    public class DSMProgressChangedEventHandlerArgs : ProgressChangedEventArgs
    {
        public DSMProgressChangedEventHandlerArgs(int progressPercentage, object userState) : base(progressPercentage, userState) { }
    }
    public delegate void DSMCompletedEventHandler(object sender, DSMCompletedEventHandlerArgs args);
    public class DSMCompletedEventHandlerArgs : AsyncCompletedEventArgs
    {
        public DSMCompletedEventHandlerArgs(Exception error, bool cancelled, object userState)
            : base(error, cancelled, userState)
        {
        }

    }
   
}
