using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Encodable
{
    public static class DecodableExtension
    {
        /**
         * <summary>Decodes <see cref="Data"/> to <see cref="bool"/></summary>
         * <param name="_">Not used.</param>
         * <param name="data">The data.</param>
         * <param name="__">Not used.</param>
         * <returns><see cref="bool"/> that the data represents.</returns>
         * <exception cref="ArgumentOutOfRangeException"></exception>
         */
        public static bool Decode(this bool _, Data data, Type? __ = null)
        {
            return BitConverter.ToBoolean(data.Bytes);
        }

        /**
         * <summary>Decodes <see cref="Data"/> to <see cref="char"/></summary>
         * <param name="_">Not used.</param>
         * <param name="data">The data.</param>
         * <param name="__">Not used.</param>
         * <returns><see cref="char"/> that the data represents.</returns>
         * <exception cref="ArgumentOutOfRangeException"></exception>
         */
        public static char Decode(this char _, Data data, Type? __ = null)
        {
            return BitConverter.ToChar(data.Bytes);
        }

        /**
         * <summary>Decodes <see cref="Data"/> to <see cref="double"/></summary>
         * <param name="_">Not used.</param>
         * <param name="data">The data.</param>
         * <param name="__">Not used.</param>
         * <returns><see cref="double"/> that the data represents.</returns>
         * <exception cref="ArgumentOutOfRangeException"></exception>
         */
        public static double Decode(this double _, Data data, Type? __ = null)
        {
            return BitConverter.ToDouble(data.Bytes);
        }

        /**
         * <summary>Decodes <see cref="Data"/> to <see cref="Half"/></summary>
         * <param name="_">Not used.</param>
         * <param name="data">The data.</param>
         * <param name="__">Not used.</param>
         * <returns><see cref="Half"/> that the data represents.</returns>
         * <exception cref="ArgumentOutOfRangeException"></exception>
         */
        public static Half Decode(this Half _, Data data, Type? __ = null)
        {
            return BitConverter.ToHalf(data.Bytes);
        }

        /**
         * <summary>Decodes <see cref="Data"/> to <see cref="short"/></summary>
         * <param name="_">Not used.</param>
         * <param name="data">The data.</param>
         * <param name="__">Not used.</param>
         * <returns><see cref="short"/> that the data represents.</returns>
         * <exception cref="ArgumentOutOfRangeException"></exception>
         */
        public static short Decode(this short _, Data data, Type? __ = null)
        {
            return BitConverter.ToInt16(data.Bytes);
        }

        /**
         * <summary>Decodes <see cref="Data"/> to <see cref="int"/></summary>
         * <param name="_">Not used.</param>
         * <param name="data">The data.</param>
         * <param name="__">Not used.</param>
         * <returns><see cref="int"/> that the data represents.</returns>
         * <exception cref="ArgumentOutOfRangeException"></exception>
         */
        public static int Decode(this int _, Data data, Type? __ = null)
        {
            return BitConverter.ToInt32(data.Bytes);
        }

        /**
         * <summary>Decodes <see cref="Data"/> to <see cref="long"/></summary>
         * <param name="_">Not used.</param>
         * <param name="data">The data.</param>
         * <param name="__">Not used.</param>
         * <returns><see cref="long"/> that the data represents.</returns>
         * <exception cref="ArgumentOutOfRangeException"></exception>
         */
        public static long Decode(this long _, Data data, Type? __ = null)
        {
            return BitConverter.ToInt64(data.Bytes);
        }

        /**
         * <summary>Decodes <see cref="Data"/> to <see cref="float"/></summary>
         * <param name="_">Not used.</param>
         * <param name="data">The data.</param>
         * <param name="__">Not used.</param>
         * <returns><see cref="float"/> that the data represents.</returns>
         * <exception cref="ArgumentOutOfRangeException"></exception>
         */
        public static float Decode(this float _, Data data, Type? __ = null)
        {
            return BitConverter.ToSingle(data.Bytes);
        }

        /**
         * <summary>Decodes <see cref="Data"/> to <see cref="ushort"/></summary>
         * <param name="_">Not used.</param>
         * <param name="data">The data.</param>
         * <param name="__">Not used.</param>
         * <returns><see cref="ushort"/> that the data represents.</returns>
         * <exception cref="ArgumentOutOfRangeException"></exception>
         */
        public static ushort Decode(this ushort _, Data data, Type? __ = null)
        {
            return BitConverter.ToUInt16(data.Bytes);
        }

        /**
         * <summary>Decodes <see cref="Data"/> to <see cref="uint"/></summary>
         * <param name="_">Not used.</param>
         * <param name="data">The data.</param>
         * <param name="__">Not used.</param>
         * <returns><see cref="uint"/> that the data represents.</returns>
         * <exception cref="ArgumentOutOfRangeException"></exception>
         */
        public static uint Decode(this uint _, Data data, Type? __ = null)
        {
            return BitConverter.ToUInt32(data.Bytes);
        }

        /**
         * <summary>Decodes <see cref="Data"/> to <see cref="ulong"/></summary>
         * <param name="_">Not used.</param>
         * <param name="data">The data.</param>
         * <param name="__">Not used.</param>
         * <returns><see cref="ulong"/> that the data represents.</returns>
         * <exception cref="ArgumentOutOfRangeException"></exception>
         */
        public static ulong Decode(this ulong _, Data data, Type? __ = null)
        {
            return BitConverter.ToUInt64(data.Bytes);
        }

        /**
         * <summary>Decodes <see cref="Data"/> to <see cref="string"/></summary>
         * <param name="_">Not used.</param>
         * <param name="data">The data.</param>
         * <param name="__">Not used.</param>
         * <returns><see cref="string"/> that the data represents.</returns>
         */
        public static string Decode(this string _, Data data, Type? __ = null)
        {
            return Encoding.UTF8.GetString(data.Bytes);
        }

        /**
         * <summary>Decodes <see cref="Data"/> to <see cref="DateTime"/></summary>
         * <param name="_">Not used.</param>
         * <param name="data">The data.</param>
         * <param name="__">Not used.</param>
         * <returns><see cref="DateTime"/> that the data represents.</returns>
         * <exception cref="ArgumentException"></exception>
         */
        public static DateTime Decode(this DateTime _, Data data, Type? __ = null)
        {
            return DateTime.FromBinary(0L.Decode(data));
        }

        /**
         * <summary>Decodes <see cref="Data"/> to <see cref="IDictionary"/></summary>
         * <param name="_">Not used.</param>
         * <param name="data">The data.</param>
         * <param name="type">The type of collection. It must have a constructor with a parameter of <see cref="IEnumerable{T}"/>(<see langword="T"/> is <see cref="KeyValuePair{TKey, TValue}"/>).</param>
         * <returns><see cref="IDictionary"/> that the data represents if succeed to decode, otherwise <see langword="null"/>.</returns>
         * <exception cref="InvalidCastException"></exception>
		 * <exception cref="InvalidOperationException"></exception>
		 * <exception cref="ArgumentNullException"></exception>
		 * <exception cref="ArgumentException"></exception>
		 * <exception cref="NotSupportedException"></exception>
		 * <exception cref="AmbiguousMatchException"></exception>
		 * <exception cref="MemberAccessException"></exception>
		 * <exception cref="MethodAccessException"></exception>
		 * <exception cref="TargetInvocationException"></exception>
		 * <exception cref="TargetParameterCountException"></exception>
		 * <exception cref="NotSupportedException"></exception>
		 * <exception cref="System.Security.SecurityException"></exception>
         */
        public static IDictionary? Decode(this IDictionary _, Data data, Type type)
        {
            ConstructorInfo? constructor = null;

            try
            {
                constructor = type.GetConstructors().First(constructor =>
                {
                    ParameterInfo[] parameters = constructor.GetParameters();
                    if (parameters.Length != 1)
                    {
                        return false;
                    }

                    Type parameterType = parameters[0].ParameterType;
                    if (!parameterType.Name.Contains(nameof(IEnumerable)) || !parameterType.IsGenericType)
                    {
                        return false;
                    }

                    Type genericType = parameterType.GetGenericArguments()[0];
                    if (genericType.Name.Contains(nameof(KeyValuePair)))
                    {
                        return true;
                    }

                    return false;
                });
            }
            catch (Exception e)
            {
                throw new InvalidCastException($"Could not find a constructor with a parameter of IEnumerable<KeyValuePair> in {type}.", e);
            }

            if (constructor == null)
            {
                return null;
            }

            if (!type.IsGenericType)
            {
                return null;
            }

            Type keyType = type.GenericTypeArguments[0];
            MethodInfo? keyMethod = keyType.GetDecodeMethod();
            if (keyMethod == null)
            {
                return null;
            }

            Type valueType = type.GenericTypeArguments[1];
            MethodInfo? valueMethod = valueType.GetDecodeMethod();
            if (valueMethod == null)
            {
                return null;
            }

            Type genericType = typeof(KeyValuePair<, >).MakeGenericType(keyType, valueType);

            ConstructorInfo? pairConstructor = genericType.GetConstructor(new Type[] { keyType, valueType });
            if (pairConstructor == null)
            {
                return null;
            }

            Type listType = typeof(List<>).MakeGenericType(genericType);

            ConstructorInfo? listConstructor = listType.GetConstructor(Type.EmptyTypes);
            if (listConstructor == null)
            {
                return null;
            }

            MethodInfo? addMethod = listType.GetMethod("Add");
            if (addMethod == null)
            {
                return null;
            }

            object? list = listConstructor.Invoke(null);
            if (list == null)
            {
                return null;
            }

            int pairDataCount = data.ContentsCount / 2;
            Data[] contents = data.Contents.ToArray();
            for (int i = 0; i < pairDataCount; i++)
            {
                Data keyData = contents[i * 2];
                object? key = keyMethod.Decode(keyData, keyType);
                if (key == null)
                {
                    continue;
                }

                Data valueData = contents[i * 2 + 1];
                object? value = valueMethod.Decode(valueData, valueType);
                if (value == null)
                {
                    continue;
                }

                object pair = pairConstructor.Invoke(new object[] { key, value });
                addMethod?.Invoke(list, new object[] { pair });
            }

            object result = constructor.Invoke(new object[] { list });
            return (IDictionary)result;
        }

        /**
         * <summary>Decodes <see cref="Data"/> to <see cref="IEnumerable"/></summary>
         * <param name="_">Not used.</param>
         * <param name="data">The data.</param>
         * <param name="type">The type of collection. It must have a constructor with a parameter of <see cref="IEnumerable"/>.</param>
         * <returns><see cref="IEnumerable"/> that the data represents if succeed to decode, otherwise <see langword="null"/>.</returns>
         * <exception cref="InvalidCastException"></exception>
		 * <exception cref="InvalidOperationException"></exception>
		 * <exception cref="ArgumentNullException"></exception>
		 * <exception cref="ArgumentException"></exception>
		 * <exception cref="NotSupportedException"></exception>
		 * <exception cref="AmbiguousMatchException"></exception>
		 * <exception cref="MemberAccessException"></exception>
		 * <exception cref="MethodAccessException"></exception>
		 * <exception cref="TargetInvocationException"></exception>
		 * <exception cref="TargetParameterCountException"></exception>
		 * <exception cref="NotSupportedException"></exception>
		 * <exception cref="System.Security.SecurityException"></exception>
         */
        public static IEnumerable? Decode(this IEnumerable _, Data data, Type type)
        {
            ConstructorInfo? constructor = null;

            try
            {
                constructor = type.GetConstructors().First(constructor =>
                {
                    ParameterInfo[] parameters = constructor.GetParameters();
                    if (parameters.Length != 1)
                    {
                        return false;
                    }

                    string name = parameters[0].ParameterType.Name;
                    if (name.Contains(nameof(IEnumerable)))
                    {
                        return true;
                    }

                    return false;
                });
            }
            catch (Exception e)
            {
                throw new InvalidCastException($"Could not find a constructor with a parameter of IEnumerable in {type}.", e);
            }

            if (constructor == null)
            {
                return null;
            }

            if (!type.IsGenericType)
            {
                return null;
            }

            Type genericType = type.GenericTypeArguments[0];
            MethodInfo? method = genericType.GetDecodeMethod();
            if (method == null)
            {
                return null;
            }

            Type listType = typeof(List<>).MakeGenericType(genericType);

            ConstructorInfo? listConstructor = listType.GetConstructor(Type.EmptyTypes);
            if (listConstructor == null)
            {
                return null;
            }

            MethodInfo? addMethod = listType.GetMethod("Add");
            if (addMethod == null)
            {
                return null;
            }

            object? list = listConstructor.Invoke(null);
            if (list == null)
            {
                return null;
            }

            foreach (Data content in data.Contents)
            {
                object? value = method.Decode(content, genericType);
                if (value != null)
                {
                    addMethod?.Invoke(list, new object[] { value });
                }
            }

            object result = constructor.Invoke(new object[] { list });
            return (IEnumerable)result;
        }

        /**
         * <summary>Decodes <see cref="Data"/> to <see cref="ICodable"/></summary>
         * <param name="_">Not used.</param>
         * <param name="data">The data.</param>
         * <param name="type">The type of <see cref="ICodable"/>. It must have a constructor without parameters,</param>
         * <returns><see cref="ICodable"/> that the data represents.</returns>
         * <exception cref="InvalidOperationException"></exception>
		 * <exception cref="MemberAccessException"></exception>
		 * <exception cref="MethodAccessException"></exception>
		 * <exception cref="ArgumentException"></exception>
		 * <exception cref="TargetInvocationException"></exception>
		 * <exception cref="TargetParameterCountException"></exception>
		 * <exception cref="NotSupportedException"></exception>
		 * <exception cref="System.Security.SecurityException"></exception>
         * <exception cref="TargetException"></exception>
         * <exception cref="FieldAccessException"></exception>
         */
        public static ICodable Decode(this ICodable _, Data data, Type type)
        {
            ConstructorInfo? constructor = type.GetConstructor(Type.EmptyTypes);
            if (constructor == null)
            {
                throw new InvalidOperationException($"Could not find a constructor without parameters in {type}.");
            }

            object result = constructor.Invoke(null);

            int fieldDataCount = data.ContentsCount / 2;
            Data[] contents = data.Contents.ToArray();
            for (int i = 0; i < fieldDataCount; i++)
            {
                Data nameData = contents[i * 2];
                string name = "".Decode(nameData);

                FieldInfo? field = type.GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
                if (field == null)
                {
                    continue;
                }

                MethodInfo? method = field.FieldType.GetDecodeMethod();
                if (method == null)
                {
                    continue;
                }

                Data valueData = contents[i * 2 + 1];
                object? fieldValue = method.Decode(valueData, field.FieldType);
                if (fieldValue != null)
                {
                    field.SetValue(result, fieldValue);
                }
            }

            return (ICodable)result;
        }

        /**
         * <summary>Decodes <see cref="Data"/> to specified type with specified decode method.</summary>
         * <param name="method">The decode method.</param>
         * <param name="data">The data.</param>
         * <param name="type">Specified type.</param>
         * <returns>The result of decoding. It may be <see langword="null"/>.</returns>
         * <exception cref="TargetException"></exception>
		 * <exception cref="ArgumentException"></exception>
		 * <exception cref="TargetInvocationException"></exception>
		 * <exception cref="TargetParameterCountException"></exception>
		 * <exception cref="MethodAccessException"></exception>
		 * <exception cref="NotSupportedException"></exception>
         */
        private static object? Decode(this MethodInfo method, Data data, Type type)
        {
            return method.Invoke(null, new object?[] { null, data, type });
        }
    }
}
