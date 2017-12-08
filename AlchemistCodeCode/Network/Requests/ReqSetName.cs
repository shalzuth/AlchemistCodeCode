using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqSetName : WebAPI
	{
		public ReqSetName(string username)
		{
			username = WebAPI.EscapeString(username);
			this.name = "setname";
			this.body = WebAPI.GetRequestString("\"name\":\"" + username + "\"");
		}
	}
}
