using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using NewsGator.Install.Common.Output;

namespace NewsGator.Install.Common.Tasks
{
    /// <summary>
    /// Task to perform by the installer
    /// </summary>
    public interface IInstallTask
    {
        /// <summary>
        /// Method to execute the task
        /// </summary>
        OutputQueue Run();

        /// <summary>
        /// Text to display for the task in the GUI or PowerShell
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Current status of the task
        /// </summary>
        [DefaultValue(0)]
        TaskStatus Status { get; set; }

        /// <summary>
        /// Maximum time, in milliseconds, allotted for the task to complete
        /// Default: 20 Minutes
        /// </summary>
        [DefaultValue(1200000)]
        int Timeout { get; set; }

        /// <summary>
        /// Automatically generated unique identifier for the object instance
        /// </summary>
        Guid InstanceId { get; }

        /// <summary>
        /// Get the PowerShell script to execute this task
        /// </summary>
        string Script { get; }
    }
}
