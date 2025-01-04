using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core
{
    public static class Configuration
    {
        public const int DefaultStatusCode = 200;
        public const int DefaultPageNumber = 1;
        public const int DefaultPageSize = 25;
        public const string CorsPolicyName = "wasm";

        public static string ConnectionString { get; set; } = string.Empty;
        public static string FrontEndUrl { get; set; } = string.Empty;
        public static string BackEndUrl { get; set; } = string.Empty;
    }
}
