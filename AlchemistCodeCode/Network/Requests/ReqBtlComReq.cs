using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqBtlComReq : WebAPI
	{
		public ReqBtlComReq(string iname, string fuid, bool multi, int partyIndex, bool isHost = false, int plid = 0, int seat = 0)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = ((!multi) ? "btl/com/req" : "btl/multi/req");
			stringBuilder.Append("\"iname\":\"");
			stringBuilder.Append(iname);
			stringBuilder.Append("\",");
			if (partyIndex >= 0)
			{
				stringBuilder.Append("\"partyid\":");
				stringBuilder.Append(partyIndex);
				stringBuilder.Append(",");
			}
			if (multi)
			{
				stringBuilder.Append("\"token\":\"");
				stringBuilder.Append(JsonEscape.Escape(GlobalVars.SelectedMultiPlayRoomName));
				stringBuilder.Append("\",");
				stringBuilder.Append("\"host\":\"");
				stringBuilder.Append((!isHost) ? "0" : "1");
				stringBuilder.Append("\",");
				stringBuilder.Append("\"plid\":\"");
				stringBuilder.Append(plid);
				stringBuilder.Append("\",");
				stringBuilder.Append("\"seat\":\"");
				stringBuilder.Append(seat);
				stringBuilder.Append("\",");
			}
			stringBuilder.Append("\"btlparam\":{\"help\":{\"fuid\":\"");
			stringBuilder.Append(fuid);
			stringBuilder.Append("\"}}");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
