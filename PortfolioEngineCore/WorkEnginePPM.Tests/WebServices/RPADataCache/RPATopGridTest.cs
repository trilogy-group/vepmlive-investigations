using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using ResourceValues;
using RPADataCache;
using WorkEnginePPM.Tests.TestDoubles.RPADataCache;

namespace WorkEnginePPM.Tests.WebServices.RPADataCache
{
    [TestClass]
    public class RPATopGridTest
    {
        private IDisposable _shimsContext;

        private IList<clsRXDisp> _columns;
        private int _pmoAdmin;
        private string _xmlString;
        private int _displayMode;
        private IList<RPATGRow> _displayList;
        private clsResourceValues _resourceValues;
        private clsLookupList _categoryLookupList;
        private GridRenderingTypes _renderingType;
        private RPATopGridTestDouble _testDouble;

        private ICollection<string> _substructsCreated;
        private IDictionary<string, IDictionary<string, string>> _stringAttributesCreated;
        private IDictionary<string, IDictionary<string, bool>> _booleanAttributesCreated;
        private IDictionary<string, IDictionary<string, int>> _intAttributesCreated;
        private IDictionary<string, IDictionary<string, double>> _doubleAttributesCreated;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            _renderingType = GridRenderingTypes.Combined;

            _columns = new []
            {
                new clsRXDisp { m_id = RPConstants.TGRID_RES_ID, m_realname = "test-name-1 /n\r\n", m_dispname = "test-name-1 /n\r\n", },
                new clsRXDisp { m_id = RPConstants.TGRID_ROLE_ID, m_realname = "test-name-2 /n\r\n", m_dispname = "test-name-2 /n\r\n" }
            };
            _displayList = new[] 
            {
                new RPATGRow { }
            };
            _pmoAdmin = 0;
            _xmlString = string.Format("<Result><View><g_1 Cols='{0}'></g_1></View></Result>", 
                string.Join(",", _columns.Select(pred => pred.m_id).ToArray()));
            _displayMode = 0;
            _resourceValues = new clsResourceValues();
            _categoryLookupList = new clsLookupList();

            _testDouble = CreateTestDouble();

            _substructsCreated = new HashSet<string>();
            _stringAttributesCreated = new Dictionary<string, IDictionary<string, string>>();
            _booleanAttributesCreated = new Dictionary<string, IDictionary<string, bool>>();
            _intAttributesCreated = new Dictionary<string, IDictionary<string, int>>();
            _doubleAttributesCreated = new Dictionary<string, IDictionary<string, double>>();

            ShimCStruct.AllInstances.CreateSubStructString = (instance, subStructName) =>
            {
                _substructsCreated.Add(subStructName);

                return new ShimCStruct
                {
                    NameGet = () => subStructName
                };
            };

