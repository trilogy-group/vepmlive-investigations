using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewsGator.Install.Common.Output;
using System.Globalization;
using NewsGator.Install.Common.Utilities;

namespace NewsGator.Install.Common.Tasks
{
    public static class TaskExtensions
    {
        /// <summary>
        /// Run an installer task.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "0#"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public static OutputQueue RunTask(ref IInstallTask task)
        {
            if (task == null)
                throw new ArgumentNullException("task");

            var start = DateTime.Now;
            var output = new OutputQueue();
            var taskToRun = task;

            output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskRunner_StartingTask, task.DisplayName));

            try
            {
                task.Status = TaskStatus.InProgress;   

                var timeout = taskToRun.Timeout >= 1200000 ? taskToRun.Timeout : 1200000;

                var methodOutput = Threading.WaitFor<OutputQueue>.Run(TimeSpan.FromMilliseconds(timeout), taskToRun.Run);
                if (methodOutput == null)
                    throw new TimeoutException();

                if (methodOutput.Items.Any(p => p.Type == OutputType.Error))
                    task.Status = TaskStatus.CompleteFailed;
                else
                    task.Status = TaskStatus.CompleteSuccess;

                output.Add(methodOutput);
            }
            catch (TimeoutException)
            {
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskRunner_Timeout, task.DisplayName));
                task.Status = TaskStatus.CompleteFailed;
            }
            catch (Exception exception)
            {
                output.Add(exception.Message, OutputType.Error, null, exception);
                task.Status = TaskStatus.CompleteFailed;
            }

            var time = (DateTime.Now - start).TotalMilliseconds;

            if (task.Status == TaskStatus.CompleteSuccess)
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskRunner_CompleteSuccess, task.DisplayName));
            else
                output.Add(string.Format(CultureInfo.CurrentUICulture, NewsGator.Install.Resources.Tasks.TaskRunner_CompleteFailed, task.DisplayName, task.Script), OutputType.Error);

            output.Add(string.Format(CultureInfo.CurrentUICulture, Resources.Tasks.TaskRunner_Time, task.DisplayName, time.ToString(CultureInfo.InvariantCulture)));
            
            return output;
        }
    }
}
