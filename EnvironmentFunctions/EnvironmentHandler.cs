using Newtonsoft.Json;
using PlaywrightDemo1.Variables;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaywrightDemo1.EnvironmentFunctions
{
    public static class EnvironmentHandler
    {
        public static string GetAbsoluteFilePath(string relativeFilePath) => System.AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug\net10.0\", "") + relativeFilePath;

        public static AppSettings LoadAppSettings()
        {
            string appSettingsFileContent = File.ReadAllText(GetAbsoluteFilePath(@"\AppSettings.json"));
            return JsonConvert.DeserializeObject<AppSettings>(appSettingsFileContent)!;
        }

        public static string GetCurrentTimestamp(string format = "yyyyMMddHHmmss") => System.DateTime.Now.ToString(format);
        public static string GetLogFilePath() => GetAbsoluteFilePath($@"\logs\log_{GetCurrentTimestamp()}");
        public static string GetDataSetFilePath(string fileName) => GetAbsoluteFilePath($@"\DataProvider\{fileName}");
    }
}
