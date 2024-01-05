using QuestEncrypter.Cyphers.Interfaces;

namespace QuestEncrypter.Cyphers.Scytale;

public class ScytaleParams : ICypherParams
{
    public int Interval = 1;
    public int StartPosition = 0;
}