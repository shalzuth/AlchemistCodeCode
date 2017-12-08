using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqFriendRemove : WebAPI
	{
		public ReqFriendRemove(string[] fuids)
		{
			this.name = "friend/remove";
			this.body = "\"fuids\":[";
			for (int i = 0; i < fuids.Length; i++)
			{
				this.body = this.body + "\"" + fuids[i] + "\"";
				if (i != fuids.Length - 1)
				{
					this.body += ",";
				}
			}
			this.body += "]";
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
