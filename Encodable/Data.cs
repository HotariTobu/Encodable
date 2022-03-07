namespace Encodable
{
    /**
     * <summary>Represents structural binary data.</summary>
     */
    public class Data
    {
        /**
         * <summary>Raw bytes.</summary>
         */
        public IEnumerable<byte> RawBytes { get; }
        /**
         * <summary>The content bytes without data of count or length.</summary>
         * <exception cref="ArgumentNullException"></exception>
         */
        public ReadOnlySpan<byte> Bytes => RawBytes.Skip(8).ToArray();

        /**
         * <summary>Initialize with specified bytes.</summary>
         * <param name="bytes">The content bytes.</param>
         * <param name="isRawBytes"><see langword="true"/> if the bytes contain data of count and length, otherwise <see langword="false"/>.</param>
         * <exception cref="ArgumentNullException"></exception>
         */
        public Data(IEnumerable<byte> bytes, bool isRawBytes = false)
        {
            if (isRawBytes)
            {
                RawBytes = bytes;
            }
            else
            {
                RawBytes = BitConverter.GetBytes(1)
                .Concat(GetBytesWithLength(bytes));
            }
        }

        /**
         * <summary>Initialize with some sub data.</summary>
         * <param name="contents">Array of sub data.</param>
         * <exception cref="ArgumentNullException"></exception>
         */
        public Data(params Data[] contents)
        {
            RawBytes = BitConverter.GetBytes(contents.Length)
                .Concat(contents
                .Select(content => GetBytesWithLength(content.RawBytes))
                .SelectMany(x => x));
        }

        /**
         * <summary>Gets the count of the sub data.</summary>
         * <exception cref="ArgumentOutOfRangeException"></exception>
         */
        public int ContentsCount => BitConverter.ToInt32(RawBytes.ToArray());
        /**
         * <summary>Gets the sub data.</summary>
         */
        public IEnumerable<Data> Contents
        {
            get
            {
                byte[] bytes = RawBytes.ToArray();
                List<Data> contents = new List<Data>();

                int length = bytes.Length;
                for (int index = 4; index < length;)
                {
                    int count = BitConverter.ToInt32(bytes, index);
                    index += 4;
                    int nextIndex = index + count;

                    Range range = new Range(index, nextIndex);
                    Data content = new Data(bytes.Take(range), true);

                    contents.Add(content);
                    index = nextIndex;
                }

                return contents;
            }
        }

        /**
         * <summary>Connects length of bytes at the head of them.</summary>
         * <returns>Bytes contains bytes of length.</returns>
         * <exception cref="ArgumentNullException"></exception>
         */
        private static IEnumerable<byte> GetBytesWithLength(IEnumerable<byte> bytes)
        {
            return BitConverter.GetBytes(bytes.Count())
                .Concat(bytes);
        }
    }
}
