using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_StringAndArray.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	public class TestAttribute :Attribute
	{
        public double Index { get; }

        public bool Prioritized { get; }
        public TestAttribute(double index = 10000, bool prioritized = false)
        {
			Index = index;
			Prioritized = prioritized;
		}
    }
}
