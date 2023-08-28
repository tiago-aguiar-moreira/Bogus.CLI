using CommandDotNet;
using System.ComponentModel.DataAnnotations;

namespace Bogus.App.Arguments;
public class DataGeneratorArgs : IArgumentModel, IValidatableObject
{
    [Operand("generate"), Required]
    public IList<string> Value { get; set; } = null!;

    public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
    {
        //TODO: implementar mais validações

        if (Value is null)
            yield return new System.ComponentModel.DataAnnotations.ValidationResult("Deu ruim");
    }
}