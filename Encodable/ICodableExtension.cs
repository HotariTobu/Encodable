using System.Reflection;
using System.Text;

namespace Encodable
{
    /**
     * <summary>Extends <see cref="ICodable"/></summary>
     */
    internal static class ICodableExtension
    {
        /**
         * <summary>Loads <see cref="ICodable"/> from specified <see cref="Uri"/>.</summary>
         * <typeparam name="T">The type of <see cref="ICodable"/></typeparam>
         * <param name="uri">Specified URI.</param>
         * <returns>Loaded <see cref="ICodable"/></returns>
         * <exception cref="ArgumentNullException"></exception>
		 * <exception cref="InvalidOperationException"></exception>
		 * <exception cref="HttpRequestException"></exception>
		 * <exception cref="TaskCanceledException"></exception>
         * <exception cref="NullReferenceException"></exception>
         * <exception cref="TargetException"></exception>
		 * <exception cref="ArgumentException"></exception>
		 * <exception cref="TargetInvocationException"></exception>
		 * <exception cref="TargetParameterCountException"></exception>
		 * <exception cref="MethodAccessException"></exception>
		 * <exception cref="NotSupportedException"></exception>
         */
        public static async Task<T> LoadAsync<T>(this Uri uri)
        {
            Data data = await uri.LoadDataAsync();
            return data.Decode<T>();
        }

        /**
         * <summary>Saves <see cref="ICodable"/> to specified <see cref="Uri"/>.</summary>
         * <param name="codable"><see cref="ICodable"/> to be saved.</param>
         * <param name="uri">Specified URI.</param>
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
		 * <exception cref="HttpRequestException"></exception>
		 * <exception cref="TaskCanceledException"></exception>
         */
        public static async Task SaveAsync(this ICodable codable, Uri uri)
        {
            Data data = codable.Encode();
            await data.SaveDataAsync(uri);
        }
    }
}
