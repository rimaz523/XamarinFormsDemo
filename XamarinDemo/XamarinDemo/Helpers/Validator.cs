using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace XamarinDemo.Helpers
{
    public static class Validator
    {
        private static Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public static bool IsValidEmail(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
                return false;
            return EmailRegex.IsMatch(emailAddress);
        }
    }
}
