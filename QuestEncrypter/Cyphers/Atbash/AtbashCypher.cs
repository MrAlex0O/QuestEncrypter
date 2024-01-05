using System.Text;
using QuestEncrypter.Cyphers.Interfaces;

namespace QuestEncrypter.Cyphers.Atbash;

public class AtbashCypher : ICypher
{
    private ICypherResult EncryptDecrypt(string text, string symbols)
    {
        text = text.ToUpper();
        var stringArray = symbols.ToCharArray();
        Array.Reverse(stringArray);
        var cipher = new string(stringArray);
        var sb = new StringBuilder();
        for (var i = 0; i < text.Length; i++)
        {
            var index = symbols.IndexOf(text[i]);
            if (index >= 0) sb.Append(cipher[index]);
        }

        return new AtbashResult { Result = sb.ToString() };
    }

    public override ICypherResult Encrypt(string text, ICypherParams cypherParams)
    {
        return EncryptDecrypt(text, cypherParams.Alphabet);
    }

    public override ICypherResult Decrypt(string text, ICypherParams cypherParams)
    {
        return EncryptDecrypt(text, cypherParams.Alphabet);
    }

    public override void CheckParamsForEncryption(ICypherParams cypherParams)
    {
    }

    public override void CheckParamsForDecryption(ICypherParams cypherParams)
    {
    }
}