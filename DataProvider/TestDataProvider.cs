using PlaywrightDemo1.DataModels;
using PlaywrightDemo1.EnvironmentFunctions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaywrightDemo1.DataProvider
{
    public static class TestDataProvider
    {
        public static IEnumerable<LoginUser> LoginDataProvider()
        {
            IEnumerable<LoginUser> loginUsers = ReadDataSet.ReadJsonDatasetAs<LoginUser>(EnvironmentHandler.GetDataSetFilePath("LoginData.json"));
            foreach(LoginUser loginUser in loginUsers)
            {
                yield return loginUser;
            }
        }
    }
}
