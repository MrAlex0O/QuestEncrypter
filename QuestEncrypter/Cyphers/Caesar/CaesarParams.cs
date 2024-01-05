using QuestEncrypter.Cyphers.Interfaces;

namespace QuestEncrypter.Cyphers.Caesar;

public class CaesarParams : ICypherParams
{
    public int Offset = 1;

    public CaesarParams ReverseOffset()
    {
        Offset *= -1;
        return this;
    }
}