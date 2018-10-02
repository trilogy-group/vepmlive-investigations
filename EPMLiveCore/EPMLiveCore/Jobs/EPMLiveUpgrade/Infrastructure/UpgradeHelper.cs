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
        V600,
        V610,
        V621,
        V630,
        V631,
        V633,
        V634,
        V640,
        V700,
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
                    case EPMLiveVersion.V600:
                        version = "6.0.0";
                        break;
                    case EPMLiveVersion.V610:
                        version = "6.1.0";
                        break;
                    case EPMLiveVersion.V621:
                        version = "6.2.1";
                        break;
                    case EPMLiveVersion.V630:
                        version = "6.3.0";
                        break;
                    case EPMLiveVersion.V631:
                        version = "6.3.1";
                        break;
                    case EPMLiveVersion.V633:
                        version = "6.3.3";
                        break;
                    case EPMLiveVersion.V634:
                        version = "6.3.4";
                        break;
                    case EPMLiveVersion.V640:
                        version = "6.4.0";
                        break;
                    case EPMLiveVersion.V700:
                        version = "7.0.0";
                        break;
                    case EPMLiveVersion.GENERIC:
                        version = "GENERIC";
                        break;
                }

                return version + "." + Order;
            }
        }

        public double Order { get; set; }

        public long SequenceOrder
        {
            get
            {

                long sequence = 0;
                string[] splitSequence;
                if (Version != EPMLiveVersion.GENERIC)
                   
                {
                     splitSequence = Name.Split(new char[] { '.' });
                }
                else
                {
                    int upper = (int)Order;
                    int lower = (int) ((Order * 100.0) - (upper * 100));
                    splitSequence = new string[] { upper.ToString(), lower.ToString() };
                }
                int multiplier = 1;
                for (int i = splitSequence.Length - 1; i >= 0; i--)
                {
                    int part = int.Parse(splitSequence[i]);
                    if (part < 10)
                        part = part * 10;
                    sequence += multiplier * part;
                    multiplier *= 100;
                }
                return sequence;
            }
        }

        public EPMLiveVersion Version { get; set; }

        #endregion Properties 
    }
}