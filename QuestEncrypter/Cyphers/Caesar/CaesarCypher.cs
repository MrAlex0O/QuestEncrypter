using System.Text;
using QuestEncrypter.Cyphers.Interfaces;

namespace QuestEncrypter.Cyphers.Caesar;

public class CaesarCypher : ICypher
{
    public ICypherResult Shift(string text, CaesarParams caesarParams)
    {
        text = text.ToUpper();
        var fullAlfabet = caesarParams.Alphabet.ToUpper();
        var alfabetLength = fullAlfabet.Length;
        var sb = new StringBuilder();
        for (var i = 0; i < text.Length; i++)
        {
            var c = text[i];
            var index = fullAlfabet.IndexOf(c);
            if (index < 0)
            {
                sb.Append(c);
            }
            else
            {
                var codeIndex = (index + caesarParams.Offset) % alfabetLength;
                sb.Append(fullAlfabet[codeIndex]);
            }
        }

        return new CaesarResult { Result = sb.ToString().ToUpper() };
    }

    public override ICypherResult Encrypt(string text, ICypherParams cypherParams)
    {
        return Shift(text, (CaesarParams)cypherParams);
    }

    public override ICypherResult Decrypt(string text, ICypherParams cypherParams)
    {
        return Shift(text, ((CaesarParams)cypherParams).ReverseOffset());
    }

    public override void CheckParamsForEncryption(ICypherParams cypherParams)
    {
    }

    public override void CheckParamsForDecryption(ICypherParams cypherParams)
    {
    }
}