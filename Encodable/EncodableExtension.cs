using System.Collections;
using System.Reflection;
using System.Text;

namespace Encodable
{
    internal static class EncodableExtension
    {
        /**
         * <summary>Encodes <see cref="bool"/> to <see cref="Data"/></summary>
         * <param name="value">The value.</param>
         * <returns><see cref="Data"/> represents the value.</returns>
         * <exception cref="ArgumentNullException"></exception>
         */
        public static Data Encode(this bool value)
        {
            return new Data(BitConverter.GetBytes(value));
        }

        /**
         * <summary>Encodes <see cref="char"/> to <see cref="Data"/></summary>
         * <param name="value">The value.</param>
         * <returns><see cref="Data"/> represents the value.</returns>
         * <exception cref="ArgumentNullException"></exception>
         */
        public static Data Encode(this char value)
        {
            return new Data(BitConverter.GetBytes(value));
        }

        /**
         * <summary>Encodes <see cref="double"/> to <see cref="Data"/></summary>
         * <param name="value">The value.</param>
         * <returns><see cref="Data"/> represents the value.</returns>
         * <exception cref="ArgumentNullException"></exception>
         */
        public static Data Encode(this double value)
        {
            return new Data(BitConverter.GetBytes(value));
        }

        /**
         * <summary>Encodes <see cref="Half"/> to <see cref="Data"/></summary>
         * <param name="value">The value.</param>
         * <returns><see cref="Data"/> represents the value.</returns>
         * <exception cref="ArgumentNullException"></exception>
         */
        public static Data Encode(this Half value)
        {
            return new Data(BitConverter.GetBytes(value));
        }

        /**
         * <summary>Encodes <see cref="short"/> to <see cref="Data"/></summary>
         * <param name="value">The value.</param>
         * <returns><see cref="Data"/> represents the value.</returns>
         * <exception cref="ArgumentNullException"></exception>
         */
        public static Data Encode(this short value)
        {
            return new Data(BitConverter.GetBytes(value));
        }

        /**
         * <summary>Encodes <see cref="int"/> to <see cref="Data"/></summary>
         * <param name="value">The value.</param>
         * <returns><see cref="Data"/> represents the value.</returns>
         * <exception cref="ArgumentNullException"></exception>
         */
        public static Data Encode(this int value)
        {
            return new Data(BitConverter.GetBytes(value));
        }

        /**
         * <summary>Encodes <see cref="long"/> to <see cref="Data"/></summary>
         * <param name="value">The value.</param>
         * <returns><see cref="Data"/> represents the value.</returns>
         * <exception cref="ArgumentNullException"></exception>
         */
        public static Data Encode(this long value)
        {
            return new Data(BitConverter.GetBytes(value));
        }

        /**
         * <summary>Encodes <see cref="float"/> to <see cref="Data"/></summary>
         * <param name="value">The value.</param>
         * <returns><see cref="Data"/> represents the value.</returns>
         * <exception cref="ArgumentNullException"></exception>
         */
        public static Data Encode(this float value)
        {
            return new Data(BitConverter.GetBytes(value));
        }

        /**
         * <summary>Encodes <see cref="ushort"/> to <see cref="Data"/></summary>
         * <param name="value">The value.</param>
         * <returns><see cref="Data"/> represents the value.</returns>
         * <exception cref="ArgumentNullException"></exception>
         */
        public static Data Encode(this ushort value)
        {
            return new Data(BitConverter.GetBytes(value));
        }

        /**
         * <summary>Encodes <see cref="uint"/> to <see cref="Data"/></summary>
         * <param name="value">The value.</param>
         * <returns><see cref="Data"/> represents the value.</returns>
         * <exception cref="ArgumentNullException"></exception>
         */
        public static Data Encode(this uint value)
        {
            return new Data(BitConverter.GetBytes(value));
        }

        /**
         * <summary>Encodes <see cref="ulong"/> to <see cref="Data"/></summary>
         * <param name="value">The value.</param>
         * <returns><see cref="Data"/> represents the value.</returns>
         * <exception cref="ArgumentNullException"></exception>
         */
        public static Data Encode(this ulong value)
        {
            return new Data(BitConverter.GetBytes(value));
        }

        /**
         * <summary>Encodes <see cref="string"/> to <see cref="Data"/></summary>
         * <param name="value">The value.</param>
         * <returns><see cref="Data"/> represents the value.</returns>
         * <exception cref="ArgumentNullException"></exception>
         * <exception cref="EncoderFallbackException"></exception>
         */
        public static Data Encode(this string value)
        {
            return new Data(Encoding.UTF8.GetBytes(value));
        }
        
        /**
         * <summary>Encodes <see cref="DateTime"/> to <see cref="Data"/></summary>
         * <param name="value">The value.</param>
         * <returns><see cref="Data"/> represents the value.</returns>
         * <exception cref="ArgumentNullException"></exception>
         */
        public static Data Encode(this DateTime value)
        {
            return value.ToBinary().Encode();
        }

