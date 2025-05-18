using Chapter_StringAndArray.Algorithms;
using Chapter_StringAndArray.CustomAttributes;
using Chapter_StringAndArray.Interface;
using System;
using System.Linq;
using System.Reflection;

namespace Chapter_StringAndArray
{
	class Program
	{
		static void Main(string[] args)
		{
			var assembly = Assembly.GetExecutingAssembly();
			//获取带有Test特性的Type, 并根据Index升序排序
			var testTypes = assembly
							.GetTypes()
							.Where(t=> t.GetCustomAttribute(typeof(TestAttribute), false) != null)
							.OrderBy(t => ((TestAttribute)t.GetCustomAttribute(typeof(TestAttribute), false)).Index);
			// 处理是否有优先测试类
			var prioritizedType = testTypes.FirstOrDefault(t =>
												{
													var attribute = (TestAttribute)t.GetCustomAttribute(typeof(TestAttribute), false);
													return attribute.Prioritized;
												});
			//如果没有则选择第一个
			var executeType = prioritizedType == null ? testTypes.FirstOrDefault() : prioritizedType;
			var instance = Activator.CreateInstance(executeType);
			if (instance is IAlgorithm algorithm)
			{
				algorithm.ShowResult();
			}
			//var method = executeType.GetMethod("ShowResult");
			//method?.Invoke(instance, null);
		}
	}
}
