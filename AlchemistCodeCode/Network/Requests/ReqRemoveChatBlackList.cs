using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqRemoveChatBlackList : WebAPI
	{
		public ReqRemoveChatBlackList(string target_uid)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "chat/blacklist/remove";
			stringBuilder.Append("\"target_uid\":\"" + target_uid + "\"");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
