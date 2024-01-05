namespace QuestEncrypter.Helpers;

public static class EncryptionConstants
{
    public const string DEFAULT_NUMBERS = "0123456789";
    public const string DEFAULT_SYMBOLS = ".,!?@#$%^& _()[]{}<>+-*/=";
    public const string DEFAULT_ALPHABET_RU = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
    public const string DEFAULT_ALPHABET_EN = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public const string DEFAULT_ALPHABET =
        DEFAULT_ALPHABET_RU + DEFAULT_ALPHABET_EN + DEFAULT_NUMBERS + DEFAULT_SYMBOLS;
}