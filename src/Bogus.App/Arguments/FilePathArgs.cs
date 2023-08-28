using CommandDotNet;

namespace Bogus.App.Arguments;
public class FilePathArgs : IArgumentModel
{
    [Option(
        Constants.SHORTNAME_COMMAND_FILE_PATH,
        Constants.LONGNAME_COMMAND_FILE_PATH,
        Description = Constants.DESCRIPTION_COMMAND_FILE_PATH)]
    public string Value { get; set; }
}