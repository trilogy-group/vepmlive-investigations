using System;
using System.Collections.Generic;
using EPMLiveCore;
using EPMLiveWebParts.Personalization.DomainModel;

namespace EPMLiveWebParts.EpmCharting.DomainModel
{
    public class EpmChartUserSettings
    {
        public static string Key
        {
            get { return "EpmChartSettings"; }
        }

        public Guid? WebPartId { get; set; }
        public string UserId { get; set; }
        public Guid? SiteId { get; set; }
        public Guid? WebId { get; set; }
        public Guid? ListId { get; set; }        
        public string XaxisField { get; set; }
        public string XaxisFieldLabel { get; set; }
        public List<string> YaxisFields { get; set; }
        public string ZaxisField { get; set; }
        public string ZaxisFieldLabel { get; set; }
        public string ZaxisColorField { get; set; }
        public string YaxisFieldsCommaSeparated
        {
            get { return YaxisFields.AsDelimitedString(","); }
        }

        public string YaxisFieldLabel { get; set; }
        public bool IsValid { get; set; }

        public string Value
        {
            get
            {
                // XAxisField|XAxisFieldLabel|YAxisField1,YAxisField2...|YAxisFieldLabel|ZAxisField|ZAxisFieldLabel|ZAxisColorField
                return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", XaxisField, XaxisFieldLabel, YaxisFieldsCommaSeparated, YaxisFieldLabel, ZaxisField, ZaxisFieldLabel, ZaxisColorField);
            }
        }

        public EpmChartUserSettings()
        {
            YaxisFields = new List<string>();
        }

        public void Hydrate(PersonalizationData personalizationData)
        {
            WebPartId = personalizationData.ForeignKey;
            UserId = personalizationData.UserId;
            SiteId = personalizationData.SiteId;
            WebId = personalizationData.WebId;
            ListId = personalizationData.ListId;

            if (WebPartId != null && !string.IsNullOrEmpty(UserId) && SiteId != null && WebId != null && ListId != null)
            {
                PopulateUserSettings(personalizationData);
            }
        }

        private void PopulateUserSettings(PersonalizationData personalizationData)
        {
            if (personalizationData.Value == null) return;
            if(!personalizationData.Value.Contains("|")) return;
            
            var valueSections = personalizationData.Value.Split(new[] {'|'});

            if (valueSections.Length != 7) return;

            var xAxisField = valueSections[0];
            if (!string.IsNullOrEmpty(xAxisField))
            {
                XaxisField = xAxisField;
            }

            var xAxisFieldLabel = valueSections[1];
            if (!string.IsNullOrEmpty(xAxisFieldLabel))
            {
                XaxisFieldLabel = xAxisFieldLabel;
            }

            var yAxisFieldSection = valueSections[2];
            if (!string.IsNullOrEmpty(yAxisFieldSection))
            {
                var yAxisFields = yAxisFieldSection.Split(new[] {','});
                foreach (var yAxisField in yAxisFields)
                {
                    YaxisFields.Add(yAxisField);
                }
            }

            var yAxisFieldLabel = valueSections[3];
            if (!string.IsNullOrEmpty(yAxisFieldLabel))
            {
                YaxisFieldLabel = yAxisFieldLabel;
            }

            var zAxisField = valueSections[4];
            if (!string.IsNullOrEmpty(zAxisField))
            {
                ZaxisField = zAxisField;
            }

            var zAxisFieldLabel = valueSections[5];
            if (!string.IsNullOrEmpty(zAxisFieldLabel))
            {
                ZaxisFieldLabel = zAxisFieldLabel;
            }

            var zAxisColorField = valueSections[6];
            if (!string.IsNullOrEmpty(zAxisColorField))
            {
                ZaxisColorField = zAxisColorField;
            }

            IsValid = true;
        }
    }
}