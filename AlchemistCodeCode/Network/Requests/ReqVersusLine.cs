using System;
using SRPG;

namespace AlchemistCodeCode.Network.Requests
{
	public class ReqVersusLine : WebAPI
	{
		public ReqVersusLine(string roomname)
		{
			this.name = "vs/friendmatch/line/recruitment";
			this.body = string.Empty;
			this.body = this.body + "\"token\":\"" + JsonEscape.Escape(roomname) + "\"";
			this.body = WebAPI.GetRequestString(this.body);
		}
	}
}
