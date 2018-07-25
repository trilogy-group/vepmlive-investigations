using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void InitializeGridLayout_Always_InitializesLayoutConfig()
        {
            // Arrange, Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert

        }
    }
}
