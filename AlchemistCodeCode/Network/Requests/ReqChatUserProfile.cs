using System;
using System.Text;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqChatUserProfile : WebAPI
	{
		public ReqChatUserProfile(string target_uid)
		{
			StringBuilder stringBuilder = WebAPI.GetStringBuilder();
			this.name = "chat/profile";
			stringBuilder.Append("\"target_uid\":\"" + target_uid + "\"");
			this.body = WebAPI.GetRequestString(stringBuilder.ToString());
		}
	}
}
