using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqFriendFollower : WebAPI
	{
		public ReqFriendFollower()
		{
			this.name = "friend/follower";
			this.body = WebAPI.GetRequestString(null);
		}
	}
}
