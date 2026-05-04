using Bogus.CLI.Core.Services.Interface;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.Core.Services.Adapters;

[ExcludeFromCodeCoverage]
public class SystemFakerAdapter(IFakerService fakerService) : ISystemFakerAdapter
{
    private readonly IFakerService _fakerService = fakerService;

    public string FileName(string? ext = null) => _fakerService.GetFaker().System.FileName(ext);
    public string DirectoryPath() => _fakerService.GetFaker().System.DirectoryPath();
    public string FilePath() => _fakerService.GetFaker().System.FilePath();
    public string CommonFileName(string? ext = null) => _fakerService.GetFaker().System.CommonFileName(ext);
    public string MimeType() => _fakerService.GetFaker().System.MimeType();
    public string CommonFileType() => _fakerService.GetFaker().System.CommonFileType();
    public string CommonFileExt() => _fakerService.GetFaker().System.CommonFileExt();
    public string FileType() => _fakerService.GetFaker().System.FileType();
    public string FileExt(string? mimeType = null) => _fakerService.GetFaker().System.FileExt(mimeType!);
    public string Semver() => _fakerService.GetFaker().System.Semver();
    public string Version() => _fakerService.GetFaker().System.Version().ToString();
    public string Exception() => _fakerService.GetFaker().System.Exception().Message;
    public string AndroidId() => _fakerService.GetFaker().System.AndroidId();
    public string ApplePushToken() => _fakerService.GetFaker().System.ApplePushToken();
    public string BlackBerryPin() => _fakerService.GetFaker().System.BlackBerryPin();
}
