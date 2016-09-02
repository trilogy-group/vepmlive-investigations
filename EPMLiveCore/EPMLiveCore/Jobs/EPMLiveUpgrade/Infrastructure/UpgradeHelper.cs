using System;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure
{
    internal enum EPMLiveVersion
    {
        V44,
        V55,
        V56,
        V564,
        V567,
        V568,
        V569,
        V5610,
        V5612,
        GENERIC
    }

    internal enum MessageKind
    {
        SUCCESS,
        FAILURE,
        SKIPPED
    }

    internal class UpgradeStepAttribute : Attribute
    {
        #region Properties (6) 

        public string Description { get; set; }

        public bool IsOptIn { get; set; }

        public string Name
        {
            get
            {
                string version = string.Empty;

                switch (Version)
                {
                    case EPMLiveVersion.V44:
                        version = "4.4.0";
                        break;
                    case EPMLiveVersion.V55:
                        version = "5.5.0";
                        break;
                    case EPMLiveVersion.V56:
                        version = "5.6.0";
                        break;
                    case EPMLiveVersion.V564:
                        version = "5.6.4";
                        break;
                    case EPMLiveVersion.V567:
                        version = "5.6.7";
                        break;
                    case EPMLiveVersion.V568:
                        version = "5.6.8";
                        break;
                    case EPMLiveVersion.V569:
                        version = "5.6.9";
                        break;
                    case EPMLiveVersion.V5610:
                        version = "5.6.10";
                        break;
                    case EPMLiveVersion.V5612:
                        version = "5.6.12";
                        break;
                    case EPMLiveVersion.GENERIC:
                        version = "GENERIC";
                        break;
                }

                return version + "." + Order;
            }
        }

        public double Order { get; set; }

        public double SequenceOrder
        {
            get
            {
                return Version == EPMLiveVersion.GENERIC ? Order : Convert.ToDouble(Name.Replace(".", string.Empty));
            }
        }

        public EPMLiveVersion Version { get; set; }

        #endregion Properties 
    }
}