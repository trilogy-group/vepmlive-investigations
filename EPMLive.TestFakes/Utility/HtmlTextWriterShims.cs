using System;
using System.Collections.Generic;
using System.IO.Fakes;
using System.Text;
using System.Web.UI;
using System.Web.UI.Fakes;

namespace EPMLive.TestFakes.Utility
{
    /// <summary>
    /// Shim class for <see cref="HtmlTextWriter"/> 
    /// </summary>
    public class HtmlTextWriterShims
    {
        public IList<HtmlTextWriter> TextWriterCreated { get; private set; }
        public IList<HtmlTextWriter> TextWriterDisposed { get; private set; }

        public IDictionary<HtmlTextWriter, StringBuilder> Contents { get; private set; }

        protected HtmlTextWriterShims()
        {
            TextWriterCreated = new List<HtmlTextWriter>();
            TextWriterDisposed = new List<HtmlTextWriter>();
            Contents = new Dictionary<HtmlTextWriter, StringBuilder>();
        }

        public static HtmlTextWriterShims ShimHtmlTextWriterCalls()
        {
            var result = new HtmlTextWriterShims();
            result.InitializeShims();
            return result;
        }

        private void InitializeShims()
        {
            ShimHtmlTextWriter.ConstructorTextWriter= (instance, writer) =>
            {
                AddWriter(instance);
            };

            ShimHtmlTextWriter.ConstructorTextWriterString = (instance, writer, s) =>
            {
                AddWriter(instance);
            };

            ShimTextWriter.AllInstances.Dispose = instance =>
            {
                var writer = instance as HtmlTextWriter;
                if (writer != null)
                {
                    TextWriterDisposed.Add(writer);
                }
            };

            ShimHtmlTextWriter.AllInstances.WriteString = (instance, value) =>
            {
                Contents[instance].Append(value);
            };

            ShimHtmlTextWriter.AllInstances.WriteLineString = (instance, value) =>
            {
                Contents[instance].AppendLine(value);
            };
        }

        private void AddWriter(HtmlTextWriter instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }
            Contents.Add(instance, new StringBuilder());
            TextWriterCreated.Add(instance);
        }
    }
}
