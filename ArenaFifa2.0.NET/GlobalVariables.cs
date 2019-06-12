using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;


namespace ArenaFifa20.NET
{
    public static class GlobalVariables
    {

        public static string STAGE_QUALIFY2 = "-2";
        public static string STAGE_QUALIFY1 = "-1";
        public static string STAGE_TEAM_TABLE = "0";
        public static string STAGE_SECOND_STAGE = "1";
        public static string STAGE_TEAM_ROUND_16 = "2";
        public static string STAGE_QUARTER_FINAL = "3";
        public static string STAGE_SEMI_FINAL = "4";
        public static string STAGE_FINAL = "5";

        public static HttpClient WebApiClient = new HttpClient();

        static GlobalVariables()
        {
            WebApiClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["api.url"]);
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }

}
