using System;

namespace NewsGator.Install.Common.Output
{
    [Serializable]
    public class OutputQueueItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods")]
        public OutputType Type { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public Exception Exception { get; set; }
    }
}
