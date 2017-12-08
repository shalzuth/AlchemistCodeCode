using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqFriendFindByUsername : WebAPI
	{
		public ReqFriendFindByUsername(string username)
		{
			username = WebAPI.EscapeString(username);
			this.name = "friend/search";
			this.body = WebAPI.GetRequestString("\"name\":\"" + username + "\"");
		}
	}
}
