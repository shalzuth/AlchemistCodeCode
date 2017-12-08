using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DataExtractor.Wiki
{
    public static class Jobs
    {
        public static String CreateJobListPage(List<JToken> jobs)
        {
            string header = "The following are the available '''Jobs''' for '''[[{{Gamename}}]]'''.[[Category:Job Data]]\n\n";
            header += "==Jobs==\n{| class=\"wikitable sortable\"\n |-\n ! Name !! Role\n";
            string footer = "\n |}";
            string jobList = String.Join("\n", jobs.Select(j => 
                " |-\n | [[" + (j["iname"].ToString() == j["origin"]?.ToString() ? Updater.Loc_english_LocalizedMasterParam[j["iname"] + "_NAME"] : (Updater.Loc_english_LocalizedMasterParam[j["iname"] + "_NAME"].Replace("[","").Replace("]","") + " (" +  j["iname"].ToString().Substring(3) + ")"))
                + "]] || " + j["role"]));
            return header + jobList + footer;
        }
        public static String CreateJobPage(JToken job)
        {
            string Content = "'''{{PAGENAME}}''' is a '''[[Jobs|Job]]''' in '''[[The Alchemist Code]]'''.[[Category:Job Data]]\n\n";
            Content += "==Stats==\n";
            Content += "{| class=\"wikitable sortable\"\n";
            Content += " |-\n ! Stat !! Value\n";
            var basicAttack = Updater.Data_MasterParam["Skill"].FirstOrDefault(a => a["iname"].ToString() == job["atkskl"]?.ToString());
            var range = basicAttack["rangemin"] ?? "0" + " - " + basicAttack["range"];
            Content += " |-\n | Range || " + range + " \n";
            Content += " |-\n | MOV || " + job["jmov"] + " \n";
            Content += " |-\n | JMP || " + job["jjmp"] + " \n";
            Content += " |-\n | HP || " + job["ranks"][0]["hp"] + " \n";
            Content += " |-\n | MP || " + job["ranks"][0]["mp"] + " \n";
            Content += " |-\n | ATK || " + job["ranks"][0]["atk"] + " \n";
            Content += " |-\n | DEF || " + job["ranks"][0]["def"] + " \n";
            Content += " |-\n | MAG || " + job["ranks"][0]["mag"] + " \n";
            Content += " |-\n | MND || " + job["ranks"][0]["mnd"] + " \n";
            Content += " |-\n | DEX || " + job["ranks"][0]["dex"] + " \n";
            Content += " |-\n | SPD || " + job["ranks"][0]["spd"] + " \n";
            Content += " |-\n | CRI || " + job["ranks"][0]["cri"] + " \n";
            Content += " |-\n | LUK || " + job["ranks"][0]["luk"] + " \n |}\n\n";

            Content += "==Main Abilities==\n";

            var abilities = Updater.Data_MasterParam["Ability"].FirstOrDefault(a => a["iname"].ToString() == job["fixabl"]?.ToString());
            if (abilities != null)
            {
                var skills = abilities.ToList().FindAll(a => ((JProperty)a).Name.Contains("skl"));
                foreach (var skill in skills)
                {
                    if (!Updater.Loc_english_LocalizedMasterParam.ContainsKey(((JProperty)skill).Value + "_NAME"))
                        continue;
                    Content += ";[[" + Updater.Loc_english_LocalizedMasterParam[((JProperty)skill).Value + "_NAME"] + "]] - Level " + abilities[((JProperty)skill).Name.ToString().Replace("skl", "lv")] + "\n";
                    Content += ": " + Updater.Loc_english_LocalizedMasterParam[((JProperty)skill).Value + "_EXPR"] + "\n";
                }
            }
            else
            {
                Content += "Job has no innate abilities.";
            }
            Content += "\n";

            Content += "==Basic Abilities==\n";

            for (int i = 0; i < job["ranks"].Count(); i++)
            {
                var rank = job["ranks"][i];
                var learn = rank["learn1"];
                abilities = Updater.Data_MasterParam["Ability"].FirstOrDefault(a => a["iname"].ToString() == learn?.ToString());
                if (abilities != null)
                {
                    Content += "'''Rank " + i + "\n";
                    var skills = abilities.ToList().FindAll(a => ((JProperty)a).Name.Contains("skl"));
                    foreach (var skill in skills)
                    {
                        if (!Updater.Loc_english_LocalizedMasterParam.ContainsKey(((JProperty)skill).Value + "_NAME"))
                            continue;
                        Content += ";[[" + Updater.Loc_english_LocalizedMasterParam[((JProperty)skill).Value + "_NAME"] + "]] - Level " + abilities[((JProperty)skill).Name.ToString().Replace("skl", "lv")] + "\n";
                        Content += ": " + Updater.Loc_english_LocalizedMasterParam[((JProperty)skill).Value + "_EXPR"] + "\n";
                    }
                }
            }
            Content += "\n";
            Content += "==Equipment==\n";
            Content += "{| class=\"wikitable\"\n";
            Content += " |-\n ! Rank !! Slot 1 !! Slot 2 !! Slot 3 !! Slot 4 !! Slot 5 !! Slot 6 \n";
            var rankEqs = new List<String>();
            for (int i = 0; i < job["ranks"].Count(); i++)
            {
                var rank = job["ranks"][i];
                if (!Updater.Loc_english_LocalizedMasterParam.ContainsKey(rank["eqid1"] + "_NAME"))
                    continue;
                rankEqs.Add(" |-\n | Rank " + i + " || [[" + Updater.Loc_english_LocalizedMasterParam[rank["eqid1"] + "_NAME"] +
                    "]] || [[" + Updater.Loc_english_LocalizedMasterParam[rank["eqid2"] + "_NAME"] +
                    "]] || [[" + Updater.Loc_english_LocalizedMasterParam[rank["eqid3"] + "_NAME"] +
                    "]] || [[" + Updater.Loc_english_LocalizedMasterParam[rank["eqid4"] + "_NAME"] +
                    "]] || [[" + Updater.Loc_english_LocalizedMasterParam[rank["eqid5"] + "_NAME"] +
                    "]] || [[" + Updater.Loc_english_LocalizedMasterParam[rank["eqid6"] + "_NAME"] + "]]");
                /*Content += " |-\n | Rank " + i + " || [[" + Updater.Loc_english_LocalizedMasterParam[rank["eqid1"] + "_NAME"] +
                    "]] || [[" + Updater.Loc_english_LocalizedMasterParam[rank["eqid2"] + "_NAME"] +
                    "]] || [[" + Updater.Loc_english_LocalizedMasterParam[rank["eqid3"] + "_NAME"] +
                    "]] || [[" + Updater.Loc_english_LocalizedMasterParam[rank["eqid4"] + "_NAME"] +
                    "]] || [[" + Updater.Loc_english_LocalizedMasterParam[rank["eqid5"] + "_NAME"] +
                    "]] || [[" + Updater.Loc_english_LocalizedMasterParam[rank["eqid6"] + "_NAME"] + "]]\n";*/
            }
            Content += String.Join("\n", rankEqs);
            return Content;
        }
    }
}
