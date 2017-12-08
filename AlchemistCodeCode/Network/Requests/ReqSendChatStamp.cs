using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqSendChatStamp : WebAPI
	{
		public ReqSendChatStamp(int channel, int stamp_id)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "chat/send/stamp";
			stringBuilder.Append("\"channel\":" + channel.ToString() + ",");
			stringBuilder.Append("\"stamp_id\":" + stamp_id.ToString());
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
