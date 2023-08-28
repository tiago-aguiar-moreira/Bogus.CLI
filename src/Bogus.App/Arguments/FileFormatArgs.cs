using CommandDotNet;

namespace Bogus.App.Arguments;
public class FileFormatArgs : IArgumentModel
{
    [Option(
        Constants.SHORTNAME_COMMAND_FILE_FORMAT,
        Constants.LONGNAME_COMMAND_FILE_FORMAT,
        Description = Constants.DESCRIPTION_COMMAND_FILE_FORMAT)]
    public string Value { get; set; }
}