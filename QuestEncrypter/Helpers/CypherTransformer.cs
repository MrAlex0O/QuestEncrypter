using System.Reflection;
using QuestEncrypter.Cyphers.Interfaces;

namespace QuestEncrypter.Helpers;

public static class CypherTransformer
{
    public static ICypher GetCrypter(string name)
    {
        var typelist = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType.Name == typeof(ICypher).Name)
            .ToArray();

        var type = typelist.FirstOrDefault(t => t.Name == name + "Cypher");
        return (ICypher)Activator.CreateInstance(type);
    }
}