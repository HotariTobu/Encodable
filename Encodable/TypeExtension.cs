using System.Reflection;

namespace Encodable
{
    /**
     * <summary>Extends <see cref="Type"/></summary>
     */
    internal static class TypeExtension
    {
        /**
         * <summary>Gets encode method corresponds to specified type.</summary>
         * <param name="type">The type.</param>
         * <returns>The method if found, otherwise <see langword="null"/>.</returns>
         */
        public static MethodInfo? GetEncodeMethod(this Type type)
        {
            foreach (MethodInfo method in CodingProperties.EncodeMethods)
            {
                if (method.GetParameters()[0].ParameterType.IsAssignableFrom(type))
                {
                    return method;
                }
            }

            return null;
        }

        /**
         * <summary>Gets decode method corresponds to specified type.</summary>
         * <param name="type">The type.</param>
         * <returns>The method if found, otherwise <see langword="null"/>.</returns>
         */
        public static MethodInfo? GetDecodeMethod(this Type type)
        {
            foreach (MethodInfo method in CodingProperties.DecodeMethods)
            {
                if (method.ReturnType.IsAssignableFrom(type))
                {
                    return method;
                }
            }

            return null;
        }
    }
}
