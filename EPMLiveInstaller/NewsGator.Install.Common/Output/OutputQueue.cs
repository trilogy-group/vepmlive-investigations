using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace NewsGator.Install.Common.Output
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix"), Serializable, DataContract]
    public class OutputQueue
    {
        internal const string Prefix = "OUTPUTQUEUE::";

        [DataMember]
        private Collection<OutputQueueItem> _items = new Collection<OutputQueueItem>();
        private OutputManager writer;

        public OutputQueue(OutputManager writer)
        {
            this.writer = writer;
        }

        public OutputQueue() { }

       [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public Collection<OutputQueueItem> Items
        {
            get { return _items; }
            private set { _items = value; }
        }

        public void Add(string message)
        {
            Add(message, OutputType.Verbose, null, null);
        }

        public void Add(string message, OutputType type)
        {
            Add(message, type, null, null);
        }

        public void Add(string message, OutputType type, string description)
        {
            Add(message, type, description, null);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "description")]
        public void Add(string message, OutputType type, string description, Exception exception)
        {
            var newItem = new OutputQueueItem();
            newItem.Type = type;
            newItem.Message = message;
            newItem.Created = DateTime.Now;

            if (exception != null && string.IsNullOrEmpty(description))
                newItem.Description = exception.ToString();

            if (this.writer == null)
                this.Items.Add(newItem);
            else
                WriteItem(this.writer, false, newItem);
        }

        public void Add(OutputQueue outputQueue)
        {
            if (outputQueue != null
                && outputQueue.Items != null
                && outputQueue.Items.Count > 0)
                foreach (var item in outputQueue.Items)
                    this.Items.Add(item);
        }

        public string Encode()
        {
            var xml = this.Serialize();
            var bytes = UTF8Encoding.UTF8.GetBytes(xml);
            return Prefix + Convert.ToBase64String(bytes);
        }

        public void DecodeAndAdd(string source)
        {
            if (string.IsNullOrEmpty(source))
                return;

            if (source.IndexOf(Prefix, StringComparison.OrdinalIgnoreCase) > -1)
                source = source.Replace(Prefix, string.Empty);

            var bytes = Convert.FromBase64String(source);
            var xml = UTF8Encoding.UTF8.GetString(bytes);
            var outputQueue = Deserialize(xml) as OutputQueue;

            if (outputQueue != null && outputQueue.Items.Count > 0)
                this.Add(outputQueue);
        }

        public string Serialize()
        {
            return Utilities.Serializer.Serialize(this);
        }

        public OutputQueue Deserialize(string source)
        {
            return Utilities.Serializer.Deserialize(source, this.GetType()) as OutputQueue;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        internal void WriteQueuedOutput(OutputManager outputManager, bool verboseLogOnly = false)
        {
            try
            {
                if (outputManager != null && this != null && this.Items != null)
                {
                    var items = this.Items.Where(p => p != null && p.Created != null).OrderBy(p => p.Created);
                    foreach (var item in items)
                    {
                        WriteItem(outputManager, verboseLogOnly, item);
                    }

                    this.Items.Clear();
                }
            }
            catch (Exception exception)
            {
                if (outputManager != null)
                    outputManager.WriteError(exception.Message, exception);
            }
        }

        public static void WriteItem(OutputManager outputManager, bool verboseLogOnly, OutputQueueItem item)
        {
            try
            {
                switch (item.Type)
                {
                    case OutputType.Error:
                        if (item.Exception == null)
                        {
                            item.Exception = new InvalidOperationException(item.Message);
                            item.Exception.Data.Add("Description", string.IsNullOrEmpty(item.Description) ? item.Message : item.Description);
                        }

                        outputManager.WriteError(item.Message, item.Exception, false, false, item.Created);
                        break;
                    case OutputType.Progress:
                        outputManager.WriteProgress(item.Message, item.Description, -1, false, item.Created);
                        break;
                    case OutputType.Warning:
                        outputManager.WriteWarning(item.Message, false, item.Created);
                        break;
                    case OutputType.Verbose:
                    default:
                        outputManager.WriteVerbose(item.Message, verboseLogOnly, item.Created);
                        break;
                }
            }
            catch (Exception exception)
            {
                if (outputManager != null)
                    outputManager.WriteError(exception.Message, exception);
            }
        }
    }
}
