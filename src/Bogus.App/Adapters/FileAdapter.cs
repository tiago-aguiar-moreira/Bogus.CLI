namespace Bogus.App.Adapters;
public class FileAdapter
{
    public void Save(string path, string? content)
        => File.WriteAllText(path, content);
}
