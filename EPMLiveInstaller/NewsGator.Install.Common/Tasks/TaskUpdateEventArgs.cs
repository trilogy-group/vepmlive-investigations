using System;
using System.Collections.ObjectModel;

namespace NewsGator.Install.Common.Tasks
{
    internal class TaskUpdateEventArgs : EventArgs
    {
        internal Guid TaskId { get; set; }
        internal TaskStatus TaskStatus { get; set; }
        internal bool RefreshTasks { get; set; }
        internal Collection<IInstallTask> Tasks { get; set; }

        internal TaskUpdateEventArgs(Guid taskId, TaskStatus status)
            : base()
        {
            this.TaskId = taskId;
            this.TaskStatus = status;
            this.RefreshTasks = false;
        }

        internal TaskUpdateEventArgs(Collection<IInstallTask> tasks)
            : base()
        {
            this.RefreshTasks = true;
            this.Tasks = tasks;
        }

        internal TaskUpdateEventArgs()
            : base()
        {
        }
    }
}
