using System;
using System.Drawing;

namespace EPMLiveWebParts.EpmCharting.DomainServices
{
    public static class HtmlColorService
    {
        public static Color GetRandomHtmlColor()
        {
            return Color.FromArgb(RandomNumber(0, 255), RandomNumber(0, 255), RandomNumber(0, 255));
        }

        /// <summary>
        /// Used to get a predefined color up to an index of 10, anything higher will be a random color.
        /// This is for things such as a chart that needs to show color in a legend dynamically and not change them randomly every time.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public static Color GetPredefinedColorBasedOnIndex(int index)
        {
            //TODO: This is sort of a strange method, that is really currenly suited for the bubble chart legend. Maybe it should live there instead of here since it doesn't have a usage outside of that scope.
            var colorToReturn = new Color();
            
            switch (index)
            {
                case 1:
                    colorToReturn = ColorTranslator.FromHtml("#ff5700");
                    break;
                case 2:
                    colorToReturn = ColorTranslator.FromHtml("#ffe800");
                    break;
                case 3:
                    colorToReturn = ColorTranslator.FromHtml("#ff0066");
                    break;
                case 4:
                    colorToReturn = ColorTranslator.FromHtml("#ffda00");
                    break;
                case 5:
                    colorToReturn = ColorTranslator.FromHtml("#ff0c00");
                    break;
                case 6:
                    colorToReturn = ColorTranslator.FromHtml("#ff00d8");
                    break;
                case 7:
                    colorToReturn = ColorTranslator.FromHtml("#ff005a");
                    break;
                case 8:
                    colorToReturn = ColorTranslator.FromHtml("#ff000a");
                    break;
                case 9:
                    colorToReturn = ColorTranslator.FromHtml("#ffeb00");
                    break;
                case 10:
                    colorToReturn = ColorTranslator.FromHtml("#f0f0f0");
                    break;
                default:
                    colorToReturn =  GetRandomHtmlColor();
                    break;
            }

            return colorToReturn;
        }

        private static readonly Random Random = new Random();
        private static readonly object SyncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (SyncLock)
            { // synchronize
                return Random.Next(min, max);
            }
        }
    }
}