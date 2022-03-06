using System;
using System.Collections.Generic;
using System.Text;

namespace Encodable
{
    internal static class PrimitiveEncodableExtension
    {
        public static byte[] Encode(this int value)
        {
            return BitConverter.GetBytes(value);
        }
    }
}
