using System;
using System.Collections.Generic;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqBtlComEnd : WebAPI
	{
		public ReqBtlComEnd(long btlid, int time, BtlResultTypes result, int[] beats, int[] itemSteals, int[] goldSteals, int[] missions, string[] fuid, Dictionary<OString, OInt> usedItems, BtlEndTypes apiType, string trophyprog = null, string bingoprog = null, string maxdata = null)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("btl/");
			stringBuilder.Append(apiType.ToString());
			stringBuilder.Append("/end");
			this.name = stringBuilder.ToString();
			stringBuilder.Length = 0;
			stringBuilder.Append("\"btlid\":");
			stringBuilder.Append(btlid);
			stringBuilder.Append(',');
			stringBuilder.Append("\"btlendparam\":{");
			stringBuilder.Append("\"time\":");
			stringBuilder.Append(time);
			stringBuilder.Append(',');
			stringBuilder.Append("\"result\":\"");
			switch (result)
			{
			case BtlResultTypes.Win:
				stringBuilder.Append("win");
				break;
			case BtlResultTypes.Lose:
				stringBuilder.Append("lose");
				break;
			case BtlResultTypes.Retire:
				stringBuilder.Append("retire");
				break;
			case BtlResultTypes.Cancel:
				stringBuilder.Append("cancel");
				break;
			}
			if (result == BtlResultTypes.Win)
			{
				if (beats == null)
				{
					beats = new int[0];
				}
				if (itemSteals == null)
				{
					itemSteals = new int[0];
				}
				if (goldSteals == null)
				{
					goldSteals = new int[0];
				}
				if (missions == null)
				{
					missions = new int[3];
				}
			}
			if (result != BtlResultTypes.Cancel && usedItems == null)
			{
				usedItems = new Dictionary<OString, OInt>();
			}
			stringBuilder.Append("\",");
			if (beats != null)
			{
				stringBuilder.Append("\"beats\":[");
				for (int i = 0; i < beats.Length; i++)
				{
					if (i > 0)
					{
						stringBuilder.Append(',');
					}
					stringBuilder.Append(beats[i].ToString());
				}
				stringBuilder.Append("],");
			}
			if (itemSteals != null || goldSteals != null)
			{
				stringBuilder.Append("\"steals\":{");
				if (itemSteals != null)
				{
					stringBuilder.Append("\"items\":[");
					for (int j = 0; j < itemSteals.Length; j++)
					{
						stringBuilder.Append(itemSteals[j].ToString());
						if (j != beats.Length - 1)
						{
							stringBuilder.Append(',');
						}
					}
					stringBuilder.Append("]");
				}
				if (goldSteals != null)
				{
					if (itemSteals != null)
					{
						stringBuilder.Append(',');
					}
					stringBuilder.Append("\"golds\":[");
					for (int k = 0; k < goldSteals.Length; k++)
					{
						stringBuilder.Append(goldSteals[k].ToString());
						if (k != beats.Length - 1)
						{
							stringBuilder.Append(",");
						}
					}
					stringBuilder.Append("]");
				}
				stringBuilder.Append("},");
			}
			if (missions != null)
			{
				stringBuilder.Append("\"missions\":[");
				for (int l = 0; l < missions.Length; l++)
				{
					if (l > 0)
					{
						stringBuilder.Append(',');
					}
					stringBuilder.Append(missions[l].ToString());
				}
				stringBuilder.Append("],");
			}
			if (usedItems != null)
			{
				stringBuilder.Append("\"inputs\":[");
				int num = 0;
				foreach (KeyValuePair<OString, OInt> current in usedItems)
				{
					if (num > 0)
					{
						stringBuilder.Append(',');
					}
					stringBuilder.Append("{");
					stringBuilder.Append("\"use\":\"");
					stringBuilder.Append(current.Key);
					stringBuilder.Append("\",");
					stringBuilder.Append("\"n\":");
					stringBuilder.Append(current.Value);
					stringBuilder.Append("}");
					num++;
				}
				stringBuilder.Append("],");
			}
			if (apiType == BtlEndTypes.multi)
			{
				stringBuilder.Append("\"token\":\"");
				stringBuilder.Append(JsonEscape.Escape(GlobalVars.SelectedMultiPlayRoomName));
				stringBuilder.Append("\",");
			}
			if (stringBuilder[stringBuilder.Length - 1] == ',')
			{
				stringBuilder.Length--;
			}
			stringBuilder.Append('}');
			if (apiType == BtlEndTypes.multi && fuid != null)
			{
				stringBuilder.Append(",\"fuids\":[");
				for (int m = 0; m < fuid.Length; m++)
				{
					if (fuid[m] != null)
					{
						if (m != 0)
						{
							stringBuilder.Append(", ");
						}
						stringBuilder.Append("\"");
						stringBuilder.Append(fuid[m]);
						stringBuilder.Append("\"");
					}
				}
				stringBuilder.Append("]");
			}
			if (!string.IsNullOrEmpty(trophyprog))
			{
				stringBuilder.Append(",");
				stringBuilder.Append(trophyprog);
			}
			if (!string.IsNullOrEmpty(bingoprog))
			{
				stringBuilder.Append(",");
				stringBuilder.Append(bingoprog);
			}
			if (!string.IsNullOrEmpty(maxdata))
			{
				stringBuilder.Append(",");
				stringBuilder.Append(maxdata);
			}
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
