using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqGetAccessToken : WebAPI
	{
		public ReqGetAccessToken(string deviceid, string secretkey)
		{
			this.name = "gauth/accesstoken";
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
			this.body = this.body + "\"device_id\":\"" + deviceid + "\",";
			this.body = this.body + "\"secret_key\":\"" + secretkey + "\"";
			this.body += "}";
			this.body += "}";
		}
	}
}
