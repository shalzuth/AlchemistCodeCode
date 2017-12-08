using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.IO.Compression;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AlchemistCodeCode;
using AlchemistCodeCode.Network;
using AlchemistCodeCode.Network.Requests;

namespace DataExtractor.Wiki
{
    class Updater
    {
        public static JObject Data_MasterParam;
        public static Dictionary<String, String> Loc_english_LocalizedMasterParam;

        static byte[] Decompress(byte[] input)
        {
            var correctedInput = input.ToList().Skip(2).ToList().ToArray();
            using (MemoryStream original = new MemoryStream(correctedInput))
            using (MemoryStream final = new MemoryStream())
            using (DeflateStream decompressionStream = new DeflateStream(original, CompressionMode.Decompress))
            {
                decompressionStream.CopyTo(final);
                return final.ToArray();
            }
        }
        public static void ReadAssetListProc(string path, ref List<AssetList.Item> ItemList)
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                var mRevision = binaryReader.ReadInt32();
                int num = binaryReader.ReadInt32();
                AssetList.Item[] array = new AssetList.Item[num];
                ItemList = null;
                ItemList = new List<AssetList.Item>(array);
                for (int i = 0; i < num; i++)
                {
                    if (ItemList[i] == null)
                    {
                        ItemList[i] = new AssetList.Item();
                    }
                    AssetList.Item item = ItemList[i];
                    item.ID = binaryReader.ReadUInt32();
                    item.IDStr = item.ID.ToString("X8").ToLower();
                    item.Size = binaryReader.ReadInt32();
                    item.CompressedSize = binaryReader.ReadInt32();
                    item.Path = binaryReader.ReadString();
                    item.PathHash = binaryReader.ReadInt32();
                    //this.SetPath(item, item.Path);
                    item.Hash = binaryReader.ReadUInt32();
                    item.Flags = (AssetBundleFlags)binaryReader.ReadInt32();
                    int num2 = binaryReader.ReadInt32();
                    if (num2 != 0)
                    {
                        if (num2 < 0)
                        {
                            throw new Exception(string.Concat(new object[]
                            {
                            "Dependencies Paramater is Broken. cnt:",
                            num,
                            "/ hash:",
                            item.IDStr
                            }));
                        }
                        item.Dependencies = new AssetList.Item[num2];
                        for (int j = 0; j < item.Dependencies.Length; j++)
                        {
                            int num3 = binaryReader.ReadInt32();
                            //if (this.mItems.get_Item(num3) == null)
                            {
                                //    ItemList.set_Item(num3, new AssetList.Item());
                            }
                            item.Dependencies[j] = ItemList[num3];
                        }
                    }
                    else
                    {
                        item.Dependencies = new AssetList.Item[0];
                    }
                    num2 = binaryReader.ReadInt32();
                    if (num2 != 0)
                    {
                        if (num2 < 0)
                        {
                            throw new Exception(string.Concat(new object[]
                            {
                            "AdditionalDependencies Paramater is Broken. cnt:",
                            num,
                            "/ hash:",
                            item.IDStr
                            }));
                        }
                        item.AdditionalDependencies = new AssetList.Item[num2];
                        for (int k = 0; k < item.AdditionalDependencies.Length; k++)
                        {
                            int num3 = binaryReader.ReadInt32();
                            //if (this.mItems.get_Item(num3) == null)
                            {
                                //    ItemList.set_Item(num3, new AssetList.Item());
                            }
                            //item.AdditionalDependencies[k] = ItemList.get_Item(num3);
                        }
                    }
                    else
                    {
                        item.AdditionalDependencies = new AssetList.Item[0];
                    }
                    num2 = binaryReader.ReadInt32();
                    if (num2 != 0)
                    {
                        if (num2 < 0)
                        {
                            throw new Exception(string.Concat(new object[]
                            {
                            "AdditionalStreamingAssets Paramater is Broken. cnt:",
                            num,
                            "/ hash:",
                            item.IDStr
                            }));
                        }
                        item.AdditionalStreamingAssets = new AssetList.Item[num2];
                        for (int l = 0; l < item.AdditionalStreamingAssets.Length; l++)
                        {
                            int num3 = binaryReader.ReadInt32();
                            //if (this.mItems.get_Item(num3) == null)
                            {
                                //    ItemList.set_Item(num3, new AssetList.Item());
                            }
                            item.AdditionalStreamingAssets[l] = ItemList[num3];
                        }
                    }
                    else
                    {
                        item.AdditionalStreamingAssets = new AssetList.Item[0];
                    }
                    //if (!this.mID2Item.ContainsKey(item.ID))
                    {
                        //    this.mID2Item.Add(item.ID, item);
                    }
                }
            }
        }
        public static void ReadAssetListProc(byte[] bytes, ref List<AssetList.Item> ItemList)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            using (BinaryReader binaryReader = new BinaryReader(stream))
            {
                var mRevision = binaryReader.ReadInt32();
                int num = binaryReader.ReadInt32();
                AssetList.Item[] array = new AssetList.Item[num];
                ItemList = null;
                ItemList = new List<AssetList.Item>(array);
                for (int i = 0; i < num; i++)
                {
                    if (ItemList[i] == null)
                    {
                        ItemList[i] = new AssetList.Item();
                    }
                    AssetList.Item item = ItemList[i];
                    item.ID = binaryReader.ReadUInt32();
                    item.IDStr = item.ID.ToString("X8").ToLower();
                    item.Size = binaryReader.ReadInt32();
                    item.CompressedSize = binaryReader.ReadInt32();
                    item.Path = binaryReader.ReadString();
                    item.PathHash = binaryReader.ReadInt32();
                    //this.SetPath(item, item.Path);
                    item.Hash = binaryReader.ReadUInt32();
                    item.Flags = (AssetBundleFlags)binaryReader.ReadInt32();
                    int num2 = binaryReader.ReadInt32();
                    if (num2 != 0)
                    {
                        if (num2 < 0)
                        {
                            throw new Exception(string.Concat(new object[]
                            {
                            "Dependencies Paramater is Broken. cnt:",
                            num,
                            "/ hash:",
                            item.IDStr
                            }));
                        }
                        item.Dependencies = new AssetList.Item[num2];
                        for (int j = 0; j < item.Dependencies.Length; j++)
                        {
                            int num3 = binaryReader.ReadInt32();
                            //if (this.mItems.get_Item(num3) == null)
                            {
                                //    ItemList.set_Item(num3, new AssetList.Item());
                            }
                            item.Dependencies[j] = ItemList[num3];
                        }
                    }
                    else
                    {
                        item.Dependencies = new AssetList.Item[0];
                    }
                    num2 = binaryReader.ReadInt32();
                    if (num2 != 0)
                    {
                        if (num2 < 0)
                        {
                            throw new Exception(string.Concat(new object[]
                            {
                            "AdditionalDependencies Paramater is Broken. cnt:",
                            num,
                            "/ hash:",
                            item.IDStr
                            }));
                        }
                        item.AdditionalDependencies = new AssetList.Item[num2];
                        for (int k = 0; k < item.AdditionalDependencies.Length; k++)
                        {
                            int num3 = binaryReader.ReadInt32();
                            //if (this.mItems.get_Item(num3) == null)
                            {
                                //    ItemList.set_Item(num3, new AssetList.Item());
                            }
                            //item.AdditionalDependencies[k] = ItemList.get_Item(num3);
                        }
                    }
                    else
                    {
                        item.AdditionalDependencies = new AssetList.Item[0];
                    }
                    num2 = binaryReader.ReadInt32();
                    if (num2 != 0)
                    {
                        if (num2 < 0)
                        {
                            throw new Exception(string.Concat(new object[]
                            {
                            "AdditionalStreamingAssets Paramater is Broken. cnt:",
                            num,
                            "/ hash:",
                            item.IDStr
                            }));
                        }
                        item.AdditionalStreamingAssets = new AssetList.Item[num2];
                        for (int l = 0; l < item.AdditionalStreamingAssets.Length; l++)
                        {
                            int num3 = binaryReader.ReadInt32();
                            //if (this.mItems.get_Item(num3) == null)
                            {
                                //    ItemList.set_Item(num3, new AssetList.Item());
                            }
                            item.AdditionalStreamingAssets[l] = ItemList[num3];
                        }
                    }
                    else
                    {
                        item.AdditionalStreamingAssets = new AssetList.Item[0];
                    }
                    //if (!this.mID2Item.ContainsKey(item.ID))
                    {
                        //    this.mID2Item.Add(item.ID, item);
                    }
                }
            }
        }
        static byte[] DownloadFile(String fileName, String type)
        {
            return new System.Net.WebClient().DownloadData("https://prod-dlc-alcww-gumi-sg.akamaized.net/assets/" + GameManager.Instance.AssetVersion + "/" + type + "/" + fileName);
        }
        public static void Update()
        {
            Networking.TicketID = 1;
            GameManager.Instance.AssetVersion = GameManager.Instance.SessionID = null;
            var CheckVersion = Networking.RequestAPI(new ReqCheckVersion(GameManager.Instance.Version, "android"));
            GameManager.Instance.AssetVersion = CheckVersion["body"]["assets"].ToString();

            //var AssetList = File.ReadAllBytes("ASSETLIST");
            var AssetList = DownloadFile("ASSETLIST", "Text"); //File.WriteAllBytes("ASSETLIST", AssetList);
            List<AssetList.Item> ItemList = new List<AssetList.Item>();
            ReadAssetListProc(AssetList, ref ItemList);

            var Data_MasterParam_Id = ItemList.Find(i => i.Path.Contains("Data/MasterParam")).IDStr;
            //var Data_MasterParam_Compressed = File.ReadAllBytes("Data_MasterParam");
            var Data_MasterParam_Compressed = DownloadFile(Data_MasterParam_Id, "Text"); //File.WriteAllBytes("Data_MasterParam", Data_MasterParam_Compressed);
            var Data_MasterParam_Json = Encoding.UTF8.GetString(Decompress(Data_MasterParam_Compressed));
            Data_MasterParam = (JObject)JsonConvert.DeserializeObject(Data_MasterParam_Json);

            var Loc_english_LocalizedMasterParam_Id = ItemList.Find(i => i.Path.Contains("Loc/english/LocalizedMasterParam")).IDStr;
            //var Loc_english_LocalizedMasterParam_Compressed = File.ReadAllBytes("LocalizedMasterParam");
            var Loc_english_LocalizedMasterParam_Compressed = DownloadFile(Loc_english_LocalizedMasterParam_Id, "Text"); //File.WriteAllBytes("LocalizedMasterParam", Loc_english_LocalizedMasterParam_Compressed);
            var Loc_english_LocalizedMasterParam_String = Encoding.UTF8.GetString(Decompress(Loc_english_LocalizedMasterParam_Compressed));
            File.WriteAllText("translation.txt", Loc_english_LocalizedMasterParam_String);
            var Loc_english_LocalizedMasterParam_Lines = Loc_english_LocalizedMasterParam_String.Replace("\r", "").Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var Loc_english_LocalizedMasterParam_KVP = Loc_english_LocalizedMasterParam_Lines.Select(l => l.Split(new char[1] { '\t' }));
            Loc_english_LocalizedMasterParam = Loc_english_LocalizedMasterParam_KVP.ToDictionary(a => a[0].Substring(a[0].IndexOf("Param") + 6), b => b[1]);

            var Loc_english_unit_Id = ItemList.Find(i => i.Path.Contains("Loc/english/unit")).IDStr;
            //var Loc_english_unit_Compressed = File.ReadAllBytes("unit");
            var Loc_english_unit_Compressed = DownloadFile(Loc_english_unit_Id, "Text"); //File.WriteAllBytes("unit", Loc_english_unit_Compressed);
            var Loc_english_unit_String = Encoding.UTF8.GetString(Decompress(Loc_english_unit_Compressed).Skip(3).ToArray());
            var Loc_english_unit_Lines = Loc_english_unit_String.Replace("\r", "").Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var Loc_english_unit_KVP = Loc_english_unit_Lines.Select(l => l.Split(new char[1] { '\t' }));
            Loc_english_unit_KVP.ToList().ForEach(u => Loc_english_LocalizedMasterParam.Add(u[0], u[1]));
            //Loc_english_LocalizedMasterParam.add = Loc_english_LocalizedMasterParam_KVP.ToDictionary(a => a[0], b => b[1]);

            foreach (var item in ItemList)
                File.WriteAllText(@"text\" + item.Path.Replace("/", "") + "_" + item.IDStr, Encoding.UTF8.GetString(Decompress(DownloadFile(item.IDStr, "Text"))));
            // DotNetWikiBot -- http://dotnetwikibot.sourceforge.net/
            var site = new Site("https://thealchemistcode.gamepedia.com", "wikiusername", "wikipassword");
            site.defaultEditComment = "unitlist element + ";
            site.minorEditByDefault = true;
            string content = "";
            var pageList = new PageList(site);
            if (false)
            {
                var units = Data_MasterParam["Unit"];
                var unitList = units.ToList().FindAll(u => Loc_english_LocalizedMasterParam.ContainsKey(u["iname"] + "_NAME") && u["ai"]?.ToString() == "AI_PLAYER" && u["iname"].ToString().Split(new char[] { '_' }).Count() == 3);
                pageList = new PageList(site, new List<string> { "Units" });
                pageList.LoadWithMetadata();
                content = Wiki.Units.CreateUnitListPage(unitList);
                if (pageList[0].text != content)
                {
                    pageList[0].text = content;
                    pageList[0].Save();
                }
                foreach (var unit in unitList)
                {
                    pageList = new PageList(site, new List<string> { Loc_english_LocalizedMasterParam[unit["iname"] + "_NAME"] });
                    pageList.LoadWithMetadata();
                    if (pageList.Count() == 0)
                    {
                        var page = new Page(Loc_english_LocalizedMasterParam[unit["iname"] + "_NAME"]);
                        pageList.Add(page);
                    }
                    content = Wiki.Units.CreateUnitPage(unit);
                    if (pageList[0].text != content)
                    {
                        pageList[0].text = content;
                        pageList[0].Save();
                    }
                }
            }

            if (false)
            {
                var jobs = Data_MasterParam["Job"];
                var jobList = jobs.ToList().FindAll(u => Loc_english_LocalizedMasterParam.ContainsKey(u["ranks"][0]["eqid1"] + "_NAME"));
                pageList = new PageList(site, new List<string> { "Jobs" });
                pageList.LoadWithMetadata();
                content = Wiki.Jobs.CreateJobListPage(jobList);
                if (pageList[0].text != content)
                {
                    pageList[0].text = content;
                    pageList[0].Save();
                }

                foreach (var job in jobList)
                {
                    pageList = new PageList(site, new List<string> { job["iname"].ToString() == job["origin"]?.ToString() ? Loc_english_LocalizedMasterParam[job["iname"] + "_NAME"] : (Loc_english_LocalizedMasterParam[job["iname"] + "_NAME"].Replace("[", "").Replace("]", "") + " (" + job["iname"].ToString().Substring(3) + ")") });
                    pageList.LoadWithMetadata();
                    if (pageList.Count() == 0)
                    {
                        var page = new Page(job["iname"].ToString() == job["origin"]?.ToString() ? Loc_english_LocalizedMasterParam[job["iname"] + "_NAME"] : (Loc_english_LocalizedMasterParam[job["iname"] + "_NAME"].Replace("[", "").Replace("]", "") + " (" + job["iname"].ToString().Substring(3) + ")"));
                        pageList.Add(page);
                    }
                    content = Wiki.Jobs.CreateJobPage(job);
                    if (pageList[0].text != content)
                    {
                        pageList[0].text = content;
                        pageList[0].Save();
                    }
                }
            }
            if (false)
            {
                var equipment = Data_MasterParam["Item"];
                var equipmentList = equipment.ToList().FindAll(u => u["type"].ToString() == "3" && Loc_english_LocalizedMasterParam.ContainsKey(u["iname"] + "_NAME"));
                pageList = new PageList(site, new List<string> { "Equipment" });
                pageList.LoadWithMetadata();
                content = Equipments.CreateEquipmentListPage(equipmentList);
                if (pageList[0].text != content)
                {
                    pageList[0].text = content;
                    pageList[0].Save();
                }

                foreach (var equip in equipmentList)
                {
                    pageList = new PageList(site, new List<string> { Loc_english_LocalizedMasterParam[equip["iname"] + "_NAME"] });
                    pageList.LoadWithMetadata();
                    if (pageList.Count() == 0)
                    {
                        var page = new Page(Loc_english_LocalizedMasterParam[equip["iname"] + "_NAME"]);
                        pageList.Add(page);
                    }
                    content = Wiki.Equipments.CreateEquipmentPage(equip);
                    if (pageList[0].text != content)
                    {
                        pageList[0].text = content;
                        pageList[0].Save();
                    }
                }
            }
            if (true)
            {
                var skills = Data_MasterParam["Skill"];
                var skillList = skills.ToList().FindAll(u => /*u["type"].ToString() == "3" &&*/ Loc_english_LocalizedMasterParam.ContainsKey(u["iname"] + "_NAME"));
                pageList = new PageList(site, new List<string> { "Skills" });
                pageList.LoadWithMetadata();
                if (pageList.Count() == 0)
                {
                    var page = new Page(site, "Skills");
                    pageList.Add(page);
                }
                content = Skills.CreateSkillListPage(skillList);
                if (pageList[0].text != content)
                {
                    pageList[0].text = content;
                    pageList[0].Save();
                }

                foreach (var skill in skillList)
                {
                    pageList = new PageList(site, new List<string> { Loc_english_LocalizedMasterParam[skill["iname"] + "_NAME"] });
                    pageList.LoadWithMetadata();
                    if (pageList.Count() == 0)
                    {
                        var page = new Page(Loc_english_LocalizedMasterParam[skill["iname"] + "_NAME"]);
                        pageList.Add(page);
                    }
                    content = Skills.CreateSkillPage(skill);
                    if (pageList[0].text != content)
                    {
                        pageList[0].text = content;
                        pageList[0].Save();
                    }
                }
            }
        }
    }
}
