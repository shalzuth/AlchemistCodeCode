using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqFriendApprove : WebAPI
	{
		public ReqFriendApprove(string fuid)
		{
			fuid = WebAPI.EscapeString(fuid);
			this.name = "friend/approve";
			this.body = WebAPI.GetRequestString("\"fuid\":\"" + fuid + "\"");
		}
	}
}
