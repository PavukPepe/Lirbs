
using Newtonsoft.Json;
using System.IO;

namespace SerializerLib
{
    public static class Serializer
    {
        public static T Read<T>(string filename)
        {
            string json = File.ReadAllText(filename);
            T types = JsonConvert.DeserializeObject<T>(json);
            return types;
        }

        public static void Write<T>(T types, string filename)
        {
            string json = JsonConvert.SerializeObject(types);
            File.WriteAllText(filename, json);
        }
    }

}
