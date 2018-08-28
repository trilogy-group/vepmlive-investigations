using System;
using System.Data;
using PortfolioEngineCore;

namespace WorkEnginePPM.Layouts.ppm
{
    internal static class XmlHelper
    {
        internal static void FillFieldsXml(DataTable table, CStruct[] xLevels)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            if (xLevels?.Length < 2)
            {
                throw new ArgumentException("Must have at least 2 elements.", nameof(xLevels));
            }

            CStruct node;
            foreach (DataRow row in table.Rows)
            {
                var permissionLevel = SqlDb.ReadIntValue(row["PERM_LEVEL"]);
                if (permissionLevel > 0)
                {
                    var permissionUid = SqlDb.ReadIntValue(row["PERM_UID"]);
                    var permissionName = SqlDb.ReadStringValue(row["PERM_NAME"]);
                    CStruct parentNode;
                    if (permissionLevel == 1)
                    {
                        parentNode = xLevels[0];                      // grab the node we are adding a child to
                        node = parentNode.CreateSubStruct("I");         // add a new child
                        xLevels[1] = node;                            // save a new parent node at this new level
                        node.CreateIntAttr("FieldID", permissionUid);      //  carry on and define details for our new node
                        node.CreateStringAttr("CBType", "Text");        // don't want a cb on title lines
                        node.CreateBooleanAttr("CanEdit", false);
                    }
                    else
                    {
                        parentNode = xLevels[1];
                        node = parentNode.CreateSubStruct("I");
                        node.CreateIntAttr("FieldID", permissionUid);
                        node.CreateBooleanAttr("CanEdit", true);
                        var nJoinedGroup = SqlDb.ReadIntValue(row["GROUP_ID"]);
                        var permissionSet = nJoinedGroup > 0;
                        node.CreateBooleanAttr("CB", permissionSet);
                    }
                    node.CreateStringAttr("Permission", permissionName);

                    node.CreateStringAttr("Color", "254,254,254");
                    node.CreateIntAttr("NoColorState", 1);
                }
            }
        }
    }
}
