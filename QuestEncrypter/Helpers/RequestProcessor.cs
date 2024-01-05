using QuestEncrypter.Cyphers.Interfaces;
using QuestEncrypter.Models;

namespace QuestEncrypter.Helpers;

public class RequestProcessor
{
    public static ICypherResult Encrypt(InputModel inputModel)
    {
        var crypter = CypherTransformer.GetCrypter(inputModel.CypherParams.CypherType);
        crypter.CheckParamsForEncryption(inputModel.CypherParams);
        return crypter.Encrypt(inputModel.Text, inputModel.CypherParams);
    }

    public static ICypherResult Decrypt(InputModel inputModel)
    {
        var crypter = CypherTransformer.GetCrypter(inputModel.CypherParams.CypherType);
        crypter.CheckParamsForDecryption(inputModel.CypherParams);
        return crypter.Decrypt(inputModel.Text, inputModel.CypherParams);
    }
}