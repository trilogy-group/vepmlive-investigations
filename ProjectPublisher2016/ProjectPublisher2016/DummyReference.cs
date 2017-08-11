using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Tools;
namespace ProjectPublisher2016
{
    class DummyReference
    {
        public DummyReference()
        {
            var dummyType = typeof(ActionsPane);
            Console.WriteLine(dummyType.FullName);
        }
    }
}
