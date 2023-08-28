using CommandDotNet;

namespace Bogus.App.Arguments;
public class SeparatorArgs : IArgumentModel
{
    [Option(
        Constants.SHORTNAME_COMMAND_SEPARATOR,
        Constants.LONGNAME_COMMAND_SEPARATOR,
        Description = Constants.DESCRIPTION_COMMAND_SEPARATOR)]
    public string Value { get; set; }
}