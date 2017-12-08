using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqChatMessage : WebAPI
	{
		public ReqChatMessage(int start_id, int channel, int limit, int exclude_id)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "chat/message";
			stringBuilder.Append("\"start_id\":" + start_id.ToString() + ",");
			stringBuilder.Append("\"channel\":" + channel.ToString() + ",");
			stringBuilder.Append("\"limit\":" + limit.ToString() + ",");
			stringBuilder.Append("\"exclude_id\":" + exclude_id.ToString());
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
