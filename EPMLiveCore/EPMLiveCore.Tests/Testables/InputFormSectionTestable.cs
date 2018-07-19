using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Tests.Testables
{
    /// <summary>
    /// Meant as a way to stub an InputFormSection member
    /// </summary>
    /// <remarks>
    /// The easiest way to stub a InputFormSection members to avoid them throwing a NullReferenceException. No specific funcitonality is required.
    /// </remarks>
    public class InputFormSectionTestable : InputFormSection
    {
    }
}
