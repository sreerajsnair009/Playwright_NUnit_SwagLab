using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlaywrightDemo1.Variables
{
    public class AppSettings
    {
        [JsonProperty(Required = Required.Always)]
        public string BaseURL { get; set; } = "";

        [JsonProperty(Required = Required.Always)]
        public string Username { get; set; } = "";

        [JsonProperty(Required = Required.Always)]
        public string Password { get; set; } = "";
    }
}
