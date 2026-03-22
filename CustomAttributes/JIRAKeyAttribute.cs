using System;
using System.Collections.Generic;
using System.Text;

namespace PlaywrightDemo1.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class JIRAKeyAttribute : Attribute
    {
        public string Key { get; }
        public JIRAKeyAttribute(string Key) => this.Key = Key;
    }
}
