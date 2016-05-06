using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Reflection;
using System.Linq;
using System.Web.UI.WebControls.WebParts;
using EPMLiveCore.Properties;
namespace EPMLiveCore.WebPartsHelper
{
    public static class WebPartsReflector
    {
        public static WebPart CreateGridListViewWebPart()
        {
            var asm = Assembly.Load(Resources.WebPartsAssembly);
            if (asm == null) throw new DllNotFoundException(Resources.WebPartsAssembly + ", not found");

            var types = asm.GetTypes();

            var gridListViewType = types.FirstOrDefault(t => t.Name == Resources.WebPartsGridListView);
            if (gridListViewType == null) throw new EntryPointNotFoundException(Resources.WebPartsAssembly + ", does not contain a definition for: " + Resources.WebPartsGridListView);

            var webPart = (WebPart)asm.CreateInstance(gridListViewType.FullName);

            return webPart;
        }

        public static WebPart CreateFancyDisplayFormWebPart()
        {
            var asm = Assembly.Load(Resources.WebPartsAssembly);
            if (asm == null) throw new DllNotFoundException(Resources.WebPartsAssembly + ", not found");

            var types = asm.GetTypes();

            var fancyDisplayFormType = types.FirstOrDefault(t => t.Name == Resources.WebPartsFancyDisplayForm);
            if (fancyDisplayFormType == null) throw new EntryPointNotFoundException(Resources.WebPartsAssembly + ", does not contain a definition for: " + Resources.WebPartsFancyDisplayForm);

            var webPart = (WebPart)asm.CreateInstance(fancyDisplayFormType.FullName);

            return webPart;
        }

        public static bool IsWebPartGridListView(WebPart wp)
        {
            if (wp == null) return false;

            var asm = Assembly.Load(Resources.WebPartsAssembly);
            if (asm == null) throw new DllNotFoundException(Resources.WebPartsAssembly + ", not found");

            var types = asm.GetTypes();

            var gridListViewType = types.FirstOrDefault(t => t.Name == Resources.WebPartsGridListView);
            if (gridListViewType == null) throw new EntryPointNotFoundException(Resources.WebPartsAssembly + ", does not contain a definition for: " + Resources.WebPartsGridListView);

            var wpType = wp.GetType();

            return gridListViewType.Equals(wpType);

        }

        public static object CreateMyWorkWebPart()
        {
            var asm = Assembly.Load(Resources.WebPartsAssembly);
            if (asm == null) throw new DllNotFoundException(Resources.WebPartsAssembly + ", not found");

            var types = asm.GetTypes();

            var myWorkType = types.FirstOrDefault(t => t.Name == Resources.WebPartsMyWork);
            if (myWorkType == null) throw new EntryPointNotFoundException(Resources.WebPartsAssembly + ", does not contain a definition for: " + Resources.WebPartsMyWork);

            var webPart = asm.CreateInstance(myWorkType.FullName);

            return webPart;
        }
        public static bool IsWebpartMyWorkWebPart(object myWorkWebPart)
        {
            if (myWorkWebPart == null) return false;

            var asm = Assembly.Load(Resources.WebPartsAssembly);
            if (asm == null) throw new DllNotFoundException(Resources.WebPartsAssembly + ", not found");

            var types = asm.GetTypes();

            var myWorkType = types.FirstOrDefault(t => t.Name == Resources.WebPartsMyWork);
            if (myWorkType == null) throw new EntryPointNotFoundException(Resources.WebPartsAssembly + ", does not contain a definition for: " + Resources.WebPartsMyWork);

            var wpType = myWorkWebPart.GetType();

            return myWorkType.Equals(wpType);
        }

        public static void SetWebPartProperty(object webPart, string property, string value)
        {
            if (webPart == null) throw new ArgumentNullException("webPart is null");

            var wpType = webPart.GetType();

            var prop = wpType.GetProperties().FirstOrDefault(p => p.Name == property && p.ReflectedType.Equals(wpType));
            if (prop == null) throw new ArgumentOutOfRangeException("Property: " + property + " does not exist for type: " + wpType.FullName);

            prop.SetValue(webPart, value);

        }
    }
}

