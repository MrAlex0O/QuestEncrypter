using QuestEncrypter.Cyphers.Interfaces;

namespace QuestEncrypter.Models;

public class InputModel
{
    public string Text { get; set; }
    public CypherMode CypherMode { get; set; }
    public ICypherParams CypherParams { get; set; }
}

public enum CypherMode
{
    Encrypt,
    Decrypt
}