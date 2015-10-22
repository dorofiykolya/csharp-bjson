namespace BinaryJSON
{
    public class BinaryJSON
    {
        private static readonly TypeDescription TypeDescriptor = new TypeDescription();
        private static readonly BinaryJSONReader Reader = new BinaryJSONReader(TypeDescriptor);
        private static readonly BinaryJSONWriter Writer = new BinaryJSONWriter(TypeDescriptor);

        public static T Read<T>(byte[] binaryJSON)
        {
            return Reader.Read<T>(binaryJSON);
        }

        public static byte[] Write(object value)
        {
            return Writer.Write(value);
        }
    }
}
