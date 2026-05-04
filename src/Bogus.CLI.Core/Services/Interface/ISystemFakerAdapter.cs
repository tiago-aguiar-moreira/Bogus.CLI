namespace Bogus.CLI.Core.Services.Interface;
public interface ISystemFakerAdapter
{
    string FileName(string? ext = null);
    string DirectoryPath();
    string FilePath();
    string CommonFileName(string? ext = null);
    string MimeType();
    string CommonFileType();
    string CommonFileExt();
    string FileType();
    string FileExt(string? mimeType = null);
    string Semver();
    string Version();
    string Exception();
    string AndroidId();
    string ApplePushToken();
    string BlackBerryPin();
}
