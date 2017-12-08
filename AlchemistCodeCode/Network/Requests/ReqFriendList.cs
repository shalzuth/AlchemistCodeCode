using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqFriendList : WebAPI
	{
		public ReqFriendList()
		{
			this.name = "friend";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
