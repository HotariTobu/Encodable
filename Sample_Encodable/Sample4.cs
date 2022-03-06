using Encodable;

namespace Sample_Encodable
{
    record Person
    {
        public string Name { get; init; } = "";
        public int Age { get; init; }
    }

    static class PersonExtension
    {
        public static Data Encode(this Person person)
        {
            Data nameData = person.Name.Encode();
            Data ageData = person.Age.Encode();
            return new Data(nameData, ageData);
        }

        public static Person Decode(this Person _, Data data, Type? __ = null)
        {
            List<Data> contents = data.Contents.ToList();
            return new Person
            {
                Name = contents[0].Decode<string>(),
                Age = contents[1].Decode<int>(),
            };
        }
    }

    internal class Sample4
    {
        class Model : ICodable
        {
            private Person _Person = new Person();
            public Person Person { get => _Person; set => _Person = value; }
        }

        public Sample4()
        {
            SaveSample().Wait();
            LoadSample().Wait();
        }

        private static async Task SaveSample()
        {
            Model model = new Model();
            model.Person = new Person
            {
                Name = "Tom",
                Age = 26,
            };

            // Register the encoder and the decoder.
            CodingProperties.AddCoder<Person>(PersonExtension.Encode, PersonExtension.Decode);

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
