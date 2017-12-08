using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqFriendFind : WebAPI
	{
		public ReqFriendFind(string fuid)
		{
			fuid = WebAPI.EscapeString(fuid);
			this.name = "friend/find";
			this.body = WebAPI.GetRequestString("\"fuid\":\"" + fuid + "\"");
		}
	}
}
