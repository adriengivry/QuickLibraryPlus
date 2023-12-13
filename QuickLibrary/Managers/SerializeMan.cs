using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text;

#pragma warning disable SYSLIB0011 // TODO: Remove this pragma and fix the serializer

namespace QuickLibrary
{
	public static class SerializeMan
	{
        public static byte[] ObjectToByteArray<T>(T obj)
        {
            if (obj == null)
                return null;

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true, // Optional: Set this to true if you want indented JSON
            };

            string jsonString = JsonSerializer.Serialize(obj, options);
            return Encoding.UTF8.GetBytes(jsonString);
        }

        public static T ByteArrayToObject<T>(byte[] arrBytes)
        {
            if (arrBytes == null)
                return default;

            string jsonString = Encoding.UTF8.GetString(arrBytes);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
