using Bogus.CLI.Core.Services.Interface;

namespace Bogus.CLI.Core.Services;
public class TemplateService : ITemplateService
{
    private string _template = string.Empty;

    public const string ERROR_TEMPLATE_NO_PLACEHOLDERS = "The template does not contain any placeholders. Please include at least one using `{{` and `}}`.";
    public const string ERROR_TEMPLATE_UNMATCHED_CLOSING_BRACE = "The template has closing braces `}}` without a matching opening brace `{{`.";
    public const string ERROR_TEMPLATE_UNMATCHED_OPENING_BRACE = "The template has opening braces `{{` without a matching closing brace `}}`.";

    private bool IsValid(string template, out string errorMessage)
    {
        var openCount = 0;
        var hasBraces = false;

        for (int i = 0; i < template.Length - 1; i++)
        {
            // Check for "{{"
            if (template[i] == '{' && template[i + 1] == '{')
            {
                openCount++;
                hasBraces = true;
                i++; // Skip the next '{'
            }
            // Check for "}}"
            else if (template[i] == '}' && template[i + 1] == '}')
            {
                hasBraces = true;
                if (openCount == 0)
                {
                    errorMessage = ERROR_TEMPLATE_UNMATCHED_CLOSING_BRACE;
                    return false;
                }
                openCount--;
                i++; // Skip the next '}'
            }
        }

        if (!hasBraces)
        {
            errorMessage = ERROR_TEMPLATE_NO_PLACEHOLDERS;
            return false;
        }

        if (openCount > 0)
        {
            errorMessage = ERROR_TEMPLATE_UNMATCHED_OPENING_BRACE;
            return false;
        }

        errorMessage = string.Empty;
        return true;
    }

    public bool SetTemplate(string template, out string errorMessage)
    {
        if(IsValid(template, out errorMessage))
        {
            _template = template;
            return true;
        }

        return false;
    }

    public string Format(List<(string Value, string Alias)> values)
    {
        var context = _template;

        for (int i = 0; i < values.Count; i++)
        {
            context = context.Replace(string.Concat("{{", i, "}}"), values[i].Value);

            if (!string.IsNullOrEmpty(values[i].Alias))
                context = context.Replace(string.Concat("{{", values[i].Alias, "}}"), values[i].Value);
        }

        return context;
    }
}