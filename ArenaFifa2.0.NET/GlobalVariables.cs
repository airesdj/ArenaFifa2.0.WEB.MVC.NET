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

        public static int TOTAL_EMAIL_PER_HOUR = 80;
        public static string SPOOLER_EMAIL_BLOG = "SPOOLER_BLOG_NOTICIA";
        public static string SPOOLER_EMAIL_NEW_SEASON = "SPOOLER_NOVA_TEMPORADA";
        public static string SPOOLER_EMAIL_DRAW_WARNING = "SPOOLER_ALERTA_SORTEIO";
        public static string SPOOLER_EMAIL_DRAW_DONE = "SPOOLER_SORTEIO_EFETUADO";
        public static string SPOOLER_EMAIL_LIVE_BROADCAST = "SPOOLER_TRANSMISSAO_AOVIVO";
        public static string SPOOLER_EMAIL_NEW_ROUND_RELEASED = "SPOOLER_LIBERA_NOVA_RODADA";
        public static string SPOOLER_EMAIL_END_CURRENT_ROUND = "SPOOLER_FINALIZA_RODADA_ATUAL";

        public static HttpClient WebApiClient = new HttpClient();

        static GlobalVariables()
        {
            WebApiClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["api.url"]);
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }

}
