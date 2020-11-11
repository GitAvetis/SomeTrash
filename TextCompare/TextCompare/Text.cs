using System.IO;

namespace TextCompare
{
    public class Text
    {
        public string[] TextExample(string path)
        {
            string[] text = File.ReadAllLines(path);
            return text;
        }
    }
}
