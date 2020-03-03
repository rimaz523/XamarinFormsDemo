﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;
using XamarinDemo.Common;

namespace XamarinDemo.Helpers
{
    public static class HTTPHelper
    {
        private readonly static string reservedCharacters = "!*'();:@&=+$,/?%#[]";

        public static void Initialize()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };
        }

        public static async Task<string> SendGetRequest(string serviceName, Dictionary<string, object> parameters)
        {
            try
            {
                HttpClient client = new HttpClient();


                string paramString = "";
                if (parameters != null)
                {
                    foreach (KeyValuePair<string, object> param in parameters)
                        paramString += $"{param.Key}={param.Value}&";
                    paramString = paramString.TrimEnd('&');
                }
                string url = Path.Combine(GetBaseAddress(), serviceName);// GetBaseAddress() + serviceName;
                url += "?" + paramString;
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + GetAuthenticationToken());
                //client.Timeout = new TimeSpan(15000);
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    if (!response.IsSuccessStatusCode)
                        throw new Exception($"Http request failed. Status code : {response.StatusCode}.");

                    using (HttpContent content = response.Content)
                    {
                        string result = await content.ReadAsStringAsync();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async static Task<string> SendPostRequest(string serviceName, object parameters, bool auth = true)
        {
            try
            {
                string url = GetBaseAddress() + serviceName;

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                    if (auth)
                        client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + GetAuthenticationToken());
                    //client.Timeout = new TimeSpan(15000);

                    string jsonData = JsonConvert.SerializeObject(parameters);
                    var postData = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, postData);

                    if (!response.IsSuccessStatusCode)
                        throw new Exception($"Http request failed. Status code : {response.StatusCode}.");

                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public static string GetBaseAddress()
        {
            return AppConstants.WebURLs.BaseURL;
        }

        public static string GetAuthenticationHeader()
        {
            //return App.Current.Properties["JWT"].ToString();
            //string username = "";
            //string password = "";
            //string encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));

            //return encoded;
            return "";
        }
        public static string GetAuthenticationToken()
        {
            return App.Current.Properties[Common.AppConstants.Constants.Token].ToString();
        }

        public static string UrlEncode(string value)
        {
            if (String.IsNullOrEmpty(value))
                return String.Empty;

            var sb = new StringBuilder();

            foreach (char @char in value)
            {
                if (reservedCharacters.IndexOf(@char) == -1)
                    sb.Append(@char);
                else
                    sb.AppendFormat("%{0:X2}", (int)@char);
            }
            return sb.ToString();
        }
    }
}
