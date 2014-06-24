using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace EPMLiveWebParts.ReportingChart
{
    public static class ColorPalettes
    {
        public static Color[] BluePalette
        {
            get
            {
                return new Color[] {
                    Color.FromArgb(76, 184, 255),
                    Color.FromArgb(0, 77, 127),
                    Color.FromArgb(0, 154, 255),
                    Color.FromArgb(38, 92, 127),
                    Color.FromArgb(0, 123, 204)
                };
            }
        }

        public static Color[] RedPalette
        {
            get
            {
                return new Color[] {
                    Color.FromArgb(255, 152, 155),
                    Color.FromArgb(127, 38, 41),
                    Color.FromArgb(255, 76, 82),
                    Color.FromArgb(127, 76, 78),
                    Color.FromArgb(204, 60, 65)
                };
            }
        }

        public static Color[] YellowPalette
        {
            get
            {
                return new Color[] {
                    Color.FromArgb(255, 242, 186),
                    Color.FromArgb(127, 114, 55),
                    Color.FromArgb(255, 227, 110),
                    Color.FromArgb(127, 121, 93),
                    Color.FromArgb(204, 182, 88)
                };
            }
        }

        public static Color[] GreenPalette
        {
            get
            {
                return new Color[] {
                    Color.FromArgb(127, 255, 80),
                    Color.FromArgb(91, 127, 78),
                    Color.FromArgb(183, 255, 156),
                    Color.FromArgb(64, 127, 40),
                    Color.FromArgb(146, 204, 125)
                };
            }
        }

        public static Color[] GrayPalette
        {
            get
            {
                return new Color[] {
                    Color.FromArgb(127, 127, 127),
                    Color.FromArgb(191, 191, 191),
                    Color.FromArgb(255, 255, 255),
                    Color.FromArgb(64, 64, 64),
                    Color.FromArgb(229, 229, 229)
                };
            }
        }

        public static Color[] Violet
        {
            get
            {
                return new Color[] {
                    Color.FromArgb(235, 215, 255),
                    Color.FromArgb(99, 69, 127),
                    Color.FromArgb(198, 139, 255),
                    Color.FromArgb(118, 108, 127),
                    Color.FromArgb(158, 111, 204)
                };
            }
        }

        public static Color[] Color1
        {
            
            get
            {
               return new Color[] {
                    ColorTranslator.FromHtml("#4386d8"),
                    ColorTranslator.FromHtml("#ff9a2e"),
                    ColorTranslator.FromHtml("#db443f"),
                    ColorTranslator.FromHtml("#a8d44f"),
                    ColorTranslator.FromHtml("#8560b3"),
                    ColorTranslator.FromHtml("#3cbfe3"),
                    ColorTranslator.FromHtml("#AFD8F8"),
                    ColorTranslator.FromHtml("#008E8E"),
                    ColorTranslator.FromHtml("#8BBA00"),
                    ColorTranslator.FromHtml("#FABD0F"),
                    ColorTranslator.FromHtml("#FA6E46"),
                    ColorTranslator.FromHtml("#9D080D"),
                    ColorTranslator.FromHtml("#A186BE"),
                    ColorTranslator.FromHtml("#CC6600"),
                    ColorTranslator.FromHtml("#FDC689")
                };
            }
        }

        public static Color[] Color2
        {
            
            get
            {
               return new Color[] {
                    //ColorTranslator.FromHtml("#00aFb0"),
                    //ColorTranslator.FromHtml("#58a128"),
                    //ColorTranslator.FromHtml("#3762ba"),
                    //ColorTranslator.FromHtml("#ff66bb"),
                    //ColorTranslator.FromHtml("#88c8d6"),
                    //ColorTranslator.FromHtml("#ffcc00"),
                    //ColorTranslator.FromHtml("#2fefef"),
                    //ColorTranslator.FromHtml("#f84000"),
                    //ColorTranslator.FromHtml("#7a7363"),
                    //ColorTranslator.FromHtml("#b3c631"),
                    //ColorTranslator.FromHtml("#ff97a3"),
                    //ColorTranslator.FromHtml("#956da3"),
                    //ColorTranslator.FromHtml("#31b77c"),
                    //ColorTranslator.FromHtml("#b2bebf"),
                    //ColorTranslator.FromHtml("#1999dd")


                    ColorTranslator.FromHtml("#2ecc71"),
                    ColorTranslator.FromHtml("#0090CA"),
                    ColorTranslator.FromHtml("#e74c3c"),
                    ColorTranslator.FromHtml("#C06FE2"),
                    ColorTranslator.FromHtml("#FFC000"),
                    ColorTranslator.FromHtml("#7c7c7c"),


                    ColorTranslator.FromHtml("#27ae60"),
                    ColorTranslator.FromHtml("#00668E"),
                    ColorTranslator.FromHtml("#9E480E"),
                    ColorTranslator.FromHtml("#5E0089"),
                    ColorTranslator.FromHtml("#d35400"),
                    ColorTranslator.FromHtml("#555555"),

                    ColorTranslator.FromHtml("#1abc9c"),
                    ColorTranslator.FromHtml("#26C6F4"),
                    ColorTranslator.FromHtml("#c0392b"),
                    ColorTranslator.FromHtml("#8e44ad"),
                    ColorTranslator.FromHtml("#e67e22"),
                    ColorTranslator.FromHtml("#A5A5A5"),

                    ColorTranslator.FromHtml("#73E2CA"),
                    ColorTranslator.FromHtml("#82E3FF"),
                    ColorTranslator.FromHtml("#E57A70"),
                    ColorTranslator.FromHtml("#CC9FE0"),
                    ColorTranslator.FromHtml("#FFE18E"),
                    ColorTranslator.FromHtml("#e2e2e2")

                };
            }
        }
    }
}
