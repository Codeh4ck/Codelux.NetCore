using System;

namespace Codelux.NetCore.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static void Guard<T>(this T o, string message) where T : class
        {
            if (o == null) throw new ArgumentNullException(message);
        }
    }
}
