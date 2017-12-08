using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqBtlTowerComReq : WebAPI
	{
		public ReqBtlTowerComReq(string qid, string fid, PartyData partyIndex)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "tower/btl/req";
			stringBuilder.Append("\"qid\":\"");
			stringBuilder.Append(qid);
			stringBuilder.Append("\",");
			stringBuilder.Append("\"fid\":\"");
			stringBuilder.Append(fid);
			stringBuilder.Append("\",");
			stringBuilder.Append("\"fuid\":\"");
			stringBuilder.Append(GlobalVars.SelectedFriendID);
			stringBuilder.Append("\"");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
