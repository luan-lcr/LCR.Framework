using Newtonsoft.Json;

namespace LCR.Framework.Utilities.Extensions;

public static class JsonExtensions
{
    public static string ToJson<T>(this T input, JsonSerializerSettings settings = null)
    {
        return JsonConvert.SerializeObject(input, settings);
    }

    public static T JsonTo<T>(this string json, JsonSerializerSettings settings = null)
    {
        return JsonConvert.DeserializeObject<T>(json, settings);
    }
}
