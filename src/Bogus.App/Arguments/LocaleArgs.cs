using CommandDotNet;
using System.ComponentModel.DataAnnotations;

namespace Bogus.App.Arguments;
public class LocaleArgs : IArgumentModel, IValidatableObject
{
    [Option(
        Constants.SHORTNAME_COMMAND_LOCALE,
        Constants.LONGNAME_COMMAND_LOCALE,
        Description = Constants.DESCRIPTION_COMMAND_LOCALE)]
    public string? Value { get; set; }

    public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!Constants.LOCALE_LIST.TryGetValue(Value, out _))
            yield return new System.ComponentModel.DataAnnotations.ValidationResult($"Invalid locale: {Value}.");
    }
}