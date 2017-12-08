using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqFriendReq : WebAPI
	{
		public ReqFriendReq(string fuid)
		{
			this.name = "friend/req";
			this.body = WebAPI.GetRequestString("\"fuid\":\"" + fuid + "\"");
		}
	}
}
