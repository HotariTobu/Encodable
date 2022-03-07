using Encodable;

namespace Sample_Encodable
{
    public class Sample2
    {
        class Model : ICodable
        {
            private List<int> _SomeCollection = new List<int>();
            public List<int> SomeCollection => _SomeCollection;

            private Dictionary<string, int> _SomeDictionary = new Dictionary<string, int>();
            public Dictionary<string, int> SomeDictionary => _SomeDictionary;

            private SubModel _SubModel = new SubModel();
            public SubModel SubModel => _SubModel;
        }

        class SubModel : ICodable
        {
            private double _SomeProperty;
            public double SomeProperty { get => _SomeProperty; set => _SomeProperty = value; }
        }

        public Sample2()
        {
            SaveSample().Wait();
            LoadSample().Wait();
        }

        private static async Task SaveSample()
        {
            Model model = new Model();
            model.SomeCollection.AddRange(Enumerable.Range(1, 10));
            model.SomeDictionary.Add("one", 1);
            model.SomeDictionary.Add("two", 2);
            model.SubModel.SomeProperty = 3.14;

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
