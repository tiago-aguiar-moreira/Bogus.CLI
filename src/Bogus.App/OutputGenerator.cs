namespace Bogus.App;
public class OutputGenerator
{
    private int _ruleIndex;
    private readonly Faker _faker;
    private readonly IList<(string? Alias, string Generator, string? Attribute)> _ruleFor;
    private readonly List<List<(string, string)>> _output;

    public string? FileFormat { get; private set; }
    public string? FilePath { get; private set; }

    private int _limitRows;
    public int LimitRows
    {
        get { return _limitRows < 1 ? 1 : _limitRows; }
        private set { _limitRows = value; }
    }
    public string? Separator { get; private set; }

    public OutputGenerator(
        IList<string> generator,
        string? locale,
        string? fileFormat,
        string? filePath,
        string? limitRows,
        string? separator)
    {
        _faker = new Faker(locale);
        _ruleFor = generator.Select(ConvertToRule).ToList();
        _output = new List<List<(string, string)>>();

        FileFormat = fileFormat;
        FilePath = filePath;
        
        _ = int.TryParse(limitRows, out var LimitRowsParsed);
        LimitRows = LimitRowsParsed;

        Separator = separator;
    }

    public string Execute()
    {
        //var responseBuilder = new StringBuilder();

        for (int limitRowIndex = 0; limitRowIndex < LimitRows; limitRowIndex++)
        {
            List<(string, string)> outputValues = new();

            for (_ruleIndex = 0; _ruleIndex < _ruleFor.Count; _ruleIndex++)
            {
                //Console.WriteLine("Generator" + _ruleFor[_ruleIndex].Generator);
                //Console.WriteLine("Attribute" + _ruleFor[_ruleIndex].Attribute);
                //Console.WriteLine("Alias" + _ruleFor[_ruleIndex].Alias);

                //TODO: encapsular todos os cases de "name" numa classe específica (NameGenerator)
                switch (_ruleFor[_ruleIndex].Generator)
                {
                    case Constants.FAKER_NAME_FIRSTNAME:
                        switch (_ruleFor[_ruleIndex].Attribute)
                        {
                            case "female":
                                outputValues.Add(GetValueFromCurrentRule(_faker.Name.FirstName(DataSets.Name.Gender.Female)));
                                break;
                            case "male":
                                outputValues.Add(GetValueFromCurrentRule(_faker.Name.FirstName(DataSets.Name.Gender.Male)));
                                break;
                            default:
                                outputValues.Add(GetValueFromCurrentRule(_faker.Name.FirstName()));
                                break;
                        }
                        break;
                    case Constants.FAKER_NAME_LASTNAME:
                        switch (_ruleFor[_ruleIndex].Attribute)
                        {
                            case "female":
                                outputValues.Add(GetValueFromCurrentRule(_faker.Name.LastName(DataSets.Name.Gender.Female)));
                                break;
                            case "male":
                                outputValues.Add(GetValueFromCurrentRule(_faker.Name.LastName(DataSets.Name.Gender.Male)));
                                break;
                            default:
                                outputValues.Add(GetValueFromCurrentRule(_faker.Name.LastName()));
                                break;
                        }
                        break;
                    default:
                        // Not supported;
                        break;
                }
            }

            _output.Add(outputValues);
        }

        return string.Empty;
    }

    private (string, string) GetValueFromCurrentRule(string value)
    {
        var key = _ruleFor[_ruleIndex].Alias;
        if (string.IsNullOrEmpty(key))
            key = (_ruleIndex + 1).ToString();

        return (key, value);
    }

    private (string? Alias, string Generator, string? Attribute) ConvertToRule(string value)
    {
        //<alias>=<generator>:<attribute>
        if (value.Contains('=') && value.Contains(':'))
        {
            var values = value.Split('=', ':');

            return (
                Alias: values[0],
                Generator: values[1].Trim().ToLower(),
                Attribute: values[2]);
        }

        //<alias>=<generator>
        if (value.Contains('='))
        {
            var values = value.Split('=');

            return (
                Alias: values[0],
                Generator: values[1].Trim().ToLower(),
                Attribute: string.Empty);
        }

        //<generator>:<attribute>
        if (value.Contains(':'))
        {
            var values = value.Split(':');

            return (
                Alias: string.Empty,
                Generator: values[0].Trim().ToLower(),
                Attribute: values[1].Trim().ToLower());
        }

        return (string.Empty, string.Empty, string.Empty);
    }
}