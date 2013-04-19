using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.SharePoint;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Infrastructure
{
    internal static class UpgradeUtilities
    {
        #region Methods (2) 

        // Internal Methods (2) 

        internal static List<Type> GetUpgradeSteps()
        {
            var versionedSteps = new Dictionary<double, Type>();
            var genericSteps = new Dictionary<double, Type>();

            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.BaseType != typeof (UpgradeStep)) continue;

                var attribute =
                    type.GetCustomAttributes(typeof (UpgradeStepAttribute), true).FirstOrDefault() as
                    UpgradeStepAttribute;

                if (attribute == null) continue;

                if (attribute.Version == EPMLiveVersion.GENERIC)
                {
                    genericSteps.Add(attribute.SequenceOrder, type);
                }
                else
                {
                    versionedSteps.Add(attribute.SequenceOrder, type);
                }
            }

            List<Type> steps = versionedSteps.OrderBy(s => s.Key).Select(s => s.Value).ToList();
            steps.AddRange(genericSteps.OrderBy(s => s.Key).Select(source => source.Value));

            return steps;
        }

        internal static SPField TryAddField(string internalName, string displayName, SPFieldType spFieldType,
                                            SPList spList, out string message, out MessageKind messageKind)
        {
            if (string.IsNullOrEmpty(internalName)) throw new ArgumentNullException("internalName");
            if (string.IsNullOrEmpty(displayName)) throw new ArgumentNullException("displayName");
            if (spList == null) throw new ArgumentNullException("spList");

            if (spList.Fields.ContainsFieldWithInternalName(internalName))
            {
                message = @"Field already exists.";
                messageKind = MessageKind.SKIPPED;

                return null;
            }

            SPField spField = spList.Fields.CreateNewField(spFieldType.ToString(), internalName);
            spList.Fields.Add(spField);
            spList.Update();

            SPField field = spList.Fields.GetFieldByInternalName(internalName);
            field.Title = displayName;
            field.Update();

            message = @"Field successfully added.";
            messageKind = MessageKind.SUCCESS;

            return field;
        }

        #endregion Methods 
    }
}