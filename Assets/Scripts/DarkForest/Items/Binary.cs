using System.IO;

public class Binary
{
    /// <summary>
    /// 序列化为二进制字节数组
    /// </summary>
    /// <param name="request">要序列化的对象</param>
    /// <returns>字节数组</returns>
    public static byte[] SerializeBinary(object request)
    {
        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        MemoryStream memStream = new MemoryStream();
        serializer.Serialize(memStream, request);
        return memStream.GetBuffer();
    }
    /// <summary>
    /// 从二进制数组反序列化得到对象 
    /// </summary>
    /// <param name="buf">字节数组</param>
    /// <returns>得到的对象</returns>
    public static object DeserializeBinary(byte[] buf)
    {
        MemoryStream memStream = new MemoryStream(buf);
        memStream.Position = 0;
        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter deserializer =
            new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        object newobj = deserializer.Deserialize(memStream);
        memStream.Close();
        return newobj;
    }
}
