using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqBtlColoReq : WebAPI
	{
		public ReqBtlColoReq(string questID, string fuid, ArenaPlayer ap, int partyIndex)
		{
			this.name = "btl/colo/req";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			if (partyIndex >= 0)
			{
				stringBuilder.Append("\"partyid\":");
				stringBuilder.Append(partyIndex);
				stringBuilder.Append(",");
			}
			stringBuilder.Append("\"btlparam\":{},");
			stringBuilder.Append("\"fuid\":\"");
			stringBuilder.Append(fuid);
			stringBuilder.Append("\"");
			stringBuilder.Append(",");
			stringBuilder.Append("\"opp_rank\":");
			stringBuilder.Append(ap.ArenaRank);
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
