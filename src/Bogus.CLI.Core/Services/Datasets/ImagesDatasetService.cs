using Bogus.CLI.Core.Constants.Properties;
using Bogus.CLI.Core.Extensions;
using Bogus.CLI.Core.Services.Interface;

namespace Bogus.CLI.Core.Services.Datasets;
public class ImagesDatasetService(IImagesFakerAdapter imagesAdapter) : IImagesDatasetService
{
    public const string PARAM_WIDTH = "width";
    public const string PARAM_HEIGHT = "height";
    public const string PARAM_COLOR = "color";
    public const string PARAM_CATEGORY = "category";
    public const string PARAM_GRAYSCALE = "grayscale";
    public const string PARAM_BLUR = "blur";
    public const string PARAM_TEXT = "text";
    public const string PARAM_FORMAT = "format";
    public const string PARAM_BACK_COLOR = "backcolor";
    public const string PARAM_TEXT_COLOR = "textcolor";
    public const string PARAM_KEYWORDS = "keywords";

    private readonly IImagesFakerAdapter _imagesAdapter = imagesAdapter;

    public string? Generate(string property, IDictionary<string, object> parameters) => property.ToLower() switch
    {
        ImagesProperty.DATA_URI => _imagesAdapter.DataUri(
            parameters.ConvertToInt(PARAM_WIDTH, 200),
            parameters.ConvertToInt(PARAM_HEIGHT, 200),
            parameters.ConvertToString(PARAM_COLOR, "grey")),

        ImagesProperty.PLACE_IMG_URL => _imagesAdapter.PlaceImgUrl(
            parameters.ConvertToInt(PARAM_WIDTH, 640),
            parameters.ConvertToInt(PARAM_HEIGHT, 480),
            parameters.ConvertToString(PARAM_CATEGORY, "Any")),

        ImagesProperty.PICSUM_URL => _imagesAdapter.PicsumUrl(
            parameters.ConvertToInt(PARAM_WIDTH, 640),
            parameters.ConvertToInt(PARAM_HEIGHT, 480),
            parameters.ConvertToBool(PARAM_GRAYSCALE, false),
            parameters.ConvertToBool(PARAM_BLUR, false)),

        ImagesProperty.PLACEHOLDER_URL => _imagesAdapter.PlaceholderUrl(
            parameters.ConvertToInt(PARAM_WIDTH, 200),
            parameters.ConvertToInt(PARAM_HEIGHT, 200),
            NullIfEmpty(parameters.ConvertToString(PARAM_TEXT, string.Empty)),
            parameters.ConvertToString(PARAM_FORMAT, "png"),
            parameters.ConvertToString(PARAM_BACK_COLOR, "cccccc"),
            parameters.ConvertToString(PARAM_TEXT_COLOR, "9c9c9c")),

        ImagesProperty.LOREM_FLICKR_URL => _imagesAdapter.LoremFlickrUrl(
            parameters.ConvertToInt(PARAM_WIDTH, 320),
            parameters.ConvertToInt(PARAM_HEIGHT, 240),
            NullIfEmpty(parameters.ConvertToString(PARAM_KEYWORDS, string.Empty)),
            parameters.ConvertToBool(PARAM_GRAYSCALE, false)),

        _ => null
    };

    private static string? NullIfEmpty(string value) => string.IsNullOrEmpty(value) ? null : value;
}
