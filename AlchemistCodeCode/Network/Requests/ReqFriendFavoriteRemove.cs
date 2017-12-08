using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqFriendFavoriteRemove : WebAPI
	{
		public ReqFriendFavoriteRemove(string fuid)
		{
			this.name = "friend/favorite/remove";
			this.body = WebAPI.GetRequestString("\"fuid\":\"" + fuid + "\"");
		}
	}
}
