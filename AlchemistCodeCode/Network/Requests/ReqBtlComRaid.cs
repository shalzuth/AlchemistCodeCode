using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqBtlComRaid : WebAPI
	{
		public ReqBtlComRaid(string iname, int ticket, int partyIndex)
		{
			this.name = "btl/com/raid2";
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			stringBuilder.Append("\"iname\":\"");
			stringBuilder.Append(iname);
			stringBuilder.Append("\",");
			if (partyIndex >= 0)
			{
				stringBuilder.Append("\"partyid\":");
				stringBuilder.Append(partyIndex);
				stringBuilder.Append(",");
			}
			stringBuilder.Append("\"ticket\":");
			stringBuilder.Append(ticket.ToString());
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
