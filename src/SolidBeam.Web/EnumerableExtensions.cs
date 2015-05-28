using System.Collections.Generic;
using System.Linq;

namespace SolidBeam.Web
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<string> ToTypeNames(this IEnumerable<object> collection)
        {
            return collection.Select(item => item.GetType().Name);
        }
    }
}