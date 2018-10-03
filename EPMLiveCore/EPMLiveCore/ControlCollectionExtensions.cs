using System;
using System.Web.UI;

namespace EPMLiveCore
{
    public static class ControlCollectionExtensions
    {
        public static void AddAfter(this ControlCollection collection, Control after, Control control)
        {
            int indexFound = -1;
            int currentIndex = 0;
            foreach (Control controlToEvaluate in collection)
            {
                if (controlToEvaluate == after)
                {
                    indexFound = currentIndex;
                    break;
                }

                currentIndex = currentIndex + 1;
            }

            if (indexFound == -1)
            {
                throw new ArgumentOutOfRangeException("control", "Control not found");
            }

            collection.AddAt(indexFound + 1, control);
        }
    }
}