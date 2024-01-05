namespace QuestEncrypter.Cyphers.Interfaces;

public abstract class ICypher
{
    public abstract ICypherResult Encrypt(string text, ICypherParams cypherParams);
    public abstract ICypherResult Decrypt(string text, ICypherParams cypherParams);
    public abstract void CheckParamsForEncryption(ICypherParams cypherParams);
    public abstract void CheckParamsForDecryption(ICypherParams cypherParams);
}