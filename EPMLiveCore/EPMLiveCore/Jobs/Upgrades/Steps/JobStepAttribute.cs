using System;

namespace EPMLiveCore.Jobs.Upgrades.Steps
{
    public class JobStepAttribute : Attribute
    {
        #region Constructors (1) 

        public JobStepAttribute(string parentJob, double sequence)
        {
            ParentJob = parentJob;
            Sequence = sequence;
        }

        #endregion Constructors 

        #region Properties (2) 

        public string ParentJob { get; private set; }

        public double Sequence { get; private set; }

        #endregion Properties 
    }
}