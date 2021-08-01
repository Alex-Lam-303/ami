using System;
using System.IO;

namespace FileConverter
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var baseroot = @"/Users/peterzhong/OneDrive/Startups/Ami/AmiApp/ami/ami/Resources/Audios/";
            foreach (var file in Directory.GetFiles(baseroot))
            {
                var name = Path.GetFileName(file);
                if (name != ".DS_Store")
                {
                    var nameWithoutExtention = name.Remove(name.Length - 4);
                    nameWithoutExtention = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(nameWithoutExtention));
                    nameWithoutExtention = nameWithoutExtention + ".caf";
                    Directory.Move(file, baseroot + nameWithoutExtention);
                }
            }
            Console.WriteLine(System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("我是人")));
        }
    }
}
