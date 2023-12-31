﻿
namespace TxtAppender2 {
    internal class Program {
        static void Main(string[] args) {
            // TODO: add appsettings for default filepath and filename
            // TODO: add ctrl+q etc, esc
            TxtAppender t = new TxtAppender(args);
            t.WriteLoop();
            t.Close();
        }    
    }

    public class TxtAppender {
        private readonly FileStream _stream;
        private readonly StreamWriter _writer;
        private readonly string _targetFile;
        private readonly string _targetDirectory;
        public TxtAppender(string[] args) {
            _targetDirectory = GetPath();
            _targetFile = GetTarget(args);
            _stream = GetStream(_targetFile);
            _writer = new StreamWriter(_stream);
           
        }

        public string GetTarget(string[] args) {
            //TODO: default name should also come from appsettings
            string target = "default";
            if (args.Length > 0) {
                target = args[0];
            }
            return target;
        }

        public string GetPath() {
            string defaultPathName = "baseThoughts";
            try {
                var currentDir = AppDomain.CurrentDomain.BaseDirectory;
                StreamReader  fileStream = new StreamReader(File.OpenRead(currentDir+"\\txt.config"));
                string line = fileStream.ReadLine();
                if(!String.IsNullOrEmpty(line)) {
                    defaultPathName = line; 
                }
            } catch(Exception e) {                
                Console.Error.WriteLine("Error loading filepath from txt.config. Writing to C:\\baseThoughts\\ instead");
            }
            return defaultPathName;
        }

        public FileStream GetStream(string target) {
           
            // this filepath should use appsetttings
            string filepathStem = $"c:\\{_targetDirectory}";
            FileInfo path = new FileInfo(filepathStem);
            Directory.CreateDirectory(filepathStem);
            string filepath = $"{filepathStem}\\{target}.txt";

            FileStream file = File.OpenWrite(filepath);
            // set stream position pointer to end otherwise will overwrite pre-existing text. 
            file.Position = file.Length;
            return file;
        }
        StreamWriter GetStreamWriter(FileStream file) {
            StreamWriter writer = new StreamWriter(file);            
            return writer;
        }

        public void WriteLoop() {


            bool keepGoing = true;
            while (keepGoing) {
                Console.Write($"[{_targetFile}]>");
                string? text = Console.ReadLine();
                if (text == null || text == "quit" || text == "q" || text == "exit") {
                    keepGoing = false;
                    break;
                }
                if (text == @"\n") {
                    _writer.WriteLine("");
                    continue;
                }
                if (!String.IsNullOrEmpty(text)) {
                    _writer.WriteLine(text);
                }                
            }            
        }

        public void Close() {
            _writer.WriteLine("");
            _writer?.Close();
            _stream?.Close();
        }
    }
}