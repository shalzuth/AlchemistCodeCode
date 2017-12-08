using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqCheckFacebookID : WebAPI
	{
		public ReqCheckFacebookID(string udid)
		{
			this.name = "player/chkfb";
			this.body = "{";
			string body = this.body;
			this.body = string.Concat(new object[]
			{
				body,
				"\"ticket\":",
				Networking.TicketID,
				","
			});
			this.body += "\"access_token\":\"\",";
			this.body += "\"param\":{";
			this.body = this.body + "\"device_id\":\"" + udid + "\"";
			this.body += "}";
			this.body += "}";
		}
	}
}
