using Bogus.CLI.Core.Constants;
using Bogus.CLI.Core.Services.Interface;
using System.Diagnostics.CodeAnalysis;

namespace Bogus.CLI.Core.Services;

[ExcludeFromCodeCoverage]
public class ListLocaleService : IListLocaleService
{
    private static readonly IList<(string Code, string Description)> _locales = new List<(string, string)>
    {
        ( LocaleCodes.AFRIKAANS, "Afrikaans (South Africa)" ),
        ( LocaleCodes.ARABIC, "Arabic" ),
        ( LocaleCodes.AZERBAIJANI, "Azerbaijani" ),
        ( LocaleCodes.CZECH, "Czech" ),
        ( LocaleCodes.GERMAN, "German" ),
        ( LocaleCodes.GERMAN_AUSTRIA, "German (Austria)" ),
        ( LocaleCodes.GERMAN_SWITZERLAND, "German (Switzerland)" ),
        ( LocaleCodes.GREEK, "Greek" ),
        ( LocaleCodes.ENGLISH, "English" ),
        ( LocaleCodes.ENGLISH_AUSTRALIA, "English (Australia)" ),
        ( LocaleCodes.ENGLISH_AUSTRALIA_OCKER, "English (Australia Ocker)" ),
        ( LocaleCodes.ENGLISH_BORK, "English (Bork)" ),
        ( LocaleCodes.ENGLISH_CANADA, "English (Canada)" ),
        ( LocaleCodes.ENGLISH_GREAT_BRITAIN, "English (United Kingdom)" ),
        ( LocaleCodes.ENGLISH_IRELAND, "English (Ireland)" ),
        ( LocaleCodes.ENGLISH_INDIA, "English (India)" ),
        ( LocaleCodes.ENGLISH_NIGERIA, "English (Nigeria)" ),
        ( LocaleCodes.ENGLISH_UNITED_STATES, "English (United States)" ),
        ( LocaleCodes.ENGLISH_SOUTH_AFRICA, "English (South Africa)" ),
        ( LocaleCodes.SPANISH, "Spanish" ),
        ( LocaleCodes.SPANISH_MEXICO, "Spanish (Mexico)" ),
        ( LocaleCodes.FARSI, "Persian (Farsi)" ),
        ( LocaleCodes.FINNISH, "Finnish" ),
        ( LocaleCodes.FRENCH, "French" ),
        ( LocaleCodes.FRENCH_CANADA, "French (Canada)" ),
        ( LocaleCodes.FRENCH_SWITZERLAND, "French (Switzerland)" ),
        ( LocaleCodes.GEORGIAN, "Georgian" ),
        ( LocaleCodes.HRVATSKI, "Croatian" ),
        ( LocaleCodes.INDONESIAN, "Indonesian" ),
        ( LocaleCodes.ITALIAN, "Italian" ),
        ( LocaleCodes.JAPANESE, "Japanese" ),
        ( LocaleCodes.KOREAN, "Korean" ),
        ( LocaleCodes.LATVIAN, "Latvian" ),
        ( LocaleCodes.NORWEGIAN, "Norwegian (Norway)" ),
        ( LocaleCodes.NEPALESE, "Nepali" ),
        ( LocaleCodes.DUTCH, "Dutch" ),
        ( LocaleCodes.DUTCH_BELGIUM, "Dutch (Belgium)" ),
        ( LocaleCodes.POLISH, "Polish" ),
        ( LocaleCodes.PORTUGUESE_BRAZIL, "Portuguese (Brazil)" ),
        ( LocaleCodes.PORTUGUESE_PORTUGAL, "Portuguese (Portugal)" ),
        ( LocaleCodes.ROMANIAN, "Romanian" ),
        ( LocaleCodes.RUSSIAN, "Russian" ),
        ( LocaleCodes.SLOVAKIAN, "Slovak" ),
        ( LocaleCodes.SWEDISH, "Swedish" ),
        ( LocaleCodes.TURKISH, "Turkish" ),
        ( LocaleCodes.UKRAINIAN, "Ukrainian" ),
        ( LocaleCodes.VIETNAMESE, "Vietnamese" ),
        ( LocaleCodes.CHINESE, "Chinese (Simplified)" ),
        ( LocaleCodes.CHINESE_TAIWAN, "Chinese (Taiwan)" ),
        ( LocaleCodes.ZULU_SOUTH_AFRICA, "Zulu (South Africa)" )
    };

    public IList<(string Code, string Description)> ExecuteCommand() => _locales;
}