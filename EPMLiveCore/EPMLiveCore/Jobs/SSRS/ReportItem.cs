using System;

namespace EPMLiveCore.Jobs.SSRS
{
    public class ReportItem
    {
        public byte[] BinaryData { get; internal set; }
        public string FileName { get; internal set; }
        public string Folder { get; internal set; }
        public DateTime LastModified { get; internal set; }
    }
}