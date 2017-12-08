using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqCheckVersion : WebAPI
	{
		public ReqCheckVersion(string ver, string os)
		{
			this.name = "chkver";
			this.body = "{";
			string body = this.body;
			this.body = string.Concat(new object[]
			{
				body,
				"\"ticket\":",
				Networking.TicketID,
				","
			});
			this.body += "\"param\":{";
			this.body = this.body + "\"ver\":\"" + ver + "\",";
			this.body = this.body + "\"os\":\"" + os + "\"";
			this.body += "}";
			this.body += "}";
		}
	}
}
