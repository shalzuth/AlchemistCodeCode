using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqAddChatBlackList : WebAPI
	{
		public ReqAddChatBlackList(string target_uid)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "chat/blacklist/add";
			stringBuilder.Append("\"target_uid\":\"" + target_uid + "\"");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
