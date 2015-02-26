using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web.Services.Protocols;
using PSLibrary = Microsoft.Office.Project.Server.Library;

namespace EPMLiveEnterprise
{
   class ExceptionHandlers
   {
      public static string HandleSoapException(SoapException ex)
      {
         PSLibrary.PSClientError error = new PSLibrary.PSClientError(ex);
         PSLibrary.PSErrorInfo[] errors = error.GetAllErrors();
         string errMess = "==============================\r\nError: \r\n";
         for (int i = 0; i < errors.Length; i++)
         {
            errMess += "\n" + ex.Message.ToString() + "\r\n";
            errMess += "".PadRight(30, '=') + "\r\nPSCLientError Output:\r\n \r\n";
            errMess += errors[i].ErrId.ToString() + "\n";

            for (int j = 0; j < errors[i].ErrorAttributes.Length; j++)
            {
               errMess += "\r\n\t" + errors[i].ErrorAttributeNames()[j] + ": "
                  + errors[i].ErrorAttributes[j];
            }
            errMess += "\r\n".PadRight(30, '=');
         }
         return errMess;
      }

      public static string HandleWebException(WebException ex)
      {
         string errMess = ex.Message.ToString() +
            "\n\nLog on, or check the Project Server Queuing Service";
         return ("Error: " + errMess);
      }

      public static string HandleException(Exception ex)
      {
         return("Error: " + ex.Message);
      }

      
   }
}
