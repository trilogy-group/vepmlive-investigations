using System;

namespace NewsGator.Install.Common.Output
{
    internal class OutputEventArgs : EventArgs
    {
        internal OutputType Type { get; set; }
        internal string Text { get; set; }

        internal OutputEventArgs(OutputType type, string text)
            : base()
        {
            this.Type = type;
            this.Text = text;
        }

        internal OutputEventArgs()
            : base()
        {

        }
    }
}
