using CommandDotNet;

namespace Bogus.App.Arguments;
public class LimitRowsArgs : IArgumentModel
{
    [Option(
        Constants.SHORTNAME_COMMAND_LIMIT_ROWS,
        Constants.LONGNAME_COMMAND_LIMIT_ROWS,
        Description = Constants.DESCRIPTION_COMMAND_LIMIT_ROWS)]
    public string Value { get; set; }
}