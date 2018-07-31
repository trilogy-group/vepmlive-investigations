using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Flags]
public enum GridRenderingTypes
{
    None = 0,
    Layout = 1,
    Data = 2,
    Combined = Layout | Data
}