        /**
         * <summary>Encodes <see cref="IDictionary"/> to <see cref="Data"/></summary>
         * <param name="value">The value.</param>
         * <returns><see cref="Data"/> represents the value if succeed to encode, otherwise <see langword="null"/>.</returns>
         * <exception cref="ArgumentNullException"></exception>
		 * <exception cref="TargetException"></exception>
		 * <exception cref="ArgumentException"></exception>
		 * <exception cref="TargetInvocationException"></exception>
		 * <exception cref="TargetParameterCountException"></exception>
		 * <exception cref="MethodAccessException"></exception>
		 * <exception cref="InvalidOperationException"></exception>
		 * <exception cref="NotSupportedException"></exception>
         */
        public static Data? Encode(this IDictionary value)
        {
            Type type = value.GetType();
            if (!type.IsGenericType)
            {
                return null;
            }

            Type keyType = type.GenericTypeArguments[0];
            MethodInfo? keyMethod = keyType.GetEncodeMethod();
            if (keyMethod == null)
            {
                return null;
            }

            Type valueType = type.GenericTypeArguments[1];
            MethodInfo? valueMethod = valueType.GetEncodeMethod();
            if (valueMethod == null)
            {
                return null;
            }

            Type genericType = typeof(DictionaryEntry);

            PropertyInfo? keyProperty = genericType.GetProperty("Key");
            if (keyProperty == null)
            {
                return null;
            }

            PropertyInfo? valueProperty = genericType.GetProperty("Value");
            if (valueProperty == null)
            {
                return null;
            }

            List<Data> list = new List<Data>();

            foreach (object pair in value)
            {
                Data? keyData = keyMethod.Encode(keyProperty.GetValue(pair));
                if (keyData == null)
                {
                    continue;
                }

                Data? valueData = valueMethod.Encode(valueProperty.GetValue(pair));
                if (valueData == null)
                {
                    continue;
                }

                list.Add(keyData);
                list.Add(valueData);
            }

            return new Data(list.ToArray());
        }

        /**
         * <summary>Encodes <see cref="IEnumerable"/> to <see cref="Data"/></summary>
         * <param name="value">The value.</param>
         * <returns><see cref="Data"/> represents the value if succeed to encode, otherwise <see langword="null"/>.</returns>
         * <exception cref="ArgumentNullException"></exception>
		 * <exception cref="TargetException"></exception>
		 * <exception cref="ArgumentException"></exception>
		 * <exception cref="TargetInvocationException"></exception>
		 * <exception cref="TargetParameterCountException"></exception>
		 * <exception cref="MethodAccessException"></exception>
		 * <exception cref="InvalidOperationException"></exception>
		 * <exception cref="NotSupportedException"></exception>
         */
        public static Data? Encode(this IEnumerable value)
        {
            Type type = value.GetType();
            if (!type.IsGenericType)
            {
                return null;
            }

            Type genericType = type.GenericTypeArguments[0];
            MethodInfo? method = genericType.GetEncodeMethod();
            if (method == null)
            {
                return null;
            }

            List<Data> list = new List<Data>();

            foreach (object obj in value)
            {
                Data? data = method.Encode(obj);
                if (data == null)
                {
                    continue;
                }

                list.Add(data);
            }

            return new Data(list.ToArray());
        }

        /**
         * <summary>Encodes <see cref=""/> to <see cref="Data"/></summary>
         * <param name="value">The value.</param>
         * <returns><see cref="Data"/> represents the value.</returns>
         * <exception cref="ArgumentNullException"></exception>
		 * <exception cref="TargetException"></exception>
		 * <exception cref="ArgumentException"></exception>
		 * <exception cref="TargetInvocationException"></exception>
		 * <exception cref="TargetParameterCountException"></exception>
		 * <exception cref="MethodAccessException"></exception>
		 * <exception cref="InvalidOperationException"></exception>
		 * <exception cref="NotSupportedException"></exception>
		 * <exception cref="FieldAccessException"></exception>
		 * <exception cref="EncoderFallbackException"></exception>
         */
        public static Data Encode(this ICodable value)
        {
            List<Data> list = new List<Data>();

            FieldInfo[] fields = value.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            foreach (FieldInfo field in fields)
            {
                string name = field.Name;
                if (!name.StartsWith(CodingProperties.Prefix))
                {
                    continue;
                }

                MethodInfo? method = field.FieldType.GetEncodeMethod();
                if (method == null)
                {
                    continue;
                }

                Data? data = method.Encode(field.GetValue(value));
                if (data == null)
                {
                    continue;
                }

                list.Add(name.Encode());
                list.Add(data);
            }

            return new Data(list.ToArray());
        }

        /**
         * <summary>Encodes specified type value to <see cref="Data"/> with specified encode method.</summary>
         * <param name="method">The encode method.</param>
         * <param name="obj">The value.</param>
         * <returns><see cref="Data"/> that represents the value if succeeded to encode, otherwise null.</returns>
		 * <exception cref="TargetException"></exception>
		 * <exception cref="ArgumentException"></exception>
		 * <exception cref="TargetInvocationException"></exception>
		 * <exception cref="TargetParameterCountException"></exception>
		 * <exception cref="MethodAccessException"></exception>
		 * <exception cref="InvalidOperationException"></exception>
		 * <exception cref="NotSupportedException"></exception>
         */
        private static Data? Encode(this MethodInfo method, object? obj)
        {
            if (obj == null)
            {
                return null;
            }

            return method.Invoke(null, new object[] { obj }) as Data;
        }
    }
}
