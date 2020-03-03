using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinDemo.Common
{
    public static class AppConstants
    {
        public static class WebURLs
        {
            public static readonly string ServerURL = "http://49.204.78.4";
            public static readonly string BaseURL = "http://49.204.78.4/qt/index.php/";
            public static readonly string LoginURL = "LoginCtrl";
        }
        public static class Messages
        {
            public const string EmailError = "Please provide a valid email";
            public const string PasswordError = "Please provide a valid password";
            public const string ErrorTitle = "Field Error";
            public const string OK = "OK";
            public const string NetworkErrorTitle = "No Internet";
            public const string NetworkError = "Please check your internet connection and try again";
        }

        public static class Constants
        {
            public const string Token = "jwt";
        }
    }
}
