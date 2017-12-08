using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqSendChatMessage : WebAPI
	{
		public ReqSendChatMessage(int channel, string message)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "chat/send";
			stringBuilder.Append("\"channel\":" + channel.ToString() + ",");
			stringBuilder.Append("\"message\":\"" + message + "\"");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
