namespace Bogus.CLI.Core.Services.Interface;
public interface IImagesFakerAdapter
{
    string DataUri(int width = 200, int height = 200, string htmlColor = "grey");
    string PlaceImgUrl(int width = 640, int height = 480, string category = "Any");
    string PicsumUrl(int width = 640, int height = 480, bool grayscale = false, bool blur = false);
    string PlaceholderUrl(int width = 200, int height = 200, string? text = null, string format = "png", string backColor = "cccccc", string textColor = "9c9c9c");
    string LoremFlickrUrl(int width = 320, int height = 240, string? keywords = null, bool grayscale = false);
}
