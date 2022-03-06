using Encodable;

namespace Sample_Encodable
{
    internal class Sample3
    {
        class Model : ICodable
        {
            private bool EncodableSomeProperty;
            public bool SomeProperty { get => EncodableSomeProperty; set => EncodableSomeProperty = value; }
        }

        public Sample3()
        {
            SaveSample().Wait();
            LoadSample().Wait();

            CodingProperties.Prefix = "_";
        }

        private static async Task SaveSample()
        {
            Model model = new Model();
            model.SomeProperty = true;

            // Change the prefix.
            CodingProperties.Prefix = "Encodable";

            Uri uri = new Uri(Path.GetFullPath("file.binary"));
            await model.SaveAsync(uri);
        }

        private static async Task LoadSample()
        {
            Uri uri = new Uri(Path.GetFullPath("file.binary"));
            Model model = await uri.LoadAsync<Model>();
        }
    }
}
