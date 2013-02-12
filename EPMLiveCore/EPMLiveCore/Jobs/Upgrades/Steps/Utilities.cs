using System.Linq;
using System.Reflection;

namespace EPMLiveCore.Jobs.Upgrades.Steps
{
    internal static class Utilities
    {
        #region Methods (1) 

        // Internal Methods (1) 

        internal static IOrderedEnumerable<JobStep> GetJobSteps(string parentJob)
        {
            return (from type in Assembly.GetExecutingAssembly().GetTypes()
                    where type.BaseType == typeof (Step)
                    from customAttribute in type.GetCustomAttributes(false)
                    where customAttribute.GetType() == typeof (JobStepAttribute)
                    let jobStepAttribute = ((JobStepAttribute) customAttribute)
                    where jobStepAttribute.ParentJob.Equals(parentJob)
                    select new JobStep {Sequence = jobStepAttribute.Sequence, Step = type})
                .OrderBy(s => s.Sequence);
        }

        internal static int GetJobType(string version)
        {
            switch(version)
            {
                case "4.3.0":
                    return 200;
            }
            return 0;
        }

        internal static string GetJobName(string version)
        {
            switch(version)
            {
                case "4.3.0":
                    return "WE43Upgrader";
            }

            return "";
        }

        #endregion Methods 
    }
}