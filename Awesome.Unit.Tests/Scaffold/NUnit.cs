using System;

namespace NUnit.Framework
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class ScenarioAttribute : TestFixtureAttribute{}
	
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public class WhenAttribute : SetUpAttribute{}

	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public class GivenAttribute : SetUpAttribute{}
	
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
	public class ThenAttribute : TestAttribute{}
}
