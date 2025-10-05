namespace StreamAndFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var path = @"D:\c#";
            var dir = new DirectoryInfo(path);

            //Lấy tất cả các thư mục con trong thư mục
            foreach (var item in dir.GetDirectories())
            {
                Console.WriteLine($"{item.Name} - {item.LastWriteTime}");
            }

            //Console.WriteLine("====================================");
            ////Lấy tất cả các file trong thư mục
            //foreach (var item in dir.GetFiles())
            //{
            //    Console.WriteLine($"{item.Name} - {item.LastWriteTime}");
            //}


            Console.WriteLine("====================================");
            string fileName = "Account.txt";
            var pathFile = GetFileDirectory(Directory.GetCurrentDirectory(), fileName);
            
            if(string.IsNullOrEmpty(pathFile.Item1))
                Console.WriteLine($"{fileName} not found");
            else
                Console.WriteLine($"File found at: {pathFile}");

            byte[] buffer = new byte[1024];

            using var instream = File.OpenRead(pathFile.Item1);

            using var outStream = File.OpenWrite(Path.Combine(pathFile.Item2,"Account_copy.txt"));
            int n = instream.Read(buffer, 0, buffer.Length);
            while (n > 0)
            {
                Console.WriteLine(n.ToString());
                outStream.Write(buffer, 0, n);
                n = instream.Read(buffer, 0, buffer.Length);
            }

            //Đọc tất cả các dòng trong file
            string text = File.ReadAllText(pathFile.Item1);
            Console.WriteLine(text);

            //Đọc từng dòng trong file
            string[] lines = File.ReadAllLines(pathFile.Item1);
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }

            //Đọc từng dòng trong file sử dụng StreamReader
            using (var reader = new StreamReader(pathFile.Item1))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            //Đọc từng dòng trong file và tách chuỗi sử dụng StreamReader
            using (var reader = new StreamReader(pathFile.Item1))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split("=",StringSplitOptions.TrimEntries);
                    if(parts.Length == 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();
                        Console.WriteLine($"Key: {key}, Value: {value}");
                    }    
                }
            }

            //Ghi log trong file sử dụng StreamWriter
            string logFilePath = Path.Combine(pathFile.Item2, "logs");
            if(!Directory.Exists(logFilePath))
                Directory.CreateDirectory(logFilePath);
            string logPath = Path.Combine(logFilePath, "Debug.txt");
            using (var writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{DateTime.Now}: Log entry 1");
            }

        }

        public static (string, string) GetFileDirectory(string Path,string FileName)
        {
            if(string.IsNullOrEmpty(Path))
                return ("Path name is null or empty","");
            if(string.IsNullOrEmpty(FileName))
                return ("File name is null or empty","");

            var curDir = new DirectoryInfo(Path);

            while(curDir != null)
            {
                var isFileExist = curDir.GetFiles(FileName, SearchOption.TopDirectoryOnly).FirstOrDefault();
                if (isFileExist != null && isFileExist.Exists)
                    return (isFileExist.FullName,curDir.FullName);
                curDir = curDir.Parent;
            }
            return (null,null);
        }
    }
}
