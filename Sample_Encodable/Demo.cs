using Encodable;

namespace Sample_Encodable
{
    public class Demo
    {
        class Model : ICodable
        {
            private int _Count;
            public int Count { get => _Count; set => _Count = value; }
        }

        public Demo()
        {
            Demonstration().Wait();
        }

        private static async Task Demonstration()
        {
            Uri uri = new Uri(Path.GetFullPath("file.binary"));

            var savedModel = new Model();
            savedModel.Count = 5;

            await savedModel.SaveAsync(uri);

            var loadedModel = await uri.LoadAsync<Model>();
        }
    }
}
