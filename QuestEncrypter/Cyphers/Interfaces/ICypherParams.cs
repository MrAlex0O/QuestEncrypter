using QuestEncrypter.Helpers;

namespace QuestEncrypter.Cyphers.Interfaces;

public abstract class ICypherParams
{
    public string Alphabet = EncryptionConstants.DEFAULT_ALPHABET;
    public virtual string CypherType { get; set; }
}