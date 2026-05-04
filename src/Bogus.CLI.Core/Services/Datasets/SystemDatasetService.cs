using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Extensions;
using Bogus.CLI.Core.Services.Interface;

namespace Bogus.CLI.Core.Services.Datasets;
public class SystemDatasetService(ISystemFakerAdapter systemAdapter) : ISystemDatasetService
{
    public const string PARAM_EXT = "ext";
    public const string PARAM_MIME_TYPE = "mimetype";

    private readonly ISystemFakerAdapter _systemAdapter = systemAdapter;

    public string? Generate(string property, IDictionary<string, object> parameters) => property.ToLower() switch
    {
        SystemProperty.FILE_NAME => _systemAdapter.FileName(NullIfEmpty(parameters.ConvertToString(PARAM_EXT, string.Empty))),
        SystemProperty.DIRECTORY_PATH => _systemAdapter.DirectoryPath(),
        SystemProperty.FILE_PATH => _systemAdapter.FilePath(),
        SystemProperty.COMMON_FILE_NAME => _systemAdapter.CommonFileName(NullIfEmpty(parameters.ConvertToString(PARAM_EXT, string.Empty))),
        SystemProperty.MIME_TYPE => _systemAdapter.MimeType(),
        SystemProperty.COMMON_FILE_TYPE => _systemAdapter.CommonFileType(),
        SystemProperty.COMMON_FILE_EXT => _systemAdapter.CommonFileExt(),
        SystemProperty.FILE_TYPE => _systemAdapter.FileType(),
        SystemProperty.FILE_EXT => _systemAdapter.FileExt(NullIfEmpty(parameters.ConvertToString(PARAM_MIME_TYPE, string.Empty))),
        SystemProperty.SEMVER => _systemAdapter.Semver(),
        SystemProperty.VERSION => _systemAdapter.Version(),
        SystemProperty.EXCEPTION => _systemAdapter.Exception(),
        SystemProperty.ANDROID_ID => _systemAdapter.AndroidId(),
        SystemProperty.APPLE_PUSH_TOKEN => _systemAdapter.ApplePushToken(),
        SystemProperty.BLACKBERRY_PIN => _systemAdapter.BlackBerryPin(),
        _ => null
    };

    private static string? NullIfEmpty(string value) => string.IsNullOrEmpty(value) ? null : value;
}
