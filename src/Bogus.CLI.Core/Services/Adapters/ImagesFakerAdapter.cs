using Bogus.CLI.Core.Services.Interface;
using Bogus.DataSets;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.Core.Services.Adapters;

[ExcludeFromCodeCoverage]
public class ImagesFakerAdapter(IFakerService fakerService) : IImagesFakerAdapter
{
    private readonly IFakerService _fakerService = fakerService;

    private Images GetFaker() => _fakerService.GetFaker().Image;

    public string DataUri(int width = 200, int height = 200, string htmlColor = "grey")
        => GetFaker().DataUri(width, height, htmlColor);

    public string PlaceImgUrl(int width = 640, int height = 480, string category = "Any")
        => GetFaker().PlaceImgUrl(width, height, category);

    public string PicsumUrl(int width = 640, int height = 480, bool grayscale = false, bool blur = false)
        => GetFaker().PicsumUrl(width, height, grayscale, blur);

    public string PlaceholderUrl(int width = 200, int height = 200, string? text = null, string format = "png", string backColor = "cccccc", string textColor = "9c9c9c")
        => GetFaker().PlaceholderUrl(width, height, text, format, backColor, textColor);

    public string LoremFlickrUrl(int width = 320, int height = 240, string? keywords = null, bool grayscale = false)
        => GetFaker().LoremFlickrUrl(width, height, keywords, grayscale);
}
