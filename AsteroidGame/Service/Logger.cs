using System;
using System.IO;

namespace AsteroidGame.Service
{
    public class Logger
    {
        private readonly TextWriter _Writer;
        private const string _FILE_PATH = "Log.log";

        public Logger()
        {
            _Writer = File.CreateText(_FILE_PATH);
            ((StreamWriter) _Writer).AutoFlush = true;
        }

        public void LogInConsole(string msg) => Console.WriteLine(msg);

        public void LogInFile(string msg) => _Writer.WriteLine(msg);
    }
}
