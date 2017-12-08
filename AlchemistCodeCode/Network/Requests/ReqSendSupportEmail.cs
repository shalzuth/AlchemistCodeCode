using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqSendSupportEmail : WebAPI
	{
		public ReqSendSupportEmail(string subject, string message, string replyTo)
		{
			this.name = "support/mail";
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
			this.body = this.body + "\"subject\":\"" + subject + "\",";
			this.body = this.body + "\"message\":\"" + message + "\",";
			this.body = this.body + "\"replyTo\":\"" + replyTo + "\"";
			this.body += "}";
			this.body += "}";
		}
	}
}
