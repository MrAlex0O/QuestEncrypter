using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuestEncrypter.Cyphers.Interfaces;

namespace EncrypterAPI.Helpers;

public class ParamsJsonConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(ICypherParams);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var obj = JObject.Load(reader);
        ICypherParams? cypherParams;
        var pt = obj["CypherType"];
        if (pt == null) throw new ArgumentException("Missing ICypherParams", "cypherParams");

        var productType = pt.Value<string>();
        var typelist = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.BaseType.Name == typeof(ICypherParams).Name).ToArray();

        var type = typelist.FirstOrDefault(t => t.Name == productType + "Params");
        if (type != null)
            cypherParams = (ICypherParams?)Activator.CreateInstance(type);
        else
            throw new NotSupportedException("Unknown product type: " + productType);
        serializer.Populate(obj.CreateReader(), cypherParams);
        return cypherParams;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}