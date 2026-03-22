using System;
using System.Collections.Generic;
using System.Text;

namespace PlaywrightDemo1.EnvironmentFunctions
{
    public static class TestLogger
    {
        //private static readonly string logFilePath = EnvironmentHandler.GetLogFilePath();
        //static TestLogger()
        //{
        //    Directory.CreateDirectory(Path.GetDirectoryName(logFilePath)!);
        //}

        public static void Info(string message) => WriteLog("INFO", message);
        public static void Pass(string message) => WriteLog("PASS", message);
        public static void Fail(string message)
        {
            Assert.Fail(message);
            WriteLog("FAIL", message);
        }

        private static void WriteLog(string level, string message)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
            TestContext.Out.WriteLine(logEntry);
            //File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
        }
    }
}
