using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WorkEnginePPM.DataServiceModules
{
    [DataContract]
    public enum DSMModule
    {
        CostPlanner
    }

    [DataContract]
    public class ScheduleDataImportRequest
    {
        public ScheduleDataImportRequest()
        {
            Options = new List<KeyValuePair<string, string>>();
        }
        [DataMember]
        public DSMModule Module { get; set; }
        [DataMember]
        public Guid ListId { get; set; }
        [DataMember]
        public Guid FileId { get; set; }
        [DataMember]
        public List<KeyValuePair<string, string>> Options { get; set; }
    }

    [DataContract]
    public class ScheduleDataImportResponse
    {
        public ScheduleDataImportResponse() { }
        [DataMember]
        public Guid JobId { get; set; }
    }

    [DataContract]
    public class DSMResult
    {
        public DSMResult()
        {
            Log = new DSMLog();
        }
        [DataMember]
        public String CurrentProcess { get; set; }
        [DataMember]
        public Int32 TotalRecords { get; set; }
        [DataMember]
        public Int32 PercentComplete { get; set; }
        [DataMember]
        public Int32 ProcessedRecords { get; set; }
        [DataMember]
        public Int32 SuccessRecords { get; set; }
        [DataMember]
        public Int32 FailedRecords { get; set; }
        [DataMember]
        public DSMLog Log { get; set; }
    }

    [DataContract]
    public class DSMLog
    {
        public DSMLog()
        {
            Messages = new List<DSMMessage>();
        }
        [DataMember]
        public Int32 InfoCount { get; set; }
        [DataMember]
        public Int32 WarningCount { get; set; }
        [DataMember]
        public Int32 ErrorCount { get; set; }
        [DataMember]
        public List<DSMMessage> Messages { get; set; }
    }

    [DataContract]
    public class DSMMessage
    {
        public DSMMessage() { }
        [DataMember]
        public Int32 Kind { get; set; }
        [DataMember]
        public DateTime DateTime { get; set; }
        [DataMember]
        public String Message { get; set; }
    }
}
