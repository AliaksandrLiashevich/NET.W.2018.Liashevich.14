using System.IO;

namespace MatrixLibrary
{
    public static class Listeners
    {
        private static string path = "";

        public static void MatrixModification(string message)
        {
            using (StreamWriter writer = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                writer.Write(message);
            }
        }
    }
}