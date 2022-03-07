using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

namespace Encodable
{
    /**
     * <summary>Extends <see cref="Data"/></summary>
     */
    public static class DataExtension
    {
        /**
         * <summary>Loads <see cref="Data"/> from specified <see cref="Uri"/>.</summary>
         * <param name="uri">Specified URI.</param>
         * <exception cref="ArgumentNullException"></exception>
		 * <exception cref="InvalidOperationException"></exception>
		 * <exception cref="HttpRequestException"></exception>
		 * <exception cref="TaskCanceledException"></exception>
         */
        public static async Task<Data> LoadDataAsync(this Uri uri)
        {
            if (uri.Scheme.StartsWith("file"))
            {
                string path = Uri.UnescapeDataString(uri.AbsolutePath);
                byte[] bytes = await File.ReadAllBytesAsync(path);
                return new Data(bytes, true);
            }
            else
            {
                using HttpClient httpClient = new HttpClient();
                byte[] bytes = await httpClient.GetByteArrayAsync(uri);
                return new Data(bytes, true);
            }
        }

        /**
         * <summary>Saves <see cref="Data"/> to specified <see cref="Uri"/>.</summary>
         * <param name="data">The data to be saved.</param>
         * <param name="uri">Specified URI.</param>
         * <exception cref="ArgumentNullException"></exception>
		 * <exception cref="InvalidOperationException"></exception>
		 * <exception cref="HttpRequestException"></exception>
		 * <exception cref="TaskCanceledException"></exception>
         */
        public static async Task SaveDataAsync(this Data data, Uri uri)
        {
            byte[] bytes = data.RawBytes.ToArray();

            if (uri.Scheme.StartsWith("file"))
            {
                string path = Uri.UnescapeDataString(uri.AbsolutePath);
                await File.WriteAllBytesAsync(path, bytes);
            }
            else
            {
                StreamContent streamContent = new StreamContent(new MemoryStream(bytes));
                streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = uri.Segments.Last(),
                };

                MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
                multipartFormDataContent.Add(streamContent);

                using HttpClient httpClient = new HttpClient();
                _ = await httpClient.PostAsync(uri, multipartFormDataContent);
            }
        }

        /**
         * <summary>Decodes data to specified type.</summary>
         * <typeparam name="T">The type of the data.</typeparam>
         * <param name="data">The data to be decoded.</param>
         * <param name="isNullable">If <see langword="true"/>, return the default value of the type when the result was <see langword="null"/>, otherwise throw an exception.</param>
         * <returns>The value that the data represents.</returns>
         * <exception cref="InvalidOperationException"></exception>
         * <exception cref="NullReferenceException"></exception>
         * <exception cref="TargetException"></exception>
		 * <exception cref="ArgumentException"></exception>
		 * <exception cref="TargetInvocationException"></exception>
		 * <exception cref="TargetParameterCountException"></exception>
		 * <exception cref="MethodAccessException"></exception>
		 * <exception cref="NotSupportedException"></exception>
         */
        public static T Decode<T>(this Data data, bool isNullable = false)
        {
            Type type = typeof(T);
            MethodInfo? method = type.GetDecodeMethod();
            if (method == null)
            {
                throw new InvalidOperationException($"Could not find a method adapted to {type}.");
            }

            object? value = method.Invoke(null, new object?[] { null, data, type });
            if (value != null)
            {
                return (T)value;
            }

            if (isNullable)
            {
                return default!;
            }

            throw new NullReferenceException($"Could not decode to {type}");
        }
    }
}
