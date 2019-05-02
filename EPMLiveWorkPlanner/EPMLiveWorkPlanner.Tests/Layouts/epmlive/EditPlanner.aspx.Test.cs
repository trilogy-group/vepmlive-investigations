using System;
using System.Reflection;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using EPMLive.TestFakes.Utility;
using EPMLiveWorkPlanner.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;

namespace EPMLiveWorkPlanner.Tests.Layouts.epmlive
{
    [TestClass, ExcludeFromCodeCoverage]
    public class EditPlannerTest
    {
        private MethodInfo _buttonClick1Method;
        private editplanner _editplanner;
        private EventArgs _args;
        private PlannerCore.WorkPlannerProperties _wps;
        private IDisposable _shimsContext;
        protected AdoShims _adoShims;
        protected SharepointShims _sharepointShims;
       
        private void SetupShims(bool isEdit)
        {          
            _shimsContext = ShimsContext.Create();
            _buttonClick1Method = typeof(editplanner).GetMethod("btnAdd_Click", BindingFlags.Instance | BindingFlags.NonPublic);
            _editplanner = new editplanner();
            _args = new EventArgs();
            _adoShims = AdoShims.ShimAdoNetCalls();
            _sharepointShims = SharepointShims.ShimSharepointCalls();

            ShimHttpRequest.AllInstances.ItemGetString = (_, __) =>
            {
                var result = string.Empty;
                return result;
            };

            _wps = new PlannerCore.WorkPlannerProperties("f1|Min");
            StateBag _stateBag = new StateBag();

            HttpRequest _httpRequest = new HttpRequest("", "http://dummy.url", "");

            ShimHttpRequest _pageHttpRequest = new ShimHttpRequest()
            {
                ItemGetString = input =>
                {
                    switch (input)
                    {
                        case "ctl00$PlaceHolderMain$hdnId":
                            return "f1";

                        case "ctl00$PlaceHolderMain$hdnOperationType":
                            return isEdit? "edit" : "add";

                        default:
                            return $"Dummy{input}";
                    }
                }
            };
            ShimPage.AllInstances.RequestGet = sender => _pageHttpRequest;

            PrivateObject _privateObject = new PrivateObject(_editplanner);

            _privateObject.SetField("ddlAddCalculation", new DropDownList() { SelectedValue = "Max" });
            _privateObject.SetField("txtAddField", new TextBox() { Text = "f2" });


            Shimeditplanner.AllInstances.loadTaskCenterFieldsSPWebBoolean = (planner, web, flag) => { };
            Shimeditplanner.AllInstances.loadFieldsSPWeb = (planner, web) => { };

            ShimControl.AllInstances.ViewStateGet = _ => _stateBag;
            _stateBag["EPMLIVE-WPS"] = _wps;
        }

        [TestMethod]
        public void btnAdd_Clicked_Edit()
        {
            // Initialize
            SetupShims(true);
                       
            // Act
            _buttonClick1Method.Invoke(_editplanner, new object[] { null, _args });

            // Assert            
            Assert.AreEqual(1, _wps.count());           
        }

        [TestMethod]
        public void btnAdd_Clicked_Add()
        {
            // Initialize
            SetupShims(false);

            // Act
            _buttonClick1Method.Invoke(_editplanner, new object[] { null, _args });

            // Assert            
            Assert.AreEqual(2, _wps.count());
        }
    }
}
