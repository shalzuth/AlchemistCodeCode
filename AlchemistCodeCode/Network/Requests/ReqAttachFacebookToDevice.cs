using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqAttachFacebookToDevice : WebAPI
	{
		public ReqAttachFacebookToDevice(string accesstoken)
		{
			this.name = "gauth/facebook/sso/device";
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
			this.body = this.body + "\"access_token\":\"" + accesstoken + "\"";
			this.body += "}";
			this.body += "}";
		}
	}
}
