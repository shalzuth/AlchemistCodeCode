using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DataExtractor.Wiki
{
    public static class Units
    {
        public static String CreateUnitListPage(List<JToken> units)
        {
            string Content = "The following are the available '''Units''' for '''[[{{Gamename}}]]'''.[[Category:Unit Data]]\n\n";
            Content += "==Summons==\n";
            Content += "{| class=\"wikitable sortable\"\n";
            Content += " |-\n ! Portrait !! Name !! Rarity !! Max Rarity || Element || Job 1 || Job 2 || Job 3\n";
            foreach(var unit in units)
            {
                var unitName = Updater.Loc_english_LocalizedMasterParam[unit["iname"] + "_NAME"];
                Content += " |-\n | [[File:" + unitName + "Portrait.png|link=" + unitName + "]] || ";
                Content += "[[" + unitName + "]] || ";
                Content += (int.Parse(unit["rare"].ToString()) + 1) + "★ || ";
                Content += (int.Parse(unit["raremax"].ToString()) + 1) + "★ || ";
                Content += "[[File: " + (SRPG.EElement)int.Parse(unit["elem"].ToString()) + "Element.png|center]] || ";
                var jobList = new List<String>() { "", "", "" };
                int i = 0;
                foreach (var job in unit["jobsets"])
                {
                    var jobset = Updater.Data_MasterParam["JobSet"].First(a => a["iname"].ToString() == job.ToString());
                    var subjob = Updater.Data_MasterParam["Job"].First(a => a["iname"].ToString() == jobset["job"].ToString());
                    var subjobname = Updater.Loc_english_LocalizedMasterParam[subjob["iname"] + "_NAME"].ToString();
                    var jobname = subjob["iname"].ToString() == subjob["origin"]?.ToString() ? subjobname : (subjobname.Replace("[", "").Replace("]", "") + " (" + subjob["iname"].ToString().Substring(3)) + ")";
                    jobList[i++] = "[[" + jobname + "]]";
                }
                Content += String.Join(" || ", jobList);
                Content += "\n |-\n";
            }
            Content += " |}";
            return Content;
        }
        public static String CreateUnitPage(JToken unit)
        {
            string Content = "{{Infobox\n| name     = {{PAGENAME}}\n| image    = {{PAGENAME}}FullImage.png\n}}\n'''{{PAGENAME}}''' is a '''[[Units|Unit]]''' in '''[[The Alchemist Code]]'''.[[Category:Summons]]\n\n";
            Content += "==Stats==\n";
            Content += "{| class=\"wikitable sortable\"\n";
            Content += " |-\n ! Stat !! Min !! Max\n";
            Content += " |-\n | HP || " + unit["hp"] + " || " + unit["mhp"] + "\n";
            Content += " |-\n | MP || " + unit["mp"] + " || " + unit["mmp"] + "\n";
            Content += " |-\n | ATK || " + unit["atk"] + " || " + unit["matk"] + "\n";
            Content += " |-\n | DEF || " + unit["def"] + " || " + unit["mdef"] + "\n";
            Content += " |-\n | MAG || " + unit["mag"] + " || " + unit["mmag"] + "\n";
            Content += " |-\n | MND || " + unit["mnd"] + " || " + unit["mmnd"] + "\n";
            Content += " |-\n | DEX || " + unit["dex"] + " || " + unit["mdex"] + "\n";
            Content += " |-\n | SPD || " + unit["spd"] + " || " + unit["mspd"] + "\n";
            Content += " |-\n | CRI || " + unit["cri"] + " || " + unit["mcri"] + "\n";
            Content += " |-\n | LUK || " + unit["luk"] + " || " + unit["mluk"] + "\n |}\n";
            Content += "'''Growth Rate'': " + unit["grow"] + "\n\n";
            Content += "==Information==\n";
            Content += "'''Initial Rarity''': " + (int.Parse(unit["rare"].ToString()) + 1) + "★\n\n";
            Content += "'''Max Rarity''': " + (int.Parse(unit["raremax"].ToString()) + 1) + "★\n\n";
            Content += "'''Element''': " + (SRPG.EElement)int.Parse(unit["elem"].ToString()) + "\n\n";
            Content += "===Leader Skill===\n";
            Content += (unit["ls1"] == null ? "This unit does not have a leader skill" : (";" + Updater.Loc_english_LocalizedMasterParam[unit["ls1"] + "_NAME"] + "\n: " + Updater.Loc_english_LocalizedMasterParam[unit["ls1"] + "_EXPR"])) + "\n\n";
            Content += "===Master Skill===\n";
            var ability = Updater.Data_MasterParam["Ability"].FirstOrDefault(a => a["iname"].ToString() == unit["ability"]?.ToString());
            Content += (ability == null ? "This unit does not have a master skill" : (";" + Updater.Loc_english_LocalizedMasterParam[ability["skl1"] + "_NAME"] + "\n: " + Updater.Loc_english_LocalizedMasterParam[ability["skl1"] + "_EXPR"])) + "\n\n";
            Content += "==Available Jobs==\n";
            foreach(var job in unit["jobsets"])
            {
                var jobset = Updater.Data_MasterParam["JobSet"].First(a => a["iname"].ToString() == job.ToString());
                var subjob = Updater.Data_MasterParam["Job"].First(a => a["iname"].ToString() == jobset["job"].ToString());
                var jobname = subjob["iname"].ToString() == subjob["origin"]?.ToString() ? Updater.Loc_english_LocalizedMasterParam[subjob["iname"] + "_NAME"] : (Updater.Loc_english_LocalizedMasterParam[subjob["iname"] + "_NAME"].ToString().Replace("[", "").Replace("]", "") + " (" + subjob["iname"].ToString().Substring(3)) + ")";
                Content += "[[" + jobname + "]]" + (jobset["lplus"] != null ? " (Limit Break " + jobset["lplus"] + "x)" : "") + "\n\n";
            }
            Content += "==Profile==\n";
            Content += "'''Description''': " + Updater.Loc_english_LocalizedMasterParam[unit["iname"] + "_PROFILE"] + "\n\n";
            Content += "'''Origin''': " + Updater.Loc_english_LocalizedMasterParam[unit["iname"] + "_COUNTRY"] + "\n\n";
            Content += "'''Height''': " + Updater.Loc_english_LocalizedMasterParam[unit["iname"] + "_HEIGHT"] + "\n\n";
            Content += "'''Weight''': " + Updater.Loc_english_LocalizedMasterParam[unit["iname"] + "_WEIGHT"] + "\n\n";
            Content += "'''Birthday''': " + Updater.Loc_english_LocalizedMasterParam[unit["iname"] + "_BIRTH"] + "\n\n";
            Content += "'''Blood Type''': " + Updater.Loc_english_LocalizedMasterParam[unit["iname"] + "_BLOOD"] + "\n\n";
            Content += "'''Zodiac''': " + Updater.Loc_english_LocalizedMasterParam[unit["iname"] + "_ZODIAC"] + "\n\n";
            Content += "'''Likes''': " + Updater.Loc_english_LocalizedMasterParam[unit["iname"] + "_FAVORITE"] + "\n\n";
            Content += "'''Hobbies''': " + Updater.Loc_english_LocalizedMasterParam[unit["iname"] + "_HOBBY"];
            return Content;
        }
    }
}
