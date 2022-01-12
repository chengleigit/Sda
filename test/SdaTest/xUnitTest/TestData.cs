using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace SdaTest
{
    public class TestData
    {
        private static readonly List<object[]> List = new List<object[]>
        {
            new object[] {0, 100},
            new object[] {1, 101},
            new object[] {50, 150},
            new object[] {101, 201}
        };

        public static IEnumerable<object[]> Data => List;
    }

    public class TestData2Attribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 0, 100 };
            yield return new object[] { 1, 101 };
            yield return new object[] { 50, 150 };
            yield return new object[] { 101, 201 };
        }
    }
}
