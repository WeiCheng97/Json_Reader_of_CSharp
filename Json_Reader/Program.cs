using Newtonsoft.Json;
using System.IO;

namespace Json_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\Weicheng\\Desktop\\json.txt";
            ReadFile(path);
            System.Console.ReadKey();
        }
        private static void ReadFile(string path)
        {
            StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8);
            string line, jsonText = "";
            while ((line = sr.ReadLine()) != null)
            {
                jsonText += line;
            }
            //System.Console.WriteLine(jsonText);
            ReadJson(jsonText);
        }
        private static void ReadJson(string jsonText)
        {
            JsonReader reader = new JsonTextReader(new StringReader(jsonText));
            string text, aid, face, time, url = "<a href =\"http://www.bilibili.com/video/av";
            int flag = 0;
            while (reader.Read())
            {
                if (reader.Value!=null)
                {
                    if (reader.Value.ToString() == "say")
                    {
                        flag++;
                        reader.Read(); 
                        text = reader.Value.ToString();
                        for (int i = 0; i < 4; i++)
                            reader.Read();
                        face = reader.Value.ToString();
                        for (int i = 0; i < 4; i++)
                            reader.Read();
                        aid = reader.Value.ToString();
                        for (int i = 0; i < 2; i++)
                            reader.Read();
                        time = reader.Value.ToString();
                        //System.Console.WriteLine(text + " " + aid + " " + time);
                     
                        System.Console.Write(url + aid + "?t=" + time + "\"  target=\"_blank\"><img src=\"http://static.hdslb.com/eggs/kichiku/src/face/" + face + "\" width=\"50\"/>" + text + "</a>");
                        if (flag % 2 == 0)
                            System.Console.WriteLine();
                    }
                    //获取数据类型&key&Value
                    /*<a href=//www.bilibili.com/video/av13420453 + "?t=" + t.time + ' target="_blank">
                     * PropertyName            System.String           say
                        String          System.String           @￥&…渣渣？
                        PropertyName            System.String           key
                        String          System.String           ZZ
                        PropertyName            System.String           face
                        String          System.String           p17.JPG
                        PropertyName            System.String           audio
                        String          System.String           ys5.mp3
                        PropertyName            System.String           aid
                        Integer         System.Int64            13420453
                        PropertyName            System.String           time
                        Integer         System.Int64            160
                     */
                    //System.Console.WriteLine(reader.TokenType + "\t\t" + reader.ValueType + "\t\t" + reader.Value);

                }
            }
                
        }
    }
}
