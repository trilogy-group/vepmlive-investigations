using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using System.Reflection;
using System.Collections;

namespace EPMLiveCore
{
    internal class ReflectionMethods
    {
        public static string GetStatusMethod(SPWeb web, string ListTitle)
        {
            Assembly assemblyInstance = Assembly.Load("EPMLiveWorkPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
            Type thisClass = assemblyInstance.GetType("EPMLiveWorkPlanner.PlannerCore", true, true);
            MethodInfo m = thisClass.GetMethod("getStatusMethod");
            return (string)m.Invoke(null, new object[] { web, ListTitle });

            //return EPMLiveWorkPlanner.PlannerCore.getStatusMethod(web, properties.ListTitle);
        }

        public static SortedList GetWorkPlannerStatusFields(SPWeb parentWeb, string ListTitle)
        {
            Assembly assemblyInstance = Assembly.Load("EPMLiveWorkPlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
            Type thisClass = assemblyInstance.GetType("EPMLiveWorkPlanner.PlannerCore", true, true);
            MethodInfo m = thisClass.GetMethod("getWorkPlannerStatusFields");
            return (SortedList)m.Invoke(null, new object[] { parentWeb, ListTitle });

            //EPMLiveWorkPlanner.PlannerCore.getWorkPlannerStatusFields(oTaskCenter.ParentWeb, oTaskCenter.Title);
        }

        
        
    }
}
