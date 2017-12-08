using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqVersusEnd : WebAPI
	{
		public ReqVersusEnd(long btlid, int time, BtlResultTypes result, int[] beats, string uid, string fuid, VERSUS_TYPE type, string trophyprog = null, string bingoprog = null, string maxdata = null)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("vs/");
			stringBuilder.Append(type.ToString().ToLower());
			stringBuilder.Append("match/end");
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
			case BtlResultTypes.Draw:
				stringBuilder.Append("draw");
				break;
			}
			if (result == BtlResultTypes.Win && beats == null)
			{
				beats = new int[0];
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
			stringBuilder.Append("\"steals\":[");
			stringBuilder.Append("],");
			stringBuilder.Append("\"missions\":[");
			stringBuilder.Append("],");
			stringBuilder.Append("\"token\":\"");
			stringBuilder.Append(JsonEscape.Escape(GlobalVars.SelectedMultiPlayRoomName));
			stringBuilder.Append("\",");
			if (stringBuilder[stringBuilder.Length - 1] == ',')
			{
				stringBuilder.Length--;
			}
			stringBuilder.Append("},");
			stringBuilder.Append("\"uid\":\"");
			stringBuilder.Append(uid);
			stringBuilder.Append("\",");
			stringBuilder.Append("\"fuid\":\"");
			stringBuilder.Append(fuid);
			stringBuilder.Append("\"");
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
