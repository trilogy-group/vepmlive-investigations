using System;
using PortfolioEngineCore;

namespace WorkEnginePPM.Layouts.ppm
{
    public class AutoAdjustPeriods
    {
        private const string AutoAdjustPeriodsAttribute = "AutoAdjustPeriods";
        private const string FinishPeriodDeltaAttribute = "FinishPeriodDelta";
        private const string StartPeriodDeltaAttribute = "StartPeriodDelta";
        private const bool EnabledDefaultValue = false;
        private const int FinishPeriodDeltaDefaultValue = 6;
        private const int StartPeriodDeltaDefaultValue = 6;

        public AutoAdjustPeriods(bool enabled, int startPeriodDelta, int finishPeriodDelta)
        {
            Enabled = enabled;
            StartPeriodDelta = startPeriodDelta;
            FinishPeriodDelta = finishPeriodDelta;
        }

        public bool Enabled { get; set; }
        public int FinishPeriodDelta { get; set; }
        public int StartPeriodDelta { get; set; }

        public static AutoAdjustPeriods Default()
        {
            return new AutoAdjustPeriods(EnabledDefaultValue, StartPeriodDeltaDefaultValue, FinishPeriodDeltaDefaultValue);
        }

        public void CreateAttributes(CStruct xmlStruct)
        {
            if (xmlStruct == null)
            {
                throw new ArgumentNullException("xmlStruct");
            }

            xmlStruct.SetIntAttr(AutoAdjustPeriodsAttribute, Enabled ? 1 : 0);
            xmlStruct.SetIntAttr(StartPeriodDeltaAttribute, StartPeriodDelta);
            xmlStruct.SetIntAttr(FinishPeriodDeltaAttribute, FinishPeriodDelta);
        }

        public string GetXml(string root)
        {
            var viewData = new CStruct();
            viewData.Initialize(root);
            CreateAttributes(viewData);
            return viewData.XML();
        }

        public bool TryLoadFromAttributes(CStruct data)
        {
            Enabled = data.GetIntAttr(AutoAdjustPeriodsAttribute) == 1;
            StartPeriodDelta = data.GetIntAttr(StartPeriodDeltaAttribute, StartPeriodDeltaDefaultValue);
            FinishPeriodDelta = data.GetIntAttr(FinishPeriodDeltaAttribute, FinishPeriodDeltaDefaultValue);
            return true;
        }

        public bool TryLoadFromXml(string viewDataXml)
        {
            if (string.IsNullOrWhiteSpace(viewDataXml))
            {
                return false;
            }

            var viewData = new CStruct();
            viewData.LoadXML(viewDataXml);

            return TryLoadFromAttributes(viewData);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AutoAdjustPeriods"/> from XML attributes or returns the instance with default values.
        /// </summary>
        /// <param name="viewDataXml">The XML string.</param>
        public static AutoAdjustPeriods TryCreateFromXml(string viewDataXml)
        {
            var value = Default();
            value.TryLoadFromXml(viewDataXml);
            return value;
        }
    }
}