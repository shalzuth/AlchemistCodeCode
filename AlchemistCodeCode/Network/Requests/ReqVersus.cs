using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqVersus : WebAPI
	{
		public ReqVersus(string iname, int plid, int seat, string uid, VERSUS_TYPE type)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "vs/" + type.ToString().ToLower() + "match/req";
			stringBuilder.Append("\"iname\":\"");
			stringBuilder.Append("QE_VS_TEST_00");
			stringBuilder.Append("\",");
			stringBuilder.Append("\"token\":\"");
			stringBuilder.Append(JsonEscape.Escape(GlobalVars.SelectedMultiPlayRoomName));
			stringBuilder.Append("\",");
			stringBuilder.Append("\"plid\":\"");
			stringBuilder.Append(plid);
			stringBuilder.Append("\",");
			stringBuilder.Append("\"seat\":\"");
			stringBuilder.Append(seat);
			stringBuilder.Append("\",");
			stringBuilder.Append("\"uid\":\"");
			stringBuilder.Append(uid);
			stringBuilder.Append("\"");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
