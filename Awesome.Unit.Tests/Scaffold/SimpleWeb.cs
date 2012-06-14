using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Simple.Web;

namespace Tests.Scaffold
{
	public static class SimpleWebExtensions
	{
		public static IEnumerable<Type> GetHandlersFor(this IEnumerable<Assembly> assemblies, string route)
		{
			return assemblies.GetTypesWith<UriTemplateAttribute>(t => t.Template.ToLower() == route.ToLower());
		}

		public static IEnumerable<Type> GetRouteCaseSensitiveHandlers(this IEnumerable<Assembly> assemblies, string route)
		{
			return assemblies.GetTypesWith<UriTemplateAttribute>(t => t.Template == route);
		}

		public static IEnumerable<Type> GetTypesWith<T>(this IEnumerable<Assembly> assemblies, Func<T, bool> filter)
		{
			foreach (var assembly in assemblies)
			{
				foreach (Type type in assembly.GetTypes())
				{
					var attrs = type.GetCustomAttributes(typeof(T), true);
					foreach (T attr in attrs)
					{
						if (filter(attr))
							yield return type;
					}
				}
			}
		}

		public static IEnumerable<Type> RespondingTo<T>(this IEnumerable<Type> types)
		{
			return types.Where(type => typeof(T).IsAssignableFrom(type));
		}
	}
}
