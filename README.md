# Encodable = En + Codable
`Encodable` enable objects to be encoded, decoded, loaded and saved.

# How To Use

## Save and Load

First, implement `ICodable` to the model object. Fields whose name starts with `_` are subject to search. `ICodable` objects must have a constructor without parameters.

```
class Model : ICodable
{
    private bool _SomeProperty;
    public bool SomeProperty { get => _SomeProperty; set => _SomeProperty = value; }
}
```

### Save

```
// Make the model.
Model model = new Model();
model.SomeProperty = true;

// Save the model.
Uri uri = new Uri(Path.GetFullPath("file.binary"));
await model.SaveAsync(uri);
```

### Load

```
// Load the model.
Uri uri = new Uri(Path.GetFullPath("file.binary"));
Model model = await uri.LoadAsync<Model>();
```

## Structural Object

Model objects can contain the below type fields.

- Primitives (`bool`, `char`, `double`, `Half`, `short`, `int`, `long`, `float`, `ushort`, `uint`, `ulong`)
- `string`
- `DateTime`
- Collections (`List`, `Dictionary`, ...)
- `ICodable`

This model is also OK.

```
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
```

### Prefix

You can also change the field search condition. Update `CodingProperties.Prefix` before loading and saving.

```
class Model : ICodable
{
    private bool EncodableSomeProperty;
    public bool SomeProperty { get => EncodableSomeProperty; set => EncodableSomeProperty = value; }
}
```

```
// Change the prefix.
CodingProperties.Prefix = "Encodable";
```

## Other than `ICodable`

Do you want to use more types? You can define custom encoders and decoders. Define and register them before encoding and decoding.

```
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

class Model : ICodable
{
    private Person _Person = new Person();
    public Person Person { get => _Person; set => _Person = value; }
}
```

```
// Register the encoder and the decoder.
CodingProperties.AddCoder<Person>(PersonExtension.Encode, PersonExtension.Decode);
```

Custom coding is faster than `ICodable` coding. Of cource, you can put this `Person` into some collection, too.

## More Options

### Collections

Usable collections have these constraints.

- Implement `IEnumerable` AND Have a constructor with a parameter of `IEnumerable`
- Implement `IDictionary` AND Have a constructor with a parameter of `IEnumerable<KeyValuePair>` AND Iterable with `DictionaryEntry`

### `Data` Class

`Data` class wrap byte collection.

![](img/Data_Image.png)

Refer `Data.RawBytes` when you operate bytes. Word definitions are below.

- Encode = Object -> `Data`
- Decode = `Data` -> Object
- Load = Some resource -> `Data` or Object
- Save = `Data` Object -> Some resource

