using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DataExtractor.Wiki
{
    public static class Skills
    {
        public static String CreateSkillListPage(List<JToken> skills)
        {
            string header = "The following are the available '''{{PAGENAME}}''' for '''[[{{Gamename}}]]'''.[[Category:Equipment Data]]\n\n";
            header += "=={{PAGENAME}}==\n{| class=\"wikitable sortable\"\n |-\n ! Name\n";
            string footer = "\n |}";
            string skillList = String.Join("\n", skills.Select(j =>
                " |-\n | [[" + Updater.Loc_english_LocalizedMasterParam[j["iname"] + "_NAME"]
                + "]] || " + Updater.Loc_english_LocalizedMasterParam[j["iname"] + "_EXPR"]));
            return header + skillList + footer;
        }
        public static String CreateSkillPage(JToken skill)
        {
            string Content = "'''{{PAGENAME}}''' is an '''[[Equipment]]''' in '''[[The Alchemist Code]]'''.[[Category:Equipment Data]]\n\n";
            Content += "==Info==\n";
            Content += "'''Stats''' : " + Updater.Loc_english_LocalizedMasterParam[skill["iname"] + "_EXPR"] + "\n\n";
            Content += "'''Description''' : " + Updater.Loc_english_LocalizedMasterParam[skill["iname"] + "_FLAVOR"] + "";
            return Content;
        }
    }
}
