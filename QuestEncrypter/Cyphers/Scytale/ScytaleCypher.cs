using System.Text;
using QuestEncrypter.Cyphers.Interfaces;

namespace QuestEncrypter.Cyphers.Scytale;

public class ScytaleCypher : ICypher
{
    public override ICypherResult Encrypt(string text, ICypherParams cypherParams)
    {
        var scytaleParams = (ScytaleParams)cypherParams;

        var length = scytaleParams.Alphabet.Length;
        var random = new Random();
        var sb = new StringBuilder();

        for (var i = 0; i < scytaleParams.StartPosition; i++) sb.Append(scytaleParams.Alphabet[random.Next(0, length)]);
        foreach (var ch in text)
        {
            sb.Append(ch);
            for (var i = 0; i < scytaleParams.Interval; i++) sb.Append(scytaleParams.Alphabet[random.Next(0, length)]);
        }

        return new ScytaleResult { Result = sb.ToString().ToUpper() };
    }

    public override ICypherResult Decrypt(string text, ICypherParams cypherParams)
    {
        var scytaleParams = (ScytaleParams)cypherParams;

        var sb = new StringBuilder();
        for (var i = scytaleParams.StartPosition; i < text.Length; i += scytaleParams.Interval + 1) sb.Append(text[i]);

        return new ScytaleResult
        {
            Result = sb.ToString()
        };
    }

    public override void CheckParamsForEncryption(ICypherParams cypherParams)
    {
        var scytaleParams = (ScytaleParams)cypherParams;
        if (cypherParams == null) throw new ArgumentException("Params must be not null");
        if (scytaleParams.Interval < scytaleParams.StartPosition)
            throw new ArgumentException("Interval must be greater or equal than StartPosition");
    }

    public override void CheckParamsForDecryption(ICypherParams cypherParams)
    {
    }
}