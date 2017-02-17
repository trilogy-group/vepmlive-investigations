using System.Web;

namespace EPMLive.OnlineLicensing.Api
{
    public static class LoggerExtensions
    {

        /// <summary>
        /// Log info message connected with currently logged in user.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="message"></param>
        public static void LogActivity(this log4net.ILog logger, string message)
        {
            logger.InfoFormat("{0}: {1}", HttpContext.Current.User.Identity.Name, message);
        }
    }
}
