using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AlchemistCodeCode.Network;
using AlchemistCodeCode.Network.Requests;
namespace AlchemistCodeCode
{
    class Program
    {
        static void RespLogin(SRPG.WWWResult www)
        {
            var response = (JObject)JsonConvert.DeserializeObject(www.text);
            var user = response["body"];
            Networking.TicketID++;
        }
        static void Login()
        {
            GameManager.Instance.AssetVersion = GameManager.Instance.SessionID = null;
            //var CheckVersion = Networking.RequestAPI(new ReqCheckVersion(GameManager.Instance.Version, "android"));
            var CheckVersion = Networking.RequestAPI(new ReqCheckVersion(GameManager.Instance.Version, "ios"));
            GameManager.Instance.AssetVersion = CheckVersion["body"]["assets"].ToString();
            Networking.TicketID = 1;
            //GameManager.Instance.UdId = "----";
            if (String.IsNullOrEmpty(GameManager.Instance.DeviceId))
            {
                var DeviceId = Networking.RequestAPI(new ReqGetDeviceID(GameManager.Instance.SecretKey, GameManager.Instance.UdId));
                GameManager.Instance.DeviceId = DeviceId["body"]["device_id"].ToString();
            }
            var AccessToken = Networking.RequestAPI(new ReqGetAccessToken(GameManager.Instance.DeviceId, GameManager.Instance.SecretKey));
            GameManager.Instance.SessionID = AccessToken["body"]["access_token"].ToString();
            //Networking.RequestAPI(new ReqSendAlterData());
            Networking.RequestAPI(new ReqFgGAuth());
            Networking.RequestAPI(new ReqLogin());
            //Networking.RequestAPI(new ReqPlayNew(false));
            //Networking.RequestAPI(new ReqSetLanguage("en"));
        }
        static void DoBattle(String iname, bool useFriend = false, int partyIndex = 0)
        {
            var battleInfo = Networking.RequestAPI(new ReqBtlComReq(iname, "", false, partyIndex));
            var beats = battleInfo["body"]["btlinfo"]["drops"].Select(b => 1).ToArray();
            var dropped = battleInfo["body"]["btlinfo"]["drops"].Select(b => 0).ToArray();
            var steal = battleInfo["body"]["btlinfo"]["drops"].Select(b => 0).ToArray();
            var missions = new int[3] { 1, 1, 1 };
            Networking.RequestAPI(
                new ReqBtlComEnd(
                    long.Parse(battleInfo["body"]["btlid"].ToString()), 
                    0,
                    SRPG.BtlResultTypes.Win,
                    beats,
                    dropped,
                    steal,
                    missions,
                    null,
                    new Dictionary<OString, OInt>(),
                    SRPG.BtlEndTypes.com, 
                    "\"hpleveldamage\":[419,1,146]"
                )
            );
        }
        static void CompleteChallenge(Boolean bingo, params string[] iname)
        {
            var trophies = new List<SRPG.TrophyState>();
            foreach (var trophy in iname)
            {
                var newTrophy = new SRPG.TrophyState
                {
                    iname = trophy,
                    Count = new int[1] { 1 },
                    StartYMD = int.Parse(DateTime.Now.ToString("yyMMdd"))
                };
                if (bingo)
                {
                    newTrophy.Param = new SRPG.TrophyParam();
                    newTrophy.Param.ParentTrophy = trophy.Substring(0, trophy.Length - 3);

                }
                trophies.Add(newTrophy);
            }
            if (bingo)
                Networking.RequestAPI(new ReqUpdateBingo(trophies, true));
            else
                Networking.RequestAPI(new ReqUpdateTrophy(trophies, true));
        }
        static void Reroll()
        {
            /*var translation = File.ReadAllLines(@"text\Loc_english_LocalizedMasterParam.txt")
                .ToList().FindAll(s => s.Contains("SRPG_UnitParam_UN_V2_"))
                .Select(s => s.Split(new char[1] { '\t' }))
                .ToDictionary(s => s[0].Replace("SRPG_UnitParam_", "").Replace("_NAME", ""), s => s[1]);*/
            /*.Select(s =>
                new KeyValuePair<string, string>(s.Substring(21, s.IndexOf("\t")), s.Substring(s.IndexOf("\t") + 1))).ToList();/*.
                ToDictionary(o => o.Key, o => o.Value);//*/
            Networking.debuglevel = 1;
            Console.WriteLine("reroll start");
            Login();
            DoBattle("QE_OP_0002");
            DoBattle("QE_OP_0003");
            DoBattle("QE_OP_0004");
            DoBattle("QE_OP_0006");
            //CompleteChallenge(true, Enumerable.Range(0, 9).Select(i => "CHALLENGE_01_0" + i).ToArray());
            CompleteChallenge(true, "CHALLENGE_01_08");
            Networking.RequestAPI(new ReqTutUpdate(8192));
            Networking.RequestAPI(new ReqAwardList());
            CompleteChallenge(false, "DAILY_GLAPVIDEO_06");
            Networking.RequestAPI(new ReqTutUpdate(8193));
            CompleteChallenge(false, "LOGIN_GLTUTORIAL_01");
            //Networking.RequestAPI(new ReqAwardList());
            //Networking.RequestAPI(new ReqTrophyProgress());
            //Networking.RequestAPI(new ReqTutUpdate(8195));
            //Networking.RequestAPI(new ReqGacha());
            //Networking.RequestAPI(new ReqBtlCom(true));
            //Networking.RequestAPI(new ReqTutUpdate(10243));
            //Networking.RequestAPI(new ReqTutUpdate(10251));
            //Networking.RequestAPI(new ReqSupporter());
            CompleteChallenge(false, Enumerable.Range(1, 10).Select(i => "WINQUEST_" + i.ToString("D3")).ToArray());
            //DoBattle("QE_ST_NO_010001");
            //DoBattle("QE_ST_NO_010002");
            //DoBattle("QE_ST_NO_010003");
            //Networking.RequestAPI(new ReqTutUpdate(10763));
            var mail = Networking.RequestAPI(new ReqMail(1, true, false));
            var mailIds = mail["body"]["mails"]["list"].Select(m => long.Parse(m["mid"].ToString())).ToArray();
            Networking.RequestAPI(new ReqMailRead(mailIds, true, 1));

            Networking.RequestAPI(new ReqGachaExec("Rare_Gacha_ii", 1));
            var summon = Networking.RequestAPI(new ReqGachaExec("3Step_Gacha_Step1_B0b", 0));
            //var units = String.Join("|", summon["body"]["units"].Select(u => translation[u["iname"].ToString()])).Replace("Logi|Lambert|Melia|", "");
            //File.AppendAllText("accounts.csv", units + "," + "http://shalzuth.us-east-1.elasticbeanstalk.com/Starter?a=" + GameManager.Instance.DeviceId + "&b=" + GameManager.Instance.SecretKey + "\r\n");
            //Console.WriteLine(String.Join(",", summon["body"]["units"].Select(u => translation[u["iname"].ToString()])).Replace("Logi,Lambert,Melia,", ""));
        }
        static void Main(string[] args)
        {
            Networking.debuglevel = 1;
            //GameManager.Instance.SecretKey = "----";
            //GameManager.Instance.DeviceId = "----";
            while (true)
            {
                GameManager.Instance.DeviceId = null;

            }
            Login();

            //CompleteChallenge(true, Enumerable.Range(0, 9).Select(i => "CHALLENGE_03_" + i.ToString("D2")).ToArray());
            var gacha = Networking.RequestAPI(new ReqGacha());
            var summon = Networking.RequestAPI(new ReqGachaExec("3Step_Gacha_Step1_B0b", 0));
            CompleteChallenge(false, Enumerable.Range(1, 90).Select(i => "WINQUEST_" + i.ToString("D3")).ToArray());
            //Enumerable.Range(11, 19).Select(i => "QE_ST_HA_0100" + i.ToString("D2")).ToList().ForEach(i => DoBattle(i));
            Console.WriteLine("fin");
            Console.Read();

            //File.WriteAllText("accounts.csv", "units,download link\r\n");
            /*while (true)
            {
                try { Reroll(); } catch { }
            }*/

        }
    }
}
