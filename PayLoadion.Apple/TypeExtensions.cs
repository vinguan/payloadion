using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace PayLoadion.Apple
{
    internal static class TypeExtensions
    {

        internal static bool IsAnonymousType(this Type type)
        {
            var hasCompilerGeneratedAttribute = type.GetTypeInfo().GetCustomAttributes(typeof(CompilerGeneratedAttribute),false).Any();
            var nameContainsAnonymousType = type.FullName.Contains("AnonymousType");
            var isAnonymousType = hasCompilerGeneratedAttribute && nameContainsAnonymousType;

            return isAnonymousType;
        }

    }
}