            ShimCStruct.AllInstances.CreateStringAttrStringString = (element, name, value) =>
            {
                if (!_stringAttributesCreated.ContainsKey(element.Name))
                {
                    _stringAttributesCreated[element.Name] = new Dictionary<string, string>();
                }

                _stringAttributesCreated[element.Name][name] = value;
            };
            ShimCStruct.AllInstances.CreateBooleanAttrStringBoolean = (element, name, value) =>
            {
                if (!_booleanAttributesCreated.ContainsKey(element.Name))
                {
                    _booleanAttributesCreated[element.Name] = new Dictionary<string, bool>();
                }

                _booleanAttributesCreated[element.Name][name] = value;
            };
            ShimCStruct.AllInstances.CreateIntAttrStringInt32 = (element, name, value) =>
            {
                if (!_intAttributesCreated.ContainsKey(element.Name))
                {
                    _intAttributesCreated[element.Name] = new Dictionary<string, int>();
                }

                _intAttributesCreated[element.Name][name] = value;
            };
            ShimCStruct.AllInstances.CreateDoubleAttrStringDouble = (element, name, value) =>
            {
                if (!_doubleAttributesCreated.ContainsKey(element.Name))
                {
                    _doubleAttributesCreated[element.Name] = new Dictionary<string, double>();
                }

                _doubleAttributesCreated[element.Name][name] = value;
            };
        }
        
        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
        }

        private RPATopGridTestDouble CreateTestDouble()
        {
            return new RPATopGridTestDouble(
                _columns,
                _pmoAdmin,
                _xmlString,
                _displayMode,
                _displayList,
                _resourceValues,
                _categoryLookupList
            );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InitializeGridLayout_RenderingTypeNone_Throws()
        {
            // Arrange
            _renderingType = GridRenderingTypes.None;

            // Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert
            // ExpectedException - ArgumentException
        }

        [TestMethod]
        public void InitializeGridLayout_Always_InitializesLayoutConfigToolbar()
        {
            // Arrange, Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert
            Assert.IsTrue(_substructsCreated.Contains("Toolbar"));
            Assert.AreEqual(0, _intAttributesCreated["Toolbar"]["Visible"]);
        }

        [TestMethod]
        public void InitializeGridLayout_Always_InitializesLayoutConfigPanel()
        {
            // Arrange, Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert
            Assert.IsTrue(_substructsCreated.Contains("Panel"));
            Assert.AreEqual(0, _intAttributesCreated["Panel"]["Visible"]);
            Assert.AreEqual(0, _intAttributesCreated["Panel"]["Select"]);
            Assert.AreEqual(0, _intAttributesCreated["Panel"]["Delete"]);
            Assert.AreEqual(0, _intAttributesCreated["Panel"]["CanHide"]);
            Assert.AreEqual(0, _intAttributesCreated["Panel"]["CanSelect"]);
        }

        [TestMethod]
        public void InitializeGridLayout_Always_InitializesLayoutConfigCfg()
        {
            // Arrange, Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert
            Assert.IsTrue(_substructsCreated.Contains("Cfg"));
            Assert.AreEqual("PortfolioItem", _stringAttributesCreated["Cfg"]["MainCol"]);
            Assert.AreEqual("GTACCNPSQEBSLC", _stringAttributesCreated["Cfg"]["Code"]);
            Assert.AreEqual(3, _intAttributesCreated["Cfg"]["SuppressCfg"]);
            Assert.AreEqual(3, _intAttributesCreated["Cfg"]["SuppressMessage"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["PrintCols"]);
            Assert.AreEqual(_pmoAdmin, _intAttributesCreated["Cfg"]["Dragging"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["Sorting"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["ColsMoving"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["ColsPosLap"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["ColsLap"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["VisibleLap"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["SectionWidthLap"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["GroupLap"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["WideHScroll"]);
            Assert.AreEqual(150, _intAttributesCreated["Cfg"]["LeftWidth"]);
            Assert.AreEqual(400, _intAttributesCreated["Cfg"]["Width"]);
            Assert.AreEqual(800, _intAttributesCreated["Cfg"]["RightWidth"]);
            Assert.AreEqual(50, _intAttributesCreated["Cfg"]["MinMidWidth"]);
            Assert.AreEqual(400, _intAttributesCreated["Cfg"]["MinRightWidth"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["LeftCanResize"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["RightCanResize"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["FocusWholeRow"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["MaxHeight"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["ShowDeleted"]);
            Assert.AreEqual(true, _booleanAttributesCreated["Cfg"]["DateStrings"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["MaxWidth"]);
            Assert.AreEqual(2, _intAttributesCreated["Cfg"]["MaxSort"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["AppendId"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["FullId"]);
            Assert.AreEqual("0123456789", _stringAttributesCreated["Cfg"]["IdChars"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["NumberId"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["LastId"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["CaseSensitiveId"]);
            Assert.AreEqual("GM", _stringAttributesCreated["Cfg"]["Style"]);
            Assert.AreEqual("ResPlanAnalyzer", _stringAttributesCreated["Cfg"]["CSS"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["FastColumns"]);
            Assert.AreEqual(3, _intAttributesCreated["Cfg"]["ExpandAllLevels"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["GroupSortMain"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["GroupRestoreSort"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["NoTreeLines"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["ShowVScroll"]);
        }

        [TestMethod]
        public void InitializeGridLayout_Always_InitializesColumns()
        {
            // Arrange, Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert
            Assert.IsTrue(_substructsCreated.Contains("LeftCols"));
            Assert.IsTrue(_substructsCreated.Contains("Cols"));
            Assert.IsTrue(_substructsCreated.Contains("RightCols"));
            Assert.AreEqual("RightCols", _testDouble.PeriodCols.Name);
            Assert.AreEqual("Cols", _testDouble.MiddleCols.Name);
        }

        [TestMethod]
        public void InitializeGridLayout_Always_InitializesDefinitions()
        {
            // Arrange
            var definitionsInitialized = new List<string>();
            ShimGridBase<CPeriod, Tuple<clsResXData, clsPIData>>.AllInstances.InitializeGridLayoutDefinitionString = (instance, name) =>
            {
                definitionsInitialized.Add(name);
                return new PortfolioEngineCore.CStruct();
            };

            // Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert
            Assert.AreEqual(2, definitionsInitialized.Count);
            Assert.IsTrue(definitionsInitialized.Contains("R"));
            Assert.IsTrue(definitionsInitialized.Contains("Leaf"));
        }

        [TestMethod]
        public void InitializeGridLayout_Always_InitializesHeaders()
        {
            // Arrange, Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert
            Assert.IsTrue(_substructsCreated.Contains("Head"));
            Assert.IsTrue(_substructsCreated.Contains("Filter"));
            Assert.AreEqual("Filter", _stringAttributesCreated["Filter"]["id"]);
            Assert.AreEqual(1, _intAttributesCreated["Header"]["PortfolioItemVisible"]);
            Assert.AreEqual(1, _intAttributesCreated["Header"]["NoEscape"]);
        }

        [TestMethod]
        public void InitializeGridLayout_Always_InitializesCategoryColumns()
        {
            // Arrange
            var nameAttributeValues = new HashSet<string>();
            var typeAttributeValues = new HashSet<string>();
            ShimCStruct.AllInstances.CreateStringAttrStringString = (element, name, value) =>
            {
                if (name == "Name")
                {
                    nameAttributeValues.Add(value);
                }
                if (name == "Type")
                {
                    typeAttributeValues.Add(value);
                }
            };

            // Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert
            Assert.IsTrue(nameAttributeValues.Contains("RowSel"));
            Assert.IsTrue(typeAttributeValues.Contains("Icon"));
            Assert.IsTrue(nameAttributeValues.Contains("rowid"));
            Assert.IsTrue(typeAttributeValues.Contains("Text"));
            Assert.IsTrue(nameAttributeValues.Contains("Select"));
            Assert.IsTrue(typeAttributeValues.Contains("Bool"));
            Assert.IsTrue(nameAttributeValues.Contains("ChangedIcon"));
            Assert.IsTrue(typeAttributeValues.Contains("Type"));
            Assert.IsTrue(nameAttributeValues.Contains("RowDraggable"));
            Assert.IsTrue(typeAttributeValues.Contains("Bool"));
            Assert.IsTrue(nameAttributeValues.Contains("RowChanged"));
            Assert.IsTrue(typeAttributeValues.Contains("Int"));
        }

        [TestMethod]
        public void InitializeGridLayout_Always_InitializesViewColumns()
        {
            // Arrange
            var nameAttributeValues = new HashSet<string>();
            ShimCStruct.AllInstances.CreateStringAttrStringString = (element, name, value) =>
            {
                if (name == "Name")
                {
                    nameAttributeValues.Add(value);
                }
            };

            // Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert
            foreach (var column in _columns)
            {
                Assert.IsTrue(nameAttributeValues.Contains(column.m_realname
                    .Replace(" ", string.Empty)
                    .Replace("\r", string.Empty)
                    .Replace("\n", string.Empty)
                    .Replace("/n", string.Empty)
                ));
            }
        }
    }
}
