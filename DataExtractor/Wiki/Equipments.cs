using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DataExtractor.Wiki
{
    public static class Equipments
    {
        public static String CreateEquipmentListPage(List<JToken> equipment)
        {
            string header = "The following are the available '''Equipments''' for '''[[{{Gamename}}]]'''.[[Category:Equipment Data]]\n\n";
            header += "==Equipment==\n{| class=\"wikitable sortable\"\n |-\n ! Name\n";
            string footer = "\n |}";
            string equipmentList = String.Join("\n", equipment.Select(j =>
                " |-\n | [[" + Updater.Loc_english_LocalizedMasterParam[j["iname"] + "_NAME"]
                + "]] || " + Updater.Loc_english_LocalizedMasterParam[j["iname"] + "_EXPR"]));
            return header + equipmentList + footer;
        }
        public static String CreateEquipmentPage(JToken equipment)
        {
            string Content = "'''{{PAGENAME}}''' is an '''[[Equipment]]''' in '''[[The Alchemist Code]]'''.[[Category:Equipment Data]]\n\n";
            Content += "==Info==\n";
            Content += "'''Stats''' : " + Updater.Loc_english_LocalizedMasterParam[equipment["iname"] + "_EXPR"] + "\n\n";
            Content += "'''Description''' : " + Updater.Loc_english_LocalizedMasterParam[equipment["iname"] + "_FLAVOR"] + "";
            return Content;
        }
    }
}
