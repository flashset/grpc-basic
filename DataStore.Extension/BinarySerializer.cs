using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataStore.Extension
{
    public class BinarySerializer<T>
    {       
        public static byte[] Serialize(T toSerialize)
        {
            using (var stream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, toSerialize);
                return stream.ToArray();
            }
        }

        public static T Deserialize(byte[] serialized)
        {
            using (var stream = new MemoryStream(serialized))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                var result = (T)binaryFormatter.Deserialize(stream);
                return result;
            }
        }
    }
}
