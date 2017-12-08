using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqVersusLineMake : WebAPI
	{
		public ReqVersusLineMake(string roomname)
		{
			this.name = "vs/friendmatch/line/make";
			this.body = string.Empty;
			this.body = this.body + "\"token\":\"" + JsonEscape.Escape(roomname) + "\"";
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
