namespace Bogus.App;
public static class Constants
{
    // Command
    public const char SHORTNAME_COMMAND_LOCALE = 'l';
    public const string LONGNAME_COMMAND_LOCALE = "locale";
    public const string DESCRIPTION_COMMAND_LOCALE = "We support a whole bunch of different locales.";
    
    public const char SHORTNAME_COMMAND_FILE_FORMAT = 'f';
    public const string LONGNAME_COMMAND_FILE_FORMAT = "file-format";
    public const string DESCRIPTION_COMMAND_FILE_FORMAT = "Description...";
    
    public const char SHORTNAME_COMMAND_FILE_PATH = 'p';
    public const string LONGNAME_COMMAND_FILE_PATH = "file-path";
    public const string DESCRIPTION_COMMAND_FILE_PATH = "Description...";
    
    public const char SHORTNAME_COMMAND_LIMIT_ROWS = 'r';
    public const string LONGNAME_COMMAND_LIMIT_ROWS = "limit-rows";
    public const string DESCRIPTION_COMMAND_LIMIT_ROWS = "Description...";
    
    public const char SHORTNAME_COMMAND_SEPARATOR = 's';
    public const string LONGNAME_COMMAND_SEPARATOR = "separator";
    public const string DESCRIPTION_COMMAND_SEPARATOR = "Description...";

    // Faker - Name
    public const string FAKER_NAME_FIRSTNAME = "name.firstname";
    public const string FAKER_NAME_LASTNAME = "name.lastname";

    // Locale
    public const string AF_ZA = "af_ZA";
    public const string AR = "ar";
    public const string AZ = "az";
    public const string CZ = "cz";
    public const string DE = "de";
    public const string DE_AT = "de_AT";
    public const string DE_CH = "de_CH";
    public const string EL = "el";
    public const string EN = "en";
    public const string EN_AU = "en_AU";
    public const string EN_AU_OCKER = "en_AU_ocker";
    public const string EN_BORK = "en_BORK";
    public const string EN_CA = "en_CA";
    public const string EN_GB = "en_GB";
    public const string EN_IE = "en_IE";
    public const string EN_IND = "en_IND";
    public const string EN_NG = "en_NG";
    public const string EN_US = "en_US";
    public const string EN_ZA = "en_ZA";
    public const string ES = "es";
    public const string ES_MX = "es_MX";
    public const string FA = "fa";
    public const string FI = "fi";
    public const string FR = "fr";
    public const string FR_CA = "fr_CA";
    public const string FR_CH = "fr_CH";
    public const string GE = "ge";
    public const string HR = "hr";
    public const string ID_ID = "id_ID";
    public const string IT = "it";
    public const string JA = "ja";
    public const string KO = "ko";
    public const string LV = "lv";
    public const string NB_NO = "nb_NO";
    public const string NE = "ne";
    public const string NL = "nl";
    public const string NL_BE = "nl_BE";
    public const string PL = "pl";
    public const string PT_BR = "pt_BR";
    public const string PT_PT = "pt_PT";
    public const string RO = "ro";
    public const string RU = "ru";
    public const string SK = "sk";
    public const string SV = "sv";
    public const string TR = "tr";
    public const string UK = "uk";
    public const string VI = "vi";
    public const string ZH_CN = "zh_CN";
    public const string ZH_TW = "zh_TW";
    public const string ZU_ZA = "zu_ZA";

    public static Dictionary<string, string> LOCALE_LIST = new()
    {
        {AF_ZA, "Afrikaans"},
        {AR, "Arabic"},
        {AZ, "Azerbaijani"},
        {CZ, "Czech"},
        {DE, "German"},
        {DE_AT, "German(Austria)"},
        {DE_CH, "German(Switzerland)"},
        {EL, "Greek"},
        {EN, "English"},
        {EN_AU, "English(Australia)"},
        {EN_AU_OCKER, "English(Australia Ocker)"},
        {EN_BORK, "English(Bork)"},
        {EN_CA, "English(Canada)"},
        {EN_GB, "English(Great Britain)"},
        {EN_IE, "English(Ireland)"},
        {EN_IND, "English(India)"},
        {EN_NG, "Nigeria(English)"},
        {EN_US, "English(United States)"},
        {EN_ZA, "English(South Africa)"},
        {ES, "Spanish"},
        {ES_MX, "Spanish(Mexico)"},
        {FA, "Farsi"},
        {FI, "Finnish"},
        {FR, "French"},
        {FR_CA, "French(Canada)"},
        {FR_CH, "French(Switzerland)"},
        {GE, "Georgian"},
        {HR, "Hrvatski"},
        {ID_ID, "Indonesia"},
        {IT, "Italian"},
        {JA, "Japanese"},
        {KO, "Korean"},
        {LV, "Latvian"},
        {NB_NO, "Norwegian"},
        {NE, "Nepalese"},
        {NL, "Dutch"},
        {NL_BE, "Dutch(Belgium)"},
        {PL, "Polish"},
        {PT_BR, "Portuguese(Brazil)"},
        {PT_PT, "Portuguese(Portugal)"},
        {RO, "Romanian"},
        {RU, "Russian"},
        {SK, "Slovakian"},
        {SV, "Swedish"},
        {TR, "Turkish"},
        {UK, "Ukrainian"},
        {VI, "Vietnamese"},
        {ZH_CN, "Chinese"},
        {ZH_TW, "Chinese(Taiwan)"},
        {ZU_ZA, "Zulu(South Africa)"}
    };
}