﻿namespace Bogus.CLI.Core.Services.Interface;
public interface ITemplateService
{
    bool SetTemplate(string templateName, out string errorMessage);
    string Format(List<(string Value, string Alias)> values);
}