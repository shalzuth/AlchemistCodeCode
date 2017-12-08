using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqChatBlackList : WebAPI
	{
		public ReqChatBlackList(int start_id, int limit, int exclude_id)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "chat/blacklist";
			stringBuilder.Append("\"start_id\":" + start_id.ToString() + ",");
			stringBuilder.Append("\"limit\":" + limit.ToString() + ",");
			stringBuilder.Append("\"exclude_id\":" + exclude_id.ToString());
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}

		public ReqChatBlackList(int offset, int limit)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "chat/blacklist";
			stringBuilder.Append("\"offset\":" + offset.ToString() + ",");
			stringBuilder.Append("\"limit\":" + limit.ToString());
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
