using TextCopy;

namespace Bogus.App.Adapters;
public class ClipboardAdapter
{
    public void Test(string text)
        => ClipboardService.SetText(text);
}
