using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing; //added for gantt styles
using Microsoft.SharePoint.JSGrid;
using Microsoft.SharePoint;
using System.Xml;
using System.Text.RegularExpressions;
using System.Collections;
using Microsoft.SharePoint.JsonUtilities;
using System.Web.UI.WebControls;
using System.Data;

namespace EPMLiveWebParts
{
    public class GanttUtilities
    {
        public enum CustomBarStyle { Summary, Standard, Milestone, PctComplete, Critical, CriticalSummary }
        private static LookupTypeInfo lookupTypeInfo;
        private static List<string> imageNames;


        public static List<string> ImageNames
        {
            set { imageNames = value; }
        } 

        public static LookupTypeInfo GanttImage(Hashtable ganttImages, List<string> imgNames)
        {
            //Register a lookup table with the grid serializer that creates  a new property type:
            //gridSerializer.RegisterPropLookupType(lookupTypeInfo);
            //Then associate it with one or more GridFields:
            //gridField.AssociateWithLookupTypeInfo(lookupTypeInfo);
            //LookupTypeInfo lookupTypeInfo = new LookupTypeInfo("GanttImage",
            //    new[] { new LookupTypeItem(1, "") { ImageUrl = "/_layouts/images/RED.GIF" },
            //            new LookupTypeItem(2, "") { ImageUrl = "/_layouts/images/YELLOW.GIF" },
            //            new LookupTypeItem(3, "") { ImageUrl = "/_layouts/images/GREEN.GIF" },
            //            new LookupTypeItem(4, "") { ImageUrl = "/_layouts/images/checkmark.GIF" },
            //            new LookupTypeItem(5, "") { ImageUrl = "/_layouts/images/edit.GIF" }}) { ShowImage = true, ShowText = false };
            InitGanttImage(ganttImages, imgNames); 
            return lookupTypeInfo;
        }

        public static Hashtable GetImagesHashTable(DataTable dt)
        {
            Hashtable htImages = new Hashtable();
            return htImages;
        }

        private static void InitGanttImage(Hashtable Images, List<string> imgNames)
        {
            if (imgNames != null)
            {
                LookupTypeItem[] lookupitems = new LookupTypeItem[imgNames.Count];
                int i = 0;
                if (imgNames.Count > 0)
                {
                    foreach (string img in imgNames)
                    {
                        string url = "/_layouts/images/" + img;
                        LookupTypeItem li = new LookupTypeItem(Images[img.ToLower()], "") { ImageUrl = url };
                        if (li.Value != null && li.Value.ToString() != "")
                        {
                            lookupitems[i] = li;
                        }
                        i++;
                    }                  
                    lookupTypeInfo = new LookupTypeInfo("GanttImage", lookupitems) { ShowImage = true, ShowText = false };
                }
            }
        }


        public static GanttStyleInfo GetStyleInfo()
        {
            GanttStyleInfo styleInfoObj = new GanttStyleInfo();
            string start = "ganttStart"; //GridUtilities.GetDisplayName(GridUtilities.GanttStartField);
            string end = "ganttFinish"; //GridUtilities.GetDisplayName(GridUtilities.GanttEndField); 

            /*Summary Bar Style*/
            styleInfoObj.AddBarStyle(new GanttBarStyle(
                CustomBarStyle.Summary, BarShape.TopHalf, Color.Black, BarPattern.Solid,
                BarEndShape.HomePlateDown, Color.Black, BarShapePattern.Filled,
                BarEndShape.HomePlateDown, Color.Black, BarShapePattern.Filled,
                start, end, 2));

            /*Standard Bar Style*/
            styleInfoObj.AddBarStyle(new GanttBarStyle(
                CustomBarStyle.Standard, BarShape.Full, Color.Blue, BarPattern.Solid,
                BarEndShape.OpenBracket, Color.Black, BarShapePattern.Filled,
                BarEndShape.CloseBracket, Color.Black, BarShapePattern.Filled,
                start, end, 2));

            /*Milestone Bar Style*/
            styleInfoObj.AddBarStyle(new GanttBarStyle(
                CustomBarStyle.Milestone, BarShape.None, Color.Black, BarPattern.Solid,
                BarEndShape.None, Color.Black, BarShapePattern.Filled,
                BarEndShape.Diamond, Color.Black, BarShapePattern.Filled,
                start, end, 1));

            /*PctComplete Bar Style*/
            styleInfoObj.AddBarStyle(new GanttBarStyle(
                CustomBarStyle.PctComplete, BarShape.MidHalf, Color.Black, BarPattern.Solid,
                BarEndShape.None, Color.Black, BarShapePattern.Filled,
                BarEndShape.None, Color.Black, BarShapePattern.Filled,
                start, "CompleteThrough", 1));

            /*Critical Standard Bar Style*/
            styleInfoObj.AddBarStyle(new GanttBarStyle(
                CustomBarStyle.Critical, BarShape.Full, Color.Red, BarPattern.Solid,
                BarEndShape.OpenBracket, Color.Black, BarShapePattern.Filled,
                BarEndShape.CloseBracket, Color.Black, BarShapePattern.Filled,
                start, end, 2));

            /*Critical Summary Bar Style*/
            styleInfoObj.AddBarStyle(new GanttBarStyle(
                CustomBarStyle.CriticalSummary, BarShape.TopHalf, Color.Red, BarPattern.Solid,
                BarEndShape.HomePlateDown, Color.Black, BarShapePattern.Filled,
                BarEndShape.HomePlateDown, Color.Black, BarShapePattern.Filled,
                start, end, 1));

            return styleInfoObj;
        }        
    }

    public class GridImage : IJsonSerializable
    {
        public object key { get; set; }
        public string imageUrl { get; set; }
        public string ToJson(Serializer s)
        {
            return JsonUtility.SerializeToJsonFromProperties(s, this);
        }
    }

    public class Dependency : IJsonSerializable
    {
        public object Key { get; set; } // recordKey
        public LinkType Type { get; set; }

        public string ToJson(Serializer s)
        {
            return JsonUtility.SerializeToJsonFromProperties(s, this);
        }
    }

    public class FieldValues : IJsonSerializable
    {
        public string fieldKey { get; set; } // recordKey
        public object dataValue { get; set; }
        public object localizedValue { get; set; } 

        public string ToJson(Serializer s)
        {
            return JsonUtility.SerializeToJsonFromProperties(s, this);
        }
    }

}
