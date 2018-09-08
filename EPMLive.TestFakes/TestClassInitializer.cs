using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLive.TestFakes
{
    /// <summary>
    ///   Common initializer for test classes
    /// </summary>
    /// <typeparam name="T">class</typeparam>
    /// <author>Mohamed A. AbdulHalim</author>
    [ExcludeFromCodeCoverage]
    public class TestClassInitializer<T> where T : class
    {
        protected const string DummyString = "DummyString";
        protected const int DummyInt = 1;

        public PrivateObject PrivateObject { get; set; }
        public PrivateType PrivateType { get; set; }
        public T TestEntity { get; set; }
        public IDisposable ShimObject { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            ShimObject = ShimsContext.Create();
            TestEntity = Activator.CreateInstance<T>();
            PrivateObject = new PrivateObject(TestEntity);
            PrivateType = new PrivateType(typeof(T));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ShimObject?.Dispose();
        }

        public TP Get<TP>(string fieldOrProperty)
        {
            return (TP)PrivateObject.GetFieldOrProperty(fieldOrProperty);
        }

        public TP GetStatic<TP>(string fieldOrProperty)
        {
            return (TP)PrivateType.GetStaticFieldOrProperty(fieldOrProperty);
        }

        protected void InitializeAllControls()
        {
            var fields = TestEntity.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                if (field.GetValue(TestEntity) == null)
                {
                    var constructor = field.FieldType.GetConstructor(new Type[0]);
                    if (constructor != null)
                    {
                        var obj = constructor.Invoke(new object[0]);
                        if (obj != null)
                        {
                            field.SetValue(TestEntity, obj);
                            TryLinkFieldWithPage(obj, TestEntity);
                        }
                    }
                }
            }
        }
        private void TryLinkFieldWithPage(object field, object page)
        {
            if (page is Page)
            {
                var fieldType = field.GetType().GetField("_page", BindingFlags.Public |
                                                                  BindingFlags.NonPublic |
                                                                  BindingFlags.Static |
                                                                  BindingFlags.Instance);
                if (fieldType != null)
                {
                    try
                    {
                        fieldType.SetValue(field, page);
                    }
                    catch (Exception ex)
                    {
                        // ignored
                        Trace.TraceError($"Unable to set value as :{ex}");
                    }
                }
            }
        }
    }
}
