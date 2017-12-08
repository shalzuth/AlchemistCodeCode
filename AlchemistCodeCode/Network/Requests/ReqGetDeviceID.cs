using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqGetDeviceID : WebAPI
	{
		public ReqGetDeviceID(string secretkey, string udid)
		{
			this.name = "gauth/register";
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
			this.body = this.body + "\"secret_key\":\"" + secretkey + "\",";
			this.body = this.body + "\"udid\":\"" + udid + "\"";
			this.body += "}";
			this.body += "}";
		}
	}
}
