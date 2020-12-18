namespace OriinDic.Models
{
    /// <summary>
    /// Adding a search for base terms if they are with translations
    /// </summary>
    public enum EnumHasTranslations : byte
    {
        WithTranslations = 1,
        WithoutTranslations = 0,
        None = 255
    }
}
