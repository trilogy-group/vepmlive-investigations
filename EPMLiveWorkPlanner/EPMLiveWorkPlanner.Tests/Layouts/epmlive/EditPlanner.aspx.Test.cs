using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Diagnostics.CodeAnalysis;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPMLive.TestFakes.Utility;
using EPMLiveWorkPlanner.Fakes;
using System.Collections.Generic;

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
        private StateBag _stateBag;
        private ShimHttpRequest _pageHttpRequest;
        private SharepointShims _sharepointShims;
        private PrivateObject _privateObject;
        private List<IDisposable> disposables;

        [TestInitialize]
        public void TestInitialize()
        {
            _editplanner = new editplanner();
            _privateObject = new PrivateObject(_editplanner);
            disposables = new List<IDisposable>();

            SetupShims();
        }

        [TestCleanup]    
        public void TestCleanup()
        {
            disposables.ForEach(d => d?.Dispose());
        }

        private void SetupShims()
        {
            _shimsContext = ShimsContext.Create();
            _buttonClick1Method = typeof(editplanner).GetMethod("btnAdd_Click", BindingFlags.Instance | BindingFlags.NonPublic);
            _args = new EventArgs();
            _stateBag = new StateBag();
            _sharepointShims = SharepointShims.ShimSharepointCalls();
            disposables.Add(_shimsContext);

            ShimHttpRequest.AllInstances.ItemGetString = (_, __) =>
            {
                var result = string.Empty;
                return result;
            };

            _wps = new PlannerCore.WorkPlannerProperties("f1|Min");

            var dropDownList = new DropDownList() { SelectedValue = "Max" };
            _privateObject.SetField("ddlAddCalculation", dropDownList);
            disposables.Add(dropDownList);

            var textBox =  new TextBox() { Text = "f2" };
            _privateObject.SetField("txtAddField", textBox);
            disposables.Add(textBox);

            Shimeditplanner.AllInstances.loadTaskCenterFieldsSPWebBoolean = (planner, web, flag) => { };
            Shimeditplanner.AllInstances.loadFieldsSPWeb = (planner, web) => { };

            ShimControl.AllInstances.ViewStateGet = _ => _stateBag;
            _stateBag["EPMLIVE-WPS"] = _wps;
        }

        private void SetupRequest(bool isEdit)
        {                     
            _pageHttpRequest = new ShimHttpRequest()
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
        }

        [TestMethod]
        public void btnAdd_Clicked_Edit()
        {
            // Initialize
            SetupRequest(true);
                       
            // Act
            _buttonClick1Method.Invoke(_editplanner, new object[] { null, _args });

            // Assert            
            Assert.AreEqual(1, _wps.count());           
        }

        [TestMethod]
        public void btnAdd_Clicked_Add()
        {
            // Initialize
            SetupRequest(false);

            // Act
            _buttonClick1Method.Invoke(_editplanner, new object[] { null, _args });

            // Assert            
            Assert.AreEqual(2, _wps.count());
        }
    }
}
