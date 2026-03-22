using OfficeOpenXml;
using PlaywrightDemo1.EnvironmentFunctions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Text;
using System.ComponentModel;
using PlaywrightDemo1.DataModels;
using Newtonsoft.Json;

namespace PlaywrightDemo1.DataProvider
{
    public static class ReadDataSet
    {
        public static IEnumerable<T> ReadJsonDatasetAs<T>(string jsonFilePath)
        {
            string jsonFileText = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<IList<T>>(jsonFileText);
        }
    }
}
