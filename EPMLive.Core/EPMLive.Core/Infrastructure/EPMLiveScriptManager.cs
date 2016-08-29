using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Infrastructure
{
    public class EPMLiveScriptManager
    {
        #region Fields (3) 

        private const string EPM_PATH = "/_layouts/15/epmlive/";
        private const string JS_PATH = EPM_PATH + "javascripts/";
        private static string _fileVersion;

        #endregion Fields 

        #region Properties (1) 

        public static string FileVersion
        {
            get
            {
                if (!string.IsNullOrEmpty(_fileVersion))
                {
                    return _fileVersion;
                }

                _fileVersion = GetFileVersion();
                return _fileVersion;
            }
        }

        #endregion Properties 

        #region Methods (4) 

        // Public Methods (2) 

        public static void RegisterScript(Page page, string script, bool localizable = false)
        {
            RegisterScript(page, new[] {script}, localizable);
        }

        public static void RegisterScript(Page page, string[] scripts, bool localizable = false)
        {
            if (page == null) return;

            bool debugMode = false;

            try
            {
                string debug = HttpContext.Current.Request.Params["epmdebug"];
                if ((debug ?? string.Empty).ToLower().Equals("true"))
                {
                    debugMode = true;
                }
            }
            catch { }

            var bundledScripts = new[]
            {
                "jquery", "jquery-ui", "UplandV5", "jquery.cookie", "tooltip", "bindWithDelay", "EPM"
            };

            foreach (string script in from script in scripts
                where !string.IsNullOrEmpty(script)
                select script.Trim().ToLower()
                into script
                where !string.IsNullOrEmpty(script)
                where !script.Equals("@")
                where !script.Equals("/")
                where !script.Equals("@/")
                select script)
            {
                string scrpt = script.Replace("@", string.Empty);

                if ((from bundledScript in bundledScripts
                    select bundledScript.ToLower()
                    into s
                    select new[] {s, s + ".js", s + ".min", s + ".min.js", s + ".debug.js"}
                    into variations
                    let pieces = scrpt.Split('/')
                    let currentScript = pieces[pieces.Length - 1]
                    where variations.Any(v => v.Equals(currentScript))
                    select variations).Any())
                {
                    continue;
                }

                bool defer = !scrpt.Equals("masterpages/uplandv5.master");
                SPPageContentManager.RegisterScriptFile(page, GetScript(script, debugMode), localizable, defer, "javascript", null);
            }
        }

        // Private Methods (2) 

        private static string GetFileVersion()
        {
            return (string) CacheStore.Current.Get("EPMLiveFileVersion", CacheStoreCategory.Infrastructure, () =>
            {
                string version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

                if (string.IsNullOrEmpty(version) || version.Equals("1.0.0.0"))
                {
                    version = DateTime.Now.ToString("M.d.yyyy");
                }

                return version;
            }, true).Value;
        }

        private static string GetScript(string script, bool debugMode)
        {
            bool debuggable = script.StartsWith("@");
            if (!script.EndsWith(".js")) script += ".js";

            if (debuggable)
            {
                script = script.Replace("@", string.Empty).Replace(".min", string.Empty);

                if (!debugMode)
                {
                    script = script.Replace(".js", ".min.js");
                }
            }

            bool useEpmPath = script.StartsWith("/");
            if (useEpmPath) script = script.Substring(1, script.Length - 1);

            return Path.Combine(useEpmPath ? EPM_PATH : JS_PATH, string.Format(@"{0}?v={1}", script, FileVersion));
        }

        #endregion Methods 
    }
}