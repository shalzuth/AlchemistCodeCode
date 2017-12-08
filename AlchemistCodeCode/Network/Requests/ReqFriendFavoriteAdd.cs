using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqFriendFavoriteAdd : WebAPI
	{
		public ReqFriendFavoriteAdd(string fuid)
		{
			this.name = "friend/favorite/add";
			this.body = WebAPI.GetRequestString("\"fuid\":\"" + fuid + "\"");
		}
	}
}
