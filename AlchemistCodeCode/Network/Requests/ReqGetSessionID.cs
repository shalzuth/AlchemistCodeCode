using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqGetSessionID : WebAPI
	{
		public ReqGetSessionID(string udid, string udid_, string romver)
		{
			this.name = "getsid";
			this.body = "{\"ticket\":" + Networking.TicketID + ",\"param\":{";
			this.body = this.body + "\"udid\":\"" + udid + "\",";
			this.body = this.body + "\"udid_\":\"" + udid_ + "\",";
			this.body = this.body + "\"romver\":\"" + romver + "\"";
			this.body += "}}";
		}
	}
}
