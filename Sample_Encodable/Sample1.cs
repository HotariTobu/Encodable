using Encodable;

namespace Sample_Encodable
{
    internal class Sample1
    {
        class Model : ICodable
        {
            private bool _SomeProperty;
            public bool SomeProperty { get => _SomeProperty; set => _SomeProperty = value; }
        }

        public Sample1()
        {
            SaveSample().Wait();
            LoadSample().Wait();
        }

        private static async Task SaveSample()
        {
            // Make the model.
            Model model = new Model();
            model.SomeProperty = true;

            // Save the model.
            Uri uri = new Uri(Path.GetFullPath("file.binary"));
            await model.SaveAsync(uri);
        }

        private static async Task LoadSample()
        {
            // Load the model.
            Uri uri = new Uri(Path.GetFullPath("file.binary"));
            Model model = await uri.LoadAsync<Model>();
        }
    }
}
