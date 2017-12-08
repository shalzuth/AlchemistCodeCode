using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqChatChannelList : WebAPI
	{
		public ReqChatChannelList(int start_id, int limit, int exclude_id)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "chat/channel";
			stringBuilder.Append("\"start_id\":" + start_id.ToString() + ",");
			stringBuilder.Append("\"limit\":" + limit.ToString() + ",");
			stringBuilder.Append("\"exclude_id\":" + exclude_id.ToString());
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}

		public ReqChatChannelList(int[] channel_ids)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "chat/channel";
			stringBuilder.Append("\"channel_ids\":[");
			for (int i = 0; i < channel_ids.Length; i++)
			{
				stringBuilder.Append(channel_ids[i]);
				if (i != channel_ids.Length - 1)
				{
					stringBuilder.Append(",");
				}
			}
			stringBuilder.Append("]");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
