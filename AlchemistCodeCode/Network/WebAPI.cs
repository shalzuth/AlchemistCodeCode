using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network
{
    public abstract class WebAPI
    {
        public string name;
        public string body;
        public Networking.ResponseCallback callback;
        public readonly string GumiTransactionId = Guid.NewGuid().ToString();
        private static StringBuilder mSB = new StringBuilder(512);
        protected static StringBuilder GetStringBuilder()
        {
            mSB.Length = 0;
            return mSB;
        }
        public static string EscapeString(string s)
        {
            s = s.Replace("\\", "\\\\");
            s = s.Replace("\"", "\\\"");
            return s;
        }
        protected static string GetRequestString(string body)
        {
            string text = "{\"ticket\":" + Networking.TicketID;
            if (!string.IsNullOrEmpty(body))
            {
                text = text + ",\"param\":{" + body + "}";
            }
            return text + "}";
        }
        protected static string GetBtlEndParamString(BattleCore.Record record, bool multi = false)
        {
            string text = null;
            if (record != null)
            {
                int num = 0;
                string text2 = "win";
                if (multi && record.result == BattleCore.QuestResult.Pending)
                {
                    text2 = "retire";
                }
                else if (record.result != BattleCore.QuestResult.Win)
                {
                    text2 = "lose";
                }
                int[] array = new int[record.drops.Length];
                for (int i = 0; i < record.drops.Length; i++)
                {
                    array[i] = record.drops[i];
                }
                int[] array2 = new int[record.item_steals.Length];
                for (int j = 0; j < record.item_steals.Length; j++)
                {
                    array2[j] = record.item_steals[j];
                }
                int[] array3 = new int[record.gold_steals.Length];
                for (int k = 0; k < record.gold_steals.Length; k++)
                {
                    array3[k] = record.gold_steals[k];
                }
                int[] array4 = new int[3];
                for (int l = 0; l < array4.Length; l++)
                {
                    array4[l] = (((record.bonusFlags & 1 << l) == 0) ? 0 : 1);
                }
                text += "\"btlendparam\":{";
                string text3 = text;
                text = string.Concat(new object[]
                {
                    text3,
                    "\"time\":",
                    num,
                    ","
                });
                text = text + "\"result\":\"" + text2 + "\",";
                text += "\"beats\":[";
                for (int m = 0; m < array.Length; m++)
                {
                    text += array[m].ToString();
                    if (m != array.Length - 1)
                    {
                        text += ",";
                    }
                }
                text += "],";
                text += "\"steals\":{";
                text += "\"items\":[";
                for (int n = 0; n < array2.Length; n++)
                {
                    text += array2[n].ToString();
                    if (n != array.Length - 1)
                    {
                        text += ",";
                    }
                }
                text += "],";
                text += "\"golds\":[";
                for (int num2 = 0; num2 < array3.Length; num2++)
                {
                    text += array3[num2].ToString();
                    if (num2 != array.Length - 1)
                    {
                        text += ",";
                    }
                }
                text += "]";
                text += "},";
                text += "\"missions\":[";
                for (int num3 = 0; num3 < array4.Length; num3++)
                {
                    text += array4[num3].ToString();
                    if (num3 != array4.Length - 1)
                    {
                        text += ",";
                    }
                }
                text += "]";
                if (multi)
                {
                    text = text + ",\"token\":\"" + JsonEscape.Escape(GlobalVars.SelectedMultiPlayRoomName) + "\"";
                }
                text += "}";
            }
            return text;
        }
        public class JSON_BaseResponse
        {
            public int stat;
            public string stat_msg;
            public string stat_code;
            public long time;
            public int ticket;
        }
        public class JSON_BodyResponse<T> : JSON_BaseResponse
        {
            public T body;
        }
    }
}
