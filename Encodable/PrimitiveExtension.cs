using System;
using System.Collections.Generic;
using System.Text;

namespace Encodable
{
    public static class PrimitiveEncodableExtension
    {
        public static byte[] Encode(this int value)
        {
            return BitConverter.GetBytes(value);
        }
    }
}
