using System.Reflection;

namespace Encodable
{
    /**
     * <summary>Have properties associated with encoding and decoding.</summary>
     */
    public static class CodingProperties
    {
        /**
         * <summary>Represents the prefix used when encoding <see cref="ICodable"/>. Fields in <see cref="ICodable"/> with the name starting with the prefix are encoded.</summary>
         */
        public static string Prefix { get; set; } = "_";

        /**
         * <summary>Gets encode methods.</summary>
         */
        public static MethodInfo[] EncodeMethods { get; private set; } = typeof(EncodableExtension).GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
        /**
         * <summary>Gets decode methods.</summary>
         */
        public static MethodInfo[] DecodeMethods { get; private set; } = typeof(DecodableExtension).GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

        /**
         * <summary>Add specified encoder and decoder to <see cref="EncodeMethods"/> and <see cref="DecodeMethods"/></summary>
         * <typeparam name="T">The type corresponds to the encoder and the decoder.</typeparam>
         * <param name="encoder">Used when encoding.</param>
         * <param name="decoder">Used when decoding.</param>
         */
        public static void AddCoder<T>(Func<T, Data> encoder, Func<T, Data, Type, T> decoder)
        {
            EncodeMethods = EncodeMethods.Append(encoder.Method).ToArray();
            DecodeMethods = DecodeMethods.Append(decoder.Method).ToArray();
        }
    }
}
