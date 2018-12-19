using System;
using System.Collections;
using Microsoft.SharePoint;

namespace EPMLiveWebParts.WebPageCode
{
    public static class GroupHelper
    {
        public static void ProcessTempGroups(SortedList arrGTemp, SPField field, string newGroup, ref string[] tempGroup)
        {
            if (tempGroup == null)
            {
                throw new ArgumentNullException(nameof(tempGroup));
            }
            if (field != null && (field.Type == SPFieldType.User || field.Type == SPFieldType.MultiChoice))
            {
                var groups = newGroup?.Split('\n');
                var tmpGroups = new string[tempGroup.Length * groups.Length];
                var tmpCounter = 0;

                foreach (var str in tempGroup)
                {
                    foreach (var sGroup in groups)
                    {
                        if (str == null)
                        {
                            tmpGroups[tmpCounter] = sGroup.Trim();
                        }
                        else
                        {
                            tmpGroups[tmpCounter] = $"{str}\n{sGroup.Trim()}";
                        }

                        if (!arrGTemp.Contains(tmpGroups[tmpCounter]))
                        {
                            arrGTemp.Add(tmpGroups[tmpCounter], string.Empty);
                        }

                        tmpCounter++;
                    }
                }

                tempGroup = tmpGroups;
            }
            else
            {
                for (var i = 0; i < tempGroup.Length; i++)
                {
                    if (tempGroup[i] == null)
                    {
                        tempGroup[i] = newGroup;
                    }
                    else
                    {
                        tempGroup[i] += $"\n{newGroup}";
                    }

                    if (!arrGTemp.Contains(tempGroup[i]))
                    {
                        arrGTemp.Add(tempGroup[i], string.Empty);
                    }
                }
            }
        }
    }
}