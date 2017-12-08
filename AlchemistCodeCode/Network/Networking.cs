using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AlchemistCodeCode.Network
{
    public static class Networking
    {
        public static int debuglevel = 0;
        public static int TicketID = 1;
        public delegate void ResponseCallback(SRPG.WWWResult result);
        private static int FindStat(string response)
        {
            Regex regex = new Regex("\"stat\":(?<stat>\\d+)", 0);
            Match match = regex.Match(response);
            if (!match.Success)
            {
                return 0;
            }
            return Convert.ToInt32(regex.Match(response).Result("${stat}"));
        }
        private static string FindMessage(string response)
        {
            Regex regex = new Regex("\"stat_msg\":\"(?<stat_msg>.+?)\"[,}]", 0);
            Match match = regex.Match(response);
            if (!match.Success)
            {
                return string.Empty;
            }
            return regex.Match(response).Result("${stat_msg}");
        }
        public static JObject RequestAPI(WebAPI api)
        {
            if (debuglevel > 0)
                Console.Write("Requesting " + api.name + "...");
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://app.alcww.gumi.sg/"/*SRPG.Network.Host*/ + api.name);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Timeout = ((int)(240 * 1000f));
            httpWebRequest.UserAgent = "Mozilla/5.0 (Linux; Android 4.4.2; SM-E7000 Build/KTU84P) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/30.0.0.0 Mobile Safari/537.36";
            if (!string.IsNullOrEmpty(GameManager.Instance.Version))
                httpWebRequest.Headers.Add("x-app-ver", GameManager.Instance.Version);
            if (!string.IsNullOrEmpty(GameManager.Instance.AssetVersion))
                httpWebRequest.Headers.Add("x-asset-ver", GameManager.Instance.AssetVersion);
            httpWebRequest.Headers.Set("X-GUMI-TRANSACTION", api.GumiTransactionId);
            httpWebRequest.Headers.Set("X-Unity-Version", "5.3.6f1");
            if (!string.IsNullOrEmpty(GameManager.Instance.SessionID))
                httpWebRequest.Headers.Add("Authorization", "gumi " + GameManager.Instance.SessionID);
            HttpWebResponse httpWebResponse = null;
            string response = null;
            try
            {
                if (string.IsNullOrEmpty(api.body))
                {
                    httpWebRequest.Method = "GET";
                }
                else
                {
                    httpWebRequest.Method = "POST";
                    byte[] bytes = Encoding.UTF8.GetBytes(api.body);
                    httpWebRequest.ContentLength = (long)bytes.Length;
                    BinaryWriter binaryWriter = new BinaryWriter(httpWebRequest.GetRequestStream());
                    binaryWriter.Write(bytes);
                    binaryWriter.Close();
                }
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), true);
                response = streamReader.ReadToEnd();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                if (httpWebResponse != null)
                    httpWebResponse.Close();
            }
            if (debuglevel > 1)
            {
                if (api.body != null)
                    Console.WriteLine(((JObject)JsonConvert.DeserializeObject(api.body)).ToString());
                Console.WriteLine(((JObject)JsonConvert.DeserializeObject(response)).ToString());
            }
            if (debuglevel > 0)
                Console.WriteLine(" done.");
            TicketID++;
            return (JObject)JsonConvert.DeserializeObject(response);
        }
    }
